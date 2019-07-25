using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.UI
{
    public class GameGraphics
    {
        public int CellSize { get; private set; }
        private readonly Graphics grf;

        public GameGraphics(Graphics grf, int cellsize = 21)
        {
            this.grf = grf;
            CellSize = cellsize;
        }

        public void DrawMap(Map map)
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    DrawCell(map.Field[x, y]);
                }
            }
        }

        public void DrawArea(Map map, Coordinates[] area, Fog fog)
        {
            foreach (var pt in area)
            {
                DrawCellOne(map[pt], fog);
            }
        }

        public void DrawArea(Mission mission, Coordinates[] area, Fog fog)
        {
            foreach (var pt in area)
            {
                DrawCellOne(mission.Map[pt], fog);

                if (!fog[pt])
                {
                    var division = mission.GetDivisionAt(pt);
                    if (null != division)
                        if (!division.IsSecuring)
                            DrawDivision(division, false);

                    var building = mission.GetBuildingAt(pt);
                    if (null != building)
                        DrawBuilding(building, false);
                }
            }
        }

        /*public void DrawObjectOne(Player player, Division selectedDivision, Building selectedBuilding, Fog fog)
        {
            foreach (var division in player.Divisions)
            {
                if (!fog[division.Position])
                {
                    if (!division.IsSecuring)
                        DrawDivision(division, division == selectedDivision);
                }
            }

            foreach (var building in player.Buildings)
            {
                if (!fog[building.Position])
                {
                    DrawBuilding(building, building == selectedBuilding);
                }
            }
        }*/

        public void DrawCell(Cell cell)
        {
            var color = GetCellColor(cell.Type, cell.Schema);
            using (Brush brush = new SolidBrush(color))
            {
                int x = cell.Coordinates.X;
                int y = cell.Coordinates.Y;
                grf.FillRectangle(brush, x * CellSize, y * CellSize, CellSize, CellSize);
            }
        }

        public void DrawCellOne(Cell cell, Fog fog)
        {
            var color = GetCellColor(cell.Type, cell.Schema);
            using (var brush = new SolidBrush(color))
            {
                int xpx = cell.Coordinates.X * CellSize;
                int ypx = cell.Coordinates.Y * CellSize;
                grf.FillRectangle(brush, xpx, ypx, CellSize, CellSize);

                brush.Color = Color.FromArgb(200, Color.DarkGray);
                if (fog[cell.Coordinates])
                    grf.FillRectangle(brush, xpx, ypx, CellSize, CellSize);
            }
        }

        private Color GetCellColor(CellType type, MapSchema schema)
        {
            switch (type)
            {
                case CellType.Grass:
                    return (MapSchema.Winter == schema) ? Color.White : Color.Green;
                case CellType.Snow:
                    return Color.WhiteSmoke;
                case CellType.Sand:
                    return (MapSchema.Winter == schema) ? Color.LightYellow : Color.Yellow;
                case CellType.Water:
                    return (MapSchema.Winter == schema) ? Color.DarkBlue : Color.Blue;
                case CellType.Stones:
                    return (MapSchema.Winter == schema) ? Color.DimGray : Color.Gray;
                case CellType.Forest:
                    return (MapSchema.Winter == schema) ? Color.DarkSeaGreen : Color.DarkGreen;
                case CellType.Road:
                    return Color.LightGray;
                case CellType.Buildings:
                    return Color.DarkGray;
                case CellType.Ice:
                    return Color.LightBlue;
            }

            return Color.Black;
        }

        // Рисования креста (когда путь не найден)
        public void DrawCross(Coordinates pt)
        {
            DrawCross(pt.X, pt.Y);
        }

        public void DrawCross(int x, int y)
        {
            string src = "img\\features\\Krest.png";
            using (var image = Image.FromFile(src))
            {
                grf.DrawImage(image, x * CellSize, y * CellSize, CellSize, CellSize);
            }
        }

        public void DrawFlag(Coordinates pt, MoveType moveType, bool isOneday)
        {
            DrawFlag(pt.X, pt.Y, moveType, isOneday);
        }

        public void DrawFlag(int x, int y, MoveType moveType, bool isOneday)
        {
            string src = GetFlagImagePath(moveType, isOneday);
            using (var image = Image.FromFile(src))
            {
                grf.DrawImage(image, x * CellSize, y * CellSize, CellSize, CellSize);
            }
        }

        private string GetFlagImagePath(MoveType moveType, bool isOneday)
        {
            var src = new StringBuilder("img\\flags\\Flag");

            switch (moveType)
            {
                case MoveType.Join:
                    src.Append("Add");
                    break;
                case MoveType.Attack:
                    src.Append("Atak");
                    break;
                case MoveType.Defend:
                    src.Append("Defend");
                    break;
                case MoveType.Capture:
                    src.Append("Capture");
                    break;
                case MoveType.Go:
                default:
                    src.Append("F");
                    break;
            }

            //если весь путь можно пройти за 1 день
            src.Append(isOneday ? "Red" : "Blue");
            src.Append(".png");
            return src.ToString();
        }

        public void DrawWay(List<Cell> wayall, int onedayIndex)
        {
            var oneday = wayall.GetRange(0, onedayIndex + 1);
            DrawWay(wayall, oneday);
        }

        /// <summary>Рисование пути, в том числе однодневную часть (синим цветом)
        /// </summary>
        /// <param name="allPut">весь путь (список координат)</param>
        /// <param name="oneDayPut">однодневный путь (часть всего пути)</param>
        /// <returns></returns>
        public void DrawWay(List<Cell> wayall, List<Cell> oneday)
        {
            using (var pen = new Pen(Color.Red))
            {
                int x1, y1, x2, y2;

                //рисуем путь на один день
                for (int k = 0; k < (oneday.Count - 1); k++)
                {
                    x1 = oneday[k].Coordinates.X * CellSize + CellSize / 2 + 1;
                    y1 = oneday[k].Coordinates.Y * CellSize + CellSize / 2 + 1;
                    x2 = oneday[k + 1].Coordinates.X * CellSize + CellSize / 2 + 1;
                    y2 = oneday[k + 1].Coordinates.Y * CellSize + CellSize / 2 + 1;
                    grf.DrawLine(pen, x1, y1, x2, y2);
                }
            }

            //если однодневный путь не меньше полного, рисуем красный флаг
            if (oneday.Count < wayall.Count)
            {
                using (var pen = new Pen(Color.Blue))
                {
                    int x1, y1, x2, y2;

                    //рисуем оставшийся путь
                    for (int k = (oneday.Count - 1); k < (wayall.Count - 1); k++)
                    {
                        x1 = wayall[k].Coordinates.X * CellSize + CellSize / 2 + 1;
                        y1 = wayall[k].Coordinates.Y * CellSize + CellSize / 2 + 1;
                        x2 = wayall[k + 1].Coordinates.X * CellSize + CellSize / 2 + 1;
                        y2 = wayall[k + 1].Coordinates.Y * CellSize + CellSize / 2 + 1;
                        grf.DrawLine(pen, x1, y1, x2, y2);
                    }
                }

                //рисуем синий флаг
                //drawFlag(grf, allPut.Last().Position.x, allPut.Last().Position.y, false);
            }
            /*else
            {
                drawFlag(grf, allPut.Last().Position.x, allPut.Last().Position.y, true);
            }*/
        }

        public void DrawPlayersObjects(Player[] players, Map map, Division selectedDivision, Building selectedBuilding)
        {
            foreach (var player in players)
            {
                foreach (var division in player.Divisions)
                {
                    if (!division.IsSecuring)
                        DrawDivision(division, division == selectedDivision);
                }

                foreach (var building in player.Buildings)
                {
                    // если есть охранение у здания, стереть уже нарисованного юнита
                    //if (building.IsSecured)
                    //    DrawCell(map[building.Position]);

                    DrawBuilding(building, building == selectedBuilding);
                }
            }
        }

        public void DrawPlayersObjects(Player[] players, int playerId, Division selectedDivision, Building selectedBuilding, Fog fog)
        {
            foreach (var player in players)
            {
                if (player.Id == playerId)
                    DrawPlayerObjects(player, selectedDivision, selectedBuilding);
                else
                    DrawPlayerObjectsWithFog(player, selectedDivision, selectedBuilding, fog);
            }
        }

        public void DrawPlayerObjects(Player player, Division selectedDivision, Building selectedBuilding)
        {
            foreach (var division in player.Divisions)
            {
                if (!division.IsSecuring)
                    DrawDivision(division, division == selectedDivision);
            }

            foreach (var building in player.Buildings)
            {
                DrawBuilding(building, building == selectedBuilding);
            }
        }

        public void DrawPlayerObjectsWithFog(Player player, Division selectedDivision, Building selectedBuilding, Fog fog)
        {
            foreach (var division in player.Divisions)
            {
                if (!fog[division.Position])
                {
                    if (!division.IsSecuring)
                        DrawDivision(division, division == selectedDivision);
                }
            }

            foreach (var building in player.Buildings)
            {
                if (!fog[building.Position])
                {
                    DrawBuilding(building, building == selectedBuilding);
                }
            }
        }

        public void DrawDivision(Division division, bool selected)
        {
            int x = division.Position.X;
            int y = division.Position.Y;

            var src = GetDivisionImagePath(division, selected);
            using (var newImage = Image.FromFile(src))
            {
                grf.DrawImage(newImage, x * CellSize, y * CellSize, CellSize, CellSize);
            }
        }

        private string GetDivisionImagePath(Division division, bool selected)
        {
            var src = new StringBuilder("img\\elements\\");

            switch (division.Type)
            {
                case DivisionType.Infantry:
                    src.Append("Human");
                    break;
                case DivisionType.Ship:
                    src.Append("Ship");
                    break;
                case DivisionType.Aviation:
                    src.Append("Plane");
                    break;
                case DivisionType.Artillery:
                    src.Append("Artiller");
                    break;
                case DivisionType.Vehicle:
                default:
                    src.Append("Tank");
                    break;
            }

            src.Append((division.PlayerId + 1).ToString());
            src.Append(selected ? "_selected.png" : ".png");
            return src.ToString();
        }

        public void DrawBuilding(Building building, bool selected)
        {
            int x = building.Position.X;
            int y = building.Position.Y;

            var src = GetBuildingImagePath(building, selected);
            using (var image = Image.FromFile(src))
            {
                grf.DrawImage(image, x * CellSize, y * CellSize, CellSize, CellSize);
            }

            //если есть охранение - пометить
            if (building.IsSecured)
            {
                src = "img\\features\\Defend.png";
                using (var image = Image.FromFile(src))
                {
                    grf.DrawImage(image, x * CellSize, y * CellSize, CellSize, CellSize);
                }
            }
        }

        private string GetBuildingImagePath(Building building, bool selected)
        {
            var src = new StringBuilder("img\\buildings\\");

            switch (building.Type)
            {
                case BuildingType.Barracks:
                    src.Append("Kazarma");
                    break;
                case BuildingType.Storehouse:
                    src.Append("Sklad");
                    break;
                case BuildingType.Radar:
                    src.Append("Radar");
                    break;
                case BuildingType.Airfield:
                    src.Append("Aeroport");
                    break;
                case BuildingType.Port:
                    src.Append("Port");
                    break;
                case BuildingType.Factory:
                default:
                    src.Append("Zavod");
                    break;
            }

            src.Append((building.PlayerId + 1).ToString());
            src.Append(selected ? "_selected.png" : ".png");
            return src.ToString();
        }

        public void DrawFog(Fog fog)
        {
            var color = Color.FromArgb(200, Color.DarkGray);
            using (Brush myBrsh = new SolidBrush(color))
            {
                for (int y = 0; y < fog.Height; y++)
                {
                    for (int x = 0; x < fog.Width; x++)
                    {
                        if (fog[x, y])
                            grf.FillRectangle(myBrsh, x * CellSize, y * CellSize, CellSize, CellSize);
                    }
                }
            }
        }

        /*public void DrawFogCell(int x, int y)
        {
            var color = Color.FromArgb(200, Color.DarkGray);
            using (Brush myBrsh = new SolidBrush(color))
            {
                grf.FillRectangle(myBrsh, x * CellSize, y * CellSize, CellSize, CellSize);
            }
        }*/
    }
}

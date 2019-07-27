using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Players;
using MT.TacticWar.Gameplay;

namespace MT.TacticWar.UI
{
    public class GameGraphics : IGraphics
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

        public void DrawArea(Mission mission, Coordinates area, Fog fog)
        {
            DrawArea(mission, new[] { area }, fog);
        }

        public void DrawArea(Mission mission, Coordinates[] area, Fog fog)
        {
            foreach (var pt in area)
            {
                DrawCellOne(mission.Map[pt], fog);

                if (!fog[pt])
                {
                    var obj = mission.Map[pt].Object;
                    if (null != obj)
                    {
                        if (obj is Division)
                        {
                            var division = obj as Division;
                            if (division.IsSecuring)
                                DrawBuilding(division.SecuredBuilding, false);
                            else
                                DrawDivision(division, false);
                        }
                        else if (obj is Building)
                        {
                            var building = obj as Building;
                            DrawBuilding(building, false);
                        }
                    }

                    /*var division = mission.GetDivisionAt(pt);
                    if (null != division)
                        if (!division.IsSecuring)
                            DrawDivision(division, false);

                    var building = mission.GetBuildingAt(pt);
                    if (null != building)
                        DrawBuilding(building, false);*/
                }
            }
        }

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

                if (fog[cell.Coordinates])
                {
                    brush.Color = GetFogColor();
                    grf.FillRectangle(brush, xpx, ypx, CellSize, CellSize);
                }
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
            int x = pt.X;
            int y = pt.Y;

            string src = @"images\features\cross.png";
            using (var image = Image.FromFile(src))
            {
                grf.DrawImage(image, x * CellSize, y * CellSize, CellSize, CellSize);
            }
        }

        public void DrawFlag(Coordinates pt, MoveType moveType, bool isOneday)
        {
            int x = pt.X;
            int y = pt.Y;

            string src = GetFlagImagePath(moveType, isOneday);
            using (var image = Image.FromFile(src))
            {
                var attr = GetFlagColorReplacement(isOneday);
                var rect = new Rectangle(x * CellSize, y * CellSize, CellSize, CellSize);
                grf.DrawImage(image, rect, 0, 0, CellSize, CellSize, GraphicsUnit.Pixel, attr);
            }
        }

        private string GetFlagImagePath(MoveType moveType, bool isOneday)
        {
            var path = @"images\flags\";
            switch (moveType)
            {
                case MoveType.Join:
                    return $"{path}join.png";
                case MoveType.Attack:
                    return $"{path}attack.png";
                case MoveType.Defend:
                    return $"{path}defend.png";
                case MoveType.Capture:
                    return $"{path}capture.png";
                case MoveType.Go:
                    return $"{path}flag.png";
            }

            throw new Exception("Неизвестный тип флага.");
        }

        private ImageAttributes GetFlagColorReplacement(bool isOneday)
        {
            var colorMap = new List<ColorMap>();
            colorMap.Add(new ColorMap
            {
                OldColor = Color.Silver,
                NewColor = isOneday ? Color.Red : Color.Blue
            });
            var attr = new ImageAttributes();
            attr.SetRemapTable(colorMap.ToArray());
            return attr;
        }

        /// <summary>Рисование пути, в том числе однодневную часть (красным цветом)</summary>
        /// <param name="wayall">весь путь (список ячеек)</param>
        /// <param name="onedayIndex">индекс, где заканчивается однодневный путь</param>
        public void DrawWay(List<Cell> wayall, int onedayIndex)
        {
            var oneday = wayall.GetRange(0, onedayIndex + 1);

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

        public void DrawPlayersObjects(Player[] players, int playerCurrent, Division selectedDivision, Building selectedBuilding, Fog fog)
        {
            foreach (var player in players)
            {
                if (player.Id == playerCurrent)
                    DrawPlayerObjects(player, selectedDivision, selectedBuilding);
                else
                    DrawPlayerObjectsWithFog(player, selectedDivision, selectedBuilding, fog);
            }
        }

        private void DrawPlayerObjects(Player player, Division selectedDivision, Building selectedBuilding)
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

        private void DrawPlayerObjectsWithFog(Player player, Division selectedDivision, Building selectedBuilding, Fog fog)
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

            var src = GetDivisionImagePath(division);
            using (var image = Image.FromFile(src))
            {
                var attr = GetObjectColorReplacement(division.Player.Color, selected);
                var rect = new Rectangle(x * CellSize, y * CellSize, CellSize, CellSize);
                grf.DrawImage(image, rect, 0, 0, CellSize, CellSize, GraphicsUnit.Pixel, attr);
            }
        }

        public void DrawBuilding(Building building, bool selected)
        {
            int x = building.Position.X;
            int y = building.Position.Y;

            var src = GetBuildingImagePath(building);
            using (var image = Image.FromFile(src))
            {
                var attr = GetObjectColorReplacement(building.Player.Color, selected);
                var rect = new Rectangle(x * CellSize, y * CellSize, CellSize, CellSize);
                grf.DrawImage(image, rect, 0, 0, CellSize, CellSize, GraphicsUnit.Pixel, attr);
            }

            //если есть охранение - пометить
            if (building.IsSecured)
            {
                src = @"images\features\defend.png";
                using (var image = Image.FromFile(src))
                {
                    grf.DrawImage(image, x * CellSize, y * CellSize, CellSize, CellSize);
                }
            }
        }

        private string GetDivisionImagePath(Division division)
        {
            var path = @"images\divisions\";
            switch (division.Type)
            {
                case DivisionType.Infantry:
                    return $"{path}human.png";
                case DivisionType.Ship:
                    return $"{path}ship.png";
                case DivisionType.Aviation:
                    return $"{path}plane.png";
                case DivisionType.Artillery:
                    return $"{path}artillery.png";
                case DivisionType.Vehicle:
                    return $"{path}tank.png";
            }

            throw new Exception("Неизвестный тип подразделения.");
        }

        private string GetBuildingImagePath(Building building)
        {
            var path = @"images\buildings\";
            switch (building.Type)
            {
                case BuildingType.Barracks:
                    return $"{path}barracks.png";
                case BuildingType.Storehouse:
                    return $"{path}storehouse.png";
                case BuildingType.Radar:
                    return $"{path}radar.png";
                case BuildingType.Airfield:
                    return $"{path}airfield.png";
                case BuildingType.Port:
                    return $"{path}port.png";
                case BuildingType.Factory:
                    return $"{path}factory.png";
            }

            throw new Exception("Неизвестный тип строения.");
        }

        private ImageAttributes GetObjectColorReplacement(PlayerColor color, bool selected)
        {
            var colorMap = new List<ColorMap>();
            colorMap.Add(new ColorMap
            {
                OldColor = Color.Silver,
                NewColor = ConvertPlayerColor(color)
            });
            if (selected)
            {
                colorMap.Add(new ColorMap
                {
                    OldColor = Color.Black,
                    NewColor = Color.DarkOrange
                });
            }
            var attr = new ImageAttributes();
            attr.SetRemapTable(colorMap.ToArray());
            return attr;
        }

        private Color ConvertPlayerColor(PlayerColor color)
        {
            switch (color)
            {
                case PlayerColor.White:
                    return Color.Snow;
                case PlayerColor.Green:
                    return Color.MediumSeaGreen;
                case PlayerColor.Red:
                    return Color.OrangeRed;
                case PlayerColor.Yellow:
                    return Color.Gold;
                case PlayerColor.Blue:
                    return Color.SlateBlue;
            }

            throw new Exception("Неизвестный цвет.");
        }

        public void DrawFog(Fog fog)
        {
            var color = GetFogColor();
            using (Brush brush = new SolidBrush(color))
            {
                for (int y = 0; y < fog.Height; y++)
                {
                    for (int x = 0; x < fog.Width; x++)
                    {
                        if (fog[x, y])
                            grf.FillRectangle(brush, x * CellSize, y * CellSize, CellSize, CellSize);
                    }
                }
            }
        }

        private Color GetFogColor()
        {
            return Color.FromArgb(96, Color.Black);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using GDIGraphics = System.Drawing.Graphics;
using System.Drawing.Imaging;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Base.Landscape.Summer;
using MT.TacticWar.Gameplay;
using MT.TacticWar.Core.Base.Landscape.Winter;

namespace MT.TacticWar.UI.Graphics
{
    public class GameGraphics : IGraphics
    {
        public int CellSize { get; private set; }
        private readonly GDIGraphics grf;

        public GameGraphics(GDIGraphics grf, int cellSize)
        {
            this.grf = grf;
            CellSize = cellSize;
        }

        public void Clear(Color color)
        {
            grf.Clear(color);
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
            var color = GetCellColor(cell);
            using (var brush = new SolidBrush(color))
            {
                int x = cell.Coordinates.X;
                int y = cell.Coordinates.Y;
                grf.FillRectangle(brush, x * CellSize, y * CellSize, CellSize, CellSize);
            }
        }

        public void DrawCellOne(Cell cell, Fog fog)
        {
            var color = GetCellColor(cell);
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

        private Color GetCellColor(Cell cell)
        {
            if (cell is Field)
                return Color.Green;
            if (cell is Road)
                return Color.LightGray;
            if (cell is Railroad)
                return Color.Gray;
            if (cell is Water)
                return Color.Blue;
            if (cell is ColdWater)
                return Color.DarkBlue;
            if (cell is Forest)
                return Color.DarkGreen;
            if (cell is WinterForest)
                return Color.DarkSeaGreen;
            if (cell is Snow)
                return Color.White;
            if (cell is Sand)
                return Color.Yellow;
            if (cell is Stones)
                return Color.DimGray;
            if (cell is Ice)
                return Color.LightBlue;
            if (cell is Bridge)
                return Color.Chocolate;
            if (cell is RailwayBridge)
                return Color.Sienna;

            return Color.Black;
        }

        // Рисования креста (когда путь не найден)
        public void DrawCross(Coordinates pt)
        {
            int x = pt.X;
            int y = pt.Y;

            using (var image = GameResources.GetCrossImage())
            {
                grf.DrawImage(image, x * CellSize, y * CellSize, CellSize, CellSize);
            }
        }

        public void DrawFlag(Coordinates pt, MoveType moveType, bool isOneday)
        {
            int x = pt.X;
            int y = pt.Y;

            using (var image = GameResources.GetFlagImage(moveType))
            {
                var attr = GetFlagColorReplacement(isOneday);
                var rect = new Rectangle(x * CellSize, y * CellSize, CellSize, CellSize);
                grf.DrawImage(image, rect, 0, 0, CellSize, CellSize, GraphicsUnit.Pixel, attr);
            }
        }

        private ImageAttributes GetFlagColorReplacement(bool isOneday)
        {
            var colorMap = new List<ColorMap>();
            colorMap.Add(new ColorMap
            {
                OldColor = Color.Silver,
                NewColor = isOneday ? Color.Red : Color.RoyalBlue
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
                for (int i = 0; i < (oneday.Count - 1); i++)
                {
                    x1 = oneday[i].Coordinates.X * CellSize + CellSize / 2 + 1;
                    y1 = oneday[i].Coordinates.Y * CellSize + CellSize / 2 + 1;
                    x2 = oneday[i + 1].Coordinates.X * CellSize + CellSize / 2 + 1;
                    y2 = oneday[i + 1].Coordinates.Y * CellSize + CellSize / 2 + 1;
                    grf.DrawLine(pen, x1, y1, x2, y2);
                }
            }

            //если однодневный путь не меньше полного, рисуем красный флаг
            if (oneday.Count < wayall.Count)
            {
                using (var pen = new Pen(Color.RoyalBlue))
                {
                    int x1, y1, x2, y2;

                    //рисуем оставшийся путь
                    for (int i = (oneday.Count - 1); i < (wayall.Count - 1); i++)
                    {
                        x1 = wayall[i].Coordinates.X * CellSize + CellSize / 2 + 1;
                        y1 = wayall[i].Coordinates.Y * CellSize + CellSize / 2 + 1;
                        x2 = wayall[i + 1].Coordinates.X * CellSize + CellSize / 2 + 1;
                        y2 = wayall[i + 1].Coordinates.Y * CellSize + CellSize / 2 + 1;
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

        public void DrawPlayersObjects(Player[] players, Division selectedDivision, Building selectedBuilding)
        {
            foreach (var player in players)
            {
                DrawPlayerObjects(player, selectedDivision, selectedBuilding);
            }
        }

        public void DrawPlayersObjects(Player[] players, Player currentPlayer, Division selectedDivision, Building selectedBuilding, Fog fog)
        {
            foreach (var player in players)
            {
                if (player == currentPlayer)
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

            using (var image = GameResources.GetDivisionImage(division))
            {
                var attr = GameResources.GetObjectColorReplacement(division.Player.Color, selected);
                var rect = new Rectangle(x * CellSize, y * CellSize, CellSize, CellSize);
                grf.DrawImage(image, rect, 0, 0, CellSize, CellSize, GraphicsUnit.Pixel, attr);
            }
        }

        public void DrawBuilding(Building building, bool selected)
        {
            int x = building.Position.X;
            int y = building.Position.Y;

            using (var image = GameResources.GetBuildingImage(building))
            {
                var attr = GameResources.GetObjectColorReplacement(building.Player.Color, selected);
                var rect = new Rectangle(x * CellSize, y * CellSize, CellSize, CellSize);
                grf.DrawImage(image, rect, 0, 0, CellSize, CellSize, GraphicsUnit.Pixel, attr);
            }

            //если есть охранение - пометить
            if (building.IsSecured)
            {
                using (var image = GameResources.GetBuildingDefendImage())
                {
                    grf.DrawImage(image, x * CellSize, y * CellSize, CellSize, CellSize);
                }
            }
        }

        public void DrawFog(Fog fog)
        {
            var color = GetFogColor();
            using (var brush = new SolidBrush(color))
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

        public void DrawZone(int id, int x, int y)
        {
            using (var drawFont = new Font("Consolas", 10))
            {
                using (var brush = new SolidBrush(Color.Cyan))
                {
                    int left = x * CellSize;
                    int top = y * CellSize;
                    grf.FillRectangle(brush, left, top, CellSize, CellSize);

                    brush.Color = Color.Black;
                    grf.DrawString(id.ToString(), drawFont, brush, left, top);
                }
            }
        }

        public void DrawGate(int id, int x, int y)
        {
            using (var drawFont = new Font("Consolas", 10))
            {
                using (var brush = new SolidBrush(Color.DeepPink))
                {
                    int left = x * CellSize;
                    int top = y * CellSize;
                    grf.FillRectangle(brush, left, top, CellSize, CellSize);

                    brush.Color = Color.Black;
                    grf.DrawString(id.ToString(), drawFont, brush, left, top);
                }
            }
        }
    }
}

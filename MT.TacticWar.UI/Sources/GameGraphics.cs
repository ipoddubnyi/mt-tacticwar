using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.UI
{
    class GameGraphics
    {
        public const int CellSize = 21;

        private readonly Graphics grf;

        public GameGraphics(Graphics grf)
        {
            this.grf = grf;
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

        public void DrawCell(Cell cell)
        {
            var color = GetCellColor(cell.Type);
            using (Brush myBrsh = new SolidBrush(color))
            {
                int x = cell.Coordinates.X;
                int y = cell.Coordinates.Y;
                grf.FillRectangle(myBrsh, x * CellSize, y * CellSize, CellSize, CellSize);
            }
        }

        private Color GetCellColor(CellType type)
        {
            switch (type)
            {
                case CellType.Grass:
                    return Color.Green;
                case CellType.Snow:
                    return Color.WhiteSmoke;
                case CellType.Sand:
                    return Color.Yellow;
                case CellType.Water:
                    return Color.Blue;
                case CellType.Stones:
                    return Color.Gray;
                case CellType.Forest:
                    return Color.DarkGreen;
                case CellType.Road:
                    return Color.LightGray;
                case CellType.Buildings:
                    return Color.DarkGray;
                case CellType.Ice:
                    return Color.LightBlue;
            }

            return Color.White;
        }

        // Рисования креста (когда путь не найден)
        public void DrawCross(int x, int y)
        {
            string src = "img\\features\\Krest.png";
            using (var image = Image.FromFile(src))
            {
                grf.DrawImage(image, x * CellSize, y * CellSize, CellSize, CellSize);
            }
        }

        public void DrawFlag(int x, int y, MoveType moveType, bool oneDay)
        {
            string src = GetFlagImagePath(moveType, oneDay);
            using (var image = Image.FromFile(src))
            {
                grf.DrawImage(image, x * CellSize, y * CellSize, CellSize, CellSize);
            }
        }

        private string GetFlagImagePath(MoveType moveType, bool oneDay)
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
            src.Append(oneDay ? "Red" : "Blue");
            src.Append(".png");
            return src.ToString();
        }

        /// <summary>Рисование пути, в том числе однодневную часть (синим цветом)
        /// </summary>
        /// <param name="allPut">весь путь (список координат)</param>
        /// <param name="oneDayPut">однодневный путь (часть всего пути)</param>
        /// <returns></returns>
        public void DrawWay(List<Cell> allPut, List<Cell> oneDayPut)
        {
            using (var pen = new Pen(Color.Red))
            {
                int x1, y1, x2, y2;

                //рисуем путь на один день
                for (int k = 0; k < (oneDayPut.Count - 1); k++)
                {
                    x1 = oneDayPut[k].Coordinates.X * CellSize + CellSize / 2 + 1;
                    y1 = oneDayPut[k].Coordinates.Y * CellSize + CellSize / 2 + 1;
                    x2 = oneDayPut[k + 1].Coordinates.X * CellSize + CellSize / 2 + 1;
                    y2 = oneDayPut[k + 1].Coordinates.Y * CellSize + CellSize / 2 + 1;
                    grf.DrawLine(pen, x1, y1, x2, y2);
                }
            }

            //если однодневный путь не меньше полного, рисуем красный флаг
            if (oneDayPut.Count < allPut.Count)
            {
                using (var pen = new Pen(Color.Blue))
                {
                    int x1, y1, x2, y2;

                    //рисуем оставшийся путь
                    for (int k = (oneDayPut.Count - 1); k < (allPut.Count - 1); k++)
                    {
                        x1 = allPut[k].Coordinates.X * CellSize + CellSize / 2 + 1;
                        y1 = allPut[k].Coordinates.Y * CellSize + CellSize / 2 + 1;
                        x2 = allPut[k + 1].Coordinates.X * CellSize + CellSize / 2 + 1;
                        y2 = allPut[k + 1].Coordinates.Y * CellSize + CellSize / 2 + 1;
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
    }
}

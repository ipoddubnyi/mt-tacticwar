using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Brush myBrsh;

            switch (cell.Type)
            {
                case CellType.Grass:
                    myBrsh = new SolidBrush(Color.Green);
                    break;
                case CellType.Snow:
                    myBrsh = new SolidBrush(Color.WhiteSmoke);
                    break;
                case CellType.Sand:
                    myBrsh = new SolidBrush(Color.Yellow);
                    break;
                case CellType.Water:
                    myBrsh = new SolidBrush(Color.Blue);
                    break;
                case CellType.Stones:
                    myBrsh = new SolidBrush(Color.Gray);
                    break;
                case CellType.Forest:
                    myBrsh = new SolidBrush(Color.DarkGreen);
                    break;
                case CellType.Road:
                    myBrsh = new SolidBrush(Color.LightGray);
                    break;
                case CellType.Buildings:
                    myBrsh = new SolidBrush(Color.DarkGray);
                    break;
                case CellType.Ice:
                    myBrsh = new SolidBrush(Color.LightBlue);
                    break;
                default:
                    myBrsh = new SolidBrush(Color.White);
                    break;
            }

            //i - строки матрицы (ось OY), j - столбцы (ось OX)
            grf.FillRectangle(myBrsh, cell.Coordinates.X * CellSize, cell.Coordinates.Y * CellSize, CellSize, CellSize);
            myBrsh.Dispose();

            //grf.Dispose();
        }

        // Рисования креста (когда путь не найден)
        public void DrawCross(int i, int j)
        {
            string image = "img\\features\\Krest.png";
            Image newImage = Image.FromFile(image);
            grf.DrawImage(newImage, i * CellSize, j * CellSize, CellSize, CellSize);
            newImage.Dispose();
        }

        /// <summary>Рисования флага
        /// </summary>
        /// <param name="grf">на чём будем рисовать</param>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <param name="atack">присоединение (Add)/атака (Atak)/захват (Capture)/ защита
        /// (Defend)/обычный флаг (F)</param>
        /// <param name="redBlue">цвет (Red/Blue)</param>
        /// <returns></returns>
        public void DrawFlag(int i, int j, string atack, string redBlue)
        {
            string image = "img\\flags\\";

            //если флаг красный, иначе - синий
            image += "Flag" + atack + redBlue + ".png";

            Image newImage = Image.FromFile(image);
            grf.DrawImage(newImage, i * CellSize, j * CellSize, CellSize, CellSize);

            newImage.Dispose();
        }

        /// <summary>Рисование пути, в том числе однодневную часть (синим цветом)
        /// </summary>
        /// <param name="grf">на чём будем рисовать</param>
        /// <param name="allPut">весь путь (список координат)</param>
        /// <param name="oneDayPut">однодневный путь (часть всего пути)</param>
        /// <returns></returns>
        public void DrawWay(List<Cell> allPut, List<Cell> oneDayPut)
        {
            Pen myPen = new Pen(Color.Red);

            int x1, y1, x2, y2;

            //рисуем путь на один день
            for (int k = 0; k < (oneDayPut.Count - 1); k++)
            {
                x1 = oneDayPut.ElementAt(k).Coordinates.X * CellSize + CellSize / 2 + 1;
                y1 = oneDayPut.ElementAt(k).Coordinates.Y * CellSize + CellSize / 2 + 1;
                x2 = oneDayPut.ElementAt(k + 1).Coordinates.X * CellSize + CellSize / 2 + 1;
                y2 = oneDayPut.ElementAt(k + 1).Coordinates.Y * CellSize + CellSize / 2 + 1;
                grf.DrawLine(myPen, x1, y1, x2, y2);
            }

            //если однодневный путь не меньше полного, рисуем красный флаг
            if (oneDayPut.Count < allPut.Count)
            {
                myPen.Dispose();
                myPen = new Pen(Color.Blue);

                //рисуем оставшийся путь
                for (int k = (oneDayPut.Count - 1); k < (allPut.Count - 1); k++)
                {
                    x1 = allPut.ElementAt(k).Coordinates.X * CellSize + CellSize / 2 + 1;
                    y1 = allPut.ElementAt(k).Coordinates.Y * CellSize + CellSize / 2 + 1;
                    x2 = allPut.ElementAt(k + 1).Coordinates.X * CellSize + CellSize / 2 + 1;
                    y2 = allPut.ElementAt(k + 1).Coordinates.Y * CellSize + CellSize / 2 + 1;
                    grf.DrawLine(myPen, x1, y1, x2, y2);
                }

                //рисуем синий флаг
                //drawFlag(grf, allPut.Last().Coordinates.x, allPut.Last().Coordinates.y, false);
            }
            /*else
            {
                drawFlag(grf, allPut.Last().Coordinates.x, allPut.Last().Coordinates.y, true);
                myPen.Dispose();
                return;
            }*/

            myPen.Dispose();
        }

        public void DrawBuilding(Building building, int left, int top, int fieldSize, bool selected)
        {
            string image = "img\\buildings\\";

            //выбрать изображение по типу подразделения
            switch (building.Type)
            {
                case BuildingType.Barracks:
                    image += "Kazarma";
                    break;
                case BuildingType.Storehouse:
                    image += "Sklad";
                    break;
                case BuildingType.Radar:
                    image += "Radar";
                    break;
                case BuildingType.Airfield:
                    image += "Aeroport";
                    break;
                case BuildingType.Port:
                    image += "Port";
                    break;
                case BuildingType.Factory:
                default:
                    image += "Zavod";
                    break;
            }

            string endOfImg = ".png";

            //если выделен
            if (selected)
                endOfImg = "_selected.png";

            image += (building.PlayerId + 1).ToString() + endOfImg;

            Image newImage = Image.FromFile(image);
            grf.DrawImage(newImage, left, top, fieldSize, fieldSize); //j * fieldSize, i * fieldSize);

            //---

            //если есть охранение - пометить
            if (building.IsSecured)
            {
                image = "img\\features\\Defend.png";

                newImage = Image.FromFile(image);
                grf.DrawImage(newImage, left, top, fieldSize, fieldSize); //j * fieldSize, i * fieldSize);
            }

            newImage.Dispose();
            //grf.Dispose();
        }

        public void DrawDivision(Division division, int left, int top, int fieldSize, bool selected)
        {
            string image = "img\\elements\\";

            //выбрать изображение по типу подразделения
            switch (division.Type)
            {
                case DivisionType.Infantry:
                    image += "Human";
                    break;
                case DivisionType.Ship:
                    image += "Ship";
                    break;
                case DivisionType.Aviation:
                    image += "Plane";
                    break;
                case DivisionType.Artillery:
                    image += "Artiller";
                    break;
                case DivisionType.Vehicle:
                default:
                    image += "Tank";
                    break;
            }

            string endOfImg = ".png";

            //если выделен
            if (selected)
                endOfImg = "_selected.png";

            image += (division.PlayerId + 1).ToString() + endOfImg;

            Image newImage = Image.FromFile(image);
            grf.DrawImage(newImage, left, top, fieldSize, fieldSize); //j * fieldSize, i * fieldSize);

            newImage.Dispose();
            //grf.Dispose();
        }
    }
}

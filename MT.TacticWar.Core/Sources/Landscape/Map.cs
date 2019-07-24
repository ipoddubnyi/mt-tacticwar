using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Landscape
{
    public class Map
    {
        public string Name;            //имя карты

        public Cell[,] Field;        //массив - поле боя

        public int Width;              //ширина поля боя
        public int Height;             //высота поля боя

        public Cell this[int x, int y] => Field[x, y];

        public Cell this[Coordinates pt] => Field[pt.X, pt.Y];

        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            Field = new Cell[height, width];

            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    Field[x, y] = new Cell(x, y);
        }

        /// <summary>Определить занятость ячеек
        /// </summary>
        /// <param name="players">массив игроков (для доступа к их объектам)</param>
        /// <returns></returns>
        public void OccupateCells(Player[] players)
        {
            int x, y;

            for (y = 0; y < Height; y++)
                for (x = 0; x < Width; x++)
                    Field[x, y].Object = null;

            foreach (var player in players)
            {
                foreach (var div in player.Divisions)
                {
                    x = div.Position.X;
                    y = div.Position.Y;
                    Field[x, y].Object = div;
                }

                foreach (var building in player.Buildings)
                {
                    x = building.Position.X;
                    y = building.Position.Y;
                    Field[x, y].Object = building;
                }
            }
        }
    }
}

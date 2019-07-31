using System;
using System.Collections.Generic;

namespace MT.TacticWar.Core.Landscape
{
    public class Map
    {
        public string Name { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Cell[,] Field { get; private set; }

        public Cell this[int x, int y] => Field[x, y];
        public Cell this[Coordinates pt] => Field[pt.X, pt.Y];

        public Map(int width, int height) :
            this("Карта местности", width, height)
        {
        }

        public Map(string name, int width, int height) :
            this(name, width, height, null)
        {
            // инициализация пустыми ячейками
            Field = new Cell[height, width];
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    Field[x, y] = null;
        }

        public Map(string name, int width, int height, Cell[,] field)
        {
            Name = name;
            Width = width;
            Height = height;
            Field = field;
        }

        /// <summary>Задать занятость ячеек</summary>
        /// <param name="players">массив игроков (для доступа к их объектам)</param>
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

        public Coordinates[] GetArea(Coordinates center, int radius)
        {
            var area = new List<Coordinates>();

            int mixX = Math.Max(0, center.X - radius);
            int maxX = Math.Min(Width - 1, center.X + radius);

            int mixY = Math.Max(0, center.Y - radius);
            int maxY = Math.Min(Height - 1, center.Y + radius);

            for (int y = mixY; y <= maxY; ++y)
            {
                for (int x = mixX; x <= maxX; ++x)
                {
                    area.Add(new Coordinates(x, y));
                }
            }

            return area.ToArray();
        }
    }
}

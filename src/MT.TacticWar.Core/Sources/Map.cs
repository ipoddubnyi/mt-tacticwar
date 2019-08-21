using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core
{
    public class Map
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public Schema Schema { get; protected set; }
        public Cell[,] Field { get; protected set; }

        public Cell this[int x, int y] => Field[x, y];
        public Cell this[Coordinates pt] => Field[pt.X, pt.Y];

        public Map(string name, string description, int width, int height) :
            this(name, description, width, height, null)
        {
        }

        public Map(string name, string description, int width, int height, Schema schema) :
            this(name, description, width, height, schema, null)
        {
            // инициализация пустыми ячейками
            Field = new Cell[height, width];
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    Field[x, y] = null;
        }

        public Map(string name, string description, int width, int height, Schema schema, Cell[,] field)
        {
            Name = name;
            Description = description;
            Width = width;
            Height = height;
            Schema = schema;
            Field = field;
        }

        public void SetCell(Cell cell)
        {
            Field[cell.Coordinates.X, cell.Coordinates.Y] = cell;
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
                foreach (var division in player.Divisions)
                    OccupateCell(division);

                foreach (var building in player.Buildings)
                    OccupateCell(building);
            }
        }

        /// <summary>Задать занятость ячейки</summary>
        /// <param name="obj">Объект, который занимает ячейку.</param>
        public void OccupateCell(IObject obj)
        {
            int x = obj.Position.X;
            int y = obj.Position.Y;
            Field[x, y].Object = obj;
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

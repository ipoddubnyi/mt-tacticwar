﻿
namespace MT.TacticWar.Core.Landscape
{
    public class Map
    {
        public string Name { get; private set; }
        public MapSchema Schema { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Cell[,] Field { get; private set; }

        public Cell this[int x, int y] => Field[x, y];
        public Cell this[Coordinates pt] => Field[pt.X, pt.Y];

        public Map(int width, int height) :
            this("Карта местности", width, height)
        {
        }

        public Map(string name, int width, int height, MapSchema schema = MapSchema.Summer) :
            this(name, width, height, null, schema)
        {
            // инициализация пустыми ячейками
            Field = new Cell[height, width];
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    Field[x, y] = new Cell(x, y, schema);
        }

        public Map(string name, int width, int height, Cell[,] field, MapSchema schema)
        {
            Name = name;
            Schema = schema;
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
    }
}

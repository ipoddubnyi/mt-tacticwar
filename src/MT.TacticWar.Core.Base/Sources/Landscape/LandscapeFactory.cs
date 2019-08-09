using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Base.Landscape.Summer;
using MT.TacticWar.Core.Base.Landscape.Winter;

namespace MT.TacticWar.Core.Base.Landscape
{
    public static class LandscapeFactory
    {
        private static readonly List<CellVariant> Cells = new List<CellVariant>()
        {
            new CellVariant { Schema = "summer", Name = "Поле",    Symbol = '-', Create = (x, y) => new Field(x, y) },
            new CellVariant { Schema = "summer", Name = "Дорога",  Symbol = '#', Create = (x, y) => new Road(x, y) },
            new CellVariant { Schema = "summer", Name = "Вода",    Symbol = '~', Create = (x, y) => new Water(x, y) },
            new CellVariant { Schema = "summer", Name = "Лес",     Symbol = '*', Create = (x, y) => new Forest(x, y) },
            new CellVariant { Schema = "summer", Name = "Песок",   Symbol = ':', Create = (x, y) => new Sand(x, y) },
            new CellVariant { Schema = "summer", Name = "Камни",   Symbol = 'o', Create = (x, y) => new Stones(x, y) },
            new CellVariant { Schema = "summer", Name = "Мост",    Symbol = '+', Create = (x, y) => new Bridge(x, y) },

            new CellVariant { Schema = "winter", Name = "Поле",    Symbol = '-', Create = (x, y) => new Snow(x, y) },
            new CellVariant { Schema = "winter", Name = "Дорога",  Symbol = '#', Create = (x, y) => new Road(x, y) },
            new CellVariant { Schema = "winter", Name = "Вода",    Symbol = '~', Create = (x, y) => new ColdWater(x, y) },
            new CellVariant { Schema = "winter", Name = "Лес",     Symbol = '*', Create = (x, y) => new WinterForest(x, y) },
            new CellVariant { Schema = "winter", Name = "Песок",   Symbol = ':', Create = (x, y) => new Sand(x, y) },
            new CellVariant { Schema = "winter", Name = "Камни",   Symbol = 'o', Create = (x, y) => new Stones(x, y) },
            new CellVariant { Schema = "winter", Name = "Мост",    Symbol = '+', Create = (x, y) => new Bridge(x, y) },
            new CellVariant { Schema = "winter", Name = "Лёд",     Symbol = '≈', Create = (x, y) => new Ice(x, y) }
        };

        public static Dictionary<string, string> GetAvailableSchema()
        {
            return new Dictionary<string, string>
            {
                { "Лето", "summer" },
                { "Зима", "winter" }
                //{ "Город", "city" }
            };
        }

        public static Dictionary<string, char> GetAvailableCells(string schema)
        {
            var d = new Dictionary<string, char>();
            foreach (var c in Cells)
            {
                if (c.Schema.Equals(schema))
                    d.Add(c.Name, c.Symbol);
            }
            return d;
        }

        public static Cell CreateCell(string schema, char cellType, int x, int y)
        {
            foreach (var c in Cells)
            {
                if (!c.Schema.Equals(schema))
                    continue;

                if (c.Symbol == cellType)
                    return c.Create(x, y);
            }

            throw new Exception("Неизвестный тип схемы ландшафта.");
        }

        public static Cell CreateCellSummer(char cellType, int x, int y)
        {
            return CreateCell("summer", cellType, x, y);
        }

        public static Cell CreateCellWinter(char cellType, int x, int y)
        {
            return CreateCell("winter", cellType, x, y);
        }

        public static char GetCellSymbol(string schema, Cell cell)
        {
            switch (schema)
            {
                case "summer":
                    return GetCellSymbolSummer(cell);
                case "winter":
                    return GetCellSymbolWinter(cell);
                case "city":
                    return '-';
            }

            throw new Exception("Неизвестный тип схемы ландшафта.");
        }

        public static char GetCellSymbolSummer(Cell cell)
        {
            if (cell is Field)
                return '-';
            if (cell is Road)
                return '#';
            if (cell is Water)
                return '~';
            if (cell is Forest)
                return '*';
            if (cell is Sand)
                return ':';
            if (cell is Stones)
                return 'o';
            if (cell is Bridge)
                return '+';

            throw new Exception("Неизвестный тип ландшафта.");
        }

        public static char GetCellSymbolWinter(Cell cell)
        {
            if (cell is Snow)
                return '-';
            if (cell is Road)
                return '#';
            if (cell is ColdWater)
                return '~';
            if (cell is WinterForest)
                return '*';
            if (cell is Sand)
                return ':';
            if (cell is Stones)
                return 'o';
            if (cell is Bridge)
                return '+';
            if (cell is Ice)
                return '≈'; // TODO: подумать о другом символе

            throw new Exception("Неизвестный тип ландшафта.");
        }
    }
}

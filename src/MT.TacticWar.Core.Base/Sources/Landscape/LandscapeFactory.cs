using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Base.Landscape.Summer;
using MT.TacticWar.Core.Base.Landscape.Winter;

namespace MT.TacticWar.Core.Base.Landscape
{
    public static class LandscapeFactory
    {
        public static Dictionary<string, char> GetAvailable()
        {
            var d = new Dictionary<string, char>();
            d.Add("Поле",       '-');
            d.Add("Дорога",     '#');
            d.Add("Вода",       '~');
            d.Add("Лес",        '*');
            d.Add("Песок",      ':');
            d.Add("Камни",      'o');
            d.Add("Мост",       '+');
            return d;
        }

        public static Cell CreateCell(string schema, char cellType, int x, int y)
        {
            switch (schema)
            {
                case "summer":
                    return CreateCellSummer(cellType, x, y);
                case "winter":
                    return CreateCellWinter(cellType, x, y);
                case "city":
                    return null;
            }

            throw new Exception("Неизвестный тип схемы ландшафта.");
        }

        public static Cell CreateCellSummer(char cellType, int x, int y)
        {
            switch (cellType)
            {
                case '-':
                    return new Field(x, y);

                case '#':
                    return new Road(x, y);

                case '~':
                    return new Water(x, y);

                case '*':
                    return new Forest(x, y);

                case ':':
                    return new Sand(x, y);

                case 'o':
                    return new Stones(x, y);

                case '+':
                    return new Bridge(x, y);
            }

            return null;
        }

        public static Cell CreateCellWinter(char cellType, int x, int y)
        {
            switch (cellType)
            {
                case '-':
                    return new Snow(x, y);

                case '#':
                    return new Road(x, y);

                case '~':
                    return new ColdWater(x, y);

                case '*':
                    return new WinterForest(x, y);

                case ':':
                    return new Sand(x, y);

                case 'o':
                    return new Stones(x, y);

                case '+':
                    return new Bridge(x, y);

                case '≈': // TODO: подумать о другом символе
                    return new Ice(x, y);
            }

            return null;
        }

        public static char GetCellCode(string schema, Cell cell)
        {
            switch (schema)
            {
                case "summer":
                    return GetCellCodeSummer(cell);
                case "winter":
                    return GetCellCodeWinter(cell);
                case "city":
                    return '-';
            }

            throw new Exception("Неизвестный тип схемы ландшафта.");
        }

        public static char GetCellCodeSummer(Cell cell)
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

        public static char GetCellCodeWinter(Cell cell)
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

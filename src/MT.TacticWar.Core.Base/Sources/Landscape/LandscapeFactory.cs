using System;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Base.Landscape.Summer;
using MT.TacticWar.Core.Base.Landscape.Winter;

namespace MT.TacticWar.Core.Base.Landscape
{
    public static class LandscapeFactory
    {
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
    }
}

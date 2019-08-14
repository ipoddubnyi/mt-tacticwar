using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Base.Landscape.Schemas;
using MT.TacticWar.Core.Base.Landscape.Summer;
using MT.TacticWar.Core.Base.Landscape.Winter;

namespace MT.TacticWar.Core.Base.Landscape
{
    public static class LandscapeFactory
    {
        public static readonly List<SchemaVariant> Schemas = new List<SchemaVariant>()
        {
            new SchemaVariant { Name = "Лето", Code = "summer", Type = typeof(SummerSchema) },
            new SchemaVariant { Name = "Зима", Code = "winter", Type = typeof(WinterSchema) }
        };

        public static readonly List<CellVariant> Cells = new List<CellVariant>()
        {
            new CellVariant { Schema = "summer", Name = "Поле",    Code = '-', Type = typeof(Field) },
            new CellVariant { Schema = "summer", Name = "Дорога",  Code = '#', Type = typeof(Road) },
            new CellVariant { Schema = "summer", Name = "Вода",    Code = '~', Type = typeof(Water) },
            new CellVariant { Schema = "summer", Name = "Лес",     Code = '*', Type = typeof(Forest) },
            new CellVariant { Schema = "summer", Name = "Песок",   Code = ':', Type = typeof(Sand) },
            new CellVariant { Schema = "summer", Name = "Камни",   Code = 'o', Type = typeof(Stones) },
            new CellVariant { Schema = "summer", Name = "Мост",    Code = '+', Type = typeof(Bridge) },

            new CellVariant { Schema = "winter", Name = "Поле",    Code = '-', Type = typeof(Snow) },
            new CellVariant { Schema = "winter", Name = "Дорога",  Code = '#', Type = typeof(Road) },
            new CellVariant { Schema = "winter", Name = "Вода",    Code = '~', Type = typeof(ColdWater) },
            new CellVariant { Schema = "winter", Name = "Лес",     Code = '*', Type = typeof(WinterForest) },
            new CellVariant { Schema = "winter", Name = "Песок",   Code = ':', Type = typeof(Sand) },
            new CellVariant { Schema = "winter", Name = "Камни",   Code = 'o', Type = typeof(Stones) },
            new CellVariant { Schema = "winter", Name = "Мост",    Code = '+', Type = typeof(Bridge) },
            new CellVariant { Schema = "winter", Name = "Лёд",     Code = '≈', Type = typeof(Ice) }
        };

        public static List<CellVariant> GetAvailableCellsForSchema(string schema)
        {
            var list = new List<CellVariant>();
            foreach (var cell in Cells)
            {
                if (cell.Schema.Equals(schema))
                    list.Add(cell);
            }
            return list;
        }

        public static Schema CreateSchema(string code)
        {
            foreach (var sch in Schemas)
            {
                if (sch.Code == code)
                    return sch.Create();
            }

            throw new Exception("Неизвестный тип схемы ландшафта.");
        }

        public static Cell CreateCell(string schema, char code, int x, int y)
        {
            foreach (var c in Cells)
            {
                if (!c.Schema.Equals(schema))
                    continue;

                if (c.Code == code)
                    return c.Create(x, y);
            }

            throw new Exception("Неизвестный тип схемы ландшафта.");
        }

        public static char GetCellCode(string schema, Cell cell)
        {
            foreach (var c in Cells)
            {
                if (!c.Schema.Equals(schema))
                    continue;

                if (c.Type.Equals(cell.GetType()))
                    return c.Code;
            }

            throw new Exception("Неизвестный тип ячейки.");
        }
    }
}

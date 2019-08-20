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
            new SchemaVariant { Code = "summer", Type = typeof(SummerSchema) },
            new SchemaVariant { Code = "winter", Type = typeof(WinterSchema) }
        };

        public static readonly List<CellVariant> Cells = new List<CellVariant>()
        {
            new CellVariant { Code = '-', Type = typeof(Field) },
            new CellVariant { Code = '#', Type = typeof(Road) },
            new CellVariant { Code = '~', Type = typeof(Water) },
            new CellVariant { Code = '*', Type = typeof(Forest) },
            new CellVariant { Code = ':', Type = typeof(Sand) },
            new CellVariant { Code = 'o', Type = typeof(Stones) },
            new CellVariant { Code = '+', Type = typeof(Bridge) },

            new CellVariant { Code = '-', Type = typeof(Snow) },
            //new CellVariant { Code = '#', Type = typeof(Road) },
            new CellVariant { Code = '~', Type = typeof(ColdWater) },
            new CellVariant { Code = '*', Type = typeof(WinterForest) },
            //new CellVariant { Code = ':', Type = typeof(Sand) },
            //new CellVariant { Code = 'o', Type = typeof(Stones) },
            //new CellVariant { Code = '+', Type = typeof(Bridge) },
            new CellVariant { Code = '≈', Type = typeof(Ice) }
        };

        public static List<CellVariant> GetAvailableCellsForSchema(Schema schema)
        {
            var list = new List<CellVariant>();
            foreach (var cell in Cells)
            {
                if (cell.GetSchemaType().Equals(schema.GetType()))
                    list.Add(cell);
            }
            return list;
        }

        public static string GetSchemaCode(Schema schema)
        {
            foreach (var sch in Schemas)
            {
                if (sch.Type.Equals(schema.GetType()))
                    return sch.Code;
            }

            throw new Exception("Неизвестный тип схемы.");
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

        public static Cell CreateCell(Schema schema, char code, int x, int y)
        {
            foreach (var c in Cells)
            {
                if (!c.GetSchemaType().Equals(schema.GetType()))
                    continue;

                if (c.Code == code)
                    return c.Create(x, y);
            }

            throw new Exception("Неизвестный тип схемы ландшафта.");
        }

        public static char GetCellCode(Schema schema, Cell cell)
        {
            foreach (var c in Cells)
            {
                if (!c.GetSchemaType().Equals(schema.GetType()))
                    continue;

                if (c.Type.Equals(cell.GetType()))
                    return c.Code;
            }

            throw new Exception("Неизвестный тип ячейки.");
        }
    }
}

using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Base.Landscape.Schemas;
using MT.TacticWar.Core.Base.Landscape.Summer;
using MT.TacticWar.Core.Base.Landscape.Winter;
using MT.TacticWar.Core.Utils;

namespace MT.TacticWar.Core.Base.Landscape
{
    public static class LandscapeFactory
    {
        public static readonly List<SchemaCreator> Schemas = new List<SchemaCreator>()
        {
            new SchemaCreator(typeof(SummerSchema)),
            new SchemaCreator(typeof(WinterSchema))
        };

        public static readonly List<CellCreator> Cells = new List<CellCreator>()
        {
            new CellCreator(typeof(SummerSchema), typeof(Field)),
            new CellCreator(typeof(SummerSchema), typeof(Road)),
            new CellCreator(typeof(SummerSchema), typeof(Railroad)),
            new CellCreator(typeof(SummerSchema), typeof(Water)),
            new CellCreator(typeof(SummerSchema), typeof(Forest)),
            new CellCreator(typeof(SummerSchema), typeof(Sand)),
            new CellCreator(typeof(SummerSchema), typeof(Stones)),
            new CellCreator(typeof(SummerSchema), typeof(Bridge)),
            new CellCreator(typeof(SummerSchema), typeof(RailwayBridge)),

            new CellCreator(typeof(WinterSchema), typeof(Snow)),
            new CellCreator(typeof(WinterSchema), typeof(Road)),
            new CellCreator(typeof(WinterSchema), typeof(Railroad)),
            new CellCreator(typeof(WinterSchema), typeof(ColdWater)),
            new CellCreator(typeof(WinterSchema), typeof(WinterForest)),
            new CellCreator(typeof(WinterSchema), typeof(Sand)),
            new CellCreator(typeof(WinterSchema), typeof(Stones)),
            new CellCreator(typeof(WinterSchema), typeof(Bridge)),
            new CellCreator(typeof(WinterSchema), typeof(RailwayBridge)),
            new CellCreator(typeof(WinterSchema), typeof(Ice))
        };

        public static CellCreator[] GetSchemaCellTypes(Schema schema)
        {
            var list = new List<CellCreator>();
            foreach (var cell in Cells)
            {
                if (cell.SchemaType.Equals(schema.GetType()))
                    list.Add(cell);
            }
            return list.ToArray();
        }
        
        public static Schema CreateSchema(string code)
        {
            foreach (var sch in Schemas)
            {
                if (sch.GetCode().Equals(code))
                    return sch.Create();
            }

            throw new Exception("Неизвестный тип схемы ландшафта.");
        }

        public static Cell CreateCell(Schema schema, char code, int x, int y)
        {
            foreach (var c in Cells)
            {
                if (!c.SchemaType.Equals(schema.GetType()))
                    continue;

                if (c.GetCellCode().Equals(code))
                    return c.Create(x, y);
            }

            throw new Exception("Неизвестный тип схемы ландшафта.");
        }
    }
}

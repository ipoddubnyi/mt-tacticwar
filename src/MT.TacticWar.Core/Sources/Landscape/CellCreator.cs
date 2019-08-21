using System;

namespace MT.TacticWar.Core.Landscape
{
    public class CellCreator
    {
        public Type SchemaType;
        public Type Type;

        public CellCreator(Type schemaType, Type type)
        {
            SchemaType = schemaType;
            Type = type;
        }

        public Cell Create(int x, int y)
        {
            return (Cell)Activator.CreateInstance(Type, x, y);
        }

        //public Type GetSchemaType()
        //{
        //    return Cell.GetSchemaType(Type);
        //}

        public char GetCellCode()
        {
            return Cell.GetCellCode(Type);
        }

        public override string ToString()
        {
            return Cell.GetCellType(Type);
        }
    }
}

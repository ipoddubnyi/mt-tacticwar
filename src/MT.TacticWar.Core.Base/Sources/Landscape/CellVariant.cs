using System;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape
{
    public struct CellVariant
    {
        public char Code;
        public Type Type;

        public Cell Create(int x, int y)
        {
            return (Cell)Activator.CreateInstance(Type, x, y);
        }

        public Type GetSchemaType()
        {
            return Cell.GetSchemaType(Type);
        }

        public override string ToString()
        {
            return Cell.GetCellType(Type);
        }
    }
}

using System;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape
{
    public struct CellVariant
    {
        public string Schema;
        public string Name;
        public char Code;
        public Type Type;

        public Cell Create(int x, int y)
        {
            return (Cell)Activator.CreateInstance(Type, x, y);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

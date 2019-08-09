using System;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape
{
    struct CellVariant
    {
        public string Schema;
        public string Name;
        public char Symbol;
        public Func<int, int, Cell> Create;
    }
}

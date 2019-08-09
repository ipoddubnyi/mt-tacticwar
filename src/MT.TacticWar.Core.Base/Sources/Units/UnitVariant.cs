using System;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public struct UnitVariant
    {
        public string DivisionType;
        public string Name;
        public string UnitType;
        public Func<int, Division, Unit> Create;

        public override string ToString()
        {
            return Name;
        }
    }
}

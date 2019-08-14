using System;
using System.Globalization;
using System.Reflection;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public struct UnitVariant
    {
        public string DivisionType;
        public string Name;
        public string UnitType;
        public Type Type;

        public Unit Create(int id, Division division)
        {
            return (Unit)Activator.CreateInstance(Type,
                    BindingFlags.CreateInstance |
                    BindingFlags.Public |
                    BindingFlags.Instance |
                    BindingFlags.OptionalParamBinding,
                    null,
                    new object[] { id, division },
                    CultureInfo.CurrentCulture
                );
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

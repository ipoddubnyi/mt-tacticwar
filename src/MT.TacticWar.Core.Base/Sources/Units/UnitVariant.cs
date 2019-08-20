using System;
using System.Globalization;
using System.Reflection;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public struct UnitVariant
    {
        public string Code;
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

        public Type GetDivisionType()
        {
            return Unit.GetDivisionType(Type);
        }

        public override string ToString()
        {
            return Unit.GetUnitType(Type);
        }
    }
}

using System;
using System.Globalization;
using System.Reflection;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Utils
{
    public class UnitCreator
    {
        public Type Type;

        public UnitCreator(Type type)
        {
            Type = type;
        }

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

        public string GetCode()
        {
            return Unit.GetUnitCode(Type);
        }

        public override string ToString()
        {
            return Unit.GetUnitType(Type);
        }
    }
}

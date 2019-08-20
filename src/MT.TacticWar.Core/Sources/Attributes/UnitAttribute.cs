using System;

namespace MT.TacticWar.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class UnitAttribute : Attribute
    {
        public UnitAttribute(string name, Type divisionType)
        {
            Name = name;
            DivisionType = divisionType;
        }

        public string Name { get; set; }
        public Type DivisionType { get; set; }
    }
}

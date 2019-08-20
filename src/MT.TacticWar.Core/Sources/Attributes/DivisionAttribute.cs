using System;

namespace MT.TacticWar.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DivisionAttribute : Attribute
    {
        public DivisionAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}

using System;

namespace MT.TacticWar.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class BuildingAttribute : Attribute
    {
        public BuildingAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}

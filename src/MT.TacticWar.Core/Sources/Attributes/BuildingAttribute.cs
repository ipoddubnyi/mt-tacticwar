using System;

namespace MT.TacticWar.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class BuildingAttribute : Attribute
    {
        public BuildingAttribute(string name)
        {
            Name = name;
            Code = string.Empty;
        }

        public string Name { get; set; }
        public string Code { get; set; }
    }
}

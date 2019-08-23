using System;

namespace MT.TacticWar.Core
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ScriptArgumentAttribute : Attribute
    {
        public ScriptArgumentAttribute(string name)
        {
            Name = name;

            CanBeEmpty = false;
            Min = 0;
            Max = 100;
        }

        public string Name { get; set; }
        public bool CanBeEmpty { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}

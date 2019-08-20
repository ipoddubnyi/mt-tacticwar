using System;

namespace MT.TacticWar.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SchemaAttribute : Attribute
    {
        public SchemaAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}

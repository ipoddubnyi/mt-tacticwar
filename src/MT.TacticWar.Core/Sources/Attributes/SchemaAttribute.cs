using System;

namespace MT.TacticWar.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SchemaAttribute : Attribute
    {
        public SchemaAttribute(string name)
        {
            Name = name;
            Code = string.Empty;
        }

        public string Name { get; set; }
        public string Code { get; set; }
    }
}

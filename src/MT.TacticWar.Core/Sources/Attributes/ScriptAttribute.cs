using System;

namespace MT.TacticWar.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ScriptAttribute : Attribute
    {
        public ScriptAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}

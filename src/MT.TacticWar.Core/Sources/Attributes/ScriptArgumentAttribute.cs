using System;

namespace MT.TacticWar.Core
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ScriptArgumentAttribute : Attribute
    {
        public ScriptArgumentAttribute(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; set; }
        public Type Type { get; set; }

        //

        public bool IsString => typeof(string) == Type;
        public bool IsInteger => typeof(int) == Type;
    }
}

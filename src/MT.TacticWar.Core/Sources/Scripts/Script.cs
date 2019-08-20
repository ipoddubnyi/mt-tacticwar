using System;

namespace MT.TacticWar.Core.Scripts
{
    public class Script
    {
        public string Description { get; private set; }
        public ICondition Condition { get; private set; }
        public IStatement Statement { get; private set; }

        public Script(string description, ICondition condition, IStatement statement)
        {
            Description = description;
            Condition = condition;
            Statement = statement;
        }

        public override string ToString()
        {
            return Description;
        }

        //

        public static string GetScriptName(Type type)
        {
            var attributes = type.GetCustomAttributes(typeof(ScriptAttribute), false);
            var script = attributes[0] as ScriptAttribute;
            return script?.Name;
        }
    }
}

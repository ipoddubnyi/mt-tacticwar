using System;

namespace MT.TacticWar.Core.Scripts
{
    public class Script
    {
        public string Description { get; private set; }
        public bool Repeatable { get; private set; }
        public ICondition Condition { get; private set; }
        public IStatement Statement { get; private set; }
        public bool Complete { get; set; }
        
        public Script(string description, bool repeatable, ICondition condition, IStatement statement)
        {
            Description = description;
            Repeatable = repeatable;
            Condition = condition;
            Statement = statement;
            Complete = false;
        }

        public bool Check(Mission mission)
        {
            return Complete ? false : Condition.Check(mission);
        }

        public ISituation Execute(Mission mission)
        {
            if (!Repeatable)
                Complete = true;

            return Statement.Execute(mission);
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

        public static string GetScriptCode(Type type)
        {
            var attributes = type.GetCustomAttributes(typeof(ScriptAttribute), false);
            var script = attributes[0] as ScriptAttribute;
            return script?.Code;
        }

        public static string GetScriptCode(ICondition condition)
        {
            return GetScriptCode(condition.GetType());
        }

        public static string GetScriptCode(IStatement statement)
        {
            return GetScriptCode(statement.GetType());
        }
    }
}

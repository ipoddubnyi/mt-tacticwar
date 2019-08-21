using System;

namespace MT.TacticWar.Core.Scripts
{
    public class ScriptConditionCreator
    {
        public Type Type;

        public ScriptConditionCreator(Type type)
        {
            Type = type;
        }

        public ICondition Create(params string[] args)
        {
            return (ICondition)Activator.CreateInstance(Type, args);
        }

        public string GetCode()
        {
            return Script.GetScriptCode(Type);
        }

        public override string ToString()
        {
            return Script.GetScriptName(Type);
        }
    }
}

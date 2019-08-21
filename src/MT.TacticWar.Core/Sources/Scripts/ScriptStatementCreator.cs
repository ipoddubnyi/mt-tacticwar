using System;

namespace MT.TacticWar.Core.Scripts
{
    public class ScriptStatementCreator
    {
        public Type Type;

        public ScriptStatementCreator(Type type)
        {
            Type = type;
        }

        public IStatement Create(params string[] args)
        {
            return (IStatement)Activator.CreateInstance(Type, args);
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

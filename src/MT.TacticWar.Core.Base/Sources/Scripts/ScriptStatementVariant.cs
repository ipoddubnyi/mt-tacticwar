using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    public struct ScriptStatementVariant
    {
        public string Code;
        public Type Type;

        public IStatement Create(params string[] args)
        {
            return (IStatement)Activator.CreateInstance(Type, args);
        }

        public override string ToString()
        {
            return Script.GetScriptName(Type);
        }
    }
}

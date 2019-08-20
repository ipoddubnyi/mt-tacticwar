using System;
using System.Globalization;
using System.Reflection;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    public struct ScriptConditionVariant
    {
        public string Code;
        public Type Type;

        public ICondition Create(params string[] args)
        {
            return (ICondition)Activator.CreateInstance(Type, args);
        }

        public override string ToString()
        {
            return Script.GetScriptName(Type);
        }
    }
}

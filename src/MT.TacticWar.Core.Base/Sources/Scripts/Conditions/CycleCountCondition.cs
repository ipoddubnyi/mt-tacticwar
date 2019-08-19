using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    public class CycleCountCondition : ICondition
    {
        private readonly int cycleCount;

        public CycleCountCondition(params string[] args)
        {
            if (1 != args.Length)
                throw new FormatException("Неверный формат условия.");

            cycleCount = int.Parse(args[0]);
        }

        public bool Check(Mission mission)
        {
            return mission.Cycles == cycleCount;
        }

        public List<ScriptArgument> GetArguments()
        {
            return new List<ScriptArgument>()
            {
                new ScriptArgument { Name = "номер шага", Value = cycleCount.ToString() }
            };
        }
    }
}

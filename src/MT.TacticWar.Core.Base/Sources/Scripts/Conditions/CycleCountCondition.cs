using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    [Script("Номер шага", Code = "cyclecount")]
    public class CycleCountCondition : ICondition
    {
        [ScriptArgument("Номер шага", typeof(int))]
        private int CycleCount { get; set; }

        public CycleCountCondition(params string[] args)
        {
            if (1 != args.Length)
                throw new FormatException("Неверный формат условия.");

            CycleCount = int.Parse(args[0]);
        }

        public bool Check(Mission mission)
        {
            return mission.Cycles == CycleCount;
        }
    }
}

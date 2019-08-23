using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    [Script("Юнит существует", Code = "unitexists")]
    public class UnitExistsCondition : ICondition
    {
        [ScriptArgument("Игрок")]
        private int PlayerId { get; set; }

        [ScriptArgument("Юнит")]
        private int UnitId { get; set; }

        public UnitExistsCondition(params string[] args)
        {
            if (2 != args.Length)
                throw new FormatException("Неверный формат условия.");

            PlayerId = int.Parse(args[0]);
            UnitId = int.Parse(args[1]);
        }

        public bool Check(Mission mission)
        {
            return null != mission.Players.GetById(PlayerId).GetUnitById(UnitId);
        }
    }
}

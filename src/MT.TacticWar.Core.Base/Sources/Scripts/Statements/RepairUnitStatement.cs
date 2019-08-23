using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    [Script("Починить юнит", Code = "repairunit")]
    public class RepairUnitStatement : IStatement
    {
        [ScriptArgument("Игрок")]
        private int PlayerId { get; set; }

        [ScriptArgument("Юнит")]
        private int UnitId { get; set; }

        [ScriptArgument("Размер аптечки")]
        private int Medkit { get; set; }

        public RepairUnitStatement(params string[] args)
        {
            if (3 != args.Length)
                throw new FormatException("Неверный формат выражения.");

            PlayerId = int.Parse(args[0]);
            UnitId = int.Parse(args[1]);
            Medkit = int.Parse(args[2]);
        }

        public ISituation Execute(Mission mission)
        {
            var unit = mission.Players.GetById(PlayerId).GetUnitById(UnitId);
            if (null != unit)
                unit.Repair(Medkit);

            return null;
        }
    }
}

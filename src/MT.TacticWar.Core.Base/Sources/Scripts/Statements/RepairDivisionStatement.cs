using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    [Script("Починить подразделение", Code = "repairdivision")]
    public class RepairDivisionStatement : IStatement
    {
        [ScriptArgument("Игрок")]
        private int PlayerId { get; set; }

        [ScriptArgument("Подразделение")]
        private int DivisionId { get; set; }

        [ScriptArgument("Размер аптечки")]
        private int Medkit { get; set; }

        public RepairDivisionStatement(params string[] args)
        {
            if (3 != args.Length)
                throw new FormatException("Неверный формат выражения.");

            PlayerId = int.Parse(args[0]);
            DivisionId = int.Parse(args[1]);
            Medkit = int.Parse(args[2]);
        }

        public ISituation Execute(Mission mission)
        {
            var division = mission.Players.GetById(PlayerId).Divisions.GetById(DivisionId);
            if (null != division)
            {
                foreach (var unit in division.Units)
                    unit.Repair(Medkit);
            }

            return null;
        }
    }
}

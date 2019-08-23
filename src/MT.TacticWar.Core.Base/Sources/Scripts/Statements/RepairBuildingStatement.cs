using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    [Script("Починить строение", Code = "repairbuilding")]
    public class RepairBuildingStatement : IStatement
    {
        [ScriptArgument("Игрок")]
        private int PlayerId { get; set; }

        [ScriptArgument("Строение")]
        private int BuildingId { get; set; }

        [ScriptArgument("Размер аптечки")]
        private int Medkit { get; set; }

        public RepairBuildingStatement(params string[] args)
        {
            if (3 != args.Length)
                throw new FormatException("Неверный формат выражения.");

            PlayerId = int.Parse(args[0]);
            BuildingId = int.Parse(args[1]);
            Medkit = int.Parse(args[2]);
        }

        public ISituation Execute(Mission mission)
        {
            var building = mission.Players.GetById(PlayerId).Buildings.GetById(BuildingId);
            if (null != building)
                building.Repair(Medkit);

            return null;
        }
    }
}

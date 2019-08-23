using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    [Script("Строение существует", Code = "buildingexists")]
    public class BuildingExistsCondition : ICondition
    {
        [ScriptArgument("Игрок")]
        private int PlayerId { get; set; }

        [ScriptArgument("Строение")]
        private int BuildingId { get; set; }

        public BuildingExistsCondition(params string[] args)
        {
            if (2 != args.Length)
                throw new FormatException("Неверный формат условия.");

            PlayerId = int.Parse(args[0]);
            BuildingId = int.Parse(args[1]);
        }

        public bool Check(Mission mission)
        {
            return null != mission.Players.GetById(PlayerId).Buildings.GetById(BuildingId);
        }
    }
}

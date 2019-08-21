using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    [Script("Строение у игрока", Code = "playerbuilding")]
    public class PlayersBuildingCondition : ICondition
    {
        [ScriptArgument("Игрок", typeof(int))]
        private int PlayerId { get; set; }

        [ScriptArgument("Строение", typeof(int))]
        private int BuildingId { get; set; }

        public PlayersBuildingCondition(params string[] args)
        {
            if (2 != args.Length)
                throw new FormatException("Неверный формат условия.");

            PlayerId = int.Parse(args[0]);
            BuildingId = int.Parse(args[1]);
        }

        public bool Check(Mission mission)
        {
            var player = mission.Players.GetById(PlayerId);
            foreach (var bld in player.Buildings)
            {
                if (bld.Id == BuildingId)
                    return true;
            }

            return false;
        }
    }
}

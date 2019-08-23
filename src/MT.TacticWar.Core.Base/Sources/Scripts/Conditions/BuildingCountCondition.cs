using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    [Script("Количество строений у игрока", Code = "buildingcount")]
    public class BuildingCountCondition : ICondition
    {
        [ScriptArgument("Игрок")]
        private int PlayerId { get; set; }

        [ScriptArgument("Операция")]
        private Operation Operation { get; set; }

        [ScriptArgument("Количество строений")]
        private int BuildingCount { get; set; }

        public BuildingCountCondition(params string[] args)
        {
            if (3 != args.Length)
                throw new FormatException("Неверный формат условия.");

            PlayerId = int.Parse(args[0]);
            Operation = new Operation(args[1]);
            BuildingCount = int.Parse(args[2]);
        }

        public bool Check(Mission mission)
        {
            var player = mission.Players.GetById(PlayerId);
            var count = player.Buildings.Count;
            return Operation.Compare(count, BuildingCount);
        }
    }
}

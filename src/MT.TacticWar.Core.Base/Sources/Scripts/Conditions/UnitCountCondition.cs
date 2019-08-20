using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    [Script("Количество юнитов у игрока")]
    public class UnitCountCondition : ICondition
    {
        [ScriptArgument("Игрок", typeof(int))]
        private int PlayerId { get; set; }

        [ScriptArgument("Количество юнитов", typeof(int))]
        private int UnitCount { get; set; }

        public UnitCountCondition(params string[] args)
        {
            if (2 != args.Length)
                throw new FormatException("Неверный формат условия.");

            PlayerId = int.Parse(args[0]);
            UnitCount = int.Parse(args[1]);
        }

        public bool Check(Mission mission)
        {
            int count = 0;
            var player = mission.Players.GetById(PlayerId);
            foreach (var div in player.Divisions)
                count += div.Units.Count;

            return count > UnitCount;
        }
    }
}

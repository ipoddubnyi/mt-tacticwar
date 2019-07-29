using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    public class UnitCountCondition : ICondition
    {
        private int playerId;
        private int unitCount;

        public UnitCountCondition(params string[] args)
        {
            if (2 != args.Length)
                throw new FormatException("Неверный формат условия.");

            playerId = int.Parse(args[0]);
            unitCount = int.Parse(args[1]);
        }

        public bool Check(Mission mission)
        {
            int count = 0;
            foreach (var div in mission.Players[playerId].Divisions)
                count += div.Units.Count;

            return count > unitCount;
        }
    }
}

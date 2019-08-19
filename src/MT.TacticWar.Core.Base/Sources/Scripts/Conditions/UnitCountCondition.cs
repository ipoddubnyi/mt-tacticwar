using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    public class UnitCountCondition : ICondition
    {
        private readonly int playerId;
        private readonly int unitCount;

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
            var player = mission.Players.GetById(playerId);
            foreach (var div in player.Divisions)
                count += div.Units.Count;

            return count > unitCount;
        }

        public List<ScriptArgument> GetArguments()
        {
            return new List<ScriptArgument>()
            {
                new ScriptArgument { Name = "игрок", Value = playerId.ToString() },
                new ScriptArgument { Name = "кол-во юнитов", Value = unitCount.ToString() }
            };
        }
    }
}

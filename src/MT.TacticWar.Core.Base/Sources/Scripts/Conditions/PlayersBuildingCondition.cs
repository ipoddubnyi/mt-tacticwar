using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    public class PlayersBuildingCondition : ICondition
    {
        private readonly int playerId;
        private readonly int buildingId;

        public PlayersBuildingCondition(params string[] args)
        {
            if (2 != args.Length)
                throw new FormatException("Неверный формат условия.");

            playerId = int.Parse(args[0]);
            buildingId = int.Parse(args[1]);
        }

        public bool Check(Mission mission)
        {
            var player = mission.Players.GetById(playerId);
            foreach (var bld in player.Buildings)
            {
                if (bld.Id == buildingId)
                    return true;
            }

            return false;
        }

        public List<ScriptArgument> GetArguments()
        {
            return new List<ScriptArgument>()
            {
                new ScriptArgument { Name = "Игрок", Value = playerId.ToString() },
                new ScriptArgument { Name = "Строение", Value = buildingId.ToString() }
            };
        }
    }
}

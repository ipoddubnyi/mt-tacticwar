using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    public class UnitInZoneCondition : ICondition
    {
        private readonly int playerId;
        private readonly int unitId;
        private readonly int zoneId;

        public UnitInZoneCondition(params string[] args)
        {
            if (3 != args.Length)
                throw new FormatException("Неверный формат условия.");

            playerId = int.Parse(args[0]);
            unitId = int.Parse(args[1]);
            zoneId = int.Parse(args[2]);
        }

        public bool Check(Mission mission)
        {
            var unit = mission.Players.GetById(playerId).GetUnitById(unitId);
            if (null != unit)
            {
                var position = unit.Division.Position;
                foreach (var zone in mission.Zones)
                {
                    if (zone.IsInZone(position))
                        return true;
                }
            }

            return false;
        }

        public List<ScriptArgument> GetArguments()
        {
            return new List<ScriptArgument>()
            {
                new ScriptArgument { Name = "Игрок", Value = playerId.ToString() },
                new ScriptArgument { Name = "Юнит", Value = unitId.ToString() },
                new ScriptArgument { Name = "Зона", Value = zoneId.ToString() }
            };
        }
    }
}

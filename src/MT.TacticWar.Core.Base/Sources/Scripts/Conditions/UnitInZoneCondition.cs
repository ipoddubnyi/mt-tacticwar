using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    [Script("Юнит в зоне", Code = "unitinzone")]
    public class UnitInZoneCondition : ICondition
    {
        [ScriptArgument("Игрок", typeof(int))]
        private int PlayerId { get; set; }

        [ScriptArgument("Юнит", typeof(int))]
        private int UnitId { get; set; }

        [ScriptArgument("Зона", typeof(int))]
        private int ZoneId { get; set; }

        public UnitInZoneCondition(params string[] args)
        {
            if (3 != args.Length)
                throw new FormatException("Неверный формат условия.");

            PlayerId = int.Parse(args[0]);
            UnitId = int.Parse(args[1]);
            ZoneId = int.Parse(args[2]);
        }

        public bool Check(Mission mission)
        {
            var unit = mission.Players.GetById(PlayerId).GetUnitById(UnitId);
            if (null != unit)
            {
                var position = unit.Division.Position;
                foreach (var zone in mission.Zones)
                {
                    if (zone.In(position))
                        return true;
                }
            }

            return false;
        }
    }
}

using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    [Script("Юнит в зоне", Code = "unitinzone")]
    public class UnitInZoneCondition : ICondition
    {
        [ScriptArgument("Игрок")]
        private int PlayerId { get; set; }

        [ScriptArgument("Юнит")]
        private int UnitId { get; set; }

        [ScriptArgument("Зона")]
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
            if (null == unit)
                return false;

            var zone = mission.Zones.GetById(ZoneId);
            if (null == zone)
                return false;

            return zone.Include(unit.Division.Position);
        }
    }
}

using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    [Script("Количество юнитов в зоне", Code = "unitcountinzone")]
    public class UnitCountInZoneCondition : ICondition
    {
        [ScriptArgument("Игрок")]
        private int PlayerId { get; set; }

        [ScriptArgument("Операция")]
        private Operation Operation { get; set; }

        [ScriptArgument("Количество юнитов")]
        private int UnitCount { get; set; }

        [ScriptArgument("Зона")]
        private int ZoneId { get; set; }

        public UnitCountInZoneCondition(params string[] args)
        {
            if (4 != args.Length)
                throw new FormatException("Неверный формат условия.");

            PlayerId = int.Parse(args[0]);
            Operation = new Operation(args[1]);
            UnitCount = int.Parse(args[2]);
            ZoneId = int.Parse(args[3]);
        }

        public bool Check(Mission mission)
        {
            var zone = mission.Zones.GetById(ZoneId);
            if (null == zone)
                return false;

            int count = 0;
            var player = mission.Players.GetById(PlayerId);
            foreach (var division in player.Divisions)
            {
                if (zone.Include(division.Position))
                    count += division.Units.Count;
            }

            return Operation.Compare(count, UnitCount);
        }
    }
}

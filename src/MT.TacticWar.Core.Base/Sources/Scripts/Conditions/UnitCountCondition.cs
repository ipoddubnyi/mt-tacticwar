﻿using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    [Script("Количество юнитов у игрока", Code = "unitcount")]
    public class UnitCountCondition : ICondition
    {
        [ScriptArgument("Игрок")]
        private int PlayerId { get; set; }

        [ScriptArgument("Операция")]
        private Operation Operation { get; set; }

        [ScriptArgument("Количество юнитов")]
        private int UnitCount { get; set; }

        public UnitCountCondition(params string[] args)
        {
            if (3 != args.Length)
                throw new FormatException("Неверный формат условия.");

            PlayerId = int.Parse(args[0]);
            Operation = new Operation(args[1]);
            UnitCount = int.Parse(args[2]);
        }

        public bool Check(Mission mission)
        {
            int count = 0;
            var player = mission.Players.GetById(PlayerId);
            foreach (var division in player.Divisions)
                count += division.Units.Count;

            return Operation.Compare(count, UnitCount);
        }
    }
}

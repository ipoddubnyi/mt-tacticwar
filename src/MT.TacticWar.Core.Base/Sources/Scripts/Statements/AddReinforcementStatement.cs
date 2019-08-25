using System;
using MT.TacticWar.Core.Scripts;
using MT.TacticWar.Core.Utils;

namespace MT.TacticWar.Core.Base.Scripts
{
    [Script("Дать подкрепление", Code = "addsupport")]
    public class AddReinforcementStatement : IStatement
    {
        [ScriptArgument("Игрок")]
        private int PlayerId { get; set; }

        [ScriptArgument("Подкрепление")]
        private int SupportId { get; set; }

        [ScriptArgument("Ворота")]
        private int GateId { get; set; }

        public AddReinforcementStatement(params string[] args)
        {
            if (3 != args.Length)
                throw new FormatException("Неверный формат выражения.");

            PlayerId = int.Parse(args[0]);
            SupportId = int.Parse(args[1]);
            GateId = int.Parse(args[2]);
        }

        public ISituation Execute(Mission mission)
        {
            var player = mission.Players.GetById(PlayerId);
            if (null == player)
                return null;

            var gate = player.Gates.GetById(GateId);
            if (null == gate)
                return null;

            var division = mission.Reinforcement.GetById(SupportId);
            if (null == division)
                return null;

            new DivisionСopier(division).Copy(player, gate.X, gate.Y);
            return null;
        }
    }
}

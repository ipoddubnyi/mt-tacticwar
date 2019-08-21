using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    [Script("Завершить игру", Code = "gameover")]
    public class GameOverStatement : IStatement
    {
        [ScriptArgument("Победитель", typeof(int))]
        private int WinnerId { get; set; }

        public GameOverStatement(params string[] args)
        {
            if (1 != args.Length)
                throw new FormatException("Неверный формат выражения.");

            WinnerId = int.Parse(args[0]);
        }

        public ISituation Execute(Mission mission)
        {
            var player = mission.Players[WinnerId];
            return new GameOverSituation(player);
        }
    }
}

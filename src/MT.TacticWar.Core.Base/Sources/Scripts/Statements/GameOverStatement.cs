using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    public class GameOverStatement : IStatement
    {
        private readonly int winnerId;

        public GameOverStatement(params string[] args)
        {
            if (1 != args.Length)
                throw new FormatException("Неверный формат выражения.");

            winnerId = int.Parse(args[0]);
        }

        public void Run(Mission mission)
        {
            var player = mission.Players[winnerId];
            mission.AddSituation(new GameOverSituation(player));
        }
    }
}

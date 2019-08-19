using System;
using System.Collections.Generic;
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

        public ISituation Execute(Mission mission)
        {
            var player = mission.Players[winnerId];
            return new GameOverSituation(player);
        }

        public List<ScriptArgument> GetArguments()
        {
            return new List<ScriptArgument>()
            {
                new ScriptArgument { Name = "победитель", Value = winnerId.ToString() }
            };
        }
    }
}

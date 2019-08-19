using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    public class MessageStatement : IStatement
    {
        private readonly string text;

        public MessageStatement(params string[] args)
        {
            if (1 != args.Length)
                throw new FormatException("Неверный формат выражения.");

            text = args[0];
        }

        public ISituation Execute(Mission mission)
        {
            return new MessageSituation(text);
        }

        public List<ScriptArgument> GetArguments()
        {
            return new List<ScriptArgument>()
            {
                new ScriptArgument { Name = "сообщение", Value = text }
            };
        }
    }
}

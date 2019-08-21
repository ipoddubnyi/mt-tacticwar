using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    [Script("Показать сообщение", Code = "message")]
    public class MessageStatement : IStatement
    {
        [ScriptArgument("Сообщение", typeof(string))]
        private string Text { get; set; }

        public MessageStatement(params string[] args)
        {
            if (1 != args.Length)
                throw new FormatException("Неверный формат выражения.");

            Text = args[0];
        }

        public ISituation Execute(Mission mission)
        {
            return new MessageSituation(Text);
        }
    }
}

using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    [Script("Показ сообщения")]
    public class MessageStatement : IStatement
    {
        [ScriptArgument("Сообщение", typeof(int))]
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

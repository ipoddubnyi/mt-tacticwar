using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    public class MessageSituation : ISituation
    {
        public string Text { get; private set; }

        public MessageSituation(string text)
        {
            Text = text;
        }
    }
}

using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    public class GameOverSituation : ISituation
    {
        public Player Winner { get; private set; }

        public GameOverSituation(Player winner)
        {
            Winner = winner;
        }
    }
}

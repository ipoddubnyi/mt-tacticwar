using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    public class Radar : Building
    {
        private const int MaxRadiusActive = 0;
        private const int MaxRadiusView = 4;

        public override string Type => "Радар";

        public Radar(Player player, int id, string name, int x, int y, int health, Division security) :
            base(player, id, name, x, y, health, MaxRadiusActive, MaxRadiusView, security)
        {
        }
    }
}

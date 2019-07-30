using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    public class VillageHut : Building
    {
        private const int MaxRadiusActive = 0;
        private const int MaxRadiusView = 1;

        public override string Type => "Сельский дом";

        public VillageHut(Player player, int id, string name, int x, int y, int health, Division security) :
            base(player, id, name, x, y, health, MaxRadiusActive, MaxRadiusView, security)
        {
        }
    }
}

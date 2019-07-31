using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    public class Ship : Division, IArmored, IAquatic
    {
        public override string Type => "Малый флот";

        public Ship(Player player, int id, string name, int x, int y) :
            base(player, id, name, x, y)
        {
        }
    }
}

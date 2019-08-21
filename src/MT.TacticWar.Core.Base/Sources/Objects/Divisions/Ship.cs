using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    [Division("Малый флот", Code = "ship")]
    public class Ship : Division, IArmored, IAquatic
    {
        public Ship(Player player, int id, string name, int x, int y) :
            base(player, id, name, x, y)
        {
        }
    }
}

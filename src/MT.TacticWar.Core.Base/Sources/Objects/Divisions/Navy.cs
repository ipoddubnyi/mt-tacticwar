using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    [Division("Большой флот")]
    public class Navy : Division, IArmored, IAquatic, ISupport
    {
        public Navy(Player player, int id, string name, int x, int y) :
            base(player, id, name, x, y)
        {
        }
    }
}

using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    [Division("Инженерные войска")]
    public class Engineers : Division, IArmored
    {
        public Engineers(Player player, int id, string name, int x, int y) :
            base(player, id, name, x, y)
        {
        }

        public override bool CanStop(Cell cell)
        {
            return true;
        }
    }
}

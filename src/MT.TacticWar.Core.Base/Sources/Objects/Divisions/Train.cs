using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    [Division("Бронепоезд", Code = "train")]
    public class Train : Division, IArmored, ISupport
    {
        public Train(Player player, int id, string name, int x, int y) :
            base(player, id, name, x, y)
        {
        }

        public override bool CanStep(Cell cell)
        {
            return cell is IRails;
        }
    }
}

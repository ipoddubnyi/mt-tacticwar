using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    public class Navy : Division, IArmored, IAquatic, ISupport
    {
        public override string Type => "Большой флот";

        public Navy(Player player, int id, string name, int x, int y) :
            base(player, id, name, x, y)
        {
        }
    }
}

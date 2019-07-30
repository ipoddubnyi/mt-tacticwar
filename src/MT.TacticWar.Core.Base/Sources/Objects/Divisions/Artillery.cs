using System.Collections.Generic;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    public class Artillery : Division, IArmored, ISupport
    {
        public override string Type => "Артиллерия";

        public Artillery(Player player, int id, string name, int x, int y) :
            base(player, id, name, x, y)
        {
        }
    }
}

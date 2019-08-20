using System.Collections.Generic;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    [Division("Артиллерия")]
    public class Artillery : Division, IArmored, ISupport
    {
        public Artillery(Player player, int id, string name, int x, int y) :
            base(player, id, name, x, y)
        {
        }
    }
}

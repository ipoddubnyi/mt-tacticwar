using System.Collections.Generic;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    public class Vehicle : Division, IArmored
    {
        public override string Type => "Бронетехника";

        public Vehicle(Player player, int id, string name, int x, int y) :
            base(player, id, name, x, y)
        {
        }
    }
}

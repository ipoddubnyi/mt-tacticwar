using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    [Division("Бронетехника", Code = "vehicle")]
    public class Vehicle : Division, IArmored
    {
        public Vehicle(Player player, int id, string name, int x, int y) :
            base(player, id, name, x, y)
        {
        }
    }
}

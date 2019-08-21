using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    [Division("Пехота", Code = "infantry")]
    public class Infantry : Division, IInfantry
    {
        public Infantry(Player player, int id, string name, int x, int y) :
            base(player, id, name, x, y)
        {
        }
    }
}

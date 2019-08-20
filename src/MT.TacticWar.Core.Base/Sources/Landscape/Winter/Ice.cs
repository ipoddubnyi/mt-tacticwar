using MT.TacticWar.Core.Base.Landscape.Schemas;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape.Winter
{
    [Cell("Лёд", typeof(WinterSchema))]
    public class Ice : Cell, ILand
    {
        // по льду надо передвигаться аккуратно
        public const int DefaultPassCost = 4;

        public Ice(int x, int y) :
            base(x, y, DefaultPassCost)
        {
        }
    }
}

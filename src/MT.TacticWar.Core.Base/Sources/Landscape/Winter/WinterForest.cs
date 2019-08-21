using MT.TacticWar.Core.Base.Landscape.Schemas;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape.Winter
{
    [Cell("Зимний лес", typeof(WinterSchema), Code = '*')]
    public class WinterForest : Cell, ILand, IForest
    {
        public const int DefaultPassCost = 4;

        public WinterForest(int x, int y) :
            base(x, y, DefaultPassCost)
        {
        }
    }
}

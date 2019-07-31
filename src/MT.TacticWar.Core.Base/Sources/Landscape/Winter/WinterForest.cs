using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape.Winter
{
    public class WinterForest : Cell, ILand, IForest
    {
        public const int DefaultPassCost = 4;

        public WinterForest(int x, int y) :
            base(x, y, DefaultPassCost)
        {
        }
    }
}

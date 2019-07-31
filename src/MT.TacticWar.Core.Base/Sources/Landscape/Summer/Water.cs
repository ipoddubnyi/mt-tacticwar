using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape.Summer
{
    public class Water : Cell, IWater
    {
        public const int DefaultPassCost = 3;

        public Water(int x, int y) :
            base(x, y, DefaultPassCost)
        {
        }
    }
}

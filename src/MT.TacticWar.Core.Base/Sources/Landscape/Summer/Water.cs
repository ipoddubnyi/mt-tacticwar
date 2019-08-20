using MT.TacticWar.Core.Base.Landscape.Schemas;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape.Summer
{
    [Cell("Вода", typeof(SummerSchema))]
    public class Water : Cell, IWater
    {
        public const int DefaultPassCost = 3;

        public Water(int x, int y) :
            base(x, y, DefaultPassCost)
        {
        }
    }
}

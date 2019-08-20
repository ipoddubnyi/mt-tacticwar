using MT.TacticWar.Core.Base.Landscape.Schemas;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape.Summer
{
    [Cell("Мост", typeof(SummerSchema))]
    public class Bridge : Cell, ILand, IWater
    {
        public const int DefaultPassCost = 2;

        public Bridge(int x, int y) :
            base(x, y, DefaultPassCost)
        {
        }
    }
}

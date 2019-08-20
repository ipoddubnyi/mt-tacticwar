using MT.TacticWar.Core.Base.Landscape.Schemas;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape.Winter
{
    [Cell("Холодная вода", typeof(WinterSchema))]
    public class ColdWater : Cell, IWater
    {
        public const int DefaultPassCost = 3;

        public ColdWater(int x, int y) :
            base(x, y, DefaultPassCost)
        {
        }
    }
}

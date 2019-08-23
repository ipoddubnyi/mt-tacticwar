using MT.TacticWar.Core.Base.Landscape.Schemas;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape.Summer
{
    [Cell("Мост ж/д", typeof(SummerSchema), Code = 'Ж')]
    public class RailwayBridge : Cell, ILand, IRails, IWater
    {
        public const int DefaultPassCost = 3;

        public RailwayBridge(int x, int y) :
            base(x, y, DefaultPassCost)
        {
        }
    }
}

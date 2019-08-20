using MT.TacticWar.Core.Base.Landscape.Schemas;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape.Summer
{
    [Cell("Песок", typeof(SummerSchema))]
    public class Sand : Cell, ILand
    {
        public const int DefaultPassCost = 3;

        public Sand(int x, int y) :
            base(x, y, DefaultPassCost)
        {
        }
    }
}

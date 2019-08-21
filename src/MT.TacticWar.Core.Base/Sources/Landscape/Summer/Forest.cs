using MT.TacticWar.Core.Base.Landscape.Schemas;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape.Summer
{
    [Cell("Лес", typeof(SummerSchema), Code = '*')]
    public class Forest : Cell, ILand, IForest
    {
        public const int DefaultPassCost = 4;

        public Forest(int x, int y) :
            base(x, y, DefaultPassCost)
        {
        }
    }
}

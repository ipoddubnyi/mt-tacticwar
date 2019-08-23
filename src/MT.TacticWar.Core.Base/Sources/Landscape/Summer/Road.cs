using MT.TacticWar.Core.Base.Landscape.Schemas;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape.Summer
{
    [Cell("Дорога", typeof(SummerSchema), Code = '+')]
    public class Road : Cell, ILand
    {
        public const int DefaultPassCost = 1;

        public Road(int x, int y) :
            base(x, y, DefaultPassCost)
        {
        }
    }
}

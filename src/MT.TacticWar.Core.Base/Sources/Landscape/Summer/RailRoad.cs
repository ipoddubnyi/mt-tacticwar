using MT.TacticWar.Core.Base.Landscape.Schemas;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape.Summer
{
    [Cell("Ж/д", typeof(SummerSchema), Code = '#')]
    public class Railroad : Cell, ILand, IRails
    {
        public const int DefaultPassCost = 2;

        public Railroad(int x, int y) :
            base(x, y, DefaultPassCost)
        {
        }
    }
}

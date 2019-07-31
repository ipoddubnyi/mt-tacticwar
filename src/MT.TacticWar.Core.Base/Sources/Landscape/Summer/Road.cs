using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape.Summer
{
    public class Road : Cell, ILand
    {
        public const int DefaultPassCost = 1;

        public Road(int x, int y) :
            base(x, y, DefaultPassCost)
        {
        }
    }
}

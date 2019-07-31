using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape.Summer
{
    public class Stones : Cell, ILand
    {
        public const int DefaultPassCost = 4;

        public Stones(int x, int y) :
            base(x, y, DefaultPassCost)
        {
        }
    }
}

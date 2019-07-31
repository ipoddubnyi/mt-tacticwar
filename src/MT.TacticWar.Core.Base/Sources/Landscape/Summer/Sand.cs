using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape.Summer
{
    public class Sand : Cell, ILand
    {
        public const int DefaultPassCost = 3;

        public Sand(int x, int y) :
            base(x, y, DefaultPassCost)
        {
        }
    }
}

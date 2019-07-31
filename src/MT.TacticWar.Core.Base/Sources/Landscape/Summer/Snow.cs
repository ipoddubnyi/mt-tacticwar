using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape.Summer
{
    public class Snow : Cell, ILand
    {
        public const int DefaultPassCost = 3;

        public Snow(int x, int y) :
            base(x, y, DefaultPassCost)
        {
        }
    }
}

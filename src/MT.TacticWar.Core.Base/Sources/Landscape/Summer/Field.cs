using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape.Summer
{
    public class Field : Cell, ILand
    {
        public const int DefaultPassCost = 2;

        public Field(int x, int y) :
            base(x, y, DefaultPassCost)
        {
        }
    }
}

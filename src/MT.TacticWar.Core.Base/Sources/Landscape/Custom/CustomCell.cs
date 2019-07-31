using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape.Summer
{
    public class CustomCell : Cell, ILand
    {
        public CustomCell(int x, int y) :
            base(x, y, 2)
        {
        }
    }
}

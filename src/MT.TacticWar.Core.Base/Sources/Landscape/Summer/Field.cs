using MT.TacticWar.Core.Base.Landscape.Schemas;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape.Summer
{
    [Cell("Поле", typeof(SummerSchema))]
    public class Field : Cell, ILand
    {
        public const int DefaultPassCost = 2;

        public Field(int x, int y) :
            base(x, y, DefaultPassCost)
        {
        }
    }
}

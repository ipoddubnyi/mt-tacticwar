using System.Collections.Generic;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    public class Ship : Division, IArmored, IAquatic
    {
        public override string Type => "Флот";

        public Ship(Player player, int id, string name, int x, int y) :
            base(player, id, name, x, y)
        {
        }

        //public override bool CanStep(Cell cell)
        //{
        //    return CellType.Water == cell.Type;
        //}
    }
}

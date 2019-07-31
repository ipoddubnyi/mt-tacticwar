using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Gameplay.Routers
{
    internal class BellmanCell
    {
        public Division Division { get; private set; }
        public Cell Base { get; private set; }
        public bool Passable => Base.Passable;
        public bool Occupied => Base.Occupied;
        public int PassCost => Division.GetStepCost(Base); //Base.PassCost;

        public BellmanDirections Directions { get; set; }
        public int Cost { get; set; }

        public BellmanCell(Cell cell, Division div)
        {
            Division = div;
            Base = cell;
            Directions = new BellmanDirections();
            Cost = int.MaxValue;
        }
    }
}

using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Gameplay.Routers
{
    internal class BellmanCell
    {
        public Cell Base { get; private set; }
        public CellType Type => Base.Type;
        public bool Passable => Base.Passable;
        public bool Occupied => Base.Occupied;
        public int PassCost => Base.PassCost;

        public BellmanDirections Directions { get; set; }
        public int Cost { get; set; }

        public BellmanCell(Cell cell)
        {
            Base = cell;
            Directions = new BellmanDirections();
            Cost = int.MaxValue;
        }
    }
}

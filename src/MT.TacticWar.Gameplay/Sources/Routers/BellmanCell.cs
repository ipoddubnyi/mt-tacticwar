using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Gameplay.Routers
{
    internal class BellmanCell
    {
        private Cell cell;
        public CellType Type => cell.Type;
        public bool Passable => cell.Passable;
        public bool Occupied => cell.Occupied;
        public int PassCost => cell.PassCost;

        public BellmanDirections Directions { get; set; }
        public int Cost { get; set; }

        public BellmanCell(Cell cell)
        {
            this.cell = cell;
            Directions = new BellmanDirections();
            Cost = int.MaxValue;
        }
    }
}

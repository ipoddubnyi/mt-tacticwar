using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Landscape
{
    public abstract class Cell
    {
        public Coordinates Coordinates { get; protected set; }

        /// <summary>Проходима ли ячейка</summary>
        public bool Passable { get; set; }

        /// <summary>Величина проходимости</summary>
        public int PassCost { get; set; }

        /// <summary>Ссылка на объект, который находится в ячейке</summary>
        public IObject Object { get; set; }

        /// <summary>Есть ли объект в ячейке</summary>
        public bool Occupied => (null != Object);

        public Cell(int x, int y, int passcost = 4)
        {
            Coordinates = new Coordinates(x, y);
            Passable = true;
            PassCost = passcost;
            Object = null;
        }
    }
}

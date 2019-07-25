using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Landscape
{
    public class Cell
    {
        public Coordinates Coordinates { get; set; }

        public CellType Type { get; set; }

        public MapSchema Schema { get; set; }

        /// <summary>Проходима ли ячейка</summary>
        public bool Passable;

        /// <summary>Величина проходимости</summary>
        public int PassCost;

        /// <summary>Ссылка на объект, который находится в ячейке</summary>
        public IObject Object { get; set; }

        /// <summary>Есть ли объект в ячейке</summary>
        public bool Occupied => (null != Object);

        public Cell(int x, int y, CellType type) :
            this(x, y, MapSchema.Summer, type)
        {
        }

        public Cell(int x, int y, MapSchema schema = MapSchema.Summer, CellType type = CellType.Grass)
        {
            Coordinates = new Coordinates(x, y);
            Type = type;
            Schema = schema;
            Passable = true; //по умолчанию, ячейка проходима // proh;
            //if (proh) PassableCost = prohCost;
            //else PassableCost = int.MaxValue;
            PassCost = GetPassCost(Type); //по умолчанию, цена прохода = проходу по траве
            Object = null;
        }

        /// <summary>Получить цену прохода по ячейке.</summary>
        public static int GetPassCost(CellType type, MapSchema schema = MapSchema.Summer)
        {
            int cost;

            switch (type)
            {
                case CellType.Snow:
                    cost = 3; //по снегу трудно двигаться
                    break;
                case CellType.Sand:
                    cost = 3; //по песку трудно двигаться
                    break;
                case CellType.Water:
                    cost = 2; //по воде долго плыть
                    break;
                case CellType.Stones:
                    cost = 3; //по камням трудно двигаться
                    break;
                case CellType.Forest:
                    cost = 4; //по лесу трудно двигаться
                    break;
                case CellType.Road:
                    cost = 1; //по дороге лучше всего ходить
                    break;
                case CellType.Buildings:
                    cost = 3; //мимо зданий трудно двигаться
                    break;
                case CellType.Ice:
                    cost = 4; //по льду трудно двигаться
                    break;
                case CellType.Grass:
                default:
                    cost = 2; //по траве ехать нормально
                    break;
            }

            // зимой передвижение хуже
            if (MapSchema.Winter == schema)
                cost += 1;

            return cost;
        }
    }
}

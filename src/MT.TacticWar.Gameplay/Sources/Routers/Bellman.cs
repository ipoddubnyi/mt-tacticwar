using System.Collections.Generic;
using System.Diagnostics;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Gameplay.Routers
{
    public class Bellman
    {
        private static List<Cell> NotFound = new List<Cell>();

        private Map map;
        private Fog fog;
        private BellmanCell[,] cells;
        private Division div;

        private Coordinates from;
        private Coordinates to;

        public Bellman(Map map, Fog fog)
        {
            this.map = map;
            this.fog = fog;
            cells = new BellmanCell[map.Width, map.Height];
        }

        /// <summary>[ГЛАВНАЯ] Поиск кратчайшего пути методом Беллмана</summary>
        /// <param name="div">подразделение, для которого ищем путь</param>
        /// <param name="flag">координаты флага (до куда ищем путь)</param>
        public List<Cell> FindPath(Division div, Coordinates flag)
        {
            // инициализация
            Initialize(div, flag);

            // если ячейка не проходима
            if (!cells[flag.X, flag.Y].Passable)
                return NotFound;

            // если юнит не может пройти по ячейке
            if (!div.CanStop(cells[flag.X, flag.Y].Base))
                return NotFound;

            //стартуем с флага
            LetsStep(flag.X, flag.Y);

            //выбор пути, если он найден
            return ChooseTheWay();
        }

        /// <summary>Инициализация переменных перед поиском кратчайшего пути</summary>
        /// <param name="div">юнит, для которого ищем путь</param>
        /// <param name="flag">координаты флага (до куда вести поиск)</param>
        private void Initialize(Division div, Coordinates flag)
        {
            this.div = div;

            from = div.Position.Copy();
            to = flag.Copy();

            for (int i = 0; i < map.Height; i++)
            {
                for (int j = 0; j < map.Width; j++)
                {
                    var cell = new BellmanCell(map.Field[i, j], div);

                    //обнуляем цену у флага
                    if (IsTargetHere(i, j))
                        cell.Cost = 0;

                    cells[i, j] = cell;
                }
            }
        }

        private bool CanStep(int x, int y)
        {
            //если координаты за пределами поля
            if (x < 0 || x >= map.Width)
                return false;

            if (y < 0 || y >= map.Height)
                return false;

            var cell = cells[x, y];

            //если ячейка (НЕ проходима) ИЛИ (занята И видна)
            if (!cell.Passable || (cell.Occupied && !fog[x, y]))
            {
                //если координаты не совпадают с координатами юнита
                if (!from.Equals(x, y))
                    return false;
            }

            // если юнит не может пройти по ячейке
            if (!div.CanStep(cell.Base))
                return false;

            return true;
        }

        /// <summary>Есть ли смысл идти в эту ячейку?</summary>
        private bool IsBenefitToStepTo(BellmanCell cell)
        {
            //если в эту ячейку попасть дороже, чем вообще в целом до флага,
            //  то эту ячейку можно и не рассматривать
            return cell.Cost <= cells[div.Position.X, div.Position.Y].Cost;
        }

        /// <summary>Достигли ли цели</summary>
        private bool IsTargetHere(int x, int y)
        {
            return to.Equals(x, y);
        }

        /// <summary>Рекурсивная функция, выполняющая шаги</summary>
        private void LetsStep(int x, int y)
        {
            var cell = cells[x, y];

            //-------------------- влево --------------------

            int dx = x - 1;

            //если сверху ещё НЕ были И там НЕТ флага, И туда можно идти
            if (!cell.Directions.Left && CanStep(dx, y) && !IsTargetHere(dx, y))
            {
                var cellLeft = cells[dx, y];

                //помечаем контакт с верхней клеткой
                cell.Directions.Left = true;
                //cellLeft.Directions.Right = true;

                //определяем цену этого контакта
                //если цена в ячейке больше,
                //  чем проход по ней + проход по предыдущим ячейкам,
                //  то заменяем цену (на более выгодную - меньшую)
                //иначе вообще не трогаем это направление
                if (cellLeft.Cost > (cellLeft.PassCost + cell.Cost))
                {
                    //заменяем цену
                    cellLeft.Cost = cellLeft.PassCost + cell.Cost;

                    cellLeft.Directions.NullDirections();
                    cellLeft.Directions.Right = true;

                    //если есть смысл шагать дальше
                    if (IsBenefitToStepTo(cellLeft))
                    {
                        //меняем приоритетное направление верхней ячейки на правое
                        cellLeft.Directions.Priority = Direction.Right;

                        //переходим к рассмотрению клетки сверху
                        LetsStep(dx, y);
                    }
                }
            }

            //-------------------- верх --------------------

            int dy = y - 1;

            //если слева ещё НЕ были И там НЕТ флага, И туда можно идти
            if (!cell.Directions.Top && CanStep(x, dy) && !IsTargetHere(x, dy))
            {
                var cellTop = cells[x, dy];

                //помечаем контакт с левой клеткой
                cell.Directions.Top = true;
                //cellTop.Directions.Bottom = true;

                //определяем цену этого контакта
                //если цена в ячейке больше,
                //  чем проход по ней + проход по предыдущим ячейкам,
                //  то заменяем цену (на более выгодную - меньшую)
                //иначе вообще не трогаем это направление
                if (cellTop.Cost > (cellTop.PassCost + cell.Cost))
                {
                    //заменяем цену
                    cellTop.Cost = cellTop.PassCost + cell.Cost;

                    cellTop.Directions.NullDirections();
                    cellTop.Directions.Bottom = true;

                    //если есть смысл шагать дальше
                    if (IsBenefitToStepTo(cellTop))
                    {
                        //меняем приоритетное направление левой ячейки на нижнее
                        cellTop.Directions.Priority = Direction.Bottom;

                        //переходим к рассмотрению клетки слева
                        LetsStep(x, dy);
                    }
                }
            }

            //-------------------- вправо --------------------

            dx = x + 1;

            //если снизу ещё НЕ были И там НЕТ флага, И туда можно идти
            if (!cell.Directions.Right && CanStep(dx, y) && !IsTargetHere(dx, y))
            {
                var cellRight = cells[dx, y];

                //помечаем контакт с нижней клеткой
                cell.Directions.Right = true;
                //cellRight.Directions.Left = true;

                //определяем цену этого контакта
                //если цена в ячейке больше,
                //  чем проход по ней + проход по предыдущим ячейкам,
                //  то заменяем цену (на более выгодную - меньшую)
                //иначе вообще не трогаем это направление
                if (cellRight.Cost > (cellRight.PassCost + cell.Cost))
                {
                    //заменяем цену
                    cellRight.Cost = cellRight.PassCost + cell.Cost;

                    cellRight.Directions.NullDirections();
                    cellRight.Directions.Left = true;

                    //если есть смысл шагать дальше
                    if (IsBenefitToStepTo(cellRight))
                    {
                        //меняем приоритетное направление нижней ячейки на левое
                        cellRight.Directions.Priority = Direction.Left;

                        //переходим к рассмотрению клетки снизу
                        LetsStep(dx, y);
                    }
                }
            }

            //-------------------- вниз --------------------

            dy = y + 1;

            //если справа ещё НЕ были И там НЕТ флага, И туда можно идти
            if (!cell.Directions.Bottom && CanStep(x, dy) && !IsTargetHere(x, dy))
            {
                var cellBottom = cells[x, dy];

                //помечаем контакт с правой клеткой
                cell.Directions.Bottom = true;
                //cellBottom.Directions.Top = true;

                //определяем цену этого контакта
                //если цена в ячейке больше,
                //  чем проход по ней + проход по предыдущим ячейкам,
                //  то заменяем цену (на более выгодную - меньшую)
                //иначе вообще не трогаем это направление
                if (cellBottom.Cost > (cellBottom.PassCost + cell.Cost))
                {
                    //заменяем цену
                    cellBottom.Cost = cellBottom.PassCost + cell.Cost;

                    cellBottom.Directions.NullDirections();
                    cellBottom.Directions.Top = true;

                    //если есть смысл шагать дальше
                    if (IsBenefitToStepTo(cellBottom))
                    {
                        //меняем приоритетное направление правой ячейки на верхнее
                        cellBottom.Directions.Priority = Direction.Top;

                        //переходим к рассмотрению клетки справа
                        LetsStep(x, dy);
                    }
                }
            }
        }

        /// <summary>Выбор пути, если он есть (сохранение координат в список)</summary>
        private List<Cell> ChooseTheWay()
        {
            var bestWay = new List<Cell>();
            int maxCost = map.Height * map.Width;

            // текущие координаты
            int x = from.X;
            int y = from.Y;

            //если цена в ячейке юнита = maxCost, значит, путь не найден
            if (cells[x, y].Cost >= maxCost)
                return NotFound;

            //счётчик для того, чтобы не было зацикливания
            int counter = 0;

            //сохраняем первую координату - положение юнита
            bestWay.Add(map.Field[x, y]);

            //пока не наткнёмся на флаг
            while (!IsTargetHere(x, y))
            {
                //перебираем приоритетные направления
                switch (cells[x, y].Directions.Priority)
                {
                    case Direction.Left:
                        x -= 1;
                        break;
                    case Direction.Top:
                        y -= 1;
                        break;
                    case Direction.Right:
                        x += 1;
                        break;
                    case Direction.Bottom:
                        y += 1;
                        break;
                    default: //иначе - путь не найден
                        return NotFound;
                        //break;
                }

                //сохраняем следующую координату
                bestWay.Add(map.Field[x, y]);

                //если счётчик итераций больше возможного числа ходов, то пути нет
                if (++counter > maxCost) return NotFound;
            }

            return bestWay;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core
{
    // Структура параметров при поиске кратчайшего пути
    public struct BellmanParam
    {
        public Coordinates From;    // откуда идём
        public Coordinates To;      // куда идём
        public List<Cell> BestWay;  // путь - массив координат
        public int Cost;            // цена всего пути
    }

    public class CellWrp
    {
        private Cell cell;
        public CellType Type => cell.Type;
        public bool Passable => cell.Passable;
        public bool Occupied => cell.Occupied;
        public int PassCost => cell.PassCost;

        public Directions Directions { get; set; }
        public int Cost { get; set; }

        public CellWrp(Cell cell)
        {
            this.cell = cell;
            Directions = new Directions();
            Cost = int.MaxValue;
        }
    }

    public class Bellman
    {
        private Map map;
        private CellWrp[,] cells;
        private Division div;
        public BellmanParam WayParams; //параметры кратчайшего пути

        public Bellman(Map map)
        {
            this.map = map;
            cells = new CellWrp[map.Width, map.Height];
            WayParams.BestWay = new List<Cell>();
        }

        /// <summary>[ГЛАВНАЯ] Поиск кратчайшего пути методом Беллмана
        /// </summary>
        /// <param name="div">подразделение, для которого ищем путь</param>
        /// <param name="flag">координаты флага (до куда ищем путь)</param>
        /// <returns>Возвращает, найден путь или нет</returns>
        public bool BellmanPoiskPuti(Division div, Coordinates flag)
        {
            // инициализация
            BellmanInitPoiskPuti(div, flag);

            // если ячейка не проходима
            if (!cells[flag.X, flag.Y].Passable)
                return false;

            // если юнит не может пройти по ячейке
            if (!div.CanStep(cells[flag.X, flag.Y].Type))
                return false;

            //стартуем с флага
            BellmanLetsStep(flag.X, flag.Y);

            //выбор пути, если он найден
            return BellmanVyborPuti();
        }

        /// <summary>Инициализация переменных перед поиском кратчайшего пути
        /// </summary>
        /// <param name="div">юнит, для которого ищем путь</param>
        /// <param name="flag">координаты флага (до куда вести поиск)</param>
        /// <returns></returns>
        private void BellmanInitPoiskPuti(Division div, Coordinates flag)
        {
            this.div = div;

            //запомнить координаты начала и конца поиска
            WayParams.From = div.Coordinates.Clone();
            WayParams.To = flag.Clone();

            //инициализируем остальные параметры
            WayParams.Cost = int.MaxValue;
            WayParams.BestWay = new List<Cell>();
            WayParams.BestWay.Clear();

            for (int i = 0; i < map.Height; i++)
            {
                for (int j = 0; j < map.Width; j++)
                {
                    var cell = new CellWrp(map.Field[i, j]);

                    //обнуляем цену у флага
                    if (BellmanIsFlagHere(i, j))
                        cell.Cost = 0;

                    cells[i, j] = cell;
                }
            }
        }

        /// <summary>Обнуление направлений
        /// </summary>
        /// <returns></returns>
        private void BellmanNapravlNulling()
        {
            for (int i = 0; i < map.Height; i++)
            {
                for (int j = 0; j < map.Width; j++)
                {
                    cells[i, j].Directions.NullDirections();
                }
            }
        }

        private bool BellmanCanStep(int i, int j)
        {
            //если координаты за пределами поля
            if (i < 0 || i >= map.Width)
                return false;

            if (j < 0 || j >= map.Height)
                return false;

            var cell = cells[i, j];

            //если ячейка НЕ проходима ИЛИ занята
            if (!cell.Passable || cell.Occupied)
            {
                //если координаты не совпадают с координатами юнита
                if (WayParams.From.X != i || WayParams.From.Y != j)
                    return false;
            }

            // если юнит не может пройти по ячейке
            if (!div.CanStep(cell.Type))
                return false;

            return true;
        }

        // Есть ли смысл идти в эту ячейку?
        private bool BellmanIsSmyslToStep(CellWrp cell)
        {
            //если в эту ячейку попасть дороже, чем вообще в целом до флага,
            //  то эту ячейку можно и не рассматривать
            return cell.Cost <= cells[div.Coordinates.X, div.Coordinates.Y].Cost;
        }

        // Проверка, есть ли флаг в этой клетке
        private bool BellmanIsFlagHere(int x, int y)
        {
            return WayParams.To.Equals(x, y);
        }

        // Рекурсивная функция, выполняющая шаги
        private void BellmanLetsStep(int x, int y)
        {
            var cell = cells[x, y];

            //-------------------- лево --------------------

            int dy = y - 1;

            //если слева ещё НЕ были И там НЕТ флага, И туда можно идти
            if (!cell.Directions.Left && !BellmanIsFlagHere(x, dy) && BellmanCanStep(x, dy))
            {
                var cellLeft = cells[x, dy];

                //помечаем контакт с левой клеткой
                cell.Directions.Left = true;
                cellLeft.Directions.Right = true;

                //определяем цену этого контакта
                //если цена в ячейке больше,
                //  чем проход по ней + проход по предыдущим ячейкам,
                //  то заменяем цену (на более выгодную - меньшую)
                //иначе вообще не трогаем это направление
                if (cellLeft.Cost > (cellLeft.PassCost + cell.Cost))
                {
                    //заменяем цену
                    cellLeft.Cost = cellLeft.PassCost + cell.Cost;

                    //если есть смысл шагать дальше
                    if (BellmanIsSmyslToStep(cellLeft))
                    {
                        //меняем приоритетное направление левой ячейки на правое
                        cellLeft.Directions.Priority = 3;

                        //переходим к рассмотрению клетки слева
                        BellmanLetsStep(x, dy);
                    }
                }
            }

            //-------------------- верх --------------------

            int dx = x - 1;

            //если сверху ещё НЕ были И там НЕТ флага, И туда можно идти
            if (!cell.Directions.Top && !BellmanIsFlagHere(dx, y) && BellmanCanStep(dx, y))
            {
                var cellTop = cells[dx, y];

                //помечаем контакт с верхней клеткой
                cell.Directions.Top = true;
                cellTop.Directions.Bottom = true;

                //определяем цену этого контакта
                //если цена в ячейке больше,
                //  чем проход по ней + проход по предыдущим ячейкам,
                //  то заменяем цену (на более выгодную - меньшую)
                //иначе вообще не трогаем это направление
                if (cellTop.Cost > (cellTop.PassCost + cell.Cost))
                {
                    //заменяем цену
                    cellTop.Cost = cellTop.PassCost + cell.Cost;

                    //если есть смысл шагать дальше
                    if (BellmanIsSmyslToStep(cellTop))
                    {
                        //меняем приоритетное направление верхней ячейки на нижнее
                        cellTop.Directions.Priority = 4;

                        //переходим к рассмотрению клетки сверху
                        BellmanLetsStep(dx, y);
                    }
                }
            }

            //-------------------- право --------------------

            dy = y + 1;

            //если справа ещё НЕ были И там НЕТ флага, И туда можно идти
            if (!cell.Directions.Right && !BellmanIsFlagHere(x, dy) && BellmanCanStep(x, dy))
            {
                var cellRight = cells[x, dy];

                //помечаем контакт с правой клеткой
                cell.Directions.Right = true;
                cellRight.Directions.Left = true;

                //определяем цену этого контакта
                //если цена в ячейке больше,
                //  чем проход по ней + проход по предыдущим ячейкам,
                //  то заменяем цену (на более выгодную - меньшую)
                //иначе вообще не трогаем это направление
                if (cellRight.Cost > (cellRight.PassCost + cell.Cost))
                {
                    //заменяем цену
                    cellRight.Cost = cellRight.PassCost + cell.Cost;

                    //если есть смысл шагать дальше
                    if (BellmanIsSmyslToStep(cellRight))
                    {
                        //меняем приоритетное направление правой ячейки на левое
                        cellRight.Directions.Priority = 1;

                        //переходим к рассмотрению клетки справа
                        BellmanLetsStep(x, dy);
                    }
                }
            }

            //-------------------- низ --------------------

            dx = x + 1;

            //если снизу ещё НЕ были И там НЕТ флага, И туда можно идти
            if (!cell.Directions.Bottom && !BellmanIsFlagHere(dx, y) && BellmanCanStep(dx, y))
            {
                var cellBottom = cells[dx, y];

                //помечаем контакт с нижней клеткой
                cell.Directions.Bottom = true;
                cellBottom.Directions.Top = true;

                //определяем цену этого контакта
                //если цена в ячейке больше,
                //  чем проход по ней + проход по предыдущим ячейкам,
                //  то заменяем цену (на более выгодную - меньшую)
                //иначе вообще не трогаем это направление
                if (cellBottom.Cost > (cellBottom.PassCost + cell.Cost))
                {
                    //заменяем цену
                    cellBottom.Cost = cellBottom.PassCost + cell.Cost;

                    //если есть смысл шагать дальше
                    if (BellmanIsSmyslToStep(cellBottom))
                    {
                        //меняем приоритетное направление нижней ячейки на верхнее
                        cellBottom.Directions.Priority = 2;

                        //переходим к рассмотрению клетки снизу
                        BellmanLetsStep(dx, y);
                    }
                }
            }

            //---------------------------------------------

            BellmanNapravlNulling(); //обнуляем направления
        }

        /// <summary>Выбор пути, если он есть (сохранение координат в список)
        /// </summary>
        /// <returns>Возвращает, есть ли путь</returns>
        private bool BellmanVyborPuti()
        {
            int maxCost = map.Height * map.Width;

            //текущие координаты
            var curCoords = WayParams.From.Clone();

            //если цена в ячейке юнита = (int.MaxValue), значит, путь не найден
            if (cells[curCoords.X, curCoords.Y].Cost >= maxCost)
                return false;

            //запоминаем цену всего пути
            WayParams.Cost = cells[curCoords.X, curCoords.Y].Cost;

            //счётчик для того, чтобы не было зацикливания
            int counter = 0;

            //сохраняем первую координату - положение юнита
            WayParams.BestWay.Add(map.Field[curCoords.X, curCoords.Y]);

            //пока не наткнёмся на флаг
            while (!BellmanIsFlagHere(curCoords.X, curCoords.Y))
            {
                //перебираем приоритетные направления
                switch (cells[curCoords.X, curCoords.Y].Directions.Priority)
                {
                    case 1: //левое
                        curCoords.Y -= 1;
                        break;
                    case 2: //верхнее
                        curCoords.X -= 1;
                        break;
                    case 3: //правое
                        curCoords.Y += 1;
                        break;
                    case 4: //нижнее
                        curCoords.X += 1;
                        break;
                    default: //иначе - путь не найден
                        return false;
                        //break;
                }

                //сохраняем следующую координату
                WayParams.BestWay.Add(map.Field[curCoords.X, curCoords.Y]);

                //если счётчик итераций больше возможного числа ходов, то пути нет
                if (++counter > maxCost) return false;
            }

            return true;
        }
    }
}

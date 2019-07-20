using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MT.TacticWar.Core.Landscape
{
    //Поле - ячейка зоны боевых действий
    public class Cell
    {
        public Coordinates mCoords;     //координаты ячейки

        public CellType mZemType;       //тип земли ячейки

        public bool mProhodima;         //проходима ли ячейка
        public int mProhodCost;         //величина проходимости

        public bool mZanyata;           //занята ли ячейка
        //???                           //ссылка на юнит, который стоит на ячейке

        public int mCost;               //общая цена прохода по рассмотренным ячейкам
        public Directions mNapravl;   //направления из ячейки

        //********************************************************************************

        /// <summary>Конструктор
        /// </summary>
        /// <param name="x">координата x (строка)</param>
        /// <param name="y">координата y (столбец)</param>
        /// <returns></returns>
        public Cell(int x, int y)
        {
            Init(x, y);
        }

        /// <summary>Инициализация (для конструкторов)
        /// </summary>
        /// <param name="x">координата x (строка)</param>
        /// <param name="y">координата y (столбец)</param>
        /// <returns></returns>
        private void Init(int x, int y)
        {
            mCoords.x = x;
            mCoords.y = y;

            mProhodima = true; //по умолчанию, ячейка проходима // proh;

            //if (proh) mProhodCost = prohCost;
            //else mProhodCost = int.MaxValue;
            mProhodCost = 2; //по умолчанию, цена прохода = проходу по траве
            mZemType = CellType.Grass;

            mZanyata = false; //по умолчанию все ячейки свободны
            //ссылка на юнит = нул

            mCost = 0; //изначально общая цена прохода = 0

            //все направления пока свободны
            mNapravl.m1_levo = mNapravl.m2_verh = false;
            mNapravl.m3_pravo = mNapravl.m4_niz = false;
            mNapravl.prioritet = 0;
        }

        /// <summary>Конструктор
        /// </summary>
        /// <param name="x">координата x (строка)</param>
        /// <param name="y">координата y (столбец)</param>
        /// <param name="type">тип земли</param>
        /// <returns></returns>
        public Cell(int x, int y, int type)
        {
            Init(x, y);

            mZemType = (CellType)type;
            countProhodCost();
        }

        //********************************************************************************

        /// <summary>Оценить цену прохода по ячейке
        /// </summary>
        /// <returns></returns>
        public void countProhodCost()
        {
            //в зависимости от типа земли
            switch (mZemType)
            {
                case CellType.Snow:
                    mProhodCost = 3; //по снегу трудно двигаться
                    break;
                case CellType.Sand:
                    mProhodCost = 3; //по песку трудно двигаться
                    break;
                case CellType.Water:
                    mProhodCost = 2; //по воде долго плыть
                    break;
                case CellType.Stones:
                    mProhodCost = 3; //по камням трудно двигаться
                    break;
                case CellType.Forest:
                    mProhodCost = 4; //по лесу трудно двигаться
                    break;
                case CellType.Road:
                    mProhodCost = 1; //по дороге лучше всего ходить
                    break;
                case CellType.Buildings:
                    mProhodCost = 3; //мимо зданий трудно двигаться
                    break;
                case CellType.Ice:
                    mProhodCost = 4; //по льду трудно двигаться
                    break;
                case CellType.Grass:
                default:
                    mProhodCost = 2; //по траве ехать нормально
                    break;
            }
        }
    }
}

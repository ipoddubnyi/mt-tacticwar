using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacticWar.TW_Landscape
{
    //Поле - ячейка зоны боевых действий
    class CField
    {
        public SCoordinates mCoords;     //координаты ячейки

        public EZemType mZemType;       //тип земли ячейки

        public bool mProhodima;         //проходима ли ячейка
        public int mProhodCost;         //величина проходимости

        public bool mZanyata;           //занята ли ячейка
        //???                           //ссылка на юнит, который стоит на ячейке

        public int mCost;               //общая цена прохода по рассмотренным ячейкам
        public SNapravleniya mNapravl;   //направления из ячейки

        //********************************************************************************

        /// <summary>Конструктор
        /// </summary>
        /// <param name="x">координата x (строка)</param>
        /// <param name="y">координата y (столбец)</param>
        /// <returns></returns>
        public CField(int x, int y)
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
            mZemType = EZemType.zt0_ZEMLYA;

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
        public CField(int x, int y, int type)
        {
            Init(x, y);

            switch (type)
            {
                case 1:
                    mZemType = EZemType.zt1_SNEG;
                    break;
                case 2:
                    mZemType = EZemType.zt2_PESOK;
                    break;
                case 3:
                    mZemType = EZemType.zt3_VODA;
                    break;
                case 4:
                    mZemType = EZemType.zt4_KAMNI;
                    break;
                case 5:
                    mZemType = EZemType.zt5_LES;
                    break;
                case 6:
                    mZemType = EZemType.zt6_DOROGA;
                    break;
                case 7:
                    mZemType = EZemType.zt7_STROENIYA;
                    break;
                case 8:
                    mZemType = EZemType.zt8_LYOD;
                    break;
                case 0:
                default:
                    mZemType = EZemType.zt0_ZEMLYA;
                    break;
            }

            countProhodCost();
        }

        /*//деструктор
        ~CField()
        {

        }*/

        //********************************************************************************

        /// <summary>Оценить цену прохода по ячейке
        /// </summary>
        /// <returns></returns>
        public void countProhodCost()
        {
            //в зависимости от типа земли
            switch (mZemType)
            {
                case EZemType.zt1_SNEG:
                    mProhodCost = 3; //по снегу трудно двигаться
                    break;
                case EZemType.zt2_PESOK:
                    mProhodCost = 3; //по песку трудно двигаться
                    break;
                case EZemType.zt3_VODA:
                    mProhodCost = 2; //по воде долго плыть
                    break;
                case EZemType.zt4_KAMNI:
                    mProhodCost = 3; //по камням трудно двигаться
                    break;
                case EZemType.zt5_LES:
                    mProhodCost = 4; //по лесу трудно двигаться
                    break;
                case EZemType.zt6_DOROGA:
                    mProhodCost = 1; //по дороге лучше всего ходить
                    break;
                case EZemType.zt7_STROENIYA:
                    mProhodCost = 3; //мимо зданий трудно двигаться
                    break;
                case EZemType.zt8_LYOD:
                    mProhodCost = 4; //по льду трудно двигаться
                    break;
                case EZemType.zt0_ZEMLYA:
                default:
                    mProhodCost = 2; //по траве ехать нормально
                    break;
            }
        }
    }
}

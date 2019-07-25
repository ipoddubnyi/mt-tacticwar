using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacticWar.TW_Units
{
    //Боевая единица
    class CUnit
    {
        public EElementTypes mType;     //тип подразделения

        public int mId;                 //номер юнита в подразделении
        public string mName;            //имя

        public EHealth mHealth;         //здоровье

        public int mPowerAntiInf;       //общая мощь против пехоты и артиллерии
        public int mPowerAntiBron;      //общая мощь против бронетехники и кораблей
        public int mPowerAntiAir;       //общая мощь против воздуха

        public int mArmourFromInf;      //общая защита от пехоты
        public int mArmourFromBron;     //общая защита от любой техники

        public int mSuplies;            //число патронов и снарядов

        public int mRadius;             //радиус действия (для артиллерии)
        public int mObzor;              //радиус обзора

        public ELevels mLevel;          //уровень повышения

        public int mSteps;              //число шагов
        public bool mStepLand;          //ходит ли по земле
        public bool mStepAqua;          //ходит ли по воде

        public SMoney mCost;             //цена юнита

        //********************************************************************************

        /*//Конструктор
        public CUnit(int id, int type, string name, int health,
            int powI, int powB, int powA,
            int armI, int armB, int suplies, int radius, int obzor, int level,
            int steps, bool stepL, bool stepA, int costs)
        {

        }

        //Конструктор
        public CUnit(int id)
        {

        }*/

        //********************************************************************************

        //Лечить юнита
        public void unitRepair()
        {
            mHealth = EHealth.eh0_READY;
        }

        //Убить юнита
        public void unitKill()
        {
            mHealth = EHealth.eh2_DEAD;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MT.TacticWar.Core.Objects
{
    //Боевая единица
    public class Unit
    {
        public DivisionType mType;     //тип подразделения

        public int mId;                 //номер юнита в подразделении
        public string mName;            //имя

        public Health mHealth;         //здоровье

        public int mPowerAntiInf;       //общая мощь против пехоты и артиллерии
        public int mPowerAntiBron;      //общая мощь против бронетехники и кораблей
        public int mPowerAntiAir;       //общая мощь против воздуха

        public int mArmourFromInf;      //общая защита от пехоты
        public int mArmourFromBron;     //общая защита от любой техники

        public int mSuplies;            //число патронов и снарядов

        public int mRadius;             //радиус действия (для артиллерии)
        public int mObzor;              //радиус обзора

        public UnitLevel mLevel;          //уровень повышения

        public int mSteps;              //число шагов
        public bool mStepLand;          //ходит ли по земле
        public bool mStepAqua;          //ходит ли по воде

        public Money mCost;             //цена юнита

        //********************************************************************************

        /*//Конструктор
        public Unit(int id, int type, string name, int health,
            int powI, int powB, int powA,
            int armI, int armB, int suplies, int radius, int obzor, int level,
            int steps, bool stepL, bool stepA, int costs)
        {

        }

        //Конструктор
        public Unit(int id)
        {

        }*/

        //********************************************************************************

        //Лечить юнита
        public void unitRepair()
        {
            mHealth = Health.Ready;
        }

        //Убить юнита
        public void unitKill()
        {
            mHealth = Health.Dead;
        }
    }
}

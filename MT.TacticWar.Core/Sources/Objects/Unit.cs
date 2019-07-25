using System;

namespace MT.TacticWar.Core.Objects
{
    public class Unit
    {
        public const int ExperienceRecruit = 0;
        public const int ExperienceWarrior = 25;
        public const int ExperienceVeteran = 75;
        public const int ExperienceHero = 100;

        public int Id;                 //номер юнита в подразделении
        public DivisionType DivisionType;     //тип подразделения

        public string Name;            //имя
        public int Health;         //здоровье
        public int Experience;          //опыт
        public int Cost;             //цена юнита

        public int PowerAntiInf;       //общая мощь против пехоты и артиллерии
        public int PowerAntiTank;      //общая мощь против бронетехники и кораблей
        public int PowerAntiAir;       //общая мощь против воздуха

        public int ArmourFromInf;      //общая защита от пехоты
        public int ArmourFromTank;     //общая защита от любой техники

        public int Supply;            //число патронов и снарядов

        public int RadiusAttack;             //радиус действия (для артиллерии)
        public int RadiusView;              //радиус обзора

        public int Steps;              //число шагов
        public bool StepLand;          //ходит ли по земле
        public bool StepAqua;          //ходит ли по воде

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

        public void Repair()
        {
            Health = 100;
        }

        public void Kill()
        {
            Health = 0;
        }

        public int GetPowerAnti(DivisionType enemyType)
        {
            switch (enemyType)
            {
                case DivisionType.Infantry:
                    return PowerAntiInf;
                case DivisionType.Aviation:
                    return PowerAntiAir;
                case DivisionType.Vehicle:
                case DivisionType.Artillery:
                case DivisionType.Ship:
                    return PowerAntiTank;
            }

            throw new Exception("Неизвестный тип юнита.");
        }

        public int GetArmourFrom(DivisionType enemyType)
        {
            switch (enemyType)
            {
                case DivisionType.Infantry:
                    return ArmourFromInf;
                case DivisionType.Aviation:
                case DivisionType.Vehicle:
                case DivisionType.Artillery:
                case DivisionType.Ship:
                    return ArmourFromTank;
            }

            throw new Exception("Неизвестный тип юнита.");
        }
    }
}


namespace MT.TacticWar.Core.Objects
{
    public class Unit
    {
        public DivisionType Type;     //тип подразделения

        public int Id;                 //номер юнита в подразделении
        public string Name;            //имя

        public Health Health;         //здоровье

        public int PowerAntiInf;       //общая мощь против пехоты и артиллерии
        public int PowerAntiBron;      //общая мощь против бронетехники и кораблей
        public int PowerAntiAir;       //общая мощь против воздуха

        public int ArmourFromInf;      //общая защита от пехоты
        public int ArmourFromBron;     //общая защита от любой техники

        public int Suplies;            //число патронов и снарядов

        public int RadiusAttack;             //радиус действия (для артиллерии)
        public int RadiusView;              //радиус обзора

        public UnitLevel Level;          //уровень повышения

        public int Steps;              //число шагов
        public bool StepLand;          //ходит ли по земле
        public bool StepAqua;          //ходит ли по воде

        public Money Cost;             //цена юнита

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
            Health = Health.Ready;
        }

        public void Kill()
        {
            Health = Health.Dead;
        }
    }
}

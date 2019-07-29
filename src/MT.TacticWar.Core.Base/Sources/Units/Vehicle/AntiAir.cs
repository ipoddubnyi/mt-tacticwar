using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public class AntiAir : Unit
    {
        public AntiAir()
        {
            //номер юнита в подразделении
            Id = 0;

            //тип подразделения
            DivisionType = DivisionType.Vehicle;
            //имя
            Name = "ЗРК";
            //цена юнита
            Cost = 2500;

            //здоровье
            Health = 100;

            //общая мощь против пехоты и артиллерии
            PowerAntiInf = 5;
            //общая мощь против бронетехники и кораблей
            PowerAntiTank = 10;
            //общая мощь против воздуха
            PowerAntiAir = 80;

            //общая защита от пехоты
            ArmourFromInf = 30;
            //общая защита от любой техники
            ArmourFromTank = 15;
            //число патронов и снарядов
            Supply = 1000;

            //радиус действия (для артиллерии)
            RadiusAttack = 0;
            //радиус обзора
            RadiusView = 1;
            //уровень повышения
            Experience = ExperienceRecruit;

            //число шагов
            Steps = 5;
            //ходит ли по земле
            StepLand = true;
            //ходит ли по воде
            StepAqua = false;
        }
    }
}

using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public class MotorizedInfantry : Unit
    {
        public MotorizedInfantry()
        {
            //номер юнита в подразделении
            Id = 0;

            //тип подразделения
            DivisionType = DivisionType.Vehicle;
            //имя
            Name = "Мотопехота";
            //цена юнита
            Cost = 800;

            //здоровье
            Health = 100;

            //общая мощь против пехоты и артиллерии
            PowerAntiInf = 20;
            //общая мощь против бронетехники и кораблей
            PowerAntiTank = 15;
            //общая мощь против воздуха
            PowerAntiAir = 5;

            //общая защита от пехоты
            ArmourFromInf = 30;
            //общая защита от любой техники
            ArmourFromTank = 30;
            //число патронов и снарядов
            Supply = 5000;

            //радиус действия (для артиллерии)
            RadiusAttack = 0;
            //радиус обзора
            RadiusView = 1;
            //уровень повышения
            Experience = ExperienceRecruit;

            //число шагов
            Steps = 8;
            //ходит ли по земле
            StepLand = true;
            //ходит ли по воде
            StepAqua = false;
        }
    }
}

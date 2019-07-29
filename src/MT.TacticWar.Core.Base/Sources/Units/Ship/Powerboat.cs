using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public class Powerboat : Unit
    {
        public Powerboat()
        {
            //номер юнита в подразделении
            Id = 0;

            //тип подразделения
            DivisionType = DivisionType.Ship;
            //имя
            Name = "Катер";
            //цена юнита
            Cost = 1500;

            //здоровье
            Health = 100;

            //общая мощь против пехоты и артиллерии
            PowerAntiInf = 20;
            //общая мощь против бронетехники и кораблей
            PowerAntiTank = 50;
            //общая мощь против воздуха
            PowerAntiAir = 5;

            //общая защита от пехоты
            ArmourFromInf = 80;
            //общая защита от любой техники
            ArmourFromTank = 50;
            //число патронов и снарядов
            Supply = 1500;

            //радиус действия (для артиллерии)
            RadiusAttack = 0;
            //радиус обзора
            RadiusView = 1;
            //уровень повышения
            Experience = ExperienceRecruit;

            //число шагов
            Steps = 10;
            //ходит ли по земле
            StepLand = false;
            //ходит ли по воде
            StepAqua = true;
        }
    }
}

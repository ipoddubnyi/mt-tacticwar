using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public class Saboteur : Unit
    {
        public Saboteur()
        {
            //номер юнита в подразделении
            Id = 0;

            //тип подразделения
            DivisionType = DivisionType.Infantry;
            //имя
            Name = "Диверсанты";
            //цена юнита
            Cost = 3000;

            //здоровье
            Health = 100;

            //общая мощь против пехоты и артиллерии
            PowerAntiInf = 35;
            //общая мощь против бронетехники и кораблей
            PowerAntiTank = 20;
            //общая мощь против воздуха
            PowerAntiAir = 2;

            //общая защита от пехоты
            ArmourFromInf = 80;
            //общая защита от любой техники
            ArmourFromTank = 30;
            //число патронов и снарядов
            Supply = 3000;

            //радиус действия (для артиллерии)
            RadiusAttack = 0;
            //радиус обзора
            RadiusView = 2;
            //уровень повышения
            Experience = ExperienceRecruit;

            //число шагов
            Steps = 10;
            //ходит ли по земле
            StepLand = true;
            //ходит ли по воде
            StepAqua = true;
        }
    }
}

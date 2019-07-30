using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public class Igor : Unit
    {
        public Igor(Division division)
        {
            //номер юнита в подразделении
            Id = 0;

            //подразделение
            Division = division;
            //имя
            Name = "Лейтенант";
            //цена юнита
            Cost = 50000;

            //здоровье
            Health = 100;

            //общая мощь против пехоты и артиллерии
            PowerAntiInf = 80;
            //общая мощь против бронетехники и кораблей
            PowerAntiTank = 80;
            //общая мощь против воздуха
            PowerAntiAir = 80;

            //общая защита от пехоты
            ArmourFromInf = 80;
            //общая защита от любой техники
            ArmourFromTank = 80;

            //максимальное число патронов и снарядов
            SupplyMax = 1500;
            //число патронов и снарядов
            Supply = 1500;

            //радиус действия (для артиллерии)
            RadiusAttack = 0;
            //радиус обзора
            RadiusView = 1;
            //уровень повышения
            Experience = ExperienceHero;

            //число шагов
            Steps = 5;
            //ходит ли по земле
            StepLand = true;
            //ходит ли по воде
            StepAqua = true;
        }
    }
}

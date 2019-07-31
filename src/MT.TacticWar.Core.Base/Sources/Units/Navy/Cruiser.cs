using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public class Cruiser : Unit
    {
        public Cruiser(Division division)
        {
            //номер юнита в подразделении
            Id = 0;

            //подразделение
            Division = division;
            //имя
            Name = "Крейсер";
            //цена юнита
            Cost = 3000;

            //здоровье
            Health = 100;

            //общая мощь против пехоты и артиллерии
            PowerAntiInf = 70;
            //общая мощь против бронетехники и кораблей
            PowerAntiTank = 70;
            //общая мощь против воздуха
            PowerAntiAir = 70;

            //общая защита от пехоты
            ArmourFromInf = 70;
            //общая защита от наземной техники
            ArmourFromTank = 70;
            //общая защита от воздушной атаки
            ArmourFromAir = 40;

            //максимальное число патронов и снарядов
            SupplyMax = 2500;
            //число патронов и снарядов
            Supply = 2500;

            //радиус действия (для артиллерии)
            RadiusAttack = 4;
            //радиус обзора
            RadiusView = 1;
            //уровень повышения
            Experience = ExperienceWarrior;

            //число шагов
            Steps = 6;
            //ходит ли по земле
            StepLand = false;
            //ходит ли по воде
            StepAqua = true;
        }
    }
}

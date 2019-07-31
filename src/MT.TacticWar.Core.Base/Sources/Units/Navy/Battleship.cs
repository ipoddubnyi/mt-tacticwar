using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public class Battleship : Unit
    {
        public Battleship(Division division)
        {
            //номер юнита в подразделении
            Id = 0;

            //подразделение
            Division = division;
            //имя
            Name = "Линкор";
            //цена юнита
            Cost = 3500;

            //здоровье
            Health = 100;

            //общая мощь против пехоты и артиллерии
            PowerAntiInf = 90;
            //общая мощь против бронетехники и кораблей
            PowerAntiTank = 90;
            //общая мощь против воздуха
            PowerAntiAir = 90;

            //общая защита от пехоты
            ArmourFromInf = 90;
            //общая защита от наземной техники
            ArmourFromTank = 90;
            //общая защита от воздушной атаки
            ArmourFromAir = 60;

            //максимальное число патронов и снарядов
            SupplyMax = 3000;
            //число патронов и снарядов
            Supply = 3000;

            //радиус действия (для артиллерии)
            RadiusAttack = 5;
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

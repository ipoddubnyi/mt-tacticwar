using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public class Soldier : Unit
    {
        public Soldier(Division division)
        {
            //номер юнита в подразделении
            Id = 0;

            //подразделение
            Division = division;
            //имя
            Name = "Солдаты";
            //цена юнита
            Cost = 700;

            //здоровье
            Health = 100;

            //общая мощь против пехоты и артиллерии
            PowerAntiInf = 25;
            //общая мощь против бронетехники и кораблей
            PowerAntiTank = 10;
            //общая мощь против воздуха
            PowerAntiAir = 5;

            //общая защита от пехоты
            ArmourFromInf = 30;
            //общая защита от наземной техники
            ArmourFromTank = 10;
            //общая защита от воздушной атаки
            ArmourFromAir = 5;

            //максимальное число патронов и снарядов
            SupplyMax = 5000;
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

        public override int GetStepBonus(Cell cell)
        {
            if (cell is IForest)
                return 1;

            return 0;
        }
    }
}

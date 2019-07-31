using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public class Aircraft : Unit
    {
        public Aircraft(Division division)
        {
            //номер юнита в подразделении
            Id = 0;

            //подразделение
            Division = division;
            //имя
            Name = "Штурмовик";
            //цена юнита
            Cost = 1500;

            //здоровье
            Health = 100;

            //общая мощь против пехоты и артиллерии
            PowerAntiInf = 20;
            //общая мощь против бронетехники и кораблей
            PowerAntiTank = 50;
            //общая мощь против воздуха
            PowerAntiAir = 50;

            //общая защита от пехоты
            ArmourFromInf = 80;
            //общая защита от наземной техники
            ArmourFromTank = 10;
            //общая защита от воздушной атаки
            ArmourFromAir = 20;

            //максимальное число патронов и снарядов
            SupplyMax = 1500;
            //число патронов и снарядов
            Supply = 1500;

            //радиус действия (для артиллерии)
            RadiusAttack = 10;
            //радиус обзора
            RadiusView = 1;
            //уровень повышения
            Experience = ExperienceWarrior;

            //число шагов
            Steps = 15;
            //ходит ли по земле
            StepLand = false;
            //ходит ли по воде
            StepAqua = false;
        }
    }
}

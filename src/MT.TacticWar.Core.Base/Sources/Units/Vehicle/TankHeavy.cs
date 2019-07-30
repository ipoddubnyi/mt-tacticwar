using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public class TankHeavy : Unit
    {
        public TankHeavy(Division division)
        {
            //номер юнита в подразделении
            Id = 0;

            //подразделение
            Division = division;
            //имя
            Name = "Тяжёлый танк";
            //цена юнита
            Cost = 3000;

            //здоровье
            Health = 100;

            //общая мощь против пехоты и артиллерии
            PowerAntiInf = 15;
            //общая мощь против бронетехники и кораблей
            PowerAntiTank = 80;
            //общая мощь против воздуха
            PowerAntiAir = 10;

            //общая защита от пехоты
            ArmourFromInf = 80;
            //общая защита от любой техники
            ArmourFromTank = 80;

            //максимальное число патронов и снарядов
            SupplyMax = 1000;
            //число патронов и снарядов
            Supply = 1000;

            //радиус действия (для артиллерии)
            RadiusAttack = 0;
            //радиус обзора
            RadiusView = 1;
            //уровень повышения
            Experience = ExperienceRecruit;

            //число шагов
            Steps = 4;
            //ходит ли по земле
            StepLand = true;
            //ходит ли по воде
            StepAqua = false;
        }
    }
}

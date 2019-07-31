using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public class Howitzer : Unit
    {
        public Howitzer(Division division)
        {
            //номер юнита в подразделении
            Id = 0;

            //подразделение
            Division = division;
            //имя
            Name = "Гаубица";
            //цена юнита
            Cost = 1500;

            //здоровье
            Health = 100;

            //общая мощь против пехоты и артиллерии
            PowerAntiInf = 80;
            //общая мощь против бронетехники и кораблей
            PowerAntiTank = 80;
            //общая мощь против воздуха
            PowerAntiAir = 0;

            //общая защита от пехоты
            ArmourFromInf = 10;
            //общая защита от наземной техники
            ArmourFromTank = 5;
            //общая защита от воздушной атаки
            ArmourFromAir = 5;

            //максимальное число патронов и снарядов
            SupplyMax = 1500;
            //число патронов и снарядов
            Supply = 1500;

            //радиус действия (для артиллерии)
            RadiusAttack = 5;
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

using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public class Partizan : Unit
    {
        public Partizan(Division division)
        {
            //номер юнита в подразделении
            Id = 0;

            //подразделение
            Division = division;
            //имя
            Name = "Партизаны";
            //цена юнита
            Cost = 400;

            //здоровье
            Health = 100;

            //общая мощь против пехоты и артиллерии
            PowerAntiInf = 20;
            //общая мощь против бронетехники и кораблей
            PowerAntiTank = 2;
            //общая мощь против воздуха
            PowerAntiAir = 2;

            //общая защита от пехоты
            ArmourFromInf = 20;
            //общая защита от любой техники
            ArmourFromTank = 30;

            //максимальное число патронов и снарядов
            SupplyMax = 1500;
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
            StepLand = true;
            //ходит ли по воде
            StepAqua = false;
        }

        public override int GetPowerBonus(Cell cell)
        {
            if (CellType.Forest == cell.Type)
                return 2;

            return 0;
        }

        public override int GetArmourBonus(Cell cell)
        {
            if (CellType.Forest == cell.Type)
                return 2;

            return 0;
        }
    }
}

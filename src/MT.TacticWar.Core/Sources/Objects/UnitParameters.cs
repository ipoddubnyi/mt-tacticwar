
namespace MT.TacticWar.Core.Objects
{
    public struct UnitParameters
    {
        /// <summary>Число шагов</summary>
        public int Steps;
        /// <summary>Число припасов</summary>
        public int Supply;
        /// <summary>Цена юнита</summary>
        public int Cost;

        /// <summary>Радиус действия</summary>
        public int RadiusAttack;
        /// <summary>Радиус обзора</summary>
        public int RadiusView;

        /// <summary>Мощь против пехоты и артиллерии</summary>
        public int PowerAntiInf;
        /// <summary>Мощь против бронетехники и кораблей</summary>
        public int PowerAntiTank;
        /// <summary>Мощь против воздуха</summary>
        public int PowerAntiAir;

        /// <summary>Защита от пехоты</summary>
        public int ArmourFromInf;
        /// <summary>Защита от наземной техники</summary>
        public int ArmourFromTank;
        /// <summary>Защита от воздушной атаки</summary>
        public int ArmourFromAir;

        /// <summary>Ходит ли по земле</summary>
        public bool CanStepLand;
        /// <summary>Ходит ли по воде</summary>
        public bool CanStepAqua;
    }
}

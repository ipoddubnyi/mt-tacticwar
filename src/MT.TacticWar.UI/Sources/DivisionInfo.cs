using System.ComponentModel;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.UI
{
    class DivisionInfo
    {
        private Division division;

        #region Данные

        [Category("Данные")]
        [DisplayName("Игрок")]
        [Description("Номер владельца подразделения")]
        public string Player => $"Игрок {division.Player.Name}";

        [Category("Данные")]
        [DisplayName("Тип")]
        [Description("Тип подразделения")]
        public string Type => division.Type.AsString();

        [Category("Данные")]
        [DisplayName("Название")]
        [Description("Название подразделения")]
        public string Name => division.Name;

        [Category("Данные")]
        [DisplayName("Координаты")]
        [Description("Координаты подразделения на карте")]
        public string Coordinates => division.Position.ToString();

        [Category("Данные")]
        [DisplayName("Мощь против пехоты")]
        [Description("Боевая мощь противопехотного оружия")]
        public int PowerAntiInf => division.PowerAntiInf;

        [Category("Данные")]
        [DisplayName("Мощь против бронетехники")]
        [Description("Боевая мощь противотанкового оружия")]
        public int PowerAntiBron => division.PowerAntiTank;

        [Category("Данные")]
        [DisplayName("Мощь против авиации")]
        [Description("Боевая мощь противовоздушного оружия")]
        public int PowerAntiAir => division.PowerAntiAir;

        [Category("Данные")]
        [DisplayName("Защита от пехоты")]
        [Description("Защита от противопехотного оружия")]
        public int ArmourFromInf => division.ArmourFromInf;

        [Category("Данные")]
        [DisplayName("Защита от техники")]
        [Description("Защита от противотанкового оружия")]
        public int ArmourFromBron => division.ArmourFromTank;

        [Category("Данные")]
        [DisplayName("Радиус атаки")]
        [Description("На каком радиусе подразделение может выполнять функции")]
        public int RadiusAttack => division.RadiusAttack;

        [Category("Данные")]
        [DisplayName("Обзор")]
        [Description("Дальность видимости подразделения")]
        public int RadiusView => division.RadiusView;

        [Category("Данные")]
        [DisplayName("Опыт")]
        [Description("Опыт поздразделения")]
        public int Experience => division.Experience;

        [Category("Данные")]
        [DisplayName("Патроны")]
        [Description("Количество патронов. Без патронов подразделение не может вести боевые действия")]
        public int Suplies => division.Supply;

        [Category("Данные")]
        [DisplayName("Шаги")]
        [Description("Число шагов подразделения")]
        public int Steps => division.Steps;

        #endregion

        public DivisionInfo(Division division)
        {
            this.division = division;
        }
    }
}

using System.ComponentModel;
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
        public string Player => $"Игрок {division.PlayerId}";

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
        public int PowerAntiBron => division.PowerAntiBron;

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
        public int ArmourFromBron => division.ArmourFromBron;

        [Category("Данные")]
        [DisplayName("Радиус атаки")]
        [Description("На каком радиусе подразделение может выполнять функции")]
        public int RadiusAttack => division.RadiusAttack;

        [Category("Данные")]
        [DisplayName("Радиус обзора")]
        [Description("Дальность видимости подразделения")]
        public int RadiusView => division.RadiusView;

        [Category("Данные")]
        [DisplayName("Уровень")]
        [Description("Уровень поздразделения")]
        public string Level => division.Level.AsString();

        [Category("Данные")]
        [DisplayName("Количество патронов")]
        [Description("Количество патронов. Без патронов подразделение не может вести боевые действия")]
        public int Suplies => division.Suplies;

        [Category("Данные")]
        [DisplayName("Количество шагов")]
        [Description("Число шагов подразделения")]
        public int Steps => division.Steps;

        #endregion

        public DivisionInfo(Division division)
        {
            this.division = division;
        }
    }
}

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
        public string Player => division.Player.Name;

        [Category("Данные")]
        [DisplayName("Тип")]
        [Description("Тип подразделения")]
        public string Type => division.Type;

        [Category("Данные")]
        [DisplayName("Название")]
        [Description("Название подразделения")]
        public string Name => division.Name;

        [Category("Данные")]
        [DisplayName("Координаты")]
        [Description("Координаты подразделения на карте")]
        public string Coordinates => division.Position.ToString();

        [Category("Данные")]
        [DisplayName("Опыт")]
        [Description("Опыт поздразделения")]
        public int Experience => division.Experience;

        [Category("Данные")]
        [DisplayName("Патроны")]
        [Description("Количество патронов. Без патронов подразделение не может вести боевые действия")]
        public string Suplies => $"{division.SupplyCurrent}/{division.Parameters.Supply}";

        [Category("Данные")]
        [DisplayName("Шаги")]
        [Description("Число шагов подразделения")]
        public string Steps => $"{division.StepsCurrent}/{division.Parameters.Steps}";

        [Category("Данные")]
        [DisplayName("Радиус атаки")]
        [Description("На каком радиусе подразделение может выполнять функции")]
        public int RadiusAttack => division.Parameters.RadiusAttack;

        [Category("Данные")]
        [DisplayName("Обзор")]
        [Description("Дальность видимости подразделения")]
        public int RadiusView => division.Parameters.RadiusView;

        [Category("Данные")]
        [DisplayName("Мощь против пехоты")]
        [Description("Боевая мощь противопехотного оружия")]
        public int PowerAntiInf => division.Parameters.PowerAntiInf;

        [Category("Данные")]
        [DisplayName("Мощь против бронетехники")]
        [Description("Боевая мощь противотанкового оружия")]
        public int PowerAntiBron => division.Parameters.PowerAntiTank;

        [Category("Данные")]
        [DisplayName("Мощь против авиации")]
        [Description("Боевая мощь противовоздушного оружия")]
        public int PowerAntiAir => division.Parameters.PowerAntiAir;

        [Category("Данные")]
        [DisplayName("Защита от пехоты")]
        [Description("Защита от противопехотного оружия")]
        public int ArmourFromInf => division.Parameters.ArmourFromInf;

        [Category("Данные")]
        [DisplayName("Защита от техники")]
        [Description("Защита от противотанкового оружия")]
        public int ArmourFromBron => division.Parameters.ArmourFromTank;

        [Category("Данные")]
        [DisplayName("Защита от авиации")]
        [Description("Защита от воздушного нападения")]
        public int ArmourFromAir => division.Parameters.ArmourFromAir;

        [Category("Данные")]
        [DisplayName("Передвижение по земле")]
        [Description("Возможность передвижение по земле")]
        public string CanStepLand => division.Parameters.CanStepLand ? "Да" : "Нет";

        [Category("Данные")]
        [DisplayName("Передвижение по воде")]
        [Description("Возможность передвижение по воде")]
        public string CanStepAqua => division.Parameters.CanStepAqua  ? "Да" : "Нет";

        #endregion

        public DivisionInfo(Division division)
        {
            this.division = division;
        }
    }
}

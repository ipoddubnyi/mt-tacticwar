using System.ComponentModel;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.UI
{
    class BuildingInfo
    {
        private Building building;

        #region Данные

        [Category("Данные")]
        [DisplayName("Игрок")]
        [Description("Номер владельца строения")]
        public string Player => $"Игрок {building.PlayerId}";

        [Category("Данные")]
        [DisplayName("Тип")]
        [Description("Тип строения")]
        public string Type => building.Type.AsString();

        [Category("Данные")]
        [DisplayName("Название")]
        [Description("Название строения")]
        public string Name => building.Name;

        [Category("Данные")]
        [DisplayName("Координаты")]
        [Description("Координаты строения на карте")]
        public string Coordinates => building.Position.ToString();

        /*[Category("Данные")]
        [DisplayName("Здоровье")]
        [Description("Здоровье")]
        public string Health => Health.ToString();*/

        [Category("Данные")]
        [DisplayName("Радиус действия")]
        [Description("На каком радиусе здание может выполнять функции")]
        public int RadiusActive => building.RadiusActive;

        [Category("Данные")]
        [DisplayName("Обзор")]
        [Description("Дальность видимости здания")]
        public int RadiusView => building.RadiusView;

        #endregion

        public BuildingInfo(Building building)
        {
            this.building = building;
        }
    }
}

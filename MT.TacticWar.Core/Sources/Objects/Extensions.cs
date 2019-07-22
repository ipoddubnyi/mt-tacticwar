using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.TacticWar.Core.Objects
{
    public static class Extensions
    {
        public static string AsString(this DivisionType type)
        {
            switch (type)
            {
                case DivisionType.Infantry:
                    return "Пехота";
                case DivisionType.Vehicle:
                    return "Бронетехника";
                case DivisionType.Artillery:
                    return "Артиллерия";
                case DivisionType.Aviation:
                    return "Авиация";
                case DivisionType.Ship:
                    return "Флот";
            }

            throw new Exception("Неизвестный тип дивизии.");
        }

        public static string AsString(this BuildingType type)
        {
            switch (type)
            {
                case BuildingType.Factory:
                    return "Завод";
                case BuildingType.Barracks:
                    return "Казарма";
                case BuildingType.Storehouse:
                    return "Склад";
                case BuildingType.Radar:
                    return "Радар";
                case BuildingType.Airfield:
                    return "Аэропорт";
                case BuildingType.Port:
                    return "Порт";
            }

            throw new Exception("Неизвестный тип строения.");
        }

        public static string AsString(this UnitLevel level)
        {
            switch (level)
            {
                case UnitLevel.None:
                    return "";
                case UnitLevel.Recruit:
                    return "Новобранец";
                case UnitLevel.Warrior:
                    return "Воин";
                case UnitLevel.Veteran:
                    return "Ветеран";
                case UnitLevel.Hero:
                    return "Герой";
            }

            throw new Exception("Неизвестный уровень.");
        }

        public static Division GetById(this IEnumerable<Division> divisions, int id)
        {
            foreach (var div in divisions)
            {
                if (div.Id == id)
                    return div;
            }

            return null;
        }
    }
}

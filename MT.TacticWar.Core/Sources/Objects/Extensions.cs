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
    }
}

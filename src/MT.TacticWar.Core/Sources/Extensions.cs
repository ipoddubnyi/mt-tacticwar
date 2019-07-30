using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core
{
    public static class Extensions
    {
        /*public static string AsString(this DivisionType type)
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
        }*/

        public static string AsString(this MissionMode mode)
        {
            switch (mode)
            {
                case MissionMode.KillThemAll:
                    return "Убить их всех";
                case MissionMode.DestroyTheTarget:
                    return "Уничтожение цели";
                case MissionMode.CaptureTheBuilding:
                    return "Захат здания";
                case MissionMode.DefendTheTarget:
                    return "Защита здания";
                case MissionMode.CaptureTheFlag:
                    return "Захват флага";
                case MissionMode.CaptureZones:
                    return "Захват зон";
            }

            throw new Exception("Неизвестный режим миссии.");
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

        public static Division GetAt(this IEnumerable<Division> divisions, Coordinates position)
        {
            foreach (var div in divisions)
            {
                if (div.Position.Equals(position))
                    return div;
            }

            return null;
        }

        public static Building GetById(this IEnumerable<Building> buildings, int id)
        {
            foreach (var bld in buildings)
            {
                if (bld.Id == id)
                    return bld;
            }

            return null;
        }

        public static Building GetAt(this IEnumerable<Building> buildings, Coordinates position)
        {
            foreach (var bld in buildings)
            {
                if (bld.Position.Equals(position))
                    return bld;
            }

            return null;
        }
    }
}

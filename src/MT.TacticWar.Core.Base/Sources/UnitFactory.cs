using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Base.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public static class UnitFactory
    {
        private static readonly List<UnitVariant> Units = new List<UnitVariant>()
        {
            new UnitVariant { DivisionType = "infantry", Name = "Партизан", UnitType = "partizan", Type = typeof(Partizan) },
            new UnitVariant { DivisionType = "infantry", Name = "Солдат", UnitType = "soldier", Type = typeof(Soldier) },
            new UnitVariant { DivisionType = "infantry", Name = "Диверсант", UnitType = "saboteur", Type = typeof(Saboteur) },
            new UnitVariant { DivisionType = "infantry", Name = "Лейтенант", UnitType = "igor", Type = typeof(Igor) },

            new UnitVariant { DivisionType = "vehicle", Name = "БМП", UnitType = "ifv", Type = typeof(IFV) },
            new UnitVariant { DivisionType = "vehicle", Name = "Средний танк", UnitType = "tank", Type = typeof(TankMiddle) },
            new UnitVariant { DivisionType = "vehicle", Name = "Тяжёлый танк", UnitType = "tankheavy", Type = typeof(TankHeavy) },
            new UnitVariant { DivisionType = "vehicle", Name = "ЗРК", UnitType = "antiair", Type = typeof(AntiAir) },

            new UnitVariant { DivisionType = "ship", Name = "Катер", UnitType = "powerboat", Type = typeof(Powerboat) },

            new UnitVariant { DivisionType = "navy", Name = "Линкор", UnitType = "battleship", Type = typeof(Battleship) },
            new UnitVariant { DivisionType = "navy", Name = "Крейсер", UnitType = "cruiser", Type = typeof(Cruiser) },

            new UnitVariant { DivisionType = "artillery", Name = "Гаубица", UnitType = "howitzer", Type = typeof(Howitzer) },

            new UnitVariant { DivisionType = "aviation", Name = "Штурмовик", UnitType = "aircraft", Type = typeof(Aircraft) }
        };

        public static List<UnitVariant> GetAvailableUnits(string divisionType)
        {
            var list = new List<UnitVariant>();
            foreach (var unit in Units)
            {
                if (unit.DivisionType.Equals(divisionType))
                    list.Add(unit);
            }
            return list;
        }

        public static Unit CreateUnit(int id, Division division, string unitType)
        {
            if (division is Infantry)
                return CreateUnit("infantry", id, division, unitType);
            else if (division is Vehicle)
                return CreateUnit("vehicle", id, division, unitType);
            else if (division is Ship)
                return CreateUnit("ship", id, division, unitType);
            else if (division is Navy)
                return CreateUnit("navy", id, division, unitType);
            else if (division is Artillery)
                return CreateUnit("artillery", id, division, unitType);
            else if (division is Aviation)
                return CreateUnit("aviation", id, division, unitType);

            throw new Exception("Неизвестный тип подразделения.");
        }

        private static Unit CreateUnit(string divisionType, int id, Division division, string unitType)
        {
            foreach (var u in Units)
            {
                if (!u.DivisionType.Equals(divisionType))
                    continue;

                if (u.UnitType.Equals(unitType))
                    return u.Create(id, division);
            }

            return null;
        }
    }
}

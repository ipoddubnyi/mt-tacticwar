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
            new UnitVariant { DivisionType = "infantry", Name = "Партизан", UnitType = "partizan", Create = (id, division) => new Partizan(id, division) },
            new UnitVariant { DivisionType = "infantry", Name = "Солдат", UnitType = "soldier", Create = (id, division) => new Soldier(id, division) },
            new UnitVariant { DivisionType = "infantry", Name = "Диверсант", UnitType = "saboteur", Create = (id, division) => new Saboteur(id, division) },
            new UnitVariant { DivisionType = "infantry", Name = "Лейтенант", UnitType = "igor", Create = (id, division) => new Igor(id, division) },

            new UnitVariant { DivisionType = "vehicle", Name = "БМП", UnitType = "ifv", Create = (id, division) => new IFV(id, division) },
            new UnitVariant { DivisionType = "vehicle", Name = "Средний танк", UnitType = "tank", Create = (id, division) => new TankMiddle(id, division) },
            new UnitVariant { DivisionType = "vehicle", Name = "Тяжёлый танк", UnitType = "tankheavy", Create = (id, division) => new TankHeavy(id, division) },
            new UnitVariant { DivisionType = "vehicle", Name = "ЗРК", UnitType = "antiair", Create = (id, division) => new AntiAir(id, division) },

            new UnitVariant { DivisionType = "ship", Name = "Катер", UnitType = "powerboat", Create = (id, division) => new Powerboat(id, division) },

            new UnitVariant { DivisionType = "navy", Name = "Линкор", UnitType = "battleship", Create = (id, division) => new Battleship(id, division) },
            new UnitVariant { DivisionType = "navy", Name = "Крейсер", UnitType = "cruiser", Create = (id, division) => new Cruiser(id, division) },

            new UnitVariant { DivisionType = "artillery", Name = "Гаубица", UnitType = "howitzer", Create = (id, division) => new Howitzer(id, division) },

            new UnitVariant { DivisionType = "aviation", Name = "Штурмовик", UnitType = "aircraft", Create = (id, division) => new Aircraft(id, division) }
        };

        /*public static Dictionary<string, string> GetAvailableUnits(string divisionType)
        {
            var d = new Dictionary<string, string>();
            foreach (var u in Units)
            {
                if (u.DivisionType.Equals(divisionType))
                    d.Add(u.Name, u.UnitType);
            }
            return d;
        }*/

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

using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Base.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public static class UnitFactory
    {
        public static readonly List<UnitVariant> Units = new List<UnitVariant>()
        {
            new UnitVariant { DivisionType = typeof(Infantry),  Name = "Партизан",      UnitType = "partizan",      Type = typeof(Partizan) },
            new UnitVariant { DivisionType = typeof(Infantry),  Name = "Солдат",        UnitType = "soldier",       Type = typeof(Soldier) },
            new UnitVariant { DivisionType = typeof(Infantry),  Name = "Диверсант",     UnitType = "saboteur",      Type = typeof(Saboteur) },
            new UnitVariant { DivisionType = typeof(Infantry),  Name = "Лейтенант",     UnitType = "igor",          Type = typeof(Igor) },

            new UnitVariant { DivisionType = typeof(Vehicle),   Name = "БМП",           UnitType = "ifv",           Type = typeof(IFV) },
            new UnitVariant { DivisionType = typeof(Vehicle),   Name = "Средний танк",  UnitType = "tank",          Type = typeof(TankMiddle) },
            new UnitVariant { DivisionType = typeof(Vehicle),   Name = "Тяжёлый танк",  UnitType = "tankheavy",     Type = typeof(TankHeavy) },
            new UnitVariant { DivisionType = typeof(Vehicle),   Name = "ЗРК",           UnitType = "antiair",       Type = typeof(AntiAir) },

            new UnitVariant { DivisionType = typeof(Ship),      Name = "Катер",         UnitType = "powerboat",     Type = typeof(Powerboat) },

            new UnitVariant { DivisionType = typeof(Navy),      Name = "Линкор",        UnitType = "battleship",    Type = typeof(Battleship) },
            new UnitVariant { DivisionType = typeof(Navy),      Name = "Крейсер",       UnitType = "cruiser",       Type = typeof(Cruiser) },

            new UnitVariant { DivisionType = typeof(Artillery), Name = "Гаубица",       UnitType = "howitzer",      Type = typeof(Howitzer) },

            new UnitVariant { DivisionType = typeof(Aviation),  Name = "Штурмовик",     UnitType = "aircraft",      Type = typeof(Aircraft) }
        };

        public static List<UnitVariant> GetAvailableUnitsForDivision(Type divisionType)
        {
            var list = new List<UnitVariant>();
            foreach (var unit in Units)
            {
                if (unit.DivisionType.Equals(divisionType))
                    list.Add(unit);
            }
            return list;
        }

        public static Unit CreateUnit(Division division, int id, string unitType)
        {
            foreach (var u in Units)
            {
                if (!u.DivisionType.Equals(division.GetType()))
                    continue;

                if (u.UnitType.Equals(unitType))
                    return u.Create(id, division);
            }

            return null;
        }
    }
}

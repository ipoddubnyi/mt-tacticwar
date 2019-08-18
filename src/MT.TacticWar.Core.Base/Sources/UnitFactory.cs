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
            new UnitVariant { DivisionType = typeof(Infantry),  Name = "Партизан",      Code = "partizan",      Type = typeof(Partizan) },
            new UnitVariant { DivisionType = typeof(Infantry),  Name = "Солдат",        Code = "soldier",       Type = typeof(Soldier) },
            new UnitVariant { DivisionType = typeof(Infantry),  Name = "Диверсант",     Code = "saboteur",      Type = typeof(Saboteur) },
            new UnitVariant { DivisionType = typeof(Infantry),  Name = "Лейтенант",     Code = "igor",          Type = typeof(Igor) },
            new UnitVariant { DivisionType = typeof(Infantry),  Name = "Врач",          Code = "medic",         Type = typeof(Medic) },

            new UnitVariant { DivisionType = typeof(Vehicle),   Name = "БМП",           Code = "ifv",           Type = typeof(IFV) },
            new UnitVariant { DivisionType = typeof(Vehicle),   Name = "Средний танк",  Code = "tank",          Type = typeof(TankMiddle) },
            new UnitVariant { DivisionType = typeof(Vehicle),   Name = "Тяжёлый танк",  Code = "tankheavy",     Type = typeof(TankHeavy) },
            new UnitVariant { DivisionType = typeof(Vehicle),   Name = "ЗРК",           Code = "antiair",       Type = typeof(AntiAir) },

            new UnitVariant { DivisionType = typeof(Ship),      Name = "Катер",         Code = "powerboat",     Type = typeof(Powerboat) },

            new UnitVariant { DivisionType = typeof(Navy),      Name = "Линкор",        Code = "battleship",    Type = typeof(Battleship) },
            new UnitVariant { DivisionType = typeof(Navy),      Name = "Крейсер",       Code = "cruiser",       Type = typeof(Cruiser) },

            new UnitVariant { DivisionType = typeof(Artillery), Name = "Гаубица",       Code = "howitzer",      Type = typeof(Howitzer) },

            new UnitVariant { DivisionType = typeof(Aviation),  Name = "Штурмовик",     Code = "aircraft",      Type = typeof(Aircraft) },

            new UnitVariant { DivisionType = typeof(Engineers), Name = "Мостоукладчик", Code = "bridgebuilder",      Type = typeof(BridgeBuilder) }
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

                if (u.Code.Equals(unitType))
                    return u.Create(id, division);
            }

            return null;
        }

        public static string GetUnitCode(Division division, Unit unit)
        {
            foreach (var u in Units)
            {
                if (!u.DivisionType.Equals(division.GetType()))
                    continue;

                if (u.Type.Equals(unit.GetType()))
                    return u.Code;
            }

            throw new Exception("Неизвестный тип юнита.");
        }
    }
}

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
            new UnitVariant { Code = "partizan",      Type = typeof(Partizan) },
            new UnitVariant { Code = "soldier",       Type = typeof(Soldier) },
            new UnitVariant { Code = "saboteur",      Type = typeof(Saboteur) },
            new UnitVariant { Code = "igor",          Type = typeof(Igor) },
            new UnitVariant { Code = "medic",         Type = typeof(Medic) },

            new UnitVariant { Code = "ifv",           Type = typeof(IFV) },
            new UnitVariant { Code = "tank",          Type = typeof(TankMiddle) },
            new UnitVariant { Code = "tankheavy",     Type = typeof(TankHeavy) },
            new UnitVariant { Code = "antiair",       Type = typeof(AntiAir) },

            new UnitVariant { Code = "powerboat",     Type = typeof(Powerboat) },

            new UnitVariant { Code = "battleship",    Type = typeof(Battleship) },
            new UnitVariant { Code = "cruiser",       Type = typeof(Cruiser) },

            new UnitVariant { Code = "howitzer",      Type = typeof(Howitzer) },

            new UnitVariant { Code = "aircraft",      Type = typeof(Aircraft) },

            new UnitVariant { Code = "bridgebuilder", Type = typeof(BridgeBuilder) }
        };

        public static List<UnitVariant> GetAvailableUnitsForDivision(Type divisionType)
        {
            var list = new List<UnitVariant>();
            foreach (var unit in Units)
            {
                if (unit.GetDivisionType().Equals(divisionType))
                    list.Add(unit);
            }
            return list;
        }

        public static Unit CreateUnit(Division division, int id, string unitType)
        {
            foreach (var u in Units)
            {
                if (!u.GetDivisionType().Equals(division.GetType()))
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
                if (!u.GetDivisionType().Equals(division.GetType()))
                    continue;

                if (u.Type.Equals(unit.GetType()))
                    return u.Code;
            }

            throw new Exception("Неизвестный тип юнита.");
        }
    }
}

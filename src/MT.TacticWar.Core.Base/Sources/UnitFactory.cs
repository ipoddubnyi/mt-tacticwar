using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public static class UnitFactory
    {
        public static readonly List<UnitCreator> Units = new List<UnitCreator>()
        {
            new UnitCreator(typeof(Partizan)),
            new UnitCreator(typeof(Soldier)),
            new UnitCreator(typeof(Saboteur)),
            new UnitCreator(typeof(Igor)),
            new UnitCreator(typeof(Medic)),

            new UnitCreator(typeof(IFV)),
            new UnitCreator(typeof(TankMiddle)),
            new UnitCreator(typeof(TankHeavy)),
            new UnitCreator(typeof(AntiAir)),

            new UnitCreator(typeof(Powerboat)),

            new UnitCreator(typeof(Battleship)),
            new UnitCreator(typeof(Cruiser)),

            new UnitCreator(typeof(Howitzer)),

            new UnitCreator(typeof(Aircraft)),

            new UnitCreator(typeof(BridgeBuilder)),
        };

        public static UnitCreator[] GetAvailableUnitsForDivision(Type divisionType)
        {
            var list = new List<UnitCreator>();
            foreach (var unit in Units)
            {
                if (unit.GetDivisionType().Equals(divisionType))
                    list.Add(unit);
            }
            return list.ToArray();
        }

        public static Unit CreateUnit(Division division, string code, int id)
        {
            foreach (var u in Units)
            {
                if (!u.GetDivisionType().Equals(division.GetType()))
                    continue;

                if (u.GetCode().Equals(code))
                    return u.Create(id, division);
            }

            return null;
        }
    }
}

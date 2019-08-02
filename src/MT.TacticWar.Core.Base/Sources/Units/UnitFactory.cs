using System;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Base.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public static class UnitFactory
    {
        public static Unit CreateUnit(int id, Division division, string unitType)
        {
            if (division is Infantry)
                return CreateUnitInfantry(id, division, unitType);
            else if (division is Vehicle)
                return CreateUnitVehicle(id, division, unitType);
            else if (division is Ship)
                return CreateUnitShip(id, division, unitType);
            else if (division is Navy)
                return CreateUnitNavy(id, division, unitType);
            else if (division is Aviation)
                return CreateUnitAviation(id, division, unitType);
            else if (division is Artillery)
                return CreateUnitArtillery(id, division, unitType);

            throw new Exception("Неизвестный тип подразделения.");
        }

        public static Unit CreateUnitInfantry(int id, Division division, string unitType)
        {
            switch (unitType)
            {
                case "partizan":
                    return new Partizan(id, division);
                case "soldier":
                    return new Soldier(id, division);
                case "saboteur":
                    return new Saboteur(id, division);
                case "igor":
                    return new Igor(id, division);
            }

            return null;
        }

        public static Unit CreateUnitVehicle(int id, Division division, string unitType)
        {
            switch (unitType)
            {
                case "ifv":
                    return new IFV(id, division);
                case "tank":
                    return new TankMiddle(id, division);
                case "tankheavy":
                    return new TankHeavy(id, division);
                case "antiair":
                    return new AntiAir(id, division);
            }

            return null;
        }

        public static Unit CreateUnitShip(int id, Division division, string unitType)
        {
            switch (unitType)
            {
                case "powerboat":
                    return new Powerboat(id, division);
            }

            return null;
        }

        public static Unit CreateUnitNavy(int id, Division division, string unitType)
        {
            switch (unitType)
            {
                case "battleship":
                    return new Battleship(id, division);
                case "cruiser":
                    return new Cruiser(id, division);
            }

            return null;
        }

        public static Unit CreateUnitAviation(int id, Division division, string unitType)
        {
            switch (unitType)
            {
                case "aircraft":
                    return new Aircraft(id, division);
            }

            return null;
        }

        public static Unit CreateUnitArtillery(int id, Division division, string unitType)
        {
            switch (unitType)
            {
                case "howitzer":
                    return new Howitzer(id, division);
            }

            return null;
        }
    }
}

using System;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Base.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public static class UnitFactory
    {
        public static Unit CreateUnit(Division division, string unitType)
        {
            if (division is Infantry)
                return CreateUnitInfantry(division, unitType);
            else if (division is Vehicle)
                return CreateUnitVehicle(division, unitType);
            else if (division is Ship)
                return CreateUnitShip(division, unitType);
            else if (division is Navy)
                return CreateUnitNavy(division, unitType);
            else if (division is Aviation)
                return CreateUnitAviation(division, unitType);
            else if (division is Artillery)
                return CreateUnitArtillery(division, unitType);

            throw new Exception("Неизвестный тип подразделения.");
        }

        public static Unit CreateUnitInfantry(Division division, string unitType)
        {
            switch (unitType)
            {
                case "partizan":
                    return new Partizan(division);
                case "soldier":
                    return new Soldier(division);
                case "saboteur":
                    return new Saboteur(division);
                case "igor":
                    return new Igor(division);
            }

            return null;
        }

        public static Unit CreateUnitVehicle(Division division, string unitType)
        {
            switch (unitType)
            {
                case "ifv":
                    return new IFV(division);
                case "tank":
                    return new TankMiddle(division);
                case "tankheavy":
                    return new TankHeavy(division);
                case "antiair":
                    return new AntiAir(division);
            }

            return null;
        }

        public static Unit CreateUnitShip(Division division, string unitType)
        {
            switch (unitType)
            {
                case "катер":
                    return new Powerboat(division);
            }

            return null;
        }

        public static Unit CreateUnitNavy(Division division, string unitType)
        {
            switch (unitType)
            {
                case "battleship":
                    return new Battleship(division);
                case "cruiser":
                    return new Cruiser(division);
            }

            return null;
        }

        public static Unit CreateUnitAviation(Division division, string unitType)
        {
            switch (unitType)
            {
                case "aircraft":
                    return new Aircraft(division);
            }

            return null;
        }

        public static Unit CreateUnitArtillery(Division division, string unitType)
        {
            switch (unitType)
            {
                case "howitzer":
                    return new Howitzer(division);
            }

            return null;
        }
    }
}

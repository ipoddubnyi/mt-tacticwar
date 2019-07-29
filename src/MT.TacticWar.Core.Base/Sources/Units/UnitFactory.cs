using System;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public static class UnitFactory
    {
        public static Unit CreateUnit(DivisionType divisionType, string unitType)
        {
            switch (divisionType)
            {
                case DivisionType.Infantry:
                    return CreateUnitInfantry(unitType);

                case DivisionType.Vehicle:
                    return CreateUnitVehicle(unitType);

                case DivisionType.Artillery:
                    return null;

                case DivisionType.Aviation:
                    return null;

                case DivisionType.Ship:
                    return CreateUnitShip(unitType);
            }

            throw new Exception("Неизвестный тип подразделения.");
        }

        public static Unit CreateUnitInfantry(string unitType)
        {
            switch (unitType)
            {
                case "partizan":
                    return new Partizan();
                case "soldier":
                    return new Soldier();
                case "saboteur":
                    return new Saboteur();
                case "igor":
                    return new Igor();
            }

            return null;
        }

        public static Unit CreateUnitVehicle(string unitType)
        {
            switch (unitType)
            {
                case "motorized":
                    return new MotorizedInfantry();
                case "tank":
                    return new TankMiddle();
                case "tankheavy":
                    return new TankHeavy();
                case "antiair":
                    return new AntiAir();
            }

            return null;
        }

        public static Unit CreateUnitShip(string unitType)
        {
            switch (unitType)
            {
                case "катер":
                    return new Powerboat();
            }

            return null;
        }
    }
}

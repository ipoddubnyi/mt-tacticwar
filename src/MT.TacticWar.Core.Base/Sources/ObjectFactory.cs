using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    public static class ObjectFactory
    {
        public static readonly List<DivisionVariant> Divisions = new List<DivisionVariant>()
        {
            new DivisionVariant { Code = "infantry",  Type = typeof(Infantry) },
            new DivisionVariant { Code = "vehicle",   Type = typeof(Vehicle) },
            new DivisionVariant { Code = "ship",      Type = typeof(Ship) },
            new DivisionVariant { Code = "navy",      Type = typeof(Navy) },
            new DivisionVariant { Code = "artillery", Type = typeof(Artillery) },
            new DivisionVariant { Code = "aviation",  Type = typeof(Aviation) },
            new DivisionVariant { Code = "engineers", Type = typeof(Engineers) }
        };

        public static readonly List<BuildingVariant> Buildings = new List<BuildingVariant>()
        {
            new BuildingVariant { Code = "factory",       Type = typeof(Factory) },
            new BuildingVariant { Code = "barracks",      Type = typeof(Barracks) },
            new BuildingVariant { Code = "storehouse",    Type = typeof(Storehouse) },
            new BuildingVariant { Code = "radar",         Type = typeof(Radar) },
            new BuildingVariant { Code = "airfield",      Type = typeof(Airfield) },
            new BuildingVariant { Code = "port",          Type = typeof(Port) },
            new BuildingVariant { Code = "shipyard",      Type = typeof(Shipyard) },

            new BuildingVariant { Code = "house",         Type = typeof(CityHouse) },
            new BuildingVariant { Code = "hut",           Type = typeof(VillageHut) },
            new BuildingVariant { Code = "church",        Type = typeof(Church) }
        };

        public static string GetDivisionCode(Division division)
        {
            foreach (var div in Divisions)
            {
                if (div.Type.Equals(division.GetType()))
                    return div.Code;
            }

            throw new Exception("Неизвестный тип подразделения.");
        }

        public static string GetBuildingCode(Building building)
        {
            foreach (var bld in Buildings)
            {
                if (bld.Type.Equals(building.GetType()))
                    return bld.Code;
            }

            throw new Exception("Неизвестный тип строения.");
        }

        public static Division CreateDivision(string code, Player player, int id, string name, int x, int y)
        {
            foreach (var div in Divisions)
            {
                if (div.Code == code)
                    return div.Create(player, id, name, x, y);
            }

            throw new Exception("Неизвестный тип подразделения.");
        }

        public static Building CreateBuilding(string code, Player player, int id, string name, int x, int y, int health, Division security)
        {
            foreach (var bld in Buildings)
            {
                if (bld.Code == code)
                    return bld.Create(player, id, name, x, y, health, security);
            }

            throw new Exception("Неизвестный тип строения.");
        }

        public static bool CompareDivisionType(Division division, string code)
        {
            foreach (var div in Divisions)
            {
                if (div.Code == code)
                    return div.Type.Equals(division.GetType());
            }

            throw new Exception("Неизвестный тип подразделения.");
        }
    }
}

using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Utils;

namespace MT.TacticWar.Core.Base.Objects
{
    public static class ObjectFactory
    {
        public static readonly List<DivisionCreator> Divisions = new List<DivisionCreator>()
        {
            new DivisionCreator(typeof(Infantry)),
            new DivisionCreator(typeof(Vehicle)),
            new DivisionCreator(typeof(Train)),
            new DivisionCreator(typeof(Ship)),
            new DivisionCreator(typeof(Navy)),
            new DivisionCreator(typeof(Artillery)),
            new DivisionCreator(typeof(Aviation)),
            new DivisionCreator(typeof(Engineers))
        };

        public static readonly List<BuildingCreator> Buildings = new List<BuildingCreator>()
        {
            new BuildingCreator(typeof(Factory)),
            new BuildingCreator(typeof(Barracks)),
            new BuildingCreator(typeof(Storehouse)),
            new BuildingCreator(typeof(Radar)),
            new BuildingCreator(typeof(Airfield)),
            new BuildingCreator(typeof(Port)),
            new BuildingCreator(typeof(Shipyard)),

            new BuildingCreator(typeof(CityHouse)),
            new BuildingCreator(typeof(VillageHut)),
            new BuildingCreator(typeof(Church))
        };

        public static Division CreateDivision(string code, Player player, int id, string name, int x, int y)
        {
            foreach (var div in Divisions)
            {
                if (div.GetCode().Equals(code))
                    return div.Create(player, id, name, x, y);
            }

            throw new Exception("Неизвестный тип подразделения.");
        }

        public static Division CreateDivisionSupport(string code, int id, string name)
        {
            return CreateDivision(code, null, id, name, -1, -1);
        }

        public static Building CreateBuilding(string code, Player player, int id, string name, int x, int y, int health, Division security)
        {
            foreach (var bld in Buildings)
            {
                if (bld.GetCode().Equals(code))
                    return bld.Create(player, id, name, x, y, health, security);
            }

            throw new Exception("Неизвестный тип строения.");
        }

        public static bool CompareDivisionType(Division division, string code)
        {
            foreach (var div in Divisions)
            {
                if (div.GetCode().Equals(code))
                    return div.Type.Equals(division.GetType());
            }

            throw new Exception("Неизвестный тип подразделения.");
        }
    }
}

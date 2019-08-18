using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    public static class ObjectFactory
    {
        public static readonly List<DivisionVariant> Divisions = new List<DivisionVariant>()
        {
            new DivisionVariant { Name = "Пехота",          Code = "infantry",  Type = typeof(Infantry) },
            new DivisionVariant { Name = "Бронетехника",    Code = "vehicle",   Type = typeof(Vehicle) },
            new DivisionVariant { Name = "Малый флот",      Code = "ship",      Type = typeof(Ship) },
            new DivisionVariant { Name = "Большой флот",    Code = "navy",      Type = typeof(Navy) },
            new DivisionVariant { Name = "Артиллерия",      Code = "artillery", Type = typeof(Artillery) },
            new DivisionVariant { Name = "Авиация",         Code = "aviation",  Type = typeof(Aviation) },
            new DivisionVariant { Name = "Стройбат",        Code = "engineers", Type = typeof(Engineers) }
        };

        public static readonly List<BuildingVariant> Buildings = new List<BuildingVariant>()
        {
            new BuildingVariant { Name = "Завод",           Code = "factory",       Type = typeof(Factory) },
            new BuildingVariant { Name = "Казармы",         Code = "barracks",      Type = typeof(Barracks) },
            new BuildingVariant { Name = "Склад",           Code = "storehouse",    Type = typeof(Storehouse) },
            new BuildingVariant { Name = "Радар",           Code = "radar",         Type = typeof(Radar) },
            new BuildingVariant { Name = "Аэродром",        Code = "airfield",      Type = typeof(Airfield) },
            new BuildingVariant { Name = "Порт",            Code = "port",          Type = typeof(Port) },
            new BuildingVariant { Name = "Верфь",           Code = "shipyard",      Type = typeof(Shipyard) },

            new BuildingVariant { Name = "Городской дом",   Code = "house",         Type = typeof(CityHouse) },
            new BuildingVariant { Name = "Сельский дом",    Code = "hut",           Type = typeof(VillageHut) },
            new BuildingVariant { Name = "Церковь",         Code = "church",        Type = typeof(Church) }
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

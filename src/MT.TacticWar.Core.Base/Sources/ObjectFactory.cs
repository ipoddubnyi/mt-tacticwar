using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    public static class ObjectFactory
    {
        public static Dictionary<string, string> GetAvailableDivisionTypes()
        {
            return new Dictionary<string, string>
            {
                { "Пехота", "infantry" },
                { "Бронетехника", "vehicle" },
                { "Малый флот", "ship" },
                { "Большой флот", "navy" },
                { "Артиллерия", "artillery" },
                { "Авиация", "aviation" }
            };
        }

        public static Dictionary<string, string> GetAvailableBuildingTypes()
        {
            return new Dictionary<string, string>
            {
                { "Завод", "factory" },
                { "Казармы", "barracks" },
                { "Склад", "storehouse" },
                { "Радар", "radar" },
                { "Аэродром", "airfield" },
                { "Порт", "port" },
                { "Верфь", "shipyard" },

                { "Городской дом", "house" },
                { "Сельский дом", "hut" },
                { "Церковь", "church" }
            };
        }

        public static string GetDivisionCode(Division division)
        {
            if (division is Infantry)
                return "infantry";

            if (division is Vehicle)
                return "vehicle";

            if (division is Ship)
                return "ship";

            if (division is Navy)
                return "navy";

            if (division is Artillery)
                return "artillery";

            if (division is Aviation)
                return "aviation";

            throw new Exception("Неизвестный тип подразделения.");
        }

        public static string GetBuildingCode(Building building)
        {
            if (building is Factory)
                return "factory";
            if (building is Barracks)
                return "barracks";
            if (building is Storehouse)
                return "storehouse";
            if (building is Radar)
                return "radar";
            if (building is Airfield)
                return "airfield";
            if (building is Port)
                return "port";
            if (building is Shipyard)
                return "shipyard";

            if (building is CityHouse)
                return "house";
            if (building is VillageHut)
                return "hut";
            if (building is Church)
                return "church";

            throw new Exception("Неизвестный тип строения.");
        }

        public static Division CreateDivision(string code, Player player, int id, string name, int x, int y)
        {
            switch (code)
            {
                case "infantry":
                    return new Infantry(player, id, name, x, y);
                case "vehicle":
                    return new Vehicle(player, id, name, x, y);
                case "ship":
                    return new Ship(player, id, name, x, y);
                case "navy":
                    return new Navy(player, id, name, x, y);
                case "artillery":
                    return new Artillery(player, id, name, x, y);
                case "aviation":
                    return new Aviation(player, id, name, x, y);
            }

            throw new Exception("Неизвестный тип подразделения.");
        }

        public static bool CompareDivisionType(Division division, string code)
        {
            switch (code)
            {
                case "infantry":
                    return division is Infantry;
                case "vehicle":
                    return division is Vehicle;
                case "ship":
                    return division is Ship;
                case "navy":
                    return division is Navy;
                case "artillery":
                    return division is Artillery;
                case "aviation":
                    return division is Aviation;
            }

            throw new Exception("Неизвестный тип подразделения.");
        }

        public static Building CreateBuilding(string code, Player player, int id, string name, int x, int y, int health, Division security)
        {
            switch (code)
            {
                case "factory":
                    return new Factory(player, id, name, x, y, health, security);
                case "barracks":
                    return new Barracks(player, id, name, x, y, health, security);
                case "storehouse":
                    return new Storehouse(player, id, name, x, y, health, security);
                case "radar":
                    return new Radar(player, id, name, x, y, health, security);
                case "airfield":
                    return new Airfield(player, id, name, x, y, health, security);
                case "port":
                    return new Port(player, id, name, x, y, health, security);
                case "shipyard":
                    return new Shipyard(player, id, name, x, y, health, security);

                case "house":
                    return new CityHouse(player, id, name, x, y, health, security);
                case "hut":
                    return new VillageHut(player, id, name, x, y, health, security);
                case "church":
                    return new Church(player, id, name, x, y, health, security);
            }

            throw new Exception("Неизвестный тип строения.");
        }
    }
}

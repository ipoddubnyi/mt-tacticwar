using System;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    public static class ObjectFactory
    {
        public static Division CreateDivision(string type, Player player, int id, string name, int x, int y)
        {
            switch (type)
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

        public static Building CreateBuilding(string type, Player player, int id, string name, int x, int y, int health, int radius, int view, Division security)
        {
            switch (type)
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

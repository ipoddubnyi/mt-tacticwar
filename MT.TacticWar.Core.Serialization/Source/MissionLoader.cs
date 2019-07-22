﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Players;
using MT.TacticWar.Core.Types;

namespace MT.TacticWar.Core.Serialization
{
    public class MissionLoader
    {
        public static Mission LoadGame(string misFolderPath)
        {
            var infoPath = Path.Combine(misFolderPath, ".info");

            var info = InfoRoot.Deserialize(infoPath);
            var mapPath = Path.Combine(misFolderPath, info.Map.Path);
            var misPath = Path.Combine(misFolderPath, info.Mission.Path);

            var map = LoadMap(mapPath);
            var mis = LoadMission(misPath, map);
            return mis;
        }

        public static Map LoadMap(string filePath)
        {
            var mp = MapRoot.Deserialize(filePath);

            var name = mp.Info.Name;
            var width = mp.Info.Size.Width;
            var height = mp.Info.Size.Height;

            var landlines = MapLandscapeSplit(mp.Landscape, width);
            if (landlines.Length != height)
                throw new FormatException("Неверный формат карты ландшафта.");

            var impasslines = MapLandscapeSplit(mp.Impassability, width);
            if (impasslines.Length != height)
                throw new FormatException("Неверный формат карты проходимости.");

            var field = LoadMapField(width, height, landlines);
            field = LoadMapField(width, height, field, impasslines);

            return new Map(width, height)
            {
                Name = name,
                Field = field
            };
        }

        private static Cell[,] LoadMapField(int width, int height, string[] landlines)
        {
            var field = new Cell[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var type = (CellType)int.Parse(landlines[y].Substring(x, 1));
                    field[x, y] = new Cell(x, y, type);
                }
            }
            return field;
        }

        private static Cell[,] LoadMapField(int width, int height, Cell[,] field, string[] impasslines)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // определяем проходимость ячейки (проходима, если 0)
                    if (0 == int.Parse(impasslines[y].Substring(x, 1)))
                    {
                        field[x, y].Passable = true;
                        //Field[k, l].PassCost = Cell.GetPassCost(Field[k, l].Type);
                    }
                    else
                    {
                        field[x, y].Passable = false;
                        field[x, y].PassCost = int.MaxValue;
                    }
                }
            }
            return field;
        }

        private static string[] MapLandscapeSplit(string landscape, int chunkSize)
        {
            landscape = new string(landscape.Where(c => !char.IsWhiteSpace(c)).ToArray());
            return Enumerable.Range(0, landscape.Length / chunkSize)
                .Select(i => landscape.Substring(i * chunkSize, chunkSize)).ToArray();
        }

        public static Mission LoadMission(string filePath, Map map)
        {
            var mis = MissionRoot.Deserialize(filePath);

            var players = LoadMissionPlayers(mis);
            return new Mission(
                mis.Info.Name,
                mis.Info.Description,
                (MissionMode)mis.Info.Mode,
                players,
                map
            );
        }

        private static Player[] LoadMissionPlayers(MissionRoot mis)
        {
            var players = new List<Player>();
            foreach (var pl in mis.Players)
            {
                var player = LoadMissionPlayer(pl);
                players.Add(player);
            }

            return players.ToArray();
        }

        private static Player LoadMissionPlayer(MissionPlayer pl)
        {
            var divisions = LoadMissionPlayerDivisions(pl);
            var buildings = LoadMissionPlayerBuildings(pl, divisions);

            var player = new Player(pl.Id, pl.Name, pl.AI);
            player.Rank = (PlayerRank)pl.Rank;
            player.Money = pl.Money;
            player.Divisions = divisions;
            player.Buildings = buildings;
            player.Gates = GetPlayerGates(pl);

            return player;
        }

        private static List<Division> LoadMissionPlayerDivisions(MissionPlayer pl)
        {
            var divisions = new List<Division>();
            foreach (var div in pl.Divisions)
            {
                var units = new List<StructUnits>();
                foreach (var u in div.Units)
                {
                    units.Add(new StructUnits()
                    {
                        unit = CreateUnitByType(u.Type),
                        count = u.Count
                    });
                }

                divisions.Add(new Division(
                    pl.Id,
                    div.Id,
                    div.Type,
                    div.Name,
                    div.Position.X,
                    div.Position.Y,
                    units
                ));
            }

            return divisions;
        }

        private static List<Building> LoadMissionPlayerBuildings(MissionPlayer pl, List<Division> divisions)
        {
            var buildings = new List<Building>();
            foreach (var bld in pl.Buildings)
            {
                var security = bld.Security.HasValue ? divisions.GetById(bld.Security.Value) : null;

                buildings.Add(new Building(
                    pl.Id,
                    bld.Id,
                    bld.Type,
                    bld.Name,
                    bld.Position.X,
                    bld.Position.Y,
                    bld.Health,
                    bld.Radius,
                    bld.View,
                    bld.Security.HasValue,
                    security
                ));
            }

            return buildings;
        }

        private static List<Gate> GetPlayerGates(MissionPlayer pl)
        {
            var gates = new List<Gate>();
            foreach (var gate in pl.Gates)
            {
                gates.Add(new Gate(gate.Id, gate.X, gate.Y));
            }
            return gates;
        }

        private static Unit CreateUnitByType(string type)
        {
            switch (type)
            {
                case "soldier":
                    return new CuiSoldiers(0);
                case "saboteur":
                    return new CuiDiversionGroup(0);
                case "igor":
                    return new CuiPoddubnyy(0);
                case "partizan":
                    return new CuiPartizans(0);

                //

                case "tank":
                    return new CuvTankMiddle(0);
                case "tankheavy":
                    return new CuvTankHeavy(0);
                case "antiair":
                    return new CuvZRK(0);
                case "motorized":
                    return new CuvMotopehota(0);
            }

            return null;
        }
    }
}
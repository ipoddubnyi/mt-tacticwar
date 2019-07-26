﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Players;

namespace MT.TacticWar.Core.Serialization
{
    public class MissionLoader
    {
        public static Mission LoadGame(string misFolderPath)
        {
            var infoPath = Path.Combine(misFolderPath, ".info");

            var info = SerialFileInfo.Deserialize(infoPath);
            var mapPath = Path.Combine(misFolderPath, info.Map.Path);
            var misPath = Path.Combine(misFolderPath, info.Mission.Path);

            var map = LoadMap(mapPath);
            var mis = LoadMission(misPath, map);
            return mis;
        }

        public static Map LoadMap(string filePath)
        {
            var mp = SerialMap.Deserialize(filePath);

            var name = mp.Info.Name;
            var width = mp.Info.Size.Width;
            var height = mp.Info.Size.Height;
            var schema = (MapSchema)mp.Info.Schema;

            var landlines = MapLandscapeSplit(mp.Landscape, width);
            if (landlines.Length != height)
                throw new FormatException("Неверный формат карты ландшафта.");

            var impasslines = MapLandscapeSplit(mp.Impassability, width);
            if (impasslines.Length != height)
                throw new FormatException("Неверный формат карты проходимости.");

            var field = LoadMapField(width, height, schema, landlines);
            field = LoadMapFieldPassable(width, height, field, impasslines);

            return new Map(name, width, height, field, schema);
        }

        private static Cell[,] LoadMapField(int width, int height, MapSchema schema, string[] landlines)
        {
            var field = new Cell[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var type = (CellType)int.Parse(landlines[y].Substring(x, 1));
                    field[x, y] = new Cell(x, y, schema, type);
                }
            }
            return field;
        }

        private static Cell[,] LoadMapFieldPassable(int width, int height, Cell[,] field, string[] impasslines)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // определяем проходимость ячейки (проходима, если 0)
                    if (0 == int.Parse(impasslines[y].Substring(x, 1)))
                    {
                        field[x, y].Passable = true;
                        //Field[k, l].PassCost = Cell.GetPassCost(Field[k, l].Team);
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

        private static string MissionTextTrim(string text)
        {
            var buffer = new StringBuilder();
            using (TextReader sr = new StringReader(text))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    buffer.AppendLine(line.Trim());
                }
            }
            return buffer.ToString().Trim();
        }

        public static Mission LoadMission(string filePath, Map map)
        {
            var mis = SerialMission.Deserialize(filePath);

            var players = LoadMissionPlayers(mis);
            return new Mission(
                mis.Info.Name,
                MissionTextTrim(mis.Info.Description),
                (MissionMode)mis.Info.Mode,
                players,
                map
            );
        }

        private static Player[] LoadMissionPlayers(SerialMission mis)
        {
            var players = new List<Player>();
            foreach (var pl in mis.Players)
            {
                var player = LoadMissionPlayer(pl, mis.Types);
                players.Add(player);
            }

            return players.ToArray();
        }

        private static Player LoadMissionPlayer(SerialPlayer pl, SerialMissionTypes types)
        {
            var player = new Player(
                pl.Id,
                pl.Name,
                pl.Team,
                (PlayerColor)pl.Color,
                (PlayerRank)pl.Rank,
                pl.Money,
                pl.AI
            );

            player.Divisions = LoadMissionPlayerDivisions(pl, types, player);
            player.Buildings = LoadMissionPlayerBuildings(pl, player);
            player.Gates = GetPlayerGates(pl);

            return player;
        }

        private static List<Division> LoadMissionPlayerDivisions(SerialPlayer pl, SerialMissionTypes types, Player player)
        {
            var divisions = new List<Division>();
            foreach (var div in pl.Divisions)
            {
                var units = new List<Unit>();
                foreach (var un in div.Units)
                {
                    units.Add(CreateUnit(un, types));
                }

                divisions.Add(new Division(
                    player,
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

        private static List<Building> LoadMissionPlayerBuildings(SerialPlayer pl, Player player)
        {
            var buildings = new List<Building>();
            foreach (var bld in pl.Buildings)
            {
                var security = bld.Security.HasValue ?
                    player.Divisions.GetById(bld.Security.Value) :
                    null;

                buildings.Add(new Building(
                    player,
                    bld.Id,
                    bld.Type,
                    bld.Name,
                    bld.Position.X,
                    bld.Position.Y,
                    bld.Health,
                    bld.Radius,
                    bld.View,
                    security
                ));
            }

            return buildings;
        }

        private static List<Gate> GetPlayerGates(SerialPlayer pl)
        {
            var gates = new List<Gate>();
            foreach (var gate in pl.Gates)
            {
                gates.Add(new Gate(gate.Id, gate.X, gate.Y));
            }
            return gates;
        }

        private static Unit CreateUnit(SerialUnit u, SerialMissionTypes types)
        {
            var unit = CreateUnitByBaseType(u.Type);
            if (null != unit)
                return u.Update(unit);

            unit = CreateUnitByCustomType(u.Type, types);
            if (null != unit)
                return u.Update(unit);

            throw new Exception($"Неизвестный тип юнита {u.Type}");
        }

        private static Unit CreateUnitByBaseType(string type)
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

        private static Unit CreateUnitByCustomType(string type, SerialMissionTypes types)
        {
            foreach (var unittype in types.Units)
            {
                if (unittype.Type.Equals(type))
                    return unittype.Create();
            }

            return null;
        }
    }
}
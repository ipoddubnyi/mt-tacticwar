using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MT.TacticWar.Core.Base.Landscape;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Base.Scripts;
using MT.TacticWar.Core.Base.Units;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Players;
using MT.TacticWar.Core.Scripts;

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
            var schema = mp.Info.Schema;

            var landlines = MapLandscapeSplit(mp.Landscape, width);
            if (landlines.Length != height)
                throw new FormatException("Неверный формат карты ландшафта.");

            var impasslines = MapLandscapeSplit(mp.Impassability, width);
            if (impasslines.Length != height)
                throw new FormatException("Неверный формат карты проходимости.");

            var field = LoadMapField(width, height, schema, landlines);
            field = LoadMapFieldPassable(width, height, field, impasslines);

            return new Map(name, width, height, field);
        }

        private static Cell[,] LoadMapField(int width, int height, string schema, string[] landlines)
        {
            var field = new Cell[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //var type = (CellType)int.Parse(landlines[y].Substring(x, 1));
                    //field[x, y] = new Cell(x, y, schema, type);
                    field[x, y] = LandscapeFactory.CreateCell(schema, landlines[y].Substring(x, 1)[0], x, y);
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
            var zones = LoadMissionZones(mis);
            var scripts = LoadMissionScripts(mis);
            return new Mission(
                mis.Info.Name,
                MissionTextTrim(mis.Info.Description),
                players,
                zones,
                scripts,
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
                pl.Color,
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
                var division = ObjectFactory.CreateDivision(
                    div.Type,
                    player,
                    div.Id,
                    div.Name,
                    div.Position.X,
                    div.Position.Y
                );

                var units = new List<Unit>();
                foreach (var un in div.Units)
                {
                    units.Add(CreateUnit(division, un, types));
                }

                division.CompleteWithUnits(units);
                divisions.Add(division);
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

                buildings.Add(ObjectFactory.CreateBuilding(
                    bld.Type,
                    player,
                    bld.Id,
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

        private static Unit CreateUnit(Division division, SerialUnit u, SerialMissionTypes types)
        {
            var unit = UnitFactory.CreateUnit(u.Id, division, u.Type);
            if (null != unit)
                return u.Update(unit);

            unit = CreateUnitByCustomType(u.Id, division, u.Type, types);
            if (null != unit)
                return u.Update(unit);

            throw new Exception($"Неизвестный тип юнита {u.Type}");
        }

        private static Unit CreateUnitByCustomType(int id, Division division, string type, SerialMissionTypes types)
        {
            foreach (var unittype in types.Units)
            {
                if (ObjectFactory.CompareDivisionType(division, unittype.DivisionType) && unittype.Type.Equals(type))
                    return unittype.Create(id, division);
            }

            return null;
        }

        private static Zone[] LoadMissionZones(SerialMission mis)
        {
            var zones = new List<Zone>();
            foreach (var zn in mis.Zones)
            {
                var points = new List<Coordinates>(zn.Points.Length);
                foreach (var pt in zn.Points)
                {
                    points.Add(new Coordinates(pt.X, pt.Y));
                }

                var zone = new Zone(zn.Id, points.ToArray());
                zones.Add(zone);
            }

            return zones.ToArray();
        }

        private static Script[] LoadMissionScripts(SerialMission mis)
        {
            var scripts = new List<Script>();
            foreach (var sc in mis.Scripts)
            {
                var script = new Script(
                    ScriptFactory.CreateCondition(sc.Condition.Type, sc.Condition.GetArguments()),
                    ScriptFactory.CreateStatement(sc.Statement.Type, sc.Statement.GetArguments())
                );
                scripts.Add(script);
            }

            return scripts.ToArray();
        }
    }
}

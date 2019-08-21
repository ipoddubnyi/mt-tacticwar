using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    public class MissionSaver
    {
        public static void SaveGame(string gameName, string mapFileName, string misFileName,
            Mission mission, string versionMap, string versionMission)
        {
            var missionsFolder = Path.Combine(
                        Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                        "missions");
            var gameFolder = Path.Combine(missionsFolder, gameName);
            var infoPath = Path.Combine(gameFolder, ".info");

            var mapPath = Path.Combine(gameFolder, mapFileName);
            var misPath = Path.Combine(gameFolder, misFileName);
            var info = new SerialFileInfo
            {
                Map = new SerialFileInfoType
                {
                    Version = versionMap,
                    Path = ""
                },
                Mission = new SerialFileInfoType
                {
                    Version = versionMission,
                    Path = ""
                }
            };

            SaveMap(mapPath, mission.Map, versionMap);
            SaveMission(misPath, mission, versionMission);

            SerialFileInfo.Serialize(infoPath, info);
        }

        public static void SaveMap(string filePath, Map map, string version)
        {
            SaveMap(filePath, map, map.Name, map.Description, version);
        }

        public static void SaveMap(string filePath, Map map, string name, string descr, string version)
        {
            var mp = new SerialMap();

            mp.Info = new SerialMapInfo() {
                Name = name,
                Description = descr,
                Schema = Schema.GetSchemaCode(map.Schema),
                Size = new SerialSize() { Width = map.Width, Height = map.Height },
                Version = version
            };
            mp.Landscape = MapLandscapeToString(map.Field, map.Width, map.Height, map.Schema);
            mp.Impassability = MapImpassabilityToString(map.Field, map.Width, map.Height);
            mp.Cells = null;

            // TODO: отрефакторить создание папки
            var dirPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            SerialMap.Serialize(filePath, mp);
        }

        private static string MapLandscapeToString(Cell[,] cells, int width, int height, Schema schema)
        {
            var sb = new StringBuilder();
            for (int y = 0; y < height; y++)
            {
                sb.Append(Environment.NewLine);
                sb.Append("        ");
                for (int x = 0; x < width; x++)
                {
                    sb.Append(Cell.GetCellCode(cells[x, y]));
                }
            }
            sb.Append(Environment.NewLine);
            sb.Append("    ");
            return sb.ToString();
        }

        private static string MapImpassabilityToString(Cell[,] cells, int width, int height)
        {
            var sb = new StringBuilder();
            for (int y = 0; y < height; y++)
            {
                sb.Append(Environment.NewLine);
                sb.Append("        ");
                for (int x = 0; x < width; x++)
                {
                    sb.Append(cells[x, y].Passable ? '0' : '1');
                }
            }
            sb.Append(Environment.NewLine);
            sb.Append("    ");
            return sb.ToString();
        }

        public static void SaveMission(string filePath, Mission mission, string version)
        {
            SaveMission(filePath, mission, mission.Name, mission.Briefing, version);
        }

        public static void SaveMission(string filePath, Mission mission, string name, string brief, string version)
        {
            var mis = new SerialMission();

            mis.Info = new SerialMissionInfo()
            {
                Name = name,
                Description = MissionBriefing(brief),
                Version = version
            };

            mis.Players = MissionPlayers(mission);
            //mis.Types = 
            mis.Zones = MissionZones(mission.Zones);
            mis.Scripts = MissionScripts(mission.Scripts);

            // TODO: отрефакторить создание папки
            var dirPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            SerialMission.Serialize(filePath, mis);
        }

        private static string MissionBriefing(string briefing)
        {
            var lines = briefing.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            var sb = new StringBuilder();
            foreach (var line in lines)
            {
                sb.Append(Environment.NewLine);
                sb.Append("        ");
                sb.Append(line);
            }
            sb.Append(Environment.NewLine);
            sb.Append("    ");
            return sb.ToString();
        }

        private static SerialPlayer[] MissionPlayers(Mission mis)
        {
            var players = new List<SerialPlayer>();
            foreach (var pl in mis.Players)
            {
                var player = MissionPlayer(pl, null);
                players.Add(player);
            }

            return players.ToArray();
        }

        private static SerialPlayer MissionPlayer(Player pl, SerialMissionTypes types)
        {
            var player = new SerialPlayer()
            {
                Id = pl.Id,
                Name = pl.Name,
                Team = pl.Team,
                Color = pl.Color,
                Rank = (int)pl.Rank,
                Money = pl.Money,
                AI = pl.AI == PlayerIntelligence.AI
            };

            player.Divisions = MissionPlayerDivisions(pl, types);
            player.Buildings = MissionPlayerBuildings(pl);
            player.Gates = MissionPlayerGates(pl);

            return player;
        }

        private static SerialDivision[] MissionPlayerDivisions(Player pl, SerialMissionTypes types)
        {
            var divisions = new List<SerialDivision>();
            foreach (var division in pl.Divisions)
            {
                divisions.Add(new SerialDivision(division));
            }
            return divisions.ToArray();
        }

        private static SerialBuilding[] MissionPlayerBuildings(Player pl)
        {
            var buildings = new List<SerialBuilding>();
            foreach (var building in pl.Buildings)
            {
                buildings.Add(new SerialBuilding(building));
            }
            return buildings.ToArray();
        }

        private static SerialGate[] MissionPlayerGates(Player pl)
        {
            var gates = new List<SerialGate>();
            foreach (var gate in pl.Gates)
            {
                var gt = new SerialGate
                {
                    Id = gate.Id,
                    X = gate.X,
                    Y = gate.Y
                };
                gates.Add(gt);
            }
            return gates.ToArray();
        }

        /*private static Unit CreateUnit(Division division, SerialUnit u, SerialMissionTypes types)
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
        }*/

        private static SerialZone[] MissionZones(Zone[] zns)
        {
            var zones = new List<SerialZone>();
            foreach (var zn in zns.Sort())
            {
                var points = new List<SerialPosition>(zn.Points.Length);
                foreach (var pt in zn.Points)
                {
                    points.Add(new SerialPosition() { X = pt.X, Y = pt.Y });
                }

                var zone = new SerialZone()
                {
                    Id = zn.Id,
                    Points = points.ToArray()
                };
                zones.Add(zone);
            }

            return zones.ToArray();
        }

        private static SerialScript[] MissionScripts(Script[] scs)
        {
            var scripts = new List<SerialScript>();
            foreach (var sc in scs)
            {
                var script = new SerialScript()
                {
                    Description = sc.Description
                };

                script.Condition = new SerialScriptEntry()
                {
                    Type = Script.GetScriptCode(sc.Condition),
                    Arguments = MissionScriptArguments(ScriptArgument.GetArguments(sc.Condition))
                };

                script.Statement = new SerialScriptEntry()
                {
                    Type = Script.GetScriptCode(sc.Statement),
                    Arguments = MissionScriptArguments(ScriptArgument.GetArguments(sc.Statement))
                };

                scripts.Add(script);
            }

            return scripts.ToArray();
        }

        private static SerialScriptArgument[] MissionScriptArguments(IEnumerable<ScriptArgument> args)
        {
            var arguments = new List<SerialScriptArgument>();
            foreach (var arg in args)
            {
                arguments.Add(new SerialScriptArgument()
                {
                    Comment = arg.Name,
                    Value = arg.Value
                });
            }
            return arguments.ToArray();
        }
    }
}

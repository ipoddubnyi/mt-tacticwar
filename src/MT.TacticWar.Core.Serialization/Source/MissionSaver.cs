using System.IO;
using System.Reflection;

namespace MT.TacticWar.Core.Serialization
{
    public class MissionSaver
    {
        public static void SaveGame(Mission mission, string gameName,
            string mapFileName, string mapVersion, string misFileName, string misVersion)
        {
            var missionsFolder = Path.Combine(
                        Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                        "missions");
            var gameFolder = Path.Combine(missionsFolder, gameName);
            var infoPath = Path.Combine(gameFolder, ".info");

            var mapPath = Path.Combine(gameFolder, mapFileName);
            var misPath = Path.Combine(gameFolder, misFileName);
            var info = new SerialFileInfo(mapVersion, mapFileName, misVersion, misFileName);

            SaveMap(mapPath, mission.Map, mapVersion);
            SaveMission(misPath, mission, misVersion);

            SerialFileInfo.Serialize(infoPath, info);
        }

        public static void SaveMap(string filePath, Map map, string version)
        {
            var smap = new SerialMap(map, version);

            // TODO: отрефакторить создание папки
            var dirPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            SerialMap.Serialize(filePath, smap);
        }

        public static void SaveMission(string filePath, Mission mission, string version)
        {
            var smission = new SerialMission(mission, version);

            // TODO: отрефакторить создание папки
            var dirPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            SerialMission.Serialize(filePath, smission);
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
    }
}

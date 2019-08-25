using System.IO;

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
            return mp.Create();
        }

        public static Mission LoadMission(string filePath, Map map)
        {
            var mis = SerialMission.Deserialize(filePath);
            return mis.Create(map);
        }
    }
}

using MT.TacticWar.Core.Objects;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    [XmlRoot("mission")]
    public class SerialMission
    {
        [XmlElement("info")]
        public SerialMissionInfo Info { get; set; }

        [XmlArray("players")]
        [XmlArrayItem("player")]
        public SerialPlayer[] Players { get; set; }

        [XmlArray("zones")]
        [XmlArrayItem("zone")]
        public SerialZone[] Zones { get; set; }

        [XmlElement("types")]
        public SerialMissionTypes Types { get; set; }

        [XmlArray("scripts")]
        [XmlArrayItem("script")]
        public SerialScript[] Scripts { get; set; }

        public SerialMission()
        {
            Zones = new SerialZone[0];
            Scripts = new SerialScript[0];
        }

        public SerialMission(Mission mission, string version)
        {
            Info = new SerialMissionInfo(mission, version);
            Players = SerialPlayer.CreateFrom(mission.Players).ToArray();
            //TODO: Types = 
            Zones = SerialZone.CreateFrom(mission.Zones.SortById()).ToArray();
            Scripts = SerialScript.CreateFrom(mission.Scripts).ToArray();
        }

        public Mission Create(Map map)
        {
            var players = SerialPlayer.Create(Players, Types).ToArray();
            var zones = SerialZone.Create(Zones).ToArray();
            var support = SerialMissionTypes.CreateReinforcement(Types).ToArray();
            var scripts = SerialScript.Create(Scripts).ToArray();
            return new Mission(
                Info.Name,
                Info.GetTrimmedBriefing(),
                players,
                zones,
                support,
                scripts,
                map
            );
        }

        public static void Serialize(string filePath, SerialMission mission)
        {
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(SerialMission));
                serializer.Serialize(fs, mission);
            }
        }

        public static SerialMission Deserialize(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(SerialMission));
                return serializer.Deserialize(fs) as SerialMission;
            }
        }
    }
}

using System.IO;
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

        [XmlElement("types")]
        public SerialMissionTypes Types { get; set; }

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

using System.IO;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    [XmlRoot("mission")]
    public class MissionRoot
    {
        [XmlElement("info")]
        public MissionInfo Info { get; set; }

        [XmlArray("players")]
        [XmlArrayItem("player")]
        public MissionPlayer[] Players { get; set; }

        [XmlElement("types")]
        public MissionTypes Types { get; set; }

        public static void Serialize(string filePath, MissionRoot mission)
        {
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(MissionRoot));
                serializer.Serialize(fs, mission);
            }
        }

        public static MissionRoot Deserialize(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(MissionRoot));
                return serializer.Deserialize(fs) as MissionRoot;
            }
        }
    }
}

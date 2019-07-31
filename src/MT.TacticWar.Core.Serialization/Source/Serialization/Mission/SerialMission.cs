using System;
using System.IO;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    [Serializable]
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

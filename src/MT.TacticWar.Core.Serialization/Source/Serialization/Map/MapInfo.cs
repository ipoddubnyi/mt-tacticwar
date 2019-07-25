using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class MapInfo
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("desc")]
        public string Description { get; set; }

        [XmlElement("version")]
        public string Version { get; set; }

        [XmlElement("size")]
        public MapSize Size { get; set; }

        [XmlElement("schema")]
        public int Schema { get; set; }
    }
}

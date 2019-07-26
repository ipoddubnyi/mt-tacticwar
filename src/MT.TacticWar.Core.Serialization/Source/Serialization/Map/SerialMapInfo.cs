using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialMapInfo
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("desc")]
        public string Description { get; set; }

        [XmlElement("version")]
        public string Version { get; set; }

        [XmlElement("size")]
        public SerialSize Size { get; set; }

        [XmlElement("schema")]
        public int Schema { get; set; }
    }
}

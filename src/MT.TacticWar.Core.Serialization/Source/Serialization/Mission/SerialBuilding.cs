using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialBuilding
    {
        [XmlAttribute("id")]
        public char Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public int Type { get; set; }

        [XmlElement("position")]
        public SerialPosition Position { get; set; }

        [XmlElement("health")]
        public int Health { get; set; }

        [XmlElement("radius")]
        public int Radius { get; set; }

        [XmlElement("view")]
        public int View { get; set; }

        [XmlElement("security", IsNullable = true)]
        public int? Security { get; set; }
    }
}

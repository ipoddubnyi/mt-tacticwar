using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialDivision
    {
        [XmlAttribute("id")]
        public char Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public int Type { get; set; }

        [XmlElement("position")]
        public SerialPosition Position { get; set; }

        [XmlArray("units")]
        [XmlArrayItem("unit")]
        public SerialUnit[] Units { get; set; }
    }
}

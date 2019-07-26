using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialPlayer
    {
        [XmlAttribute("id")]
        public char Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("team")]
        public int Team { get; set; }

        [XmlAttribute("color")]
        public int Color { get; set; }

        [XmlAttribute("rank")]
        public int Rank { get; set; }

        [XmlAttribute("money")]
        public int Money { get; set; }

        [XmlAttribute("ai")]
        public bool AI { get; set; }

        [XmlArray("divisions")]
        [XmlArrayItem("division")]
        public SerialDivision[] Divisions { get; set; }

        [XmlArray("buildings")]
        [XmlArrayItem("building")]
        public SerialBuilding[] Buildings { get; set; }

        [XmlArray("gates")]
        [XmlArrayItem("gate")]
        public SerialZone[] Gates { get; set; }
    }
}

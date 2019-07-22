using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class MissionPlayer
    {
        [XmlAttribute("id")]
        public char Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("rank")]
        public int Rank { get; set; }

        [XmlAttribute("money")]
        public int Money { get; set; }

        [XmlAttribute("ai")]
        public bool AI { get; set; }

        [XmlArray("divisions")]
        [XmlArrayItem("division")]
        public MissionDivision[] Divisions { get; set; }

        [XmlArray("buildings")]
        [XmlArrayItem("building")]
        public MissionBuilding[] Buildings { get; set; }

        [XmlArray("gates")]
        [XmlArrayItem("gate")]
        public MissionGate[] Gates { get; set; }
    }
}

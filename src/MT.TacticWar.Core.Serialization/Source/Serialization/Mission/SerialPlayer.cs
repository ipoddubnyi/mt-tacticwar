using System;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    [Serializable]
    public class SerialPlayer
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("team")]
        public int Team { get; set; }

        [XmlAttribute("color")]
        public string Color { get; set; }

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
        public SerialGate[] Gates { get; set; }
    }
}

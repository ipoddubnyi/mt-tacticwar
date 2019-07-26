using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialCell
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("passable")]
        public bool Passable { get; set; }

        [XmlAttribute("passcost")]
        public int PassCost { get; set; }

        [XmlAttribute("color")]
        public string Color { get; set; }

        [XmlAttribute("image")]
        public string Image { get; set; }
    }
}

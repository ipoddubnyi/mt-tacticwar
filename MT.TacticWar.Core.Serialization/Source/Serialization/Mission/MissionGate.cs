using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class MissionGate
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("x")]
        public int X { get; set; }

        [XmlAttribute("y")]
        public int Y { get; set; }
    }
}

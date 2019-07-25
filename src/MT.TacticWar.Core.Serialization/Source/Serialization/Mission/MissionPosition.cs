using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class MissionPosition
    {
        [XmlAttribute("x")]
        public int X { get; set; }

        [XmlAttribute("y")]
        public int Y { get; set; }
    }
}

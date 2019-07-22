using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class MissionUnit
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("count")]
        public int Count { get; set; }
    }
}

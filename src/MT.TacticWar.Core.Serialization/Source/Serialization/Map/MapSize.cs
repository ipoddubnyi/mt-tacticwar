using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class MapSize
    {
        [XmlAttribute("width")]
        public int Width { get; set; }

        [XmlAttribute("height")]
        public int Height { get; set; }
    }
}

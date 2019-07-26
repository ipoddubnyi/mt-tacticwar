using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialZone : SerialPosition
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}

using System;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    [Serializable]
    public class SerialZone
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("point")]
        public SerialPosition[] Points { get; set; }
    }
}

using System;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    [Serializable]
    public class SerialZone : SerialPosition
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}

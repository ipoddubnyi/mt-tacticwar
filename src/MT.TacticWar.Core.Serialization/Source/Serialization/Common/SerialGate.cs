using System;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    [Serializable]
    public class SerialGate : SerialPosition
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}

using System;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    [Serializable]
    public class SerialPosition
    {
        [XmlAttribute("x")]
        public int X { get; set; }

        [XmlAttribute("y")]
        public int Y { get; set; }
    }
}

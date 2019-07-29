using System;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    [Serializable]
    public class SerialScript
    {
        [XmlAttribute("desc")]
        public string Description { get; set; }

        [XmlElement("condition")]
        public SerialScriptEntry Condition { get; set; }

        [XmlElement("statement")]
        public SerialScriptEntry Statement { get; set; }
    }
}

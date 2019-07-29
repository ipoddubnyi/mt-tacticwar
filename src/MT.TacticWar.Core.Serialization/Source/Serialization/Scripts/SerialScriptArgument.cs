using System;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    [Serializable]
    public class SerialScriptArgument
    {
        [XmlAttribute("comment")]
        public string Comment { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}

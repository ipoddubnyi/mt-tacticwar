using System;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    [Serializable]
    public class SerialFileInfoType
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("path")]
        public string Path { get; set; }
    }
}

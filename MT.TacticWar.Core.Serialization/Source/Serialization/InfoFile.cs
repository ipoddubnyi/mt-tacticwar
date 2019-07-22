using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class InfoFile
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("path")]
        public string Path { get; set; }
    }
}

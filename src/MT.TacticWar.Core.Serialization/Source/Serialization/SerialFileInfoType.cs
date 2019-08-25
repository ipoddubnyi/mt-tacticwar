using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialFileInfoType
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("path")]
        public string Path { get; set; }

        public SerialFileInfoType()
        {
        }

        public SerialFileInfoType(string version, string path)
        {
            Version = version;
            Path = path;
        }
    }
}

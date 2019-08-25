using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialMapInfo
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("desc")]
        public string Description { get; set; }

        [XmlElement("version")]
        public string Version { get; set; }

        [XmlElement("size")]
        public SerialSize Size { get; set; }

        [XmlElement("schema")]
        public string Schema { get; set; }

        public SerialMapInfo()
        {
        }

        public SerialMapInfo(Map map, string version)
        {
            Name = map.Name;
            Description = map.Description;
            Schema = Landscape.Schema.GetSchemaCode(map.Schema);
            Size = new SerialSize(map.Width, map.Height);
            Version = version;
        }
    }
}

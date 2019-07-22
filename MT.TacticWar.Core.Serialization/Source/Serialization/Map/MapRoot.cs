using System.IO;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    [XmlRoot("map")]
    public class MapRoot
    {
        [XmlElement("info", IsNullable = false)]
        public MapInfo Info { get; set; }

        [XmlElement("landscape")]
        public string Landscape { get; set; }

        [XmlElement("impassability")]
        public string Impassability { get; set; }

        [XmlArray("cells")]
        [XmlArrayItem("cell")]
        public MapCell[] Cells { get; set; }

        public static void Serialize(string filePath, MapRoot map)
        {
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(MapRoot));
                serializer.Serialize(fs, map);
            }
        }

        public static MapRoot Deserialize(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(MapRoot));
                return serializer.Deserialize(fs) as MapRoot;
            }
        }
    }
}

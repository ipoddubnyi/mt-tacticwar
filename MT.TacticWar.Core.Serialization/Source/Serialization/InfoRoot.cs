using System.IO;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    [XmlRoot("info")]
    public class InfoRoot
    {
        [XmlElement("mission")]
        public InfoFile Mission { get; set; }

        [XmlElement("map")]
        public InfoFile Map { get; set; }

        public static void Serialize(string filePath, InfoRoot info)
        {
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(InfoRoot));
                serializer.Serialize(fs, info);
            }
        }

        public static InfoRoot Deserialize(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(InfoRoot));
                return serializer.Deserialize(fs) as InfoRoot;
            }
        }
    }
}

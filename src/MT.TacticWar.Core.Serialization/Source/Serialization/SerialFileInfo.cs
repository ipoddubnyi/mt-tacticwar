using System.IO;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    [XmlRoot("info")]
    public class SerialFileInfo
    {
        [XmlElement("mission")]
        public SerialFileInfoType Mission { get; set; }

        [XmlElement("map")]
        public SerialFileInfoType Map { get; set; }

        public SerialFileInfo()
        {
        }

        public SerialFileInfo(string mapVersion, string mapFilePath, string misVersion, string misFilePath)
        {
            Map = new SerialFileInfoType(mapVersion, mapFilePath);
            Mission = new SerialFileInfoType(misVersion, misFilePath);
        }

        public static void Serialize(string filePath, SerialFileInfo info)
        {
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(SerialFileInfo));
                serializer.Serialize(fs, info);
            }
        }

        public static SerialFileInfo Deserialize(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(SerialFileInfo));
                return serializer.Deserialize(fs) as SerialFileInfo;
            }
        }
    }
}

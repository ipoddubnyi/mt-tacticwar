﻿using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    [XmlRoot("map")]
    public class SerialMap
    {
        [XmlElement("info", IsNullable = false)]
        public SerialMapInfo Info { get; set; }

        [XmlElement("landscape")]
        public string Landscape { get; set; }

        [XmlElement("impassability")]
        public string Impassability { get; set; }

        [XmlArray("cells")]
        [XmlArrayItem("cell")]
        public SerialCell[] Cells { get; set; }

        public static void Serialize(string filePath, SerialMap map)
        {
            using (var writer = XmlWriter.Create(filePath,
                new XmlWriterSettings { Indent = true, IndentChars = "    " }))
            {
                var serializer = new XmlSerializer(typeof(SerialMap));
                serializer.Serialize(writer, map);
            }
        }

        public static SerialMap Deserialize(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(SerialMap));
                return serializer.Deserialize(fs) as SerialMap;
            }
        }
    }
}

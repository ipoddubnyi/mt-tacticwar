﻿using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class MissionInfo
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("desc")]
        public string Description { get; set; }

        [XmlElement("version")]
        public string Version { get; set; }

        [XmlElement("mode")]
        public int Mode { get; set; }
    }
}
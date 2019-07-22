﻿using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class MissionDivision
    {
        [XmlAttribute("id")]
        public char Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public int Type { get; set; }

        [XmlElement("position")]
        public MissionPosition Position { get; set; }

        [XmlArray("units")]
        [XmlArrayItem("unit")]
        public MissionUnit[] Units { get; set; }
    }
}

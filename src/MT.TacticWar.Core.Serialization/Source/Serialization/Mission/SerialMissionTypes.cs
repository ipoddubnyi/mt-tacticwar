using System;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialMissionTypes
    {
        [XmlArray("units")]
        [XmlArrayItem("unit")]
        public SerialTypeUnit[] Units { get; set; }

        [XmlArray("reinforcement")]
        [XmlArrayItem("division")]
        public SerialDivision[] Reinforcement { get; set; }

        public SerialMissionTypes()
        {
            Units = new SerialTypeUnit[0];
            Reinforcement = new SerialDivision[0];
        }
    }
}

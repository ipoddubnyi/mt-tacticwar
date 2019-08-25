using System;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialMissionTypes
    {
        [XmlArray("units")]
        [XmlArrayItem("unit")]
        public SerialTypeUnit[] Units { get; set; }

        [XmlArray("support")]
        [XmlArrayItem("division")]
        public SerialDivision[] Divisions { get; set; }

        public SerialMissionTypes()
        {
            Units = new SerialTypeUnit[0];
            Divisions = new SerialDivision[0];
        }
    }
}

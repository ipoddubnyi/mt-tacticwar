using System;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    [Serializable]
    public class SerialMissionTypes
    {
        [XmlArray("units")]
        [XmlArrayItem("unit")]
        public SerialUnit[] Units { get; set; }
    }
}

using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class MissionTypes
    {
        [XmlArray("units")]
        [XmlArrayItem("unit")]
        public MissionUnit[] Units { get; set; }
    }
}

using System.Collections.Generic;
using System.Xml.Serialization;
using MT.TacticWar.Core.Objects;

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

        public static IEnumerable<Division> CreateReinforcement(SerialMissionTypes types)
        {
            if (null == types)
                yield break;

            foreach (var sdivision in types.Reinforcement)
                yield return sdivision.CreateReinforcement(types);
        }
    }
}

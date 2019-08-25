using System.Collections.Generic;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialGate : SerialPosition
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        public SerialGate()
        {
        }

        public SerialGate(Gate gate)
        {
            Id = gate.Id;
            X = gate.X;
            Y = gate.Y;
        }
        public new Gate Create()
        {
            return new Gate(Id, X, Y);
        }

        public static IEnumerable<Gate> Create(IEnumerable<SerialGate> sgates)
        {
            foreach (var sgate in sgates)
                yield return sgate.Create();
        }

        public static IEnumerable<SerialGate> CreateFrom(IEnumerable<Gate> gates)
        {
            foreach (var gate in gates)
                yield return new SerialGate(gate);
        }
    }
}

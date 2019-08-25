using System.Collections.Generic;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialPosition
    {
        [XmlAttribute("x")]
        public int X { get; set; }

        [XmlAttribute("y")]
        public int Y { get; set; }

        public SerialPosition()
        {
        }

        public SerialPosition(Coordinates position)
        {
            X = position.X;
            Y = position.Y;
        }

        public Coordinates Create()
        {
            return new Coordinates(X, Y);
        }

        public static IEnumerable<Coordinates> Create(IEnumerable<SerialPosition> spositions)
        {
            foreach (var sposition in spositions)
                yield return sposition.Create();
        }

        public static IEnumerable<SerialPosition> CreateFrom(IEnumerable<Coordinates> positions)
        {
            foreach (var position in positions)
                yield return new SerialPosition(position);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialZone
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("point")]
        public SerialPosition[] Points { get; set; }

        public SerialZone()
        {
        }

        public SerialZone(Zone zone)
        {
            Id = zone.Id;
            Points = SerialPosition.CreateFrom(zone.Points).ToArray();
        }

        public Zone Create()
        {
            return new Zone(Id, SerialPosition.Create(Points).ToArray());
        }

        public static IEnumerable<Zone> Create(IEnumerable<SerialZone> szones)
        {
            foreach (var szone in szones)
                yield return szone.Create();
        }

        public static IEnumerable<SerialZone> CreateFrom(IEnumerable<Zone> zones)
        {
            foreach (var zone in zones)
            {
                if (0 == zone.Points.Length)
                    continue;

                yield return new SerialZone(zone);
            }
        }
    }
}

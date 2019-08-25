using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialBuilding
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("position")]
        public SerialPosition Position { get; set; }

        [XmlElement("health")]
        public int? Health { get; set; }

        [XmlElement("security", IsNullable = true)]
        public int? Security { get; set; }

        //

        [XmlIgnore]
        public bool HealthSpecified => Health.HasValue && Health.Value != 100;

        [XmlIgnore]
        public bool SecuritySpecified => Security.HasValue;

        public SerialBuilding()
        {
        }

        public SerialBuilding(Building building)
        {
            Id = building.Id;
            Type = Building.GetBuildingCode(building);

            Name = building.Name;
            Position = new SerialPosition(building.Position);
            Health = building.Health;
            Security = building.IsSecured ? (int?)building.SecurityDivision.Id : null;
        }

        public Building Create(Player player)
        {
            var security = Security.HasValue ?
                player.Divisions.GetById(Security.Value) :
                null;

            return ObjectFactory.CreateBuilding(
                Type,
                player,
                Id,
                Name,
                Position.X,
                Position.Y,
                Health ?? 100,
                security
            );
        }

        public static IEnumerable<Building> Create(IEnumerable<SerialBuilding> sbuildings, Player player)
        {
            foreach (var sbuilding in sbuildings)
                yield return sbuilding.Create(player);
        }

        public static IEnumerable<SerialBuilding> CreateFrom(IEnumerable<Building> buildings)
        {
            foreach (var building in buildings)
                yield return new SerialBuilding(building);
        }
    }
}

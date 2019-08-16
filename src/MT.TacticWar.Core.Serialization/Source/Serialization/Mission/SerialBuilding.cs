using System;
using System.Xml.Serialization;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Serialization
{
    [Serializable]
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
            Type = ObjectFactory.GetBuildingCode(building);

            Name = building.Name;
            Position = new SerialPosition() { X = building.Position.X, Y = building.Position.Y };
            Health = building.Health;
            Security = building.IsSecured ? (int?)building.SecurityDivision.Id : null;
        }
    }
}

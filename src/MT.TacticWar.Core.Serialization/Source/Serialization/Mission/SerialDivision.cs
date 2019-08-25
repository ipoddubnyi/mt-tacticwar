using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialDivision
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("position")]
        public SerialPosition Position { get; set; }

        [XmlArray("units")]
        [XmlArrayItem("unit")]
        public SerialUnit[] Units { get; set; }

        public SerialDivision()
        {
        }

        public SerialDivision(Division division)
        {
            Id = division.Id;
            Type = Division.GetDivisionCode(division);

            Name = division.Name;
            Position = new SerialPosition(division.Position);
            Units = SerialUnit.CreateFrom(division.Units).ToArray();
        }

        public Division Create(Player player, SerialMissionTypes types)
        {
            var division = ObjectFactory.CreateDivision(Type, player, Id, Name, Position.X, Position.Y);
            var units = SerialUnit.Create(Units, division, types);
            division.CompleteWithUnits(units);
            return division;
        }

        public Division CreateSupport(SerialMissionTypes types)
        {
            var division = ObjectFactory.CreateDivisionSupport(Type, Id, Name);
            var units = SerialUnit.Create(Units, division, types);
            division.CompleteWithUnits(units);
            return division;
        }

        public static IEnumerable<Division> Create(IEnumerable<SerialDivision> sdivisions,
            Player player, SerialMissionTypes types)
        {
            foreach (var sdivision in sdivisions)
                yield return sdivision.Create(player, types);
        }

        public static IEnumerable<Division> CreateSupport(IEnumerable<SerialDivision> sdivisions,
            SerialMissionTypes types)
        {
            foreach (var sdivision in sdivisions)
                yield return sdivision.CreateSupport(types);
        }

        public static IEnumerable<SerialDivision> CreateFrom(IEnumerable<Division> divisions)
        {
            foreach (var division in divisions)
                yield return new SerialDivision(division);
        }
    }
}

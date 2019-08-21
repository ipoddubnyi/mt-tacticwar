using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Serialization
{
    [Serializable]
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
            Position = new SerialPosition() { X = division.Position.X, Y = division.Position.Y };

            var units = new List<SerialUnit>();
            foreach (var unit in division.Units)
                units.Add(new SerialUnit(unit));

            Units = units.ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Base.Units;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialUnit
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        #region Изменяемые параметры

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlIgnore]
        public bool NameSpecified => false;

        [XmlElement("experience")]
        public int? Experience { get; set; }

        [XmlIgnore]
        public bool ExperienceSpecified => Experience != 0;

        [XmlElement("health")]
        public int? Health { get; set; }

        [XmlIgnore]
        public bool HealthSpecified => Health != 100;

        [XmlElement("supply")]
        public int? SupplyCurrent { get; set; }

        [XmlIgnore]
        public bool SupplyCurrentSpecified { get; set; }

        #endregion

        public SerialUnit()
        {
        }

        public SerialUnit(Unit unit)
        {
            Id = unit.Id;
            Type = Unit.GetUnitCode(unit);

            //

            Name = unit.Name;
            Experience = unit.Experience;
            Health = unit.Health;
            SupplyCurrent = unit.SupplyCurrent;

            //

            // не сериализовать, если максимум патронов
            SupplyCurrentSpecified = unit.SupplyCurrent != unit.Parameters.Supply;
        }

        public Unit Update(Unit unit)
        {
            unit.Update(Name, Experience, Health, SupplyCurrent);
            return unit;
        }

        public Unit Create(Division division, SerialMissionTypes types)
        {
            var unit = UnitFactory.CreateUnit(division, Type, Id);
            if (null != unit)
                return Update(unit);

            unit = SerialTypeUnit.Create(types.Units, Id, division, Type);
            if (null != unit)
                return Update(unit);

            throw new Exception($"Неизвестный тип юнита {Type}");
        }

        public static IEnumerable<Unit> Create(IEnumerable<SerialUnit> sunits, Division division, SerialMissionTypes types)
        {
            foreach (var sunit in sunits)
                yield return sunit.Create(division, types);
        }

        public static IEnumerable<SerialUnit> CreateFrom(IEnumerable<Unit> units)
        {
            foreach (var unit in units)
                yield return new SerialUnit(unit);
        }
    }
}

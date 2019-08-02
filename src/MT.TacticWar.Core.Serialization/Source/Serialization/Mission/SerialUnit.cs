using System;
using System.Xml.Serialization;
using MT.TacticWar.Core.Base.Units;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Serialization
{
    [Serializable]
    public class SerialUnit
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("divtype")]
        public string DivisionType { get; set; }

        #region Изменяемые параметры

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("experience")]
        public int? Experience { get; set; }

        [XmlElement("health")]
        public int? Health { get; set; }

        [XmlElement("supply")]
        public int? SupplyCurrent { get; set; }

        #endregion

        #region Характеристики типа

        [XmlElement("steps")]
        public int? Steps { get; set; }
        [XmlElement("supplymax")]
        public int? Supply { get; set; }
        [XmlElement("cost")]
        public int? Cost { get; set; }

        [XmlElement("radiusattack")]
        public int? RadiusAttack { get; set; }
        [XmlElement("radiusview")]
        public int? RadiusView { get; set; }

        [XmlElement("powerinf")]
        public int? PowerAntiInf { get; set; }
        [XmlElement("powerarm")]
        public int? PowerAntiTank { get; set; }
        [XmlElement("powerair")]
        public int? PowerAntiAir { get; set; }

        [XmlElement("armourinf")]
        public int? ArmourFromInf { get; set; }
        [XmlElement("armourarm")]
        public int? ArmourFromTank { get; set; }
        [XmlElement("armourair")]
        public int? ArmourFromAir { get; set; }

        [XmlElement("stepland")]
        public bool? StepLand { get; set; }
        [XmlElement("stepaqua")]
        public bool? StepAqua { get; set; }

        #endregion

        public Unit Create(int id, Division division)
        {
            var name = Name;
            var exp = Experience.HasValue ? Experience.Value : Unit.ExperienceRecruit;
            var health = Health.HasValue ? Health.Value : Unit.HealthMax;
            var supply = SupplyCurrent;

            return new CustomUnit(id, division, GetParameters(), name, exp, health, supply);
        }

        private UnitParameters GetParameters()
        {
            return new UnitParameters()
            {
                Steps = Steps.Value,
                Supply = Supply.Value,
                Cost = Cost.Value,

                RadiusAttack = RadiusAttack.Value,
                RadiusView = RadiusView.Value,

                PowerAntiInf = PowerAntiInf.Value,
                PowerAntiTank = PowerAntiTank.Value,
                PowerAntiAir = PowerAntiAir.Value,

                ArmourFromInf = ArmourFromInf.Value,
                ArmourFromTank = ArmourFromTank.Value,
                ArmourFromAir = ArmourFromAir.Value,

                CanStepLand = StepLand.Value,
                CanStepAqua = StepAqua.Value
            };
        }

        public Unit Update(Unit unit)
        {
            unit.Update(Name, Experience, Health, SupplyCurrent);
            return unit;
        }
    }
}

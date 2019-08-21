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
        public bool SupplyCurrentSpecified => SupplyCurrent != Supply;

        #endregion

        #region Характеристики типа

        [XmlElement("steps")]
        public int? Steps { get; set; }
        [XmlIgnore]
        public bool StepsSpecified => false;
        [XmlElement("supplymax")]
        public int? Supply { get; set; }
        [XmlIgnore]
        public bool SupplySpecified => false;
        [XmlElement("cost")]
        public int? Cost { get; set; }
        [XmlIgnore]
        public bool CostSpecified => false;

        [XmlElement("radiusattack")]
        public int? RadiusAttack { get; set; }
        [XmlIgnore]
        public bool RadiusAttackSpecified => false;
        [XmlElement("radiusview")]
        public int? RadiusView { get; set; }
        [XmlIgnore]
        public bool RadiusViewSpecified => false;

        [XmlElement("powerinf")]
        public int? PowerAntiInf { get; set; }
        [XmlIgnore]
        public bool PowerAntiInfSpecified => false;
        [XmlElement("powerarm")]
        public int? PowerAntiTank { get; set; }
        [XmlIgnore]
        public bool PowerAntiTankSpecified => false;
        [XmlElement("powerair")]
        public int? PowerAntiAir { get; set; }
        [XmlIgnore]
        public bool PowerAntiAirSpecified => false;

        [XmlElement("armourinf")]
        public int? ArmourFromInf { get; set; }
        [XmlIgnore]
        public bool ArmourFromInfSpecified => false;
        [XmlElement("armourarm")]
        public int? ArmourFromTank { get; set; }
        [XmlIgnore]
        public bool ArmourFromTankSpecified => false;
        [XmlElement("armourair")]
        public int? ArmourFromAir { get; set; }
        [XmlIgnore]
        public bool ArmourFromAirSpecified => false;

        [XmlElement("stepland")]
        public bool? StepLand { get; set; }
        [XmlIgnore]
        public bool StepLandSpecified => false;
        [XmlElement("stepaqua")]
        public bool? StepAqua { get; set; }
        [XmlIgnore]
        public bool StepAquaSpecified => false;

        #endregion

        public SerialUnit()
        {
        }

        public SerialUnit(Unit unit)
        {
            Id = unit.Id;
            Type = Unit.GetUnitCode(unit);
            DivisionType = Division.GetDivisionCode(unit.Division);

            //

            Name = unit.Name;
            Experience = unit.Experience;
            Health = unit.Health;
            SupplyCurrent = unit.SupplyCurrent;

            //

            Steps = unit.Parameters.Steps;
            Supply = unit.Parameters.Supply;
            Cost = unit.Parameters.Cost;

            RadiusAttack = unit.Parameters.RadiusAttack;
            RadiusView = unit.Parameters.RadiusView;

            PowerAntiInf = unit.Parameters.PowerAntiInf;
            PowerAntiTank = unit.Parameters.PowerAntiTank;
            PowerAntiAir = unit.Parameters.PowerAntiAir;

            ArmourFromInf = unit.Parameters.ArmourFromInf;
            ArmourFromTank = unit.Parameters.ArmourFromTank;
            ArmourFromAir = unit.Parameters.ArmourFromAir;

            StepLand = unit.Parameters.CanStepLand;
            StepAqua = unit.Parameters.CanStepAqua;
        }

        public Unit CreateCustom(int id, Division division)
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

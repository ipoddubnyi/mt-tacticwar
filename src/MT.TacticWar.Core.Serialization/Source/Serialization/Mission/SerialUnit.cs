using System;
using System.Xml.Serialization;
using MT.TacticWar.Core.Base.Objects;
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
        public string DivType { get; set; }

        //

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("health")]
        public int? Health { get; set; }

        [XmlElement("experience")]
        public int? Experience { get; set; }

        [XmlElement("cost")]
        public int? Cost { get; set; }

        //

        [XmlElement("powerinf")]
        public int? PowerAntiInf { get; set; }

        [XmlElement("powerarm")]
        public int? PowerAntiTank { get; set; }

        [XmlElement("powerair")]
        public int? PowerAntiAir { get; set; }

        //

        [XmlElement("armourinf")]
        public int? ArmourFromInf { get; set; }

        [XmlElement("armourarm")]
        public int? ArmourFromTank { get; set; }

        //

        [XmlElement("supplymax")]
        public int? SupplyMax { get; set; }

        [XmlElement("supply")]
        public int? Supply { get; set; }

        //

        [XmlElement("radiusattack")]
        public int? RadiusAttack { get; set; }

        [XmlElement("radiusview")]
        public int? RadiusView { get; set; }

        //

        [XmlElement("steps")]
        public int? Steps { get; set; }

        [XmlElement("stepland")]
        public bool? StepLand { get; set; }

        [XmlElement("stepaqua")]
        public bool? StepAqua { get; set; }

        public Unit Create(Division division)
        {
            return Update(new CustomUnit(division));
        }

        public bool CompareDivisionType(Division division)
        {
            switch (DivType)
            {
                case "infantry":
                    return division is Infantry;
                case "vehicle":
                    return division is Vehicle;
                case "ship":
                    return division is Ship;
                case "artillery":
                    return division is Artillery;
                case "aviation":
                    return division is Aviation;
            }

            throw new Exception("Неизвестный тип подразделения.");
        }

        public Unit Update(Unit unit)
        {
            if (null != Name)
                unit.Name = Name;
            if (Health.HasValue)
                unit.Health = Health.Value;
            if (Experience.HasValue)
                unit.Experience = Experience.Value;
            if (Cost.HasValue)
                unit.Cost = Cost.Value;

            if (PowerAntiInf.HasValue)
                unit.PowerAntiInf = PowerAntiInf.Value;
            if (PowerAntiTank.HasValue)
                unit.PowerAntiTank = PowerAntiTank.Value;
            if (PowerAntiAir.HasValue)
                unit.PowerAntiAir = PowerAntiAir.Value;

            if (ArmourFromInf.HasValue)
                unit.ArmourFromInf = ArmourFromInf.Value;
            if (ArmourFromTank.HasValue)
                unit.ArmourFromTank = ArmourFromTank.Value;

            if (SupplyMax.HasValue)
                unit.SupplyMax = SupplyMax.Value;
            if (Supply.HasValue)
                unit.Supply = Supply.Value;

            if (RadiusAttack.HasValue)
                unit.RadiusAttack = RadiusAttack.Value;
            if (RadiusView.HasValue)
                unit.RadiusView = RadiusView.Value;

            if (Steps.HasValue)
                unit.Steps = Steps.Value;
            if (StepLand.HasValue)
                unit.StepLand = StepLand.Value;
            if (StepAqua.HasValue)
                unit.StepAqua = StepAqua.Value;

            return unit;
        }
    }
}

using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public class Medic : Unit
    {
        private const int MedkitValue = 25;

        public Medic(int id, Division division, string name = null,
            int experience = ExperienceRecruit, int health = HealthMax, int? supply = null) :
            base(id, division, name, experience, health, supply)
        {
            Parameters = new UnitParameters()
            {
                Steps = 8,
                Supply = 3000,
                Cost = 1000,

                RadiusAttack = 0,
                RadiusView = 1,

                PowerAntiInf = 3,
                PowerAntiTank = 0,
                PowerAntiAir = 0,

                ArmourFromInf = 3,
                ArmourFromTank = 0,
                ArmourFromAir = 0,

                CanStepLand = true,
                CanStepAqua = false
            };

            if (string.IsNullOrEmpty(name))
                Name = "Врач";

            if (!supply.HasValue)
                SupplyCurrent = Parameters.Supply;
        }

        public override void Activate(Mission mission)
        {
            foreach (var unit in Division.Units)
            {
                if (0 == SupplyCurrent)
                    break;

                if (!Division.Player.CanBuy(MedkitValue))
                    break;

                unit.Repair(MedkitValue);
                SupplyCurrent -= MedkitValue;
                Division.Player.Buy(MedkitValue, $"Лечение юнита {unit} ({unit.Id})");
            }
        }

        public override int GetStepBonus(Cell cell)
        {
            if (cell is IForest)
                return 1;

            return 0;
        }
    }
}

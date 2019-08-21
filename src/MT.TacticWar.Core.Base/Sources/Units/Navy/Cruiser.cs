using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    [Unit("Крейсер", typeof(Navy), Code = "cruiser")]
    public class Cruiser : Unit
    {
        public Cruiser(int id, Division division, string name = null,
            int experience = ExperienceWarrior, int health = HealthMax, int? supply = null) :
            base(id, division, name, experience, health, supply)
        {
            Parameters = new UnitParameters()
            {
                Steps = 6,
                Supply = 3000,
                Cost = 5000,

                RadiusAttack = 4,
                RadiusView = 2,

                PowerAntiInf = 70,
                PowerAntiTank = 70,
                PowerAntiAir = 70,

                ArmourFromInf = 70,
                ArmourFromTank = 70,
                ArmourFromAir = 40,

                CanStepLand = false,
                CanStepAqua = true
            };

            if (string.IsNullOrEmpty(name))
                Name = "Крейсер";

            if (!supply.HasValue)
                SupplyCurrent = Parameters.Supply;
        }
    }
}

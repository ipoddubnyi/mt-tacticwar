using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    [Unit("Штурмовик", typeof(Aviation))]
    public class Aircraft : Unit
    {
        public Aircraft(int id, Division division, string name = null,
            int experience = ExperienceWarrior, int health = HealthMax, int? supply = null) :
            base(id, division, name, experience, health, supply)
        {
            Parameters = new UnitParameters()
            {
                Steps = 15,
                Supply = 1500,
                Cost = 2000,

                RadiusAttack = 10,
                RadiusView = 1,

                PowerAntiInf = 20,
                PowerAntiTank = 50,
                PowerAntiAir = 50,

                ArmourFromInf = 80,
                ArmourFromTank = 10,
                ArmourFromAir = 20,

                CanStepLand = false,
                CanStepAqua = false
            };

            if (string.IsNullOrEmpty(name))
                Name = "Штурмовик";

            if (!supply.HasValue)
                SupplyCurrent = Parameters.Supply;
        }
    }
}

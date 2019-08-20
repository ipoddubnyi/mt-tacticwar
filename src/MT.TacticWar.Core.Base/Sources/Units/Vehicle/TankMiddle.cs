using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    [Unit("Средний танк", typeof(Vehicle))]
    public class TankMiddle : Unit
    {
        public TankMiddle(int id, Division division, string name = null,
            int experience = ExperienceRecruit, int health = HealthMax, int? supply = null) :
            base(id, division, name, experience, health, supply)
        {
            Parameters = new UnitParameters()
            {
                Steps = 6,
                Supply = 1500,
                Cost = 1500,

                RadiusAttack = 0,
                RadiusView = 1,

                PowerAntiInf = 20,
                PowerAntiTank = 50,
                PowerAntiAir = 5,

                ArmourFromInf = 80,
                ArmourFromTank = 50,
                ArmourFromAir = 50,

                CanStepLand = true,
                CanStepAqua = false
            };

            if (string.IsNullOrEmpty(name))
                Name = "Средний танк";

            if (!supply.HasValue)
                SupplyCurrent = Parameters.Supply;
        }
    }
}

using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    [Unit("Тяжёлый танк", typeof(Vehicle))]
    public class TankHeavy : Unit
    {
        public TankHeavy(int id, Division division, string name = null,
            int experience = ExperienceRecruit, int health = HealthMax, int? supply = null) :
            base(id, division, name, experience, health, supply)
        {
            Parameters = new UnitParameters()
            {
                Steps = 4,
                Supply = 1200,
                Cost = 2000,

                RadiusAttack = 0,
                RadiusView = 1,

                PowerAntiInf = 20,
                PowerAntiTank = 80,
                PowerAntiAir = 20,

                ArmourFromInf = 80,
                ArmourFromTank = 80,
                ArmourFromAir = 80,

                CanStepLand = true,
                CanStepAqua = false
            };

            if (string.IsNullOrEmpty(name))
                Name = "Тяжёлый танк";

            if (!supply.HasValue)
                SupplyCurrent = Parameters.Supply;
        }
    }
}

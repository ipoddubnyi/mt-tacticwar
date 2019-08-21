using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    [Unit("Гаубица", typeof(Artillery), Code = "howitzer")]
    public class Howitzer : Unit
    {
        public Howitzer(int id, Division division, string name = null,
            int experience = ExperienceRecruit, int health = HealthMax, int? supply = null) :
            base(id, division, name, experience, health, supply)
        {
            Parameters = new UnitParameters()
            {
                Steps = 4,
                Supply = 1500,
                Cost = 1500,

                RadiusAttack = 5,
                RadiusView = 1,

                PowerAntiInf = 80,
                PowerAntiTank = 80,
                PowerAntiAir = 0,

                ArmourFromInf = 10,
                ArmourFromTank = 5,
                ArmourFromAir = 5,

                CanStepLand = true,
                CanStepAqua = false
            };

            if (string.IsNullOrEmpty(name))
                Name = "Гаубица";

            if (!supply.HasValue)
                SupplyCurrent = Parameters.Supply;
        }
    }
}

using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    [Unit("БМП", typeof(Vehicle), Code = "ifv")]
    public class IFV : Unit
    {
        public IFV(int id, Division division, string name = null,
            int experience = ExperienceRecruit, int health = HealthMax, int? supply = null) :
            base(id, division, name, experience, health, supply)
        {
            Parameters = new UnitParameters()
            {
                Steps = 8,
                Supply = 1500,
                Cost = 800,

                RadiusAttack = 0,
                RadiusView = 1,

                PowerAntiInf = 20,
                PowerAntiTank = 15,
                PowerAntiAir = 5,

                ArmourFromInf = 30,
                ArmourFromTank = 20,
                ArmourFromAir = 10,

                CanStepLand = true,
                CanStepAqua = true
            };

            if (string.IsNullOrEmpty(name))
                Name = "БМП";

            if (!supply.HasValue)
                SupplyCurrent = Parameters.Supply;
        }
    }
}

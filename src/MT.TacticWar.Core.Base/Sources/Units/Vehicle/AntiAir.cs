using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    [Unit("ЗРК", typeof(Vehicle), Code = "antiair")]
    public class AntiAir : Unit
    {
        public AntiAir(int id, Division division, string name = null,
            int experience = ExperienceRecruit, int health = HealthMax, int? supply = null) :
            base(id, division, name, experience, health, supply)
        {
            Parameters = new UnitParameters()
            {
                Steps = 6,
                Supply = 1000,
                Cost = 2000,

                RadiusAttack = 0,
                RadiusView = 1,

                PowerAntiInf = 5,
                PowerAntiTank = 10,
                PowerAntiAir = 80,

                ArmourFromInf = 30,
                ArmourFromTank = 15,
                ArmourFromAir = 10,

                CanStepLand = true,
                CanStepAqua = false
            };

            if (string.IsNullOrEmpty(name))
                Name = "ЗРК";

            if (!supply.HasValue)
                SupplyCurrent = Parameters.Supply;
        }
    }
}

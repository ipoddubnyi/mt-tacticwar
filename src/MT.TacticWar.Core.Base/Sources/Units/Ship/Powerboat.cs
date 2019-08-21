using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    [Unit("Катер", typeof(Ship), Code = "powerboat")]
    public class Powerboat : Unit
    {
        public Powerboat(int id, Division division, string name = null,
            int experience = ExperienceRecruit, int health = HealthMax, int? supply = null) :
            base(id, division, name, experience, health, supply)
        {
            Parameters = new UnitParameters()
            {
                Steps = 10,
                Supply = 1500,
                Cost = 1500,

                RadiusAttack = 0,
                RadiusView = 1,

                PowerAntiInf = 20,
                PowerAntiTank = 50,
                PowerAntiAir = 5,

                ArmourFromInf = 80,
                ArmourFromTank = 50,
                ArmourFromAir = 20,

                CanStepLand = false,
                CanStepAqua = true
            };

            if (string.IsNullOrEmpty(name))
                Name = "Катер";

            if (!supply.HasValue)
                SupplyCurrent = Parameters.Supply;
        }

        public override int GetStepBonus(Cell cell)
        {
            if (cell is IWater)
                return 1;

            return 0;
        }
    }
}

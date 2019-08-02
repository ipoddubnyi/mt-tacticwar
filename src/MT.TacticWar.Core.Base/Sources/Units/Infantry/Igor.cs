using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public class Igor : Unit
    {
        public Igor(int id, Division division, string name = null,
            int experience = ExperienceHero, int health = HealthMax, int? supply = null) :
            base(id, division, name, experience, health, supply)
        {
            Parameters = new UnitParameters()
            {
                Steps = 6,
                Supply = 1500,
                Cost = 20000,

                RadiusAttack = 0,
                RadiusView = 1,

                PowerAntiInf = 80,
                PowerAntiTank = 80,
                PowerAntiAir = 80,

                ArmourFromInf = 80,
                ArmourFromTank = 80,
                ArmourFromAir = 80,

                CanStepLand = true,
                CanStepAqua = true
            };

            if (string.IsNullOrEmpty(name))
                Name = "Лейтенант";

            if (!supply.HasValue)
                SupplyCurrent = Parameters.Supply;
        }

        public override int GetStepBonus(Cell cell)
        {
            if (cell is IForest)
                return 2;

            return 0;
        }
    }
}

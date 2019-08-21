using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    [Unit("Диверсант", typeof(Infantry), Code = "saboteur")]
    public class Saboteur : Unit
    {
        public Saboteur(int id, Division division, string name = null,
            int experience = ExperienceWarrior, int health = HealthMax, int? supply = null) :
            base(id, division, name, experience, health, supply)
        {
            Parameters = new UnitParameters()
            {
                Steps = 10,
                Supply = 3000,
                Cost = 2500,

                RadiusAttack = 0,
                RadiusView = 2,

                PowerAntiInf = 35,
                PowerAntiTank = 20,
                PowerAntiAir = 5,

                ArmourFromInf = 80,
                ArmourFromTank = 20,
                ArmourFromAir = 20,

                CanStepLand = true,
                CanStepAqua = true
            };

            if (string.IsNullOrEmpty(name))
                Name = "Диверсант";

            if (!supply.HasValue)
                SupplyCurrent = Parameters.Supply;
        }

        public override int GetStepBonus(Cell cell)
        {
            if (cell is IWater)
                return -1;

            if (cell is IForest)
                return 2;

            return 0;
        }
    }
}

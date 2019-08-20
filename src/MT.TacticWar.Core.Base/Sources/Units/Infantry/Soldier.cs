using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    [Unit("Солдат", typeof(Infantry))]
    public class Soldier : Unit
    {
        public Soldier(int id, Division division, string name = null,
            int experience = ExperienceRecruit, int health = HealthMax, int? supply = null) :
            base(id, division, name, experience, health, supply)
        {
            Parameters = new UnitParameters()
            {
                Steps = 8,
                Supply = 3000,
                Cost = 700,

                RadiusAttack = 0,
                RadiusView = 1,

                PowerAntiInf = 25,
                PowerAntiTank = 10,
                PowerAntiAir = 5,

                ArmourFromInf = 30,
                ArmourFromTank = 10,
                ArmourFromAir = 5,

                CanStepLand = true,
                CanStepAqua = false
            };

            if (string.IsNullOrEmpty(name))
                Name = "Солдат";

            if (!supply.HasValue)
                SupplyCurrent = Parameters.Supply;
        }

        public override int GetStepBonus(Cell cell)
        {
            if (cell is IForest)
                return 1;

            return 0;
        }
    }
}

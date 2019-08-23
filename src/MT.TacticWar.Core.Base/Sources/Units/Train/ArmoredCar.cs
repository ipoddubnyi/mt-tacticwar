using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    [Unit("Броневагон", typeof(Train), Code = "armoredcar")]
    public class ArmoredCar : Unit
    {
        public ArmoredCar(int id, Division division, string name = null,
            int experience = ExperienceRecruit, int health = HealthMax, int? supply = null) :
            base(id, division, name, experience, health, supply)
        {
            Parameters = new UnitParameters()
            {
                Steps = 6,
                Supply = 2500,
                Cost = 3000,

                RadiusAttack = 5,
                RadiusView = 1,

                PowerAntiInf = 70,
                PowerAntiTank = 60,
                PowerAntiAir = 0,

                ArmourFromInf = 80,
                ArmourFromTank = 50,
                ArmourFromAir = 30,

                CanStepLand = true,
                CanStepAqua = false
            };

            if (string.IsNullOrEmpty(name))
                Name = "Броневагон";

            if (!supply.HasValue)
                SupplyCurrent = Parameters.Supply;
        }

        public override int GetStepBonus(Cell cell)
        {
            if (cell is IRails)
                return 2;

            return 0;
        }
    }
}

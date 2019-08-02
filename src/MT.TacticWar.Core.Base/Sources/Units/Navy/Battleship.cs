using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public class Battleship : Unit
    {
        public Battleship(int id, Division division, string name = null,
            int experience = ExperienceWarrior, int health = HealthMax, int? supply = null) :
            base(id, division, name, experience, health, supply)
        {
            Parameters = new UnitParameters()
            {
                Steps = 6,
                Supply = 3500,
                Cost = 5500,

                RadiusAttack = 5,
                RadiusView = 2,

                PowerAntiInf = 90,
                PowerAntiTank = 90,
                PowerAntiAir = 90,

                ArmourFromInf = 90,
                ArmourFromTank = 90,
                ArmourFromAir = 60,

                CanStepLand = false,
                CanStepAqua = true
            };

            if (string.IsNullOrEmpty(name))
                Name = "Линкор";

            if (!supply.HasValue)
                SupplyCurrent = Parameters.Supply;
        }
    }
}

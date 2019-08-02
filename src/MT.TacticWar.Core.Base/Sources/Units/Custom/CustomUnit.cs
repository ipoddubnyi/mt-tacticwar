using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    public class CustomUnit : Unit
    {
        public CustomUnit(int id, Division division, UnitParameters parameters, string name,
            int experience = ExperienceRecruit, int health = HealthMax, int? supply = null) :

            base(id, division, name, experience, health, supply)
        {
            Parameters = parameters;

            if (string.IsNullOrEmpty(name))
                Name = "Боевая единица";

            if (!supply.HasValue)
                SupplyCurrent = Parameters.Supply;
        }
    }
}

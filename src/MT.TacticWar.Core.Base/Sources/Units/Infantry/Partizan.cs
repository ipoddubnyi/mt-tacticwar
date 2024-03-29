﻿using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    [Unit("Партизан", typeof(Infantry), Code = "partizan")]
    public class Partizan : Unit
    {
        public Partizan(int id, Division division, string name = null,
            int experience = ExperienceRecruit, int health = HealthMax, int? supply = null) :
            base(id, division, name, experience, health, supply)
        {
            Parameters = new UnitParameters()
            {
                Steps = 10,
                Supply = 1500,
                Cost = 400,

                RadiusAttack = 0,
                RadiusView = 1,

                PowerAntiInf = 20,
                PowerAntiTank = 10,
                PowerAntiAir = 2,

                ArmourFromInf = 20,
                ArmourFromTank = 10,
                ArmourFromAir = 5,

                CanStepLand = true,
                CanStepAqua = false
            };

            if (string.IsNullOrEmpty(name))
                Name = "Партизан";

            if (!supply.HasValue)
                SupplyCurrent = Parameters.Supply;
        }

        public override int GetPowerBonus(Cell cell)
        {
            if (cell is IForest)
                return 5;

            return 0;
        }

        public override int GetArmourBonus(Cell cell)
        {
            var bonus = base.GetArmourBonus(cell);

            if (cell is IForest)
                return bonus + 5;

            return bonus;
        }

        public override int GetStepBonus(Cell cell)
        {
            if (cell is IForest)
                return 2;

            return 0;
        }
    }
}

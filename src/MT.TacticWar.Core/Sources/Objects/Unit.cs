using System;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Objects
{
    public abstract class Unit
    {
        public const int HealthMax = 100;

        public const int ExperienceRecruit = 0;
        public const int ExperienceWarrior = 25;
        public const int ExperienceVeteran = 75;
        public const int ExperienceHero = 100;

        public int Id { get; protected set; }
        public Division Division { get; protected set; }
        public string Name { get; protected set; }
        public int Experience { get; protected set; }
        public int Health { get; protected set; }
        public int SupplyCurrent { get; protected set; }

        public UnitParameters Parameters { get; protected set; }

        public Unit(Division division) :
            this(0, division, "Боевая единица")
        {
        }

        public Unit(int id, Division division, string name,
            int experience = ExperienceRecruit, int health = HealthMax, int? supply = null)
        {
            Id = id;
            Division = division;
            Name = name;
            Experience = experience;
            Health = health;
            SupplyCurrent = supply.HasValue ? supply.Value : 1000;
        }

        public void Update(string name = null, int? experience = null, int? health = null, int? supply = null)
        {
            if (null != name)
                Name = name;

            if (experience.HasValue)
                Experience = experience.Value;

            if (health.HasValue)
                Health = health.Value;

            if (supply.HasValue)
                SupplyCurrent = supply.Value;
        }

        public void Wound(int wound)
        {
            Health -= wound;
            if (Health < 0) Health = 0;
        }

        public int Repair(int medkit)
        {
            medkit = Math.Min(medkit, HealthMax - Health);
            Health += medkit;
            return medkit;
        }

        public void Shoot(int supply)
        {
            SupplyCurrent -= supply;
            if (SupplyCurrent < 0) SupplyCurrent = 0;
        }

        public int Equip(int weapon)
        {
            weapon = Math.Min(weapon, Parameters.Supply - SupplyCurrent);
            SupplyCurrent += weapon;
            return weapon;
        }

        /// <summary>Активировать функции юнита. Например, лечение, построение мостов и т.п.</summary>
        public virtual void Activate(Mission mission)
        {
        }

        public virtual int GetPowerAnti(Division enemy)
        {
            if (enemy is IInfantry)
                return Parameters.PowerAntiInf;
            else if (enemy is IArmored)
                return Parameters.PowerAntiTank;
            else if (enemy is IAviation)
                return Parameters.PowerAntiAir;

            return Parameters.PowerAntiInf;
        }

        public virtual int GetArmourFrom(Division enemy)
        {
            if (enemy is IInfantry)
                return Parameters.ArmourFromInf;
            else if (enemy is IArmored)
                return Parameters.ArmourFromTank;
            else if (enemy is IAviation)
                return Parameters.ArmourFromAir;

            return Parameters.ArmourFromInf;
        }

        public virtual int GetPowerBonus(Cell cell)
        {
            return 0;
        }

        public virtual int GetArmourBonus(Cell cell)
        {
            return Division.IsSecuring ? 10 : 0;
        }

        public virtual int GetStepBonus(Cell cell)
        {
            return 0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

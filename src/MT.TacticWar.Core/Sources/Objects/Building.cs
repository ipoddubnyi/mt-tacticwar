
namespace MT.TacticWar.Core.Objects
{
    public abstract class Building : IObject
    {
        public Player Player { get; protected set; }
        public int Id { get; protected set; }
        public virtual string Type => "Строение";
        public string Name { get; protected set; }
        public Coordinates Position { get; protected set; }
        public int Health { get; protected set; }
        public int RadiusActive { get; protected set; }             // радиус действия
        public int RadiusView { get; protected set; }               // радиус обзора
        public Division SecurityDivision { get; protected set; }    // подразделение на охранении
        public bool IsSecured => null != SecurityDivision;

        public Building(Player player, int id, string name, int x, int y, int health, int radius, int view, Division security)
        {
            Player = player;
            Id = id;
            Name = name;
            Position = new Coordinates(x, y);
            Health = health;
            RadiusActive = radius;
            RadiusView = view;
            SecurityDivision = null;

            if (null != security)
                AddSecurity(security);
        }

        /// <summary>Добавить охранение в здание</summary>
        /// <returns>Возвращает false, если охранение уже есть</returns>
        public bool AddSecurity(Division security)
        {
            if (IsSecured) return false;
            SecurityDivision = security;
            security.SecuredBuilding = this;
            return true;
        }

        public void RemoveSecurity()
        {
            if (null != SecurityDivision)
                SecurityDivision.SecuredBuilding = null;

            SecurityDivision = null;
        }

        public void Capture(Division enemy)
        {
            Player.Buildings.Remove(this);
            Player = enemy.Player;
            Player.Buildings.Add(this);

            AddSecurity(enemy);
        }

        /// <summary>Активировать функцию строения. Например, ремонт техники в радиусе действия.</summary>
        public virtual void Activate(Mission mission)
        {
        }
    }
}

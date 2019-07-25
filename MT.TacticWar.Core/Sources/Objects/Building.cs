
namespace MT.TacticWar.Core.Objects
{
    public class Building : IObject
    {
        public int Id { get; protected set; }

        public Coordinates Position { get; set; }

        public string Name;            //имя
        public BuildingType Type;    //тип строения
        public int PlayerId;            //ид игрока
        public int Health;             //здоровье

        public int RadiusActive;             //радиус действия
        public int RadiusView;              //радиус обзора

        public Division SecurityDivision { get; set; }   //подразделение на охранении
        public bool IsSecured => null != SecurityDivision;

        private Building()
        {
        }

        public Building(int igrok, int id, int type, string name, int i, int j, int health, int radius, int obzor, Division elemOhr)
        {
            Type = (BuildingType)type;

            //координаты на зоне БД
            Position = new Coordinates(i, j);

            Id = id; //номер здания
            Name = name; //имя
            PlayerId = igrok; //ид игрока
            Health = health; //здоровье

            RadiusActive = radius; //радиус действия
            RadiusView = obzor; //радиус обзора

            SecurityDivision = null;

            if (null != elemOhr)
                AddSecurity(elemOhr);
        }

        public Building Copy()
        {
            var newBuilding = new Building();

            newBuilding.Type = Type; //тип строения

            newBuilding.Position.X = Position.X; //координаты на зоне БД
            newBuilding.Position.Y = Position.Y;

            newBuilding.Id = Id; ; //номер
            newBuilding.Name = Name; //имя
            newBuilding.PlayerId = PlayerId; //ид игрока
            newBuilding.Health = Health; //здоровье

            newBuilding.RadiusActive = RadiusActive; //радиус действия
            newBuilding.RadiusView = RadiusView; //радиус обзора

            newBuilding.SecurityDivision = SecurityDivision; //подразделение на охранении
            // TODO: поменять охранение???

            return newBuilding;
        }

        //Добавить охранение в здание
        //Возвращает false при ошибке
        public bool AddSecurity(Division security)
        {
            //если уже есть охранение - ошибка
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
    }
}

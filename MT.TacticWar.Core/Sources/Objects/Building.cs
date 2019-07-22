
namespace MT.TacticWar.Core.Objects
{
    public class Building : IObject
    {
        public BuildingType Type;    //тип строения

        public Coordinates Position { get; set; }

        public int Id;                 //номер
        public string Name;            //имя
        public int PlayerId;            //ид игрока
        public int Health;             //здоровье

        public int RadiusActive;             //радиус действия
        public int RadiusView;              //радиус обзора

        public bool IsSecured;           //есть ли охранение в здании
        public Division SecurityDivision;   //подразделение на охранении

        private Building()
        {
        }

        public Building(int igrok, int id, int type, string name, int i, int j, int health, int radius, int obzor, bool isOhr, Division elemOhr)
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

            IsSecured = isOhr; //есть ли охранение в здании
            SecurityDivision = elemOhr; //подразделение на охранении
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

            newBuilding.IsSecured = IsSecured; //есть ли охранение в здании
            newBuilding.SecurityDivision = SecurityDivision; //подразделение на охранении

            return newBuilding;
        }

        //Добавить охранение в здание
        //Возвращает false при ошибке
        public bool AddSecurity(Division security)
        {
            //если уже есть охранение - ошибка
            if (IsSecured) return false;

            IsSecured = true;
            SecurityDivision = security;

            return true;
        }
    }
}

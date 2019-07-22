using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MT.TacticWar.Core.Objects
{
    //Строение
    public class Building : IObject
    {
        public BuildingType Type;    //тип строения

        public Coordinates Coordinates;     //координаты на зоне БД

        public int Id;                 //номер
        public string Name;            //имя
        public int PlayerId;            //ид игрока
        public int Health;             //здоровье

        public int RadiusActive;             //радиус действия
        public int RadiusView;              //радиус обзора

        public bool IsSecured;           //есть ли охранение в здании
        public Division SecurityDivision;   //подразделение на охранении

        //********************************************************************************

        #region Настройки класса

        [System.ComponentModel.Description("Номер владельца строения")] 
        public string Игрок
        {
            get { return ("Игрок " + PlayerId.ToString()); }
        }

        [System.ComponentModel.Description("Тип строения")] 
        public string Тип
        {
            get
            {
                string res = "";

                switch (Type)
                {
                    case BuildingType.Factory:
                        res = "Завод";
                        break;
                    case BuildingType.Barracks:
                        res = "Казарма";
                        break;
                    case BuildingType.Storehouse:
                        res = "Склад";
                        break;
                    case BuildingType.Radar:
                        res = "Радар";
                        break;
                    case BuildingType.Airfield:
                        res = "Аэропорт";
                        break;
                    case BuildingType.Port:
                        res = "Порт";
                        break;
                }

                return res;
            }
        }

        [System.ComponentModel.Description("Название строения")] 
        public string Название
        {
            get { return Name; }
        }

        [System.ComponentModel.Description("Координаты строения на карте")] 
        public string Координаты
        {
            get { return ("(" + Coordinates.Y + ", " + Coordinates.X + ")"); }
        }

        /*[System.ComponentModel.Description("")] 
        public string Здоровье
        {
            get { return Health.ToString(); }
        }*/

        [System.ComponentModel.Description("На каком радиусе здание может выполнять функции")] 
        public string Радиус
        {
            get { return RadiusActive.ToString(); }
        }

        [System.ComponentModel.Description("Дальность видимости здания")] 
        public string Обзор
        {
            get { return RadiusView.ToString(); }
        }

        #endregion

        //********************************************************************************

        //Конструктор
        public Building()
        {

        }

        //Конструктор
        public Building(int igrok, int id, int type, string name, int i, int j, int health, int radius, int obzor, bool isOhr, Division elemOhr)
        {
            Type = (BuildingType)type;

            //координаты на зоне БД
            Coordinates = new Coordinates(i, j);

            Id = id; //номер здания
            Name = name; //имя
            PlayerId = igrok; //ид игрока
            Health = health; //здоровье

            RadiusActive = radius; //радиус действия
            RadiusView = obzor; //радиус обзора

            IsSecured = isOhr; //есть ли охранение в здании
            SecurityDivision = elemOhr; //подразделение на охранении
        }

        //********************************************************************************

        //Копировать здание
        public Building copyBuilding()
        {
            Building newBuilding = new Building();

            newBuilding.Type = Type; //тип строения

            newBuilding.Coordinates.X = Coordinates.X; //координаты на зоне БД
            newBuilding.Coordinates.Y = Coordinates.Y;

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

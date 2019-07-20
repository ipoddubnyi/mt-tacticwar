using System.Collections.Generic;

namespace MT.TacticWar.Core.Types.Simulator
{
    // Структура с информацией о юните
    public struct UnitInfo
    {
        public int playerId;
        public int elemId;
        public int buildId;

        public List<StructUnits> units; // список юнитов (охраниения здания)
    }

    /*//Структура с информацией о юните
    public struct UnitInfo
    {
        public int igrokId;         //ид игрока
        public string type;         //тип (строка)
        public string name;         //имя

        public Coordinates coords;  //координаты на зоне БД

        public int health;          //здоровье

        public int powerAntiInf;    //общая мощь против пехоты и артиллерии
        public int powerAntiBron;   //общая мощь против бронетехники и кораблей
        public int powerAntiAir;    //общая мощь против воздуха

        public int armourFromInf;    //общая защита от пехоты
        public int armourFromBron;   //общая защита от любой техники

        public int radius;           //радиус действия (для артиллерии)
        public int obzor;            //радиус обзора
        public int suplies;         //партоны

        public UnitLevel level;        //уровень повышения

        public int steps;           //число шагов

        public List<StructUnits> units; //список юнитов (охраниения здания)
    }*/
}

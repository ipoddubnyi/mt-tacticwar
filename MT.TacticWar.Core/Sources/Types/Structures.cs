using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MT.TacticWar.Core.Types.Mission;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core
{
    #region Для земли и ориентации

    //Направления, с которыми клетка уже имела контакт
    public struct Directions
    {
        public bool m1_levo;    //левое
        public bool m2_verh;    //верхнее
        public bool m3_pravo;   //правое
        public bool m4_niz;     //нижнее

        public int prioritet;   //приоритет направления (более выгодное)
        //1 - лево, 2 - верх, 3 - право, 4 - низ
    }

    //Структура параметров при поиске кратчайшего пути
    public struct BellmanParam
    {
        public int cost;                    //цена всего пути

        public List<Cell> kratPut;        //путь - массив координат

        public Division elem;      //юнит - нужны его параметры

        public Coordinates unitCoords;      //координаты юнита (откуда идём)
        public Coordinates flagCoords;      //координаты флага (куда идём)
    }

    #endregion

    #region Для юнитов

    //Структура боевых единиц
    public struct StructUnits
    {
        public Unit unit;      //юнит
        public int count;       //число таких юнитов
        //public bool selected;   //выделены ли эти юниты
    }

    #endregion
}

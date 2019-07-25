﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacticWar
{
    //типы данных ПЕРЕЧИСЛЕНИЯ

    #region Для симулятора и GUI

    //Сигналы для обмена графики и симулятора
    enum ESignals
    {
        s00_NONE,               //без информации
        s01_ALL_IS_GD,          //всё хорошо
        s02_ALL_IS_BD,          //всё плохо
        s03_READY_UNIT_INFO,    //информация о юнитах готова
        s04_ATTACK,             //атака юнитов, их индексы в структуре
        s05_OUT_OF_RANGE        //индексы вне границ массива
    }

    #endregion

    #region Для миссий

    //Перечисление типов игры
    enum EGameMode
    {
        //игроку 1 нужно уничтожить все юниты игрока 2,
        //игроку 2 нужно уничтожить все юниты игрока 1
        gm0_KILL_THEM_ALL,
        //игроку 1 нужно уничтожить один объект врага (именно уничтожить),
        //игроку 2 нужно защитить этот объект (уничтожить все юниты игрока 1)
        gm1_KILL_OBJECT,
        //игроку 1 нужно захватить строение игрока 2,
        //игроку 2 нужно защитить строение (уничтожить все юниты игрока 1)
        gm2_CAPTURE_OBJECT,
        //игроку 1 нужно защитить объект (уничтожить все юниты игрока 2),
        //игроку 2 нужно уничтожить этот объект
        gm3_DEFEND_OBJECT,
        //игроку 1 нужно захватить флаг игрока 2 и принести его на базу,
        //игроку 2 нужно захватить флаг игрока 1 и принести его на базу
        gm4_CAPTURE_ONE_FLAG,
        //игрокам нужно захватить все зоны (дерижабли) на карте или уничтожить противника
        gm5_CAPTURE_ZONES
    };

    //Победа/поражение
    enum EGameOver
    {
        go0_GAME_IS_NOT_OVER,   //игра ещё не окончена
        go1_GAME_WIN,           //победа игрока 1, поражение игрока 2
        go2_GAME_LOSE,          //поражение игрока 1, победа игрока 2
        go3_GAME_DRAW           //ничья
    };

    #endregion

    #region Для земли

    //Схема земли
    enum EZemShema
    {
        Leto = 0,   //лето
        Zima = 1,   //зима
        Gorod = 2   //город
    };

    //Тип земли
    enum EZemType
    {
        zt0_ZEMLYA,     //обычная земля с травой
        zt1_SNEG,       //снег
        zt2_PESOK,      //песок
        zt3_VODA,       //вода
        zt4_KAMNI,      //камни, скалы
        zt5_LES,        //лес
        zt6_DOROGA,     //дорога
        zt7_STROENIYA,  //строения
        zt8_LYOD        //лёд
    };

    #endregion

    #region Для игроков

    //Какие бывают игроки
    enum EIgroki
    {
        igr0_NIKTO,     //нет игрока (белый)
        igr1_IGROK_0,   //игрок 0 (зелёный?)
        igr2_IGROK_1,   //игрок 1 (красный?)
        igr3_SOUZNIK,   //союзник игрока 0 (если игрок 1 - ИИ) (жёлтый)
        igr4_NEYTRAL    //нейтрал (синий)
    };

    //Принадлежность к искусственному интелекту
    enum EHandmadeEssence
    {
        he0_NONE,       //не установлено
        he1_HUMAN,      //человек
        he2_COMPUTER    //комп (возможны уровни сложности)
    };

    //Звания игроков
    enum ERank
    {
        rnk0_SOLDAT,    //солдат
        rnk1_SERZHANT,  //сержант
        rnk2_PRAPOR,    //прапорщик
        rnk3_ML_OFICER, //младший офицер
        rnk4_ST_OFICER, //старший офицер
        rnk5_GENERAL    //генерал
    };

    #endregion

    #region Для подразделений

    //Типы подразделений
    enum EElementTypes
    {
        Infantry,   //отделение пехоты
        Vehicle,    //бронетехника
        Artillery,  //артиллерия
        Aviation,   //авиация
        Ship        //корабль
    };

    //Типы зданий
    enum EBuildingTypes
    {
        Factory,    //завод (ремонт техники, постройка новой)
        Kazarma,    //призывной пункт, казарма, госпиталь (доукомплектование пехотой)
        Storehouse, //склад (вооружение, продовольствие)
        Radar,      //радар (увеличивает обзор за счёт большого радиуса обзора)
        Airfield,   //аэродром (для поддержки авиации)
        Port        //порт (для поддержки кораблей)
    };

    //Уровни повышений подразделений
    enum ELevels
    {
        None,       //без уровня
        Recruit,    //новобранец (изначально у подразделений)
        Warrior,    //воин (после первого боя)
        Veteran,    //ветеран (после нескольких боёв)
        Hero        //герой
    };

    #endregion

    #region Для юнитов

    //Здоровье
    enum EHealth
    {
        eh0_READY,      //годен
        eh1_WOUNDED,    //ранен
        eh2_DEAD        //мёртв
    };

    #endregion
}
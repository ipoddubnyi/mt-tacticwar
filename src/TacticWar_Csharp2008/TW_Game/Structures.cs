using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacticWar
{
    //типы данных СТРУКТУРЫ

    #region Для симулятора

    //Структура с информацией о юните
    struct SUnitInfo
    {
        public int playerId;
        public int elemId;
        public int buildId;

        public List<SStructUnits> units; //список юнитов (охраниения здания)
    }

    /*//Структура с информацией о юните
    struct SUnitInfo
    {
        public int igrokId;         //ид игрока
        public string type;         //тип (строка)
        public string name;         //имя

        public SCoordinates coords;  //координаты на зоне БД

        public int health;          //здоровье

        public int powerAntiInf;    //общая мощь против пехоты и артиллерии
        public int powerAntiBron;   //общая мощь против бронетехники и кораблей
        public int powerAntiAir;    //общая мощь против воздуха

        public int armourFromInf;    //общая защита от пехоты
        public int armourFromBron;   //общая защита от любой техники

        public int radius;           //радиус действия (для артиллерии)
        public int obzor;            //радиус обзора
        public int suplies;         //партоны

        public ELevels level;        //уровень повышения

        public int steps;           //число шагов

        public List<SStructUnits> units; //список юнитов (охраниения здания)
    }*/

    //Структура с информацией об атаке
    struct SAttackInfo
    {
        public int igrokAttacked;   //ид атакующего игрока
        public int igrokDefended;   //ид атакуемого игрока

        public int elemAttacked;    //ид атакующего юнита
        public int elemDefended;    //ид атакуемого юнита
    }

    #endregion

    #region Для миссии

    //Структура с условиями победы/поражения
    struct SMode
    {
        int idOfWinIgrok;   //ид игрока-победителя (0 - никто, 3 - союзник, 4 - нейтрал)

        #region 0 KILL THEM ALL

        //Конец ли игры (перегруженная функция)
        private EGameOver isEnd(TW_Units.CIgrok igrk1, TW_Units.CIgrok igrk2)
        {
            byte tmp = 0;

            //если у игрока 1 не осталось подразделений
            if (igrk1.mElements.Count < 1)
                tmp = 2;

            //если у игрока 2 не осталось подразделений
            if (igrk1.mElements.Count < 1)
                tmp += 1;

            //проверка побед
            switch (tmp)
            {
                case 1: //победил 1
                    idOfWinIgrok = 1;
                    return EGameOver.go1_GAME_WIN;
                case 2: //победил 2
                    idOfWinIgrok = 2;
                    return EGameOver.go2_GAME_LOSE;
                case 3: //ничья
                    idOfWinIgrok = 0;
                    return EGameOver.go3_GAME_DRAW;
            }

            //иначе, пока не конец
            idOfWinIgrok = 0;
            return EGameOver.go0_GAME_IS_NOT_OVER;
        }

        #endregion

        #region KILL THE OBJECT

        int idOfKillingObject;  //ид юнита, которого нужно уничтожить

        //Конец ли игры (перегруженная функция)
        private EGameOver isEnd_gm1(TW_Units.CIgrok igrk1, TW_Units.CIgrok igrk2)
        {
            //если у игрока 1 не осталось подразделений
            if (igrk1.mElements.Count < 1)
            {
                idOfWinIgrok = 2;
                return EGameOver.go2_GAME_LOSE;
            }

            bool objectAlive = false;

            //если у игрока 2 не осталось подразделений
            for (int i = 0; i < igrk1.mElements.Count; i++)
            {
                //если объект ещё есть в списке живых
                if (igrk1.mElements.ElementAt(i).mId == idOfKillingObject)
                    objectAlive = true;
            }

            //если объекта нет в списке живых
            if (!objectAlive)
            {
                idOfWinIgrok = 1;
                return EGameOver.go1_GAME_WIN;
            }

            //иначе, пока не конец
            idOfWinIgrok = 0;
            return EGameOver.go0_GAME_IS_NOT_OVER;
        }

        #endregion

        //Проверить игру на окончание
        public EGameOver checkGameOver(EGameMode gameMode, TW_Units.CIgrok igrk1, TW_Units.CIgrok igrk2)
        {
            //выбираем режим игры
            switch (gameMode)
            {
                case EGameMode.gm0_KILL_THEM_ALL:
                    return isEnd(igrk1, igrk2);
                case EGameMode.gm1_KILL_OBJECT:
                    return isEnd_gm1(igrk1, igrk2);
                case EGameMode.gm2_CAPTURE_OBJECT:
                    break;
                case EGameMode.gm3_DEFEND_OBJECT:
                    break;
                case EGameMode.gm4_CAPTURE_ONE_FLAG:
                    break;
                case EGameMode.gm5_CAPTURE_ZONES:
                    break;
                default:
                    break;
            }

            return EGameOver.go0_GAME_IS_NOT_OVER;
        }
    }

    #endregion

    #region Для земли и ориентации

    //Координаты
    struct SCoordinates
    {
        public int x;   //по оси OX
        public int y;   //по оси OY
    }

    //Направления, с которыми клетка уже имела контакт
    struct SNapravleniya
    {
        public bool m1_levo;    //левое
        public bool m2_verh;    //верхнее
        public bool m3_pravo;   //правое
        public bool m4_niz;     //нижнее

        public int prioritet;   //приоритет направления (более выгодное)
        //1 - лево, 2 - верх, 3 - право, 4 - низ
    }

    //Структура параметров при поиске кратчайшего пути
    struct SBellmanParam
    {
        public int cost;                    //цена всего пути

        public List<TW_Landscape.CField> kratPut;        //путь - массив координат

        public TW_Units.CElement elem;      //юнит - нужны его параметры

        public SCoordinates unitCoords;      //координаты юнита (откуда идём)
        public SCoordinates flagCoords;      //координаты флага (куда идём)
    }

    #endregion

    #region Для юнитов

    //Структура боевых единиц
    struct SStructUnits
    {
        public TW_Units.CUnit unit;      //юнит
        public int count;       //число таких юнитов
        //public bool selected;   //выделены ли эти юниты
    }

    //Структура "Деньги"
    struct SMoney
    {
        public int value;

        #region Операторы

        /// <summary>Оператор сложения денег
        /// </summary>
        /// <param name="M1">деньги 1</param>
        /// <param name="M2">деньги 2</param>
        /// <returns></returns>
        public static SMoney operator +(SMoney M1, SMoney M2)
        {
            SMoney MRes;
            MRes.value = M1.value + M2.value;

            return MRes;
        }

        /// <summary>Оператор сложения числа к деньгам
        /// </summary>
        /// <param name="M1">деньги</param>
        /// <param name="chislo">число</param>
        /// <returns></returns>
        public static SMoney operator +(SMoney M1, int chislo)
        {
            SMoney MRes;
            MRes.value = M1.value + chislo;

            return MRes;
        }

        /// <summary>Оператор вычитания денег
        /// </summary>
        /// <param name="M1">деньги 1</param>
        /// <param name="M2">деньги 2</param>
        /// <returns></returns>
        public static SMoney operator -(SMoney M1, SMoney M2)
        {
            SMoney MRes;
            MRes.value = M1.value - M2.value;

            return MRes;
        }

        /// <summary>Оператор вычитания числа из денег
        /// </summary>
        /// <param name="M1">деньги</param>
        /// <param name="chislo">число</param>
        /// <returns></returns>
        public static SMoney operator -(SMoney M1, int chislo)
        {
            SMoney MRes;
            MRes.value = M1.value - chislo;

            return MRes;
        }

        /// <summary>Оператор умножения денег на число
        /// </summary>
        /// <param name="M1">деньги</param>
        /// <param name="chislo">число</param>
        /// <returns></returns>
        public static SMoney operator *(SMoney M1, int chislo)
        {
            SMoney MRes;
            MRes.value = M1.value * chislo;

            return MRes;
        }

        /// <summary>Оператор деления денег на число
        /// </summary>
        /// <param name="M1">деньги</param>
        /// <param name="chislo">число</param>
        /// <returns></returns>
        public static SMoney operator /(SMoney M1, int chislo)
        {
            SMoney MRes;
            MRes.value = M1.value / chislo;

            return MRes;
        }

        /// <summary>Оператор сравнения денег
        /// </summary>
        /// <param name="M1">деньги, которые сравнивают</param>
        /// <param name="M2">деньги, с которыми сравнивают</param>
        /// <returns></returns>
        public static bool operator ==(SMoney M1, SMoney M2)
        {
            return (M1.value == M2.value);
        }

        /// <summary>Оператор сравнения денег с числом
        /// </summary>
        /// <param name="M1">деньги, которые сравнивают</param>
        /// <param name="chislo">число, с которым сравнивают</param>
        /// <returns></returns>
        public static bool operator ==(SMoney M1, int chislo)
        {
            return (M1.value == chislo);
        }

        /// <summary>Оператор сравнения денег
        /// </summary>
        /// <param name="M1">деньги, которые сравнивают</param>
        /// <param name="M2">деньги, с которыми сравнивают</param>
        /// <returns></returns>
        public static bool operator !=(SMoney M1, SMoney M2)
        {
            return (M1.value != M2.value);
        }

        /// <summary>Оператор сравнения денег с числом
        /// </summary>
        /// <param name="M1">деньги, которые сравнивают</param>
        /// <param name="chislo">число, с которым сравнивают</param>
        /// <returns></returns>
        public static bool operator !=(SMoney M1, int chislo)
        {
            return (M1.value != chislo);
        }

        #endregion
    }

    #endregion
}

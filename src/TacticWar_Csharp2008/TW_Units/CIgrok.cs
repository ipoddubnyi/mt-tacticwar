﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TacticWar.TW_Units
{
    //Игрок
    class CIgrok
    {
        EIgroki mIgrokType;             //кто игрок (игрок 1, 2, союзник, нейтрал)
        EHandmadeEssence mAI;           //искусственный интелект

        string mName;                   //имя
        int mId;                        //номер игрока
        //System.Drawing.Color mColor;  //цвет юнитов игрока
        bool mIsPlay;                   //играет ли данный игрок (возможно, уже проиграл)
        ERank mRank;                    //уровень игрока. В зависимости от него игрок может формировать новые подразделения

        SMoney mMoney;                   //ресурсы, за которые игрок может ремонтировать войска и покупать новое вооружение

        public List<TW_Units.CElement> mElements;   //список подразделение
        public List<TW_Units.CBuilding> mBuildings;  //список структур

        public SCoordinates mVorota;     //ворота для выхода подкреплений

        public int mSelectedElementId;  //ид выделенного юнита игрока (-1, если нет)
        public int mSelectedBuildingId; //ид выделенного здания игрока (-1, если нет)

        public string mError;           //ошибка

        //********************************************************************************

        /// <summary>Конструктор
        /// </summary>
        /// <param name="id">ид игрока</param>
         /// <returns></returns>
        public CIgrok(int id)
        {
            if(id == 0)
                mIgrokType = EIgroki.igr1_IGROK_0;     //кто игрок (игрок 1, 2, союзник, нейтрал)
            else if(id == 1)
                mIgrokType = EIgroki.igr2_IGROK_1;

            mAI = EHandmadeEssence.he1_HUMAN;   //искусственный интелект

            mName = "Игрок";                   //имя
            mId = id;                        //номер игрока
            //System.Drawing.Color mColor;  //цвет юнитов игрока
            mIsPlay = true;                   //играет ли данный игрок (возможно, уже проиграл)
            mRank = ERank.rnk0_SOLDAT;                    //уровень игрока. В зависимости от него игрок может формировать новые подразделения

            mMoney = mMoney + 10000;                   //ресурсы, за которые игрок может ремонтировать войска и покупать новое вооружение

            mElements = new List<TW_Units.CElement>();      //список подразделение
            mBuildings = new List<TW_Units.CBuilding>();     //список структур

            mVorota.x = -1;
            mVorota.y = -1;

            mSelectedElementId = -1;  //ид выделенного юнита игрока (-1, если нет)
            mSelectedBuildingId = -1; //ид выделенного здания игрока (-1, если нет)
        }

        /// <summary>Конструктор
        /// </summary>
        /// <param name="id">ид игрока</param>
        /// <param name="name">имя игрока</param>
        /// <param name="AI">управление ИИ</param>
        /// <param name="filePath">путь к файлу с объектами игрока</param>
        /// <returns></returns>
        public CIgrok(int id, string name, bool AI, string filePath)
        {
            mError = "";

            //номер игрока
            mId = id;

            //тип игрока
            switch (mId)
            {
                case 0:
                    mIgrokType = EIgroki.igr1_IGROK_0;
                    break;
                case 1:
                    mIgrokType = EIgroki.igr2_IGROK_1;
                    break;
                case 2:
                    mIgrokType = EIgroki.igr3_SOUZNIK;
                    break;
                case 3:
                    mIgrokType = EIgroki.igr4_NEYTRAL;
                    break;
                default:
                    mIgrokType = EIgroki.igr0_NIKTO;
                    break;
            }

            //имя
            mName = name;

            //искусственный интеллект
            if (AI)
                mAI = EHandmadeEssence.he2_COMPUTER;
            else
                mAI = EHandmadeEssence.he1_HUMAN;

            //загружаем файл
            loadIgrokState(filePath);

            //System.Drawing.Color mColor; //цвет юнитов игрока
            mIsPlay = true; //играет ли данный игрок (возможно, уже проиграл)

            mSelectedElementId = -1; //ид выделенного юнита игрока (-1, если нет)
            mSelectedBuildingId = -1; //ид выделенного здания игрока (-1, если нет)
        }

        //********************************************************************************

        /// <summary>Загрузка файла с данными об объектах игрока
        /// </summary>
        /// <param name="igrkFileName">путь к файлу с объектами игрока</param>
        /// <returns>Возвращает (false) в случае ошибки</returns>
        private bool loadIgrokState(string igrkFileName)
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(igrkFileName))
                {
                    //проверяем ид игрока
                    if(mId != int.Parse(sr.ReadLine()))
                    {
                        mError = "Ошибка загрузки данных об игроке " + mId.ToString();
                        return false;
                    }

                    //читаем имя игрока
                    //mName = sr.ReadLine();

                    //читаем уровень игрока
                    switch (int.Parse(sr.ReadLine()))
                    {
                        case 1:
                            mRank = ERank.rnk1_SERZHANT;
                            break;
                        case 2:
                            mRank = ERank.rnk2_PRAPOR;
                            break;
                        case 3:
                            mRank = ERank.rnk3_ML_OFICER;
                            break;
                        case 4:
                            mRank = ERank.rnk4_ST_OFICER;
                            break;
                        case 5:
                            mRank = ERank.rnk5_GENERAL;
                            break;
                        case 0:
                        default:
                            mRank = ERank.rnk0_SOLDAT;                            
                            break;
                    }

                    //читаем деньги
                    mMoney.value = int.Parse(sr.ReadLine());

                    //читаем число подразделений
                    int countElem = int.Parse(sr.ReadLine());

                    //читаем число зданий
                    int countBuild = int.Parse(sr.ReadLine());

                    //читаем подразделения
                    mElements = new List<TacticWar.TW_Units.CElement>();

                    for (int k = 0; k < countElem; k++)
                    {
                        //[подразделение]
                        sr.ReadLine();

                        string nameElem = sr.ReadLine();

                        int type = int.Parse(sr.ReadLine());

                        int elemX = int.Parse(sr.ReadLine());
                        int elemY = int.Parse(sr.ReadLine());

                        //число разных юнитов
                        int countUnit = int.Parse(sr.ReadLine());

                        //список юнитов
                        List<SStructUnits> unitList = new List<SStructUnits>();

                        //читаем юнитов
                        //mElements[k].mUnits = new List<TacticWar.TW_Units.StructUnits>();

                        for (int kk = 0; kk < countUnit; kk++)
                        {
                            //[юнит]
                            sr.ReadLine();

                            //читать имя юнита (зависит от типа юнита)
                            int unitName = int.Parse(sr.ReadLine());

                            //число таких юнитов
                            int count = int.Parse(sr.ReadLine());

                            TW_Units.CUnit unit;

                            //создать юнита в зависимости от типа юнита

                            if (type == 0) //пехота
                            {
                                switch (unitName)
                                {
                                    case 1:
                                        unit = new TW_Units.CuiSoldiers(kk);
                                        break;
                                    case 2:
                                        unit = new TW_Units.CuiDiversionGroup(kk);
                                        break;
                                    case 3:
                                        unit = new TW_Units.CuiPoddubnyy(kk);
                                        break;
                                    case 0:
                                    default:
                                        unit = new TW_Units.CuiPartizans(kk);
                                        break;
                                }
                            }
                            else //if (type == 1) //!!!!!!!!!! бронетехника
                            {
                                switch (unitName)
                                {
                                    case 1:
                                        unit = new TW_Units.CuvTankMiddle(kk);
                                        break;
                                    case 2:
                                        unit = new TW_Units.CuvTankHeavy(kk);
                                        break;
                                    case 3:
                                        unit = new TW_Units.CuvZRK(kk);
                                        break;
                                    case 0:
                                    default:
                                        unit = new TW_Units.CuvMotopehota(kk);
                                        break;
                                }
                            }

                            //создать структуру
                            SStructUnits tmpStructUnit;
                            tmpStructUnit.unit = unit;
                            tmpStructUnit.count = count;

                            unitList.Add(tmpStructUnit);
                        }

                        TW_Units.CElement tmpElem;

                        //создаём подразделение
                        tmpElem = new TacticWar.TW_Units.CElement(mId, k, type, nameElem, elemX, elemY, unitList);

                        //добавить здание
                        mElements.Add(tmpElem);
                    }

                    //читаем здания
                    mBuildings = new List<TacticWar.TW_Units.CBuilding>();

                    for (int k = 0; k < countBuild; k++)
                    {
                        //[здание]
                        sr.ReadLine();

                        string nameBld = sr.ReadLine();

                        int type = int.Parse(sr.ReadLine());

                        int bldX = int.Parse(sr.ReadLine());
                        int bldY = int.Parse(sr.ReadLine());

                        int hlth = int.Parse(sr.ReadLine());

                        int rdus = int.Parse(sr.ReadLine());
                        int obzr = int.Parse(sr.ReadLine());

                        int ohrid = int.Parse(sr.ReadLine());

                        TW_Units.CBuilding tmpBld;

                        //создать юнита в зависимости от охранения
                        if(ohrid == -1)
                            tmpBld = new TacticWar.TW_Units.CBuilding(mId, k, type, nameBld, bldX, bldY, hlth, rdus, obzr, false, null);
                        else
                            tmpBld = new TacticWar.TW_Units.CBuilding(mId, k, type, nameBld, bldX, bldY, hlth, rdus, obzr, true, mElements[ohrid]);

                        //добавить здание
                        mBuildings.Add(tmpBld);
                    }

                    //[ворота]
                    sr.ReadLine();

                    //читаем ворота
                    mVorota.x = int.Parse(sr.ReadLine());
                    mVorota.y = int.Parse(sr.ReadLine());
                }
            }
            catch (Exception e)
            {
                mError = "Ошибка загрузки данных об игроке " + mId.ToString();
                return false;
            }

            return true;
        }

        /// <summary>Проверяет, есть ли подразделение по координатам
        /// </summary>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns>Возвращает индекс подразделения или -1</returns>
        public int isElementAtCoords(int i, int j)
        {
            //бежим по списку подразделений игрока
            for (int k = 0; k < mElements.Count; k++)
            {
                //если координаты совпадают
                if ((mElements.ElementAt(k).mCoords.x == i) &&
                    (mElements.ElementAt(k).mCoords.y == j))
                    return k;
            }

            return -1;
        }

        /// <summary>Проверяет, есть ли строение по координатам
        /// </summary>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns>Возвращает индекс строения или -1</returns>
        public int isBuildingAtCoords(int i, int j)
        {
            //бежим по списку подразделений игрока
            for (int k = 0; k < mBuildings.Count; k++)
            {
                //если координаты совпадают
                if ((mBuildings.ElementAt(k).mCoords.x == i) &&
                    (mBuildings.ElementAt(k).mCoords.y == j))
                    return k;
            }

            return -1;
        }

        #region Обработчики нажатий

        /// <summary>Обработчик нажатия по своему подразделению
        /// </summary>
        /// <param name="index">индекс подразделения</param>
        /// <returns>Возвращает команды: 1 - собрать информацию об этом подразделении,
        /// 2 - поставить флаг, просчитать и проложить путь,
        /// 3 - продвинуть выделенное подразделение</returns>
        public int clickMyElement(int index)
        {
            //если ЕСТЬ выделенный юнит и щёлкнули НЕ по нему
            if ((mSelectedElementId != -1) && (mSelectedElementId != index))
            {
                //если флаг выделенного юнита указывает сюда
                if ((mElements[mSelectedElementId].mFlag.x == mElements[index].mCoords.x) &&
                    (mElements[mSelectedElementId].mFlag.y == mElements[index].mCoords.y))
                {
                    //продвинуть выделенный юнит
                    return 3;
                }
                else
                {
                    //если типы юнитов не совпадают - выделить нового юнита
                    if (mElements[mSelectedElementId].mType != mElements[index].mType)
                        return 1;

                    //поставить флаг, просчитать путь
                    return 2;
                }
            }
            else
            {
                //передать информацию о выделенном юните
                return 1;
            }

            //return 0;
        }

        /// <summary>Обработчик нажатия по чужому подразделению
        /// </summary>
        /// <param name="enemie">координаты противника</param>
        /// <returns>Возвращает команды: 1 - собрать информацию об этом подразделении,
        /// 2 - поставить флаг, просчитать и проложить путь,
        /// 3 - продвинуть выделенное подразделение</returns>
        public int clickEnemieElement(SCoordinates enemie)
        {
            //если ЕСТЬ выделенный юнит
            if (mSelectedElementId != -1)
            {
                //если флаг выделенного юнита указывает сюда
                if ((mElements[mSelectedElementId].mFlag.x == enemie.x) &&
                    (mElements[mSelectedElementId].mFlag.y == enemie.y))
                {
                    //продвинуть выделенный юнит
                    return 3;
                }
                else
                {
                    //поставить флаг, просчитать путь
                    return 2;
                }
            }
            else
            {
                //передать информацию о выделенном юните
                return 1;
            }

            //return 0;
        }

        /// <summary>Обработчик нажатия по своему зданию
        /// </summary>
        /// <param name="index">индекс здания</param>
        /// <returns>Возвращает команды: 1 - собрать информацию о здании
        /// или подразделении на охранении,
        /// 2 - поставить флаг, просчитать и проложить путь,
        /// 3 - продвинуть выделенное подразделение</returns>
        public int clickMyBuilding(int index)
        {
            int ohrInd = -1;

            //если есть охранение
            if (mBuildings[index].mIsOhran)
                ohrInd = mBuildings[index].mOhraneniye.mId;

            //если ЕСТЬ выделенный юнит и щёлкнули НЕ по нему
            if ((mSelectedElementId != -1) && (mSelectedElementId != ohrInd))
            {
                //если флаг выделенного юнита указывает сюда
                if ((mElements[mSelectedElementId].mFlag.x == mBuildings[index].mCoords.x) &&
                    (mElements[mSelectedElementId].mFlag.y == mBuildings[index].mCoords.y))
                {
                    //продвинуть выделенный юнит
                    return 3;
                }
                else
                {
                    //если есть охранение в здании
                    if (mBuildings[index].mIsOhran)
                    {
                        //если типы юнита и охранения не совпадают - выделить здание и его охранение
                        if (mElements[mSelectedElementId].mType != mBuildings[index].mOhraneniye.mType)
                            return 1;
                    }

                    //поставить флаг, просчитать путь
                    return 2;
                }
            }
            else
            {
                //передать информацию о выделенном юните
                return 1;
            }

            //return 0;
        }

        /// <summary>Обработчик нажатия по чужому зданию
        /// </summary>
        /// <param name="enemie">координаты противника</param>
        /// <returns>Возвращает команды: 1 - собрать информацию о здании
        /// или подразделении на охранении,
        /// 2 - поставить флаг, просчитать и проложить путь,
        /// 3 - продвинуть выделенное подразделение</returns>
        public int clickEnemieBuilding(SCoordinates enemie)
        {
            //если ЕСТЬ выделенный юнит
            if (mSelectedElementId != -1)
            {
                //если флаг выделенного юнита указывает сюда
                if ((mElements[mSelectedElementId].mFlag.x == enemie.x) &&
                    (mElements[mSelectedElementId].mFlag.y == enemie.y))
                {
                    //продвинуть выделенный юнит
                    return 3;
                }
                else
                {
                    //поставить флаг, просчитать путь
                    return 2;
                }
            }
            else
            {
                //передать информацию о выделенном юните
                return 1;
            }

            //return 0;
        }

        #endregion

        #region Выделение объектов

        /// <summary>Выделить подразделение по индексу
        /// </summary>
        /// <param name="index">индекс подразделения</param>
        /// <returns></returns>
        public void selectElement(int index)
        {
            mElements[index].selectMe();
            mSelectedElementId = index;
        }

        /// <summary>Снять выделение с подразделения по индексу
        /// </summary>
        /// <param name="index">индекс подразделения</param>
        /// <returns></returns>
        public void deselectElement(int index)
        {
            mElements[index].deselectMe();
            mSelectedElementId = -1;
        }

        /// <summary>Выделить здание по индексу
        /// </summary>
        /// <param name="index">индекс здания</param>
        /// <returns></returns>
        public void selectBuilding(int index)
        {
            mBuildings[index].selectMe();
            mSelectedBuildingId = index;

            //если в здании есть охранение - выделить его
            if (mBuildings[index].mIsOhran)
            {
                mBuildings[index].mOhraneniye.selectMe();
                mSelectedElementId = mBuildings[index].mOhraneniye.mId;
            }
        }

        /// <summary>Снять выделение со здания по индексу
        /// </summary>
        /// <param name="index">индекс здания</param>
        /// <returns></returns>
        public void deselectBuilding(int index)
        {
            mBuildings[index].deselectMe();
            mSelectedBuildingId = -1;

            //если в здании есть охранение - снять выделение с него
            if (mBuildings[index].mIsOhran)
            {
                mBuildings[index].mOhraneniye.deselectMe();
                mSelectedElementId = -1;
            }
        }

        #endregion

        /// <summary>Пересчитать идентификаторы подразделений и зданий игрока
        /// </summary>
        /// <returns></returns>
        public void recountIds()
        {
            //бежим по подразделениям
            for (int k = 0; k < mElements.Count; k++)
            {
                mElements[k].mId = k;
                mElements[k].mIgrokId = mId;
            }

            //бежим по зданиям
            for (int k = 0; k < mBuildings.Count; k++)
            {
                mBuildings[k].mId = k;
                mBuildings[k].mIgrokId = mId;
            }
        }

        /// <summary>Объединить два подразделения
        /// </summary>
        /// <param name="idAddedEl">ид подразделения, которое добавляют</param>
        /// <param name="idBigEl">ид подразделения, к которому добавляют</param>
        /// <returns>Возвращает ид нового большого подразделения или -1</returns>
        public int addElementToElement(int idAddedEl, int idBigEl)
        {
            //если типы подразделений не совпадают
            if(mElements[idBigEl].mType != mElements[idAddedEl].mType)
                return -1;

            //добавить все юниты добавляемого подразделения в новый
            for(int k = 0; k < mElements[idAddedEl].mUnits.Count; k++)
            {
                mElements[idBigEl].mUnits.Add(mElements[idAddedEl].mUnits[k]);
            }

            //число шагов нового подразделения = минимуму из числа шагов составных подразделений
            int steps = Math.Min(mElements[idBigEl].mSteps, mElements[idAddedEl].mSteps);

            //уничтожить добавляемое подразделение
            mElements.RemoveAt(idAddedEl);

            //меняем ид нового элемента
            idBigEl = Math.Min(idAddedEl, idBigEl); //!!!

            //сдвигаем идентификаторы всех юнитов
            for (int i = 0; i < mElements.Count; i++)
            {
                mElements[i].mId = i;
            }

            //пересчитать показатели нового подразделения
            mElements[idBigEl].recountParams();

            //изменяем число шагов
            mElements[idBigEl].mSteps = steps;

            //выделенный юнит - большой
            mSelectedElementId = idBigEl;

            return idBigEl;
        }
    }
}
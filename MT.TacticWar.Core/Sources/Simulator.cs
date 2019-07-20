using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MT.TacticWar.Core.Types.Simulator;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core
{
    // Симулятор игры - то, что контактирует с граф. интерфейсом и делает все просчёты
    public class Simulator
    {
        //карта
        public Field mGameMap;

        //миссия
        public Mission mMission;

        //игроки
        public Player[] mMasIgroki;    //массив из двух элементов (0 - игрок 1, 1 - игрок 2)

        //параметры игры
        // - системные параметры
        //    * ширина ячейки поля ?в переменной mGameMap?
        //
        // - число сделанных ходов
        // - кто ходит сейчас
        int mIgrok; //-1 - никто, 0 - игрок 0, 1 - игрок 1
        // - набранные очки ?
        // - информация о выделенном юните для графики
        public UnitInfo mUnitInfo;
        // - информация об атаке
        public AttackInfo mAttackInfo;
        // - информация об ошибках
        public string mError;
        // - графика (где рисуется поле боя)
        private Graphics mGrf;

        //!!!! временная переменная (пока не знаю, как сделать иначе)
        Coordinates mKrestCoords; //координаты установленного креста

        //********************************************************************************

        /// <summary>Конструктор
        /// </summary>
        /// <param name="misPath">путь к файлу миссии</param>
        /// <param name="igrk0Name">имя игрока 0</param>
        /// <param name="igrk1Name">имя игрока 1</param>
        /// <param name="igrk0AI">игрок 0 управляется ИИ</param>
        /// <param name="igrk1AI">игрок 1 управляется ИИ</param>
        /// <returns></returns>
        public Simulator(string misPath, string igrk0Name, string igrk1Name,
                                    bool igrk0AI, bool igrk1AI)
        {
            mGrf = null;

            mKrestCoords.x = -1;
            mKrestCoords.y = -1;

            //-----------------------------

            mError = "";

            mMission = new Mission(misPath + "mission.mis");

            //если при загрузке миссии были ошибки
            if (mMission.mError != "")
            {
                mError = mMission.mError;
                return;
            }

            string mapPath = mMission.mPathMap;
            mGameMap = new Field(misPath + mapPath);

            //если при загрузке карты были ошибки
            if (mGameMap.mError != "")
            {
                mError = mGameMap.mError;
                return;
            }
            
            //---------- игроки ----------

            mMasIgroki = new Player[mMission.mCountIgroki];

            /*for (int k = 0; k < mMission.mCountIgroki; k++)
            {
                mMasIgroki[k] = new CIgrok(k, "Игрок " + k.ToString(), false,
                                        misPath + "igrok" + k.ToString() + ".igr");

                //если при загрузке юнитов игрока были ошибки
                if (mMasIgroki[k].mError != "")
                {
                    mError = mMasIgroki[k].mError;
                    return;
                }
            }*/

            mMasIgroki[0] = new Player(0, igrk0Name, igrk0AI, misPath + "igrok0.igr");
            
            //если при загрузке юнитов игрока были ошибки
            if (mMasIgroki[0].mError != "")
            {
                mError = mMasIgroki[0].mError;
                return;
            }

            mMasIgroki[1] = new Player(1, igrk1Name, igrk1AI, misPath + "igrok1.igr");

            //если при загрузке юнитов игрока были ошибки
            if (mMasIgroki[1].mError != "")
            {
                mError = mMasIgroki[1].mError;
                return;
            }

            //-------------------

            /*
            mMasIgroki = new CIgrok[2];
            mMasIgroki[0] = new CIgrok(0);
            mMasIgroki[1] = new CIgrok(1);

            mMasIgroki[0].loadElementsState("123", 0, 3, 3);
            //mMasIgroki[0].mElements[0].mType = DivisionType.Infantry;

            mMasIgroki[0].loadElementsState("123", 1, 3, 1);
            mMasIgroki[0].loadBuildingsState("123", 0, 3, 1);
            mMasIgroki[0].mBuildings[0].addOhraneniye(mMasIgroki[0].mElements[1]);

            mMasIgroki[1].loadElementsState("123", 0, 1, 3);
            mMasIgroki[1].loadBuildingsState("123", 0, 1, 1);
            //mMasIgroki[1].mBuildings[0].addOhraneniye(mMasIgroki[1].mElements[0]);
            */

            //-------------------

            mIgrok = 0;
            mGameMap.fieldZanyatost(mMasIgroki);
        }

        //********************************************************************************

        #region Обработчики рисования

        /// <summary>Рисовать всё
        /// </summary>
        /// <param name="grf">графика, на которой рисовать</param>
        /// <returns></returns>
        public void drawAll(Graphics grf)
        {
            mGrf = grf; //обновляем поле

            mGameMap.drawMap(mGrf);
            int left, top;

            //нарисовать подразделения игрока 0
            for (int k = 0; k < mMasIgroki[0].mElements.Count; k++)
            {
                left = mMasIgroki[0].mElements[k].mCoords.y * mGameMap.mFieldWidth;
                top = mMasIgroki[0].mElements[k].mCoords.x * mGameMap.mFieldWidth;
                mMasIgroki[0].mElements[k].drawElement(mGrf, left, top, mGameMap.mFieldWidth);
            }

            //нарисовать подразделения игрока 1
            for (int k = 0; k < mMasIgroki[1].mElements.Count; k++)
            {
                left = mMasIgroki[1].mElements[k].mCoords.y * mGameMap.mFieldWidth;
                top = mMasIgroki[1].mElements[k].mCoords.x * mGameMap.mFieldWidth;
                mMasIgroki[1].mElements[k].drawElement(mGrf, left, top, mGameMap.mFieldWidth);
            }

            //нарисовать здания игрока 0
            for (int k = 0; k < mMasIgroki[0].mBuildings.Count; k++)
            {
                left = mMasIgroki[0].mBuildings[k].mCoords.y * mGameMap.mFieldWidth;
                top = mMasIgroki[0].mBuildings[k].mCoords.x * mGameMap.mFieldWidth;

                //если есть охранение у здания, стереть уже нарисованного юнита
                if (mMasIgroki[0].mBuildings[k].mIsOhran)
                    mGameMap.drawField(mGrf, mMasIgroki[0].mBuildings[k].mCoords.x, mMasIgroki[0].mBuildings[k].mCoords.y);

                mMasIgroki[0].mBuildings[k].drawBuilding(mGrf, left, top, mGameMap.mFieldWidth);
            }

            //нарисовать здания игрока 1
            for (int k = 0; k < mMasIgroki[1].mBuildings.Count; k++)
            {
                left = mMasIgroki[1].mBuildings[k].mCoords.y * mGameMap.mFieldWidth;
                top = mMasIgroki[1].mBuildings[k].mCoords.x * mGameMap.mFieldWidth;

                //если есть охранение у здания, стереть уже нарисованного юнита
                if (mMasIgroki[1].mBuildings[k].mIsOhran)
                    mGameMap.drawField(mGrf, mMasIgroki[1].mBuildings[k].mCoords.x, mMasIgroki[1].mBuildings[k].mCoords.y);

                mMasIgroki[1].mBuildings[k].drawBuilding(mGrf, left, top, mGameMap.mFieldWidth);
            }

            //нарисовать крест, если он есть
            if (mKrestCoords.x != -1)
                mGameMap.drawKrest(mGrf, mKrestCoords.x, mKrestCoords.y);

            /*//нарисовать путь
            if (mMasIgroki[0].mSelectedElementId != -1)
            {
                drawPutManager(grf, mIgrok, mMasIgroki[0].mSelectedElementId, false);
                //drawFlagManager(grf, 
            }
            else if (mMasIgroki[1].mSelectedElementId != -1)
            {
                drawPutManager(grf, mIgrok, mMasIgroki[1].mSelectedElementId, false);
                //drawFlagManager(grf, 
            }*/
        }

        /// <summary>Снять выделение со всего
        /// </summary>
        /// <returns>Возвращает сигналы обмена с GUI</returns>
        public Signals deselectAll()
        {
            int i, j;

            //!!!!!!!!!!!!! снять крест, если он есть
            if(mKrestCoords.x != -1)
                mGameMap.drawField(mGrf, mKrestCoords.x, mKrestCoords.y);

            mKrestCoords.x = -1;
            mKrestCoords.y = -1;

            //если есть проложенный путь, стираем его
            if (mGameMap.mPutParams.kratPut.Count > 0)
            {
                for (int k = 0; k < mGameMap.mPutParams.kratPut.Count; k++)
                {
                    //перерисовать поле
                    i = mGameMap.mPutParams.kratPut[k].mCoords.x;
                    j = mGameMap.mPutParams.kratPut[k].mCoords.y;
                    mGameMap.drawField(mGrf, i, j);
                }

                mGameMap.mPutParams.kratPut.Clear();
            }

            //бежим по игрокам, перерисовываем юнитов и здания
            for (int k = 0; k < mMasIgroki.GetLength(0); k++)
            {
                //бежим по юнитам игрока k
                for (int kk = 0; kk < mMasIgroki[k].mElements.Count; kk++)
                {
                    //если юнит выделен, снимаем выделение
                    if (mMasIgroki[k].mElements[kk].mSelected)
                    {
                        mMasIgroki[k].deselectElement(kk);
                        mMasIgroki[k].mElements[kk].removeFlag();                        
                    }
                    
                    //перерисовать юнит
                    i = mMasIgroki[k].mElements[kk].mCoords.x;
                    j = mMasIgroki[k].mElements[kk].mCoords.y;
                    mGameMap.drawField(mGrf, i, j); //рисуем ячейку поля
                    mMasIgroki[k].mElements[kk].drawElement(mGrf, j * mGameMap.mFieldWidth, i * mGameMap.mFieldWidth, mGameMap.mFieldWidth);
                }

                //бежим по зданиям игрока k
                for (int kk = 0; kk < mMasIgroki[k].mBuildings.Count; kk++)
                {
                    //если здание выделено, снимаем выделение
                    if (mMasIgroki[k].mBuildings[kk].mSelected)
                    {
                        mMasIgroki[k].deselectBuilding(kk);
                    }

                    //перерисовать юнит
                    i = mMasIgroki[k].mBuildings[kk].mCoords.x;
                    j = mMasIgroki[k].mBuildings[kk].mCoords.y;
                    int index = mMasIgroki[k].isElementAtCoords(i, j);

                    /*//если есть подразделение с этими координатами (у здания нет охранения)
                    if (index == -1)
                    {
                        mMasIgroki[k].mBuildings[kk].mIsOhran = false;
                        mMasIgroki[k].mBuildings[kk].mOhraneniye = null;
                    }
                    else //если есть
                    {
                        mMasIgroki[k].mBuildings[kk].mIsOhran = true;
                        mMasIgroki[k].mBuildings[kk].mOhraneniye = mMasIgroki[k].mElements[index];
                    }*/

                    mGameMap.drawField(mGrf, i, j); //рисуем ячейку поля
                    mMasIgroki[k].mBuildings[kk].drawBuilding(mGrf, j * mGameMap.mFieldWidth, i * mGameMap.mFieldWidth, mGameMap.mFieldWidth);
                }
            }

            return Signals.s01_ALL_IS_GD;
        }

        /// <summary>Рисовать флаг
        /// </summary>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <param name="flagKrest">флаг (true) или крест (false)</param>
        /// <param name="isFEB">флаг на поле (0), на подразделении (1), на здании (2)</param>
        /// <param name="addAtak">добавление (true) или атака (false)</param>
        /// <param name="redBlue">красный (true) или синий флаг (false)</param>
        /// <returns></returns>
        private void drawFlagManager(int i, int j, bool flagKrest, int isFEB, bool addAtak, bool redBlue)
        {
            //нарисовать крест
            if (!flagKrest)
            {
                mGameMap.drawKrest(mGrf, i, j);
                return;
            }

            //нарисовать флаг
            string strRedBlue, strAtak;

            //если весь путь можно пройти за 1 день
            if (redBlue) strRedBlue = "Red";
            else strRedBlue = "Blue";

            //если это не здание
            if (isFEB == 1) //если это подразделение
            {
                //если щелчок по врагу
                if (!addAtak) strAtak = "Atak";
                else strAtak = "Add";
            }
            else if (isFEB == 2) //если это здание
            {
                //если щелчок по вражескому зданию
                if (!addAtak) strAtak = "Capture";
                else strAtak = "Defend";
            }
            else //если это поле
            {
                strAtak = "F";
            }

            mGameMap.drawFlag(mGrf, i, j, strAtak, strRedBlue);
        }

        /// <summary>Рисовать путь для подразделения
        /// </summary>
        /// <param name="igrok">ид игрока, хозяина подразделения</param>
        /// <param name="elemInd">ид подразделения</param>
        /// <param name="countPut">надо ли считать путь заново</param>
        /// <returns>Возвращает (false), если путь не найден</returns>
        private bool drawPutManager(int igrok, int elemInd, bool countPut)
        {
            //просчитать путь, если надо
            if(countPut)
                mGameMap.BellmanPoiskPuti(mMasIgroki[igrok].mElements[elemInd],
                                mMasIgroki[igrok].mElements[elemInd].mFlag);

            //если путь найден
            if (mGameMap.mPutParams.kratPut.Count > 0)
            {
                //просчитать путь для юнита на один день (для рисования на карте)
                List<Cell> oneDayPut = mGameMap.mPutParams.kratPut.ToList<Cell>();
                mMasIgroki[igrok].mElements[elemInd].countOneDayOfElement(ref oneDayPut);

                //нарисовать путь
                mGameMap.drawPut(mGrf, mGameMap.mPutParams.kratPut, oneDayPut);

                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Обработчики нажатий

        /// <summary>Заполнение информации о подразделении
        /// </summary>
        /// <param name="elem">подразделение, о котором собираем информацию</param>
        /// <returns></returns>
        public void setUnitInfo(Division elem)
        {
            /*mUnitInfo.type = elem.mType.ToString();
            mUnitInfo.name = elem.mName;
            mUnitInfo.coords = elem.mCoords;
            mUnitInfo.igrokId = elem.mIgrokId;

            mUnitInfo.health = -1; //нет такого поля
            mUnitInfo.powerAntiAir = elem.mPowerAntiAir;
            mUnitInfo.powerAntiBron = elem.mPowerAntiBron;
            mUnitInfo.powerAntiInf = elem.mPowerAntiInf;

            mUnitInfo.armourFromBron = elem.mArmourFromBron;
            mUnitInfo.armourFromInf = elem.mArmourFromInf;

            mUnitInfo.level = elem.mLevel;
            mUnitInfo.obzor = elem.mObzor;
            mUnitInfo.radius = elem.mRadius;

            mUnitInfo.suplies = elem.mSuplies;
            mUnitInfo.steps = elem.mSteps;*/

            mUnitInfo.playerId = elem.mIgrokId;
            mUnitInfo.elemId = elem.mId;
            mUnitInfo.buildId = -1;

            mUnitInfo.units = elem.mUnits;
        }

        /// <summary>Заполнение информации о здании
        /// </summary>
        /// <param name="building">здание, о котором собираем информацию</param>
        /// <returns></returns>
        public void setUnitInfo(Building building)
        {
            /*mUnitInfo.type = building.mType.ToString();
            mUnitInfo.name = building.mName;
            mUnitInfo.coords = building.mCoords;
            mUnitInfo.igrokId = building.mIgrokId;

            mUnitInfo.health = building.mHealth;
            mUnitInfo.powerAntiAir = -1; //нет такого поля
            mUnitInfo.powerAntiBron = -1; //нет такого поля
            mUnitInfo.powerAntiInf = -1; //нет такого поля

            mUnitInfo.armourFromBron = -1; //нет такого поля
            mUnitInfo.armourFromInf = -1; //нет такого поля

            mUnitInfo.level = UnitLevel.None; //нет такого поля
            mUnitInfo.obzor = building.mObzor;
            mUnitInfo.radius = building.mRadius;

            mUnitInfo.suplies = -1; //нет такого поля
            mUnitInfo.steps = -1; //нет такого поля*/

            mUnitInfo.playerId = building.mIgrokId;
            mUnitInfo.elemId = -1;
            mUnitInfo.buildId = building.mId;

            //если есть охранение
            if (building.mIsOhran)
                mUnitInfo.units = building.mOhraneniye.mUnits;
            else
                mUnitInfo.units = null;
        }

        //----------------------

        /// <summary>Выделить подразделение и собрать информацию о нём
        /// </summary>
        /// <param name="igrokId">ид игрока, хозяина подразделения</param>
        /// <param name="elemId">ид подразделения</param>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns></returns>
        private void clickEM_getElemInfo(int igrokId, int elemId, int i, int j)
        {
            //снять выделение со всего
            deselectAll();

            //выделить юнит
            mMasIgroki[igrokId].selectElement(elemId);
            //заполнить структуру с информацией о юните, чтобы передать гую
            setUnitInfo(mMasIgroki[igrokId].mElements[elemId]);
            //перерисовать землю под юнитом
            mGameMap.drawField(mGrf, i, j);
            //перерисовать выделенный юнит
            mMasIgroki[igrokId].mElements[elemId].drawElement(mGrf, j * mGameMap.mFieldWidth, i * mGameMap.mFieldWidth, mGameMap.mFieldWidth);
        }

        /// <summary>Выделить здание и собрать информацию о нём
        /// </summary>
        /// <param name="igrokId">ид игрока, хозяина здания</param>
        /// <param name="buildId">ид здания</param>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns></returns>
        private void clickEM_getBuildInfo(int igrokId, int buildId, int i, int j)
        {
            //снять выделение со всего
            deselectAll();

            //выделить здание
            mMasIgroki[igrokId].selectBuilding(buildId);

            //если есть охранение - собрать о нём информацию
            if (mMasIgroki[igrokId].mBuildings[buildId].mIsOhran)
                setUnitInfo(mMasIgroki[igrokId].mElements[mMasIgroki[igrokId].mSelectedElementId]);
            else //иначе - о здании
                setUnitInfo(mMasIgroki[igrokId].mBuildings[buildId]);

            //перерисовать землю под зданием
            mGameMap.drawField(mGrf, i, j);
            //перерисовать выделенное здание
            mMasIgroki[igrokId].mBuildings[buildId].drawBuilding(mGrf, j * mGameMap.mFieldWidth, i * mGameMap.mFieldWidth, mGameMap.mFieldWidth);
        }

        /// <summary>Просчитать путь до подразделения, поставить флаг (атака или присоединение)
        /// </summary>
        /// <param name="igrokId">ид игрока, хозяина выделенного подразделения</param>
        /// <param name="enemieClick">щелчок по объекту врага</param>
        /// <param name="toFEB">куда идём (0 - до поля, 1 - до подразделения [, 2 - до здания])</param>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns></returns>
        private void clickEM_countPutToObject(int igrokId, bool enemieClick, int toFEB, int i, int j)
        {
            Coordinates tmp; //для запоминания координат

            //запомнить индекс выделенного юнита
            int oldSelectInd = mMasIgroki[igrokId].mSelectedElementId;

            //снять выделение со всего и заново выделить юнит
            deselectAll();
            mMasIgroki[igrokId].selectElement(oldSelectInd);

            //перерисовать юнит (уже с выделением)
            tmp.x = mMasIgroki[igrokId].mElements[oldSelectInd].mCoords.x;
            tmp.y = mMasIgroki[igrokId].mElements[oldSelectInd].mCoords.y;
            mGameMap.drawField(mGrf, tmp.x, tmp.y);
            mMasIgroki[igrokId].mElements[oldSelectInd].drawElement(mGrf, tmp.y * mGameMap.mFieldWidth, tmp.x * mGameMap.mFieldWidth, mGameMap.mFieldWidth);

            //установить флаг на нажатую клетку
            mMasIgroki[igrokId].mElements[oldSelectInd].setFlag(i, j);

            //просчитать путь, и если он существует нарисовать его и флаг
            if (drawPutManager(igrokId, oldSelectInd, true))
            {
                bool redBlue = false;

                //если юнит за день дойдёт до флага, то красный
                if ((mMasIgroki[igrokId].mElements[oldSelectInd].mFlag.x == mMasIgroki[igrokId].mElements[oldSelectInd].mDayTag.x) &&
                    (mMasIgroki[igrokId].mElements[oldSelectInd].mFlag.y == mMasIgroki[igrokId].mElements[oldSelectInd].mDayTag.y))
                    redBlue = true;

                //нарисовать флаг (координаты, флаг/крест, поле0/подразд1/здание2, добавление/атака, красный/синий)
                drawFlagManager(i, j, true, toFEB, !enemieClick, redBlue);
            }
            else
            {
                //нарисовать крест
                mKrestCoords.x = i;
                mKrestCoords.y = j;
                mGameMap.drawKrest(mGrf, i, j);
            }
        }

        /// <summary>Просчитать путь до здания, поставить флаг (захват, атака или присоединение)
        /// </summary>
        /// <param name="igrokId">ид игрока, хозяина выделенного подразделения</param>
        /// <param name="buildId">ид здания</param>
        /// <param name="enemieClick">щелчок по зданию врага</param>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns></returns>
        private void clickEM_countPutToBuild(int igrokId, int buildId, bool enemieClick, int i, int j)
        {
            Coordinates tmp; //для запоминания координат

            //запомнить нидекс выделенного юнита
            int oldSelectInd = mMasIgroki[igrokId].mSelectedElementId;

            //снять выделение со всего и заново выделить юнит
            deselectAll();
            mMasIgroki[igrokId].selectElement(oldSelectInd);

            //перерисовать юнит
            tmp.x = mMasIgroki[igrokId].mElements[oldSelectInd].mCoords.x;
            tmp.y = mMasIgroki[igrokId].mElements[oldSelectInd].mCoords.y;
            //mGameMap.drawField(grf, tmp.x, tmp.y);
            mMasIgroki[igrokId].mElements[oldSelectInd].drawElement(mGrf, tmp.y * mGameMap.mFieldWidth, tmp.x * mGameMap.mFieldWidth, mGameMap.mFieldWidth);

            //установить флаг
            mMasIgroki[igrokId].mElements[oldSelectInd].setFlag(i, j);

            //просчитать путь, и если он существует
            if (drawPutManager(igrokId, oldSelectInd, true))
            {
                bool redBlue = false;

                if ((mMasIgroki[igrokId].mElements[oldSelectInd].mFlag.x == mMasIgroki[igrokId].mElements[oldSelectInd].mDayTag.x) &&
                    (mMasIgroki[igrokId].mElements[oldSelectInd].mFlag.y == mMasIgroki[igrokId].mElements[oldSelectInd].mDayTag.y))
                    redBlue = true;

                //нарисовать флаг

                //если нажатие по зданию врага
                if (enemieClick)
                {
                    //если есть охранение - поставить флаг атаки
                    if (mMasIgroki[(igrokId + 1) % 2].mBuildings[buildId].mIsOhran)
                        drawFlagManager(i, j, true, 1, !enemieClick, redBlue);
                    else //поставить флаг захвата
                        drawFlagManager(i, j, true, 2, !enemieClick, redBlue);
                }
                else
                {
                    //если есть охранение - поставить флаг добавления
                    if (mMasIgroki[igrokId].mBuildings[buildId].mIsOhran)
                        drawFlagManager(i, j, true, 1, !enemieClick, redBlue);
                    else //поставить флаг защиты здания
                        drawFlagManager(i, j, true, 2, !enemieClick, redBlue);
                }
            }
            else
            {
                //нарисовать крест
                mGameMap.drawKrest(mGrf, i, j);
                mKrestCoords.x = i;
                mKrestCoords.y = j;
            }
        }

        /// <summary>Продвинуть выделенный элемент к объекту
        /// </summary>
        /// <param name="igrokId">ид игрока, хозяина выделенного подразделения</param>
        /// <param name="enemieClick">щелчок по объекту врага</param>
        /// <param name="toFEB">куда идём (0 - до поля, 1 - до подразделения, 2 - до здания)</param>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns></returns>
        private void clickEM_pushElemToObject(int igrokId, bool enemieClick, int toFEB, int i, int j)
        {
            Coordinates tmp; //для запоминания координат

            //запомнить нидекс выделенного юнита
            int oldSelectInd = mMasIgroki[igrokId].mSelectedElementId;
            //запомнить координаты выделенного юнитаюнита
            tmp = mMasIgroki[igrokId].mElements[oldSelectInd].mCoords;

            //если путь был найден
            if (mGameMap.mPutParams.kratPut.Count > 0)
            {
                //сдвинуть юнит
                mMasIgroki[igrokId].mElements[oldSelectInd].pushElement(mGameMap.mPutParams.kratPut);
                
                //если юнит сместился (!)
                if ((tmp.x != mMasIgroki[igrokId].mElements[oldSelectInd].mCoords.x) ||
                    (tmp.y != mMasIgroki[igrokId].mElements[oldSelectInd].mCoords.y))
                {
                    //стереть юнит со старого места
                    mGameMap.drawField(mGrf, tmp.x, tmp.y);


                    //если на старом месте нет здания - освободить старую ячейку
                    int indd = mMasIgroki[igrokId].isBuildingAtCoords(tmp.x, tmp.y);
                    if (indd == -1)
                        mGameMap.mField[tmp.x, tmp.y].mZanyata = false;
                    else //иначе - освободить здание
                    {
                        mMasIgroki[igrokId].mBuildings[indd].mOhraneniye = null;
                        mMasIgroki[igrokId].mBuildings[indd].mIsOhran = false;
                    }

                    //нарисовать юнит на новом месте
                    tmp.x = mMasIgroki[igrokId].mElements[oldSelectInd].mCoords.x;
                    tmp.y = mMasIgroki[igrokId].mElements[oldSelectInd].mCoords.y;

                    //занять новую ячейку
                    mGameMap.mField[tmp.x, tmp.y].mZanyata = true;

                    //временно сохранить путь
                    List<Cell> tmpPut = mGameMap.mPutParams.kratPut.ToList<Cell>();

                    //убрать из путь часть, которую уже прошли
                    while (tmpPut.Count > 0)
                    {
                        if ((tmpPut[0].mCoords.x == tmp.x) && (tmpPut[0].mCoords.y == tmp.y))
                            break;

                        tmpPut.RemoveAt(0);
                    }

                    //выделить юнит заново и собрать информацию о нём
                    clickEM_getElemInfo(igrokId, oldSelectInd, tmp.x, tmp.y);

                    //загрузить путь из временной памяти
                    mGameMap.mPutParams.kratPut = tmpPut.ToList<Cell>();

                    //установить флаг
                    mMasIgroki[igrokId].mElements[oldSelectInd].setFlag(i, j);

                    //нарисовать путь без пересчёта и нарисавать флаг
                    if (drawPutManager(igrokId, oldSelectInd, false))
                    {
                        //если юнит НЕ дошёл до флага за день
                        if ((mMasIgroki[igrokId].mElements[oldSelectInd].mFlag.x != mMasIgroki[igrokId].mElements[oldSelectInd].mDayTag.x) ||
                            (mMasIgroki[igrokId].mElements[oldSelectInd].mFlag.y != mMasIgroki[igrokId].mElements[oldSelectInd].mDayTag.y))
                        {
                            //нарисовать флаг (координаты, флаг/крест, поле0/подразд1/здание2, добавление/атака, красный/синий)
                            drawFlagManager(i, j, true, toFEB, !enemieClick, false);
                        }

                        //иначе флаг будет поверх присоединённого или атакуемого юнита
                    }
                } //конец условия смещения юнита
            } //конец условия нахождения пути
        }

        //----------------------

        /// <summary>Обработчик нажатия на подразделение
        /// </summary>
        /// <param name="igrok">ид текущего игрока</param>
        /// <param name="enemie">ид врага</param>
        /// <param name="enemieClick">щелчок по подразделению врага</param>
        /// <param name="ind">индекс подразделения, на которое нажали</param>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns>Возвращает сигналы обмена с GUI</returns>
        private Signals clickElementManager(int igrok, int enemie, bool enemieClick, int ind, int i, int j)
        {
            int switchInt; //варианты движения юнита

            if (!enemieClick)
                switchInt = mMasIgroki[igrok].clickMyElement(ind);
            else
                switchInt = mMasIgroki[igrok].clickEnemieElement(mMasIgroki[enemie].mElements[ind].mCoords);

            //вызвать обработчик нажатия на свой юнит
            switch (switchInt)
            {
                case 1: //передать информацию о выделенном юните

                    //если щёлкнули по врагу - собрать о его юните информацию
                    if (enemieClick) igrok = enemie;

                    //выделить юнита, заполнить структуру
                    clickEM_getElemInfo(igrok, ind, i, j);

                    //готова информация о единице
                    return Signals.s03_READY_UNIT_INFO;
                case 2: //поставить флаг, просчитать путь

                    //считаем путь до элемента, рисуем его и флаг
                    clickEM_countPutToObject(igrok, enemieClick, 1, i, j);
                    break;
                case 3: //продвинуть выделенный юнит к данному

                    //продвинуть выделенный элемент к данному элементу
                    clickEM_pushElemToObject(igrok, enemieClick, 1, i, j);

                    //---

                    int oldSelectInd = mMasIgroki[igrok].mSelectedElementId;

                    //если атакуем противника
                    if (!enemieClick)
                    {
                        //если координаты юнита совпадают с координатами целевого юнита
                        if ((mMasIgroki[igrok].mElements[oldSelectInd].mCoords.x == mMasIgroki[igrok].mElements[ind].mCoords.x) &&
                            (mMasIgroki[igrok].mElements[oldSelectInd].mCoords.y == mMasIgroki[igrok].mElements[ind].mCoords.y))
                        {
                            return achievementTag(mMasIgroki[igrok].mElements[oldSelectInd], mMasIgroki[igrok].mElements[ind]);
                        }
                    }
                    else
                    {
                        //если координаты юнита совпадают с координатами целевого юнита
                        if ((mMasIgroki[igrok].mElements[oldSelectInd].mCoords.x == mMasIgroki[enemie].mElements[ind].mCoords.x) &&
                            (mMasIgroki[igrok].mElements[oldSelectInd].mCoords.y == mMasIgroki[enemie].mElements[ind].mCoords.y))
                        {
                            return achievementTag(mMasIgroki[igrok].mElements[oldSelectInd], mMasIgroki[enemie].mElements[ind]);
                        }
                    }

                    //обновлена информация о единице
                    return Signals.s03_READY_UNIT_INFO;
            }

            //передаём гую, что всё хорошо
            return Signals.s01_ALL_IS_GD;
        }
        
        /// <summary>Обработчик нажатия на здание
        /// </summary>
        /// <param name="igrok">ид текущего игрока</param>
        /// <param name="enemie">ид врага</param>
        /// <param name="enemieClick">щелчок по зданию врага</param>
        /// <param name="ind">индекс здания, на которое нажали</param>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns>Возвращает сигналы обмена с GUI</returns>
        private Signals clickBuildingManager(int igrok, int enemie, bool enemieClick, int ind, int i, int j)
        {
            int switchInt;
            int oldSelectInd; //индекс уже выделенного юнита
            Coordinates tmp; //для запоминания координат

            if (!enemieClick)
                switchInt = mMasIgroki[igrok].clickMyBuilding(ind);
            else
                switchInt = mMasIgroki[igrok].clickEnemieBuilding(mMasIgroki[enemie].mBuildings[ind].mCoords);

            //вызвать обработчик нажатия на свой юнит
            switch (switchInt)
            {
                case 1: //передать информацию о выделенном юните

                    //если щёлкнули по врагу - собрать о его юните информацию
                    if (enemieClick) igrok = enemie;

                    //выделить здание, заполнить структуру
                    clickEM_getBuildInfo(igrok, ind, i, j);

                    //готова информация о единице
                    return Signals.s03_READY_UNIT_INFO;
                case 2: //поставить флаг, просчитать путь

                    //просчитать путь до здания, поставить флаг (захват, атака или присоединение)
                    clickEM_countPutToBuild(igrok, ind, enemieClick, i, j);

                    break;
                case 3: //продвинуть выделенный юнит к данному

                    //захватываем здание или нападаем на охранение здания?
                    int toFEB = 2;

                    if (enemieClick)
                    {
                        if (mMasIgroki[enemie].mBuildings[ind].mIsOhran)
                            toFEB = 1;
                    }
                    else
                    {
                        if (mMasIgroki[igrok].mBuildings[ind].mIsOhran)
                            toFEB = 1;
                    }

                    //продвинуть выделенный элемент к данному зданию
                    clickEM_pushElemToObject(igrok, enemieClick, toFEB, i, j);

                    //---

                    oldSelectInd = mMasIgroki[igrok].mSelectedElementId;
                    tmp.x = mMasIgroki[igrok].mElements[oldSelectInd].mCoords.x;
                    tmp.y = mMasIgroki[igrok].mElements[oldSelectInd].mCoords.y;

                    //если двигаем к своему зданию
                    if (!enemieClick)
                    {
                        //если координаты юнита совпадают с координатами целевого здания
                        if ((mMasIgroki[igrok].mElements[oldSelectInd].mCoords.x == mMasIgroki[igrok].mBuildings[ind].mCoords.x) &&
                            (mMasIgroki[igrok].mElements[oldSelectInd].mCoords.y == mMasIgroki[igrok].mBuildings[ind].mCoords.y))
                        {
                            Signals tmpSig = achievementTag(mMasIgroki[igrok].mElements[oldSelectInd], mMasIgroki[igrok].mBuildings[ind]);

                            mGameMap.drawField(mGrf, tmp.x, tmp.y);
                            mMasIgroki[igrok].mBuildings[ind].drawBuilding(mGrf, tmp.y * mGameMap.mFieldWidth, tmp.x * mGameMap.mFieldWidth, mGameMap.mFieldWidth);
                            return tmpSig;
                        }
                    }
                    else
                    {
                        //если координаты юнита совпадают с координатами целевого здания
                        if ((mMasIgroki[igrok].mElements[oldSelectInd].mCoords.x == mMasIgroki[enemie].mBuildings[ind].mCoords.x) &&
                            (mMasIgroki[igrok].mElements[oldSelectInd].mCoords.y == mMasIgroki[enemie].mBuildings[ind].mCoords.y))
                        {
                            Signals tmpSig = achievementTag(mMasIgroki[igrok].mElements[oldSelectInd], mMasIgroki[enemie].mBuildings[ind]);

                            mGameMap.drawField(mGrf, tmp.x, tmp.y);
                            mMasIgroki[igrok].mBuildings[mMasIgroki[igrok].mBuildings.Count - 1].drawBuilding(mGrf, tmp.y * mGameMap.mFieldWidth, tmp.x * mGameMap.mFieldWidth, mGameMap.mFieldWidth);
                            return tmpSig;
                        }
                    }

                    return Signals.s03_READY_UNIT_INFO;
            }

            //передаём гую, что всё хорошо
            return Signals.s01_ALL_IS_GD;
        }

        /// <summary>Обработчик попадания на пустую клетку
        /// </summary>
        /// <param name="igrok">ид текущего игрока</param>
        /// <param name="ind">индекс выделенного подразделения</param>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns>Возвращает сигналы обмена с GUI</returns>
        private Signals clickEmptyFieldManager(int igrok, int ind, int i, int j)
        {
            //если на этом месте стоит флаг - продвинуть юнит
            if ((mMasIgroki[igrok].mElements[ind].mFlag.x == i) &&
                (mMasIgroki[igrok].mElements[ind].mFlag.y == j))
            {
                //продвинуть юнит
                clickEM_pushElemToObject(igrok, false, 0, i, j);

                //обновить информацию
                return Signals.s03_READY_UNIT_INFO;
            }
            else
            {
                //считаем путь до поля и рисуем его
                clickEM_countPutToObject(igrok, false, 0, i, j);
            }

            //вернуть, что всё хорошо
            return Signals.s01_ALL_IS_GD;
        }

        //----------------------

        /// <summary>Обработчик достижения цели (подразделения)
        /// </summary>
        /// <param name="thisElem">текущее подразделение</param>
        /// <param name="tagElem">целевое подразделение</param>
        /// <returns>Возвращает сигналы обмена с GUI</returns>
        public Signals achievementTag(Division thisElem, Division tagElem)
        {
            //если целевой юнит - это юнит того же игрока
            if (thisElem.mIgrokId == tagElem.mIgrokId)
            {
                //присоединить юниты
                int newUnitId = mMasIgroki[thisElem.mIgrokId].addElementToElement(thisElem.mId, tagElem.mId);
                setUnitInfo(mMasIgroki[thisElem.mIgrokId].mElements[newUnitId]);
            }
            else
            {
                //заполняем структуру информации об атаке
                mAttackInfo.igrokAttacked = thisElem.mIgrokId;
                mAttackInfo.igrokDefended = tagElem.mIgrokId;
                mAttackInfo.elemAttacked = thisElem.mId;
                mAttackInfo.elemDefended = tagElem.mId;

                //атака всегда отнимает шаги до минимума
                thisElem.mSteps = 0;
                tagElem.mSteps = 0;

                return Signals.s04_ATTACK;
            }

            return Signals.s03_READY_UNIT_INFO;
        }

        /// <summary>Обработчик достижения цели (здания)
        /// </summary>
        /// <param name="thisElem">текущее подразделение</param>
        /// <param name="tagBuild">целевое здание</param>
        /// <returns>Возвращает сигналы обмена с GUI</returns>
        public Signals achievementTag(Division thisElem, Building tagBuild)
        {
            int tmp;

            //если целевое здание - это здание того же игрока
            if (thisElem.mIgrokId == tagBuild.mIgrokId)
            {
                //если в здании есть охранение
                if (mMasIgroki[thisElem.mIgrokId].mBuildings[tagBuild.mId].mIsOhran)
                {
                    //если типы юнитов совпадают
                    if (thisElem.mType == mMasIgroki[tagBuild.mIgrokId].mBuildings[tagBuild.mId].mOhraneniye.mType)
                    {
                        //присоединить юниты
                        mMasIgroki[thisElem.mIgrokId].addElementToElement(thisElem.mId, mMasIgroki[thisElem.mIgrokId].mBuildings[tagBuild.mId].mOhraneniye.mId);
                    }
                    else //иначе - всё плохо
                        return Signals.s02_ALL_IS_BD;
                }
                else
                {
                    //поставить на охрану
                    mMasIgroki[tagBuild.mIgrokId].mBuildings[tagBuild.mId].mOhraneniye = thisElem;
                    mMasIgroki[tagBuild.mIgrokId].mBuildings[tagBuild.mId].mIsOhran = true;

                    //встать на охранение здания - отнимает все шаги
                    mMasIgroki[thisElem.mIgrokId].mElements[thisElem.mId].mSteps = 0;
                }

                tmp = tagBuild.mId;
            }
            else
            {
                //если в здании есть охранение
                if (mMasIgroki[tagBuild.mIgrokId].mBuildings[tagBuild.mId].mIsOhran)
                {
                    //заполняем структуру информации об атаке
                    mAttackInfo.igrokAttacked = thisElem.mIgrokId;
                    mAttackInfo.igrokDefended = mMasIgroki[tagBuild.mIgrokId].mBuildings[tagBuild.mId].mOhraneniye.mIgrokId;
                    mAttackInfo.elemAttacked = thisElem.mId;
                    mAttackInfo.elemDefended = mMasIgroki[tagBuild.mIgrokId].mBuildings[tagBuild.mId].mOhraneniye.mId;

                    //атака всегда отнимает шаги до минимума
                    thisElem.mSteps = 0;
                    mMasIgroki[tagBuild.mIgrokId].mBuildings[tagBuild.mId].mOhraneniye.mSteps = 0;

                    return Signals.s04_ATTACK;
                }
                else
                {
                    Building tmpBuild;

                    //захват постройки
                    tmp = tagBuild.mId;
                    tmpBuild = tagBuild.copyBuilding();
                    mMasIgroki[thisElem.mIgrokId].mBuildings.Add(tmpBuild);
                    mMasIgroki[thisElem.mIgrokId].recountIds();
                    mMasIgroki[tagBuild.mIgrokId].mBuildings.RemoveAt(tmp);
                    mMasIgroki[tagBuild.mIgrokId].recountIds();

                    //захват всегда отнимает все шаги
                    thisElem.mSteps = 0;

                    //поставить юнита на охранение
                    tmp = mMasIgroki[thisElem.mIgrokId].mBuildings[mMasIgroki[thisElem.mIgrokId].mBuildings.Count - 1].mId;
                    mMasIgroki[thisElem.mIgrokId].mBuildings[tmp].mOhraneniye = thisElem;
                    mMasIgroki[thisElem.mIgrokId].mBuildings[tmp].mIsOhran = true;
                }
            }

            mMasIgroki[thisElem.mIgrokId].selectBuilding(tmp);

            return Signals.s03_READY_UNIT_INFO;
        }

        //----------------------

        /// <summary>Обработчик нажатия на зону боевых действий
        /// </summary>
        /// <param name="x">координата по высоте (!)</param>
        /// <param name="y">координата по ширине (!)</param>
        /// <returns>Возвращает сигналы обмена с GUI</returns>
        public Signals zonaClick(int x, int y)
        {
            int i = y / mGameMap.mFieldWidth;
            int j = x / mGameMap.mFieldWidth;

            //если координаты за границами карты
            if((i < 0) || (i > (mGameMap.mHeight-1))) return Signals.s05_OUT_OF_RANGE;
            if((j < 0) || (j > (mGameMap.mWidth-1))) return Signals.s05_OUT_OF_RANGE;

            //проверяем, по чему щёлкнули...

            int ind; //индекс текущего юнита

            //mIgrok = 1; //!!!!!!!! дебаг !!!!!!!!

            //если ходит игрок 0
            if (mIgrok == 0)
            {
                //--- здание игрока 0 ---

                ind = mMasIgroki[0].isBuildingAtCoords(i, j);

                if (ind != -1)
                    return clickBuildingManager(0, 1, false, ind, i, j);

                //--- здание игрока 1 ---

                ind = mMasIgroki[1].isBuildingAtCoords(i, j);

                if (ind != -1)
                    return clickBuildingManager(0, 1, true, ind, i, j);

                //--- если щёлкнули по юниту игрока 0 ---

                ind = mMasIgroki[0].isElementAtCoords(i, j);

                if (ind != -1)
                    return clickElementManager(0, 1, false, ind, i, j);

                //--- если щёлкнули по юниту игрока 1 ---

                ind = mMasIgroki[1].isElementAtCoords(i, j);

                if (ind != -1)
                    return clickElementManager(0, 1, true, ind, i, j);



                //--- попали на пустую клетку ---

                //если выделен юнит игрока 0
                ind = mMasIgroki[0].mSelectedElementId;

                if (ind != -1)
                    return clickEmptyFieldManager(0, ind, i, j);
            }
            else //если ходит игрок 1 (mIgrok == 1)
            {
                //--- если щёлкнули по юниту игрока 0 ---

                ind = mMasIgroki[0].isElementAtCoords(i, j);

                if (ind != -1)
                    return clickElementManager(1, 0, true, ind, i, j);

                //--- если щёлкнули по юниту игрока 1 ---

                ind = mMasIgroki[1].isElementAtCoords(i, j);

                if (ind != -1)
                    return clickElementManager(1, 0, false, ind, i, j);

                //--- здание игрока 0 ---

                ind = mMasIgroki[0].isBuildingAtCoords(i, j);

                if (ind != -1)
                    return clickBuildingManager(1, 0, true, ind, i, j);

                //--- здание игрока 1 ---

                ind = mMasIgroki[1].isBuildingAtCoords(i, j);

                if (ind != -1)
                    return clickBuildingManager(1, 0, false, ind, i, j);

                //--- попали на пустую клетку ---

                //если выделен юнит игрока 1
                ind = mMasIgroki[1].mSelectedElementId;

                if (ind != -1)
                    return clickEmptyFieldManager(1, ind, i, j);
            }

            //передаём гую, что всё хорошо
            return Signals.s01_ALL_IS_GD;
        }

        #endregion

        //Симулятор атаки
        public int attackSimulator(Division elem1, Division elem2,
                List<Division> podderzh1, List<Division> podderzh2)
        {
            Random rand = new Random();
            int elem;
            int indUnit1, indUnit2;

            StructUnits sui1, sui2;
            bool elem1_none_supl = false; //если у нападающего кончатся патроны

            //пока есть юниты в обоих подразделениях
            while ((elem1.mUnits.Count > 0) && (elem2.mUnits.Count > 0))
            {
                //- ПРЯМАЯ АТАКА -

                //случайно выбираем подразделение
                elem = rand.Next(0, podderzh1.Count);

                //если это АТАКУЮЩЕЕ подразделение атакующего игрока
                if (elem == 0)
                {
                    //случайно выбираем юнита из атакующего подразделения
                    indUnit1 = rand.Next(0, elem1.mUnits.Count - 1);

                    //случайно выбираем юнита из атакуемого подразделения
                    indUnit2 = rand.Next(0, elem2.mUnits.Count - 1);

                    //атакуем
                    sui1 = elem1.mUnits[indUnit1];
                    sui2 = elem2.mUnits[indUnit2];
                    unitAtakUnit(ref sui1, ref sui2);
                    elem1.mUnits[indUnit1] = sui1;
                    elem2.mUnits[indUnit2] = sui2;
                }
                else //если это подразделение ПОДДЕРЖКИ
                {
                    //случайно выбираем юнита из выбранного подразделения поддержки
                    indUnit1 = rand.Next(0, podderzh1[elem-1].mUnits.Count - 1);

                    //случайно выбираем юнита из атакуемого подразделения
                    indUnit2 = rand.Next(0, elem2.mUnits.Count - 1);

                    //атакуем
                    sui1 = podderzh1[elem - 1].mUnits[indUnit1];
                    sui2 = elem2.mUnits[indUnit2];
                    unitAtakUnit(ref sui1, ref sui2);
                    podderzh1[elem - 1].mUnits[indUnit1] = sui1;
                    elem2.mUnits[indUnit2] = sui2;
                }

                //удалить юнита, если его убили
                if (elem2.mUnits[indUnit2].unit.mHealth == Health.Dead)
                    elem2.mUnits.RemoveAt(indUnit2);

                //если врага убили - конец цикла
                if (elem2.mUnits.Count < 1)
                    break;

                //- ОТВЕТНАЯ АТАКА -

                //случайно выбираем подразделение
                elem = rand.Next(0, podderzh2.Count);

                //если это АТАКУЮЩЕЕ подразделение защищающегося игрока
                if (elem == 0)
                {
                    //случайно выбираем юнита из атакующего подразделения
                    indUnit2 = rand.Next(0, elem2.mUnits.Count - 1);

                    //случайно выбираем юнита из атакуемого подразделения
                    indUnit1 = rand.Next(0, elem1.mUnits.Count - 1);

                    //атакуем
                    sui1 = elem2.mUnits[indUnit2];
                    sui2 = elem1.mUnits[indUnit1];
                    unitAtakUnit(ref sui1, ref sui2);
                    elem2.mUnits[indUnit2] = sui1;
                    elem1.mUnits[indUnit1] = sui2;
                }
                else //если это подразделение ПОДДЕРЖКИ
                {
                    //случайно выбираем юнита из выбранного подразделения поддержки
                    indUnit2 = rand.Next(0, podderzh2[elem - 1].mUnits.Count - 1);

                    //случайно выбираем юнита из атакуемого подразделения
                    indUnit1 = rand.Next(0, elem1.mUnits.Count - 1);

                    //атакуем
                    sui1 = podderzh2[elem - 1].mUnits[indUnit2];
                    sui2 = elem1.mUnits[indUnit1];
                    unitAtakUnit(ref sui1, ref sui2);
                    podderzh2[elem - 1].mUnits[indUnit2] = sui1;
                    elem1.mUnits[indUnit1] = sui2;
                }

                //удалить юнита, если его убили
                if (elem1.mUnits[indUnit1].unit.mHealth == Health.Dead)
                    elem1.mUnits.RemoveAt(indUnit1);

                //если врага убили - конец цикла
                if (elem1.mUnits.Count < 1)
                    break;

                //----------

                //если у нападающего кончились патроны - он отступает
                if(elem1.mUnits[indUnit1].unit.mSuplies == 0)
                {
                    elem1_none_supl = true;
                    recedeElem(elem1); //отступить
                    break;
                }
            } //конец цикла

            //----------

            int win = 0; //ид победителя (0 - ничья, 1 - атакующий, 2 - атакуемый)

            if (elem1.mUnits.Count > 0)
            {
                win = 1;
                elem1.recountParams();

                //пересчитать показатели поддержки
                for (int k = 0; k < podderzh1.Count; k++)
                    podderzh1[k].recountParams();
            }

            if (elem2.mUnits.Count > 0)
            {
                win = 2;
                elem2.recountParams();

                //пересчитать показатели поддержки
                for (int k = 0; k < podderzh2.Count; k++)
                    podderzh2[k].recountParams();
            }

            //если у нападающего кончились патроны - ничья
            if (elem1_none_supl) win = 0;

            return win;
        }

        //Вернуть долю, которую вносит уровень повышения юнита
        private double getLevelVes(UnitLevel lev)
        {
            double max_level = 3.0;

            switch (lev)
            {
                case UnitLevel.Warrior:
                    return (1.0 / max_level);
                case UnitLevel.Veteran:
                    return (2.0 / max_level);
                case UnitLevel.Hero:
                    return (3.0 / max_level);
                case UnitLevel.Recruit:
                default:
                    return 0.0;
            }
        }

        //Считаем защиту юнита
        private void unitAtakUnit(ref StructUnits structUnit1, ref StructUnits structUnit2)
        {
            Random rand = new Random();

            double armour;          //защита атакуемого юнита
            double attack_power;    //мощь удара атакующего юнита
            double wound;           //ранение (armour - attack_power)
            double level;           //уровни юнитов (для подсчёта силы удара и защиты)

            //выбираем уровень атакуемого юнита
            level = getLevelVes(structUnit2.unit.mLevel);

            //по типу атакующего юнита определяем защиту
            switch (structUnit1.unit.mType)
            {
                case DivisionType.Infantry:
                    armour = (double)structUnit2.unit.mArmourFromInf;
                    break;
                case DivisionType.Aviation:
                case DivisionType.Vehicle:
                case DivisionType.Artillery:
                case DivisionType.Ship:
                default:
                    armour = (double)structUnit2.unit.mArmourFromBron;
                    break;
            }

            //определяем защиту атакуемого юнита
            armour *= (double)structUnit2.count * (rand.NextDouble() * (1 - level) + level);

            //----------

            //выбираем уровень атакующего юнита
            level = getLevelVes(structUnit1.unit.mLevel);

            //по типу атакуемого юнита определяем мощь атаки
            switch (structUnit2.unit.mType)
            {
                case DivisionType.Infantry:
                    attack_power = (double)structUnit1.unit.mPowerAntiInf;
                    break;
                case DivisionType.Aviation:
                    attack_power = (double)structUnit1.unit.mPowerAntiAir;
                    break;
                case DivisionType.Vehicle:
                case DivisionType.Artillery:
                case DivisionType.Ship:
                default:
                    attack_power = (double)structUnit1.unit.mPowerAntiBron;
                    break;
            }

            //определяем мощь атакующего юнита
            attack_power *= (double)structUnit1.count *
                                (rand.NextDouble() * (1 - level) + level);

            //если патронов у юнита не хватает
            if (structUnit1.unit.mSuplies < attack_power)
            {
                attack_power = structUnit1.unit.mSuplies;
                structUnit1.unit.mSuplies = 0;
            }
            else
            {
                structUnit1.unit.mSuplies -= (int)attack_power;
            }

            //----------

            //подсчёт повреждения для атакуемого юнита
            wound = armour - attack_power;
            if (wound <= 0)
            {
                structUnit2.count = 0;
                structUnit2.unit.mHealth = Health.Dead;
            }
            else if ((wound / (double)structUnit2.unit.mArmourFromInf) < 1)
            {
                structUnit2.count = 1;
                structUnit2.unit.mHealth = Health.Wounded;
            }
            else
            {
                structUnit2.count = (int)(wound / (double)structUnit2.unit.mArmourFromInf);
            }
        }

        //Отступить подразделению на ближайшую свободную клетку
        private void recedeElem(Division elem)
        {
            bool fl = true;
            Coordinates coords;
            coords.x = elem.mCoords.x;
            coords.y = elem.mCoords.y;

            //лево
            if ((!mGameMap.mField[coords.x, coords.y - 1].mZanyata) &&
                (mGameMap.mField[coords.x, coords.y - 1].mProhodima))
            {
                //если вода, а юнит не плавает
                if ((mGameMap.mField[coords.x, coords.y - 1].mZemType == CellType.Water) &&
                    (!elem.mStepAqua))
                    fl = false;

                //если не вода, а юнит только плавает
                if ((mGameMap.mField[coords.x, coords.y - 1].mZemType != CellType.Water) &&
                    (!elem.mStepLand))
                    fl = false;

                if (fl)
                {
                    elem.mCoords.y -= 1;
                    return;
                }
            }

            fl = true;

            //верх
            if ((!mGameMap.mField[coords.x - 1, coords.y].mZanyata) &&
                (mGameMap.mField[coords.x - 1, coords.y].mProhodima))
            {
                //если вода, а юнит не плавает
                if ((mGameMap.mField[coords.x - 1, coords.y].mZemType == CellType.Water) &&
                    (!elem.mStepAqua))
                    fl = false;

                //если не вода, а юнит только плавает
                if ((mGameMap.mField[coords.x - 1, coords.y].mZemType != CellType.Water) &&
                    (!elem.mStepLand))
                    fl = false;

                if (fl)
                {
                    elem.mCoords.x -= 1;
                    return;
                }
            }

            fl = true;

            //право
            if ((!mGameMap.mField[coords.x, coords.y + 1].mZanyata) &&
                (mGameMap.mField[coords.x, coords.y + 1].mProhodima))
            {
                //если вода, а юнит не плавает
                if ((mGameMap.mField[coords.x, coords.y + 1].mZemType == CellType.Water) &&
                    (!elem.mStepAqua))
                    fl = false;

                //если не вода, а юнит только плавает
                if ((mGameMap.mField[coords.x, coords.y + 1].mZemType != CellType.Water) &&
                    (!elem.mStepLand))
                    fl = false;

                if (fl)
                {
                    elem.mCoords.y += 1;
                    return;
                }
            }

            fl = true;

            //вниз
            if ((!mGameMap.mField[coords.x + 1, coords.y].mZanyata) &&
                (mGameMap.mField[coords.x + 1, coords.y].mProhodima))
            {
                //если вода, а юнит не плавает
                if ((mGameMap.mField[coords.x + 1, coords.y].mZemType == CellType.Water) &&
                    (!elem.mStepAqua))
                    fl = false;

                //если не вода, а юнит только плавает
                if ((mGameMap.mField[coords.x + 1, coords.y].mZemType != CellType.Water) &&
                    (!elem.mStepLand))
                    fl = false;

                if (fl)
                {
                    elem.mCoords.x += 1;
                    return;
                }
            }
        }
    }
}

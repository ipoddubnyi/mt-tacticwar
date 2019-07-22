using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Types.Simulator;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.UI
{
    // Симулятор игры - то, что контактирует с граф. интерфейсом и делает все просчёты
    public class Simulator
    {
        //карта
        public Map Map;

        //миссия
        public Mission Mission;

        //игроки
        public Player[] Players;    //массив из двух элементов (0 - игрок 1, 1 - игрок 2)

        //параметры игры
        // - системные параметры
        //    * ширина ячейки поля ?в переменной Map?
        //
        // - число сделанных ходов
        // - кто ходит сейчас
        int PlayerCurrent; //-1 - никто, 0 - игрок 0, 1 - игрок 1
        // - набранные очки ?
        // - информация о выделенном юните для графики
        public UnitInfo SelectedUnitInfo;
        // - информация об атаке
        public AttackInfo AttackInfo;
        // - графика (где рисуется поле боя)
        private GameGraphics graphics;

        //!!!! временная переменная (пока не знаю, как сделать иначе)
        public Coordinates KrestCoords; //координаты установленного креста

        public Division SelectedDivision { get; set; }
        public Building SelectedBuilding { get; set; }

        private Bellman bellman;

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
            KrestCoords = new Coordinates(-1, -1);
            Mission = MissionLoader.LoadMission(misPath + "mission.mis");

            string mapPath = Mission.mPathMap;
            Map = MissionLoader.LoadMap(misPath + mapPath);

            Players = new Player[Mission.mCountIgroki];
            Players[0] = MissionLoader.LoadPlayerState(misPath + "igrok0.igr");
            Players[1] = MissionLoader.LoadPlayerState(misPath + "igrok1.igr");

            PlayerCurrent = 0;
            Map.OccupateCells(Players);

            bellman = new Bellman(Map);

            SelectedDivision = null;
            SelectedBuilding = null;
        }

        public void InitGraphics(Graphics grf)
        {
            graphics = new GameGraphics(grf);
        }

        public void SelectDivision(Division division)
        {
            // TODO: проверка, что подразделение принадлежит игроку
            SelectedDivision = division;
        }

        public void SelectBuilding(Building building)
        {
            SelectedBuilding = building;

            // если в здании есть охранение - выделить его
            if (building.IsSecured)
            {
                SelectedDivision = building.SecurityDivision;
            }
        }

        public void DeselectBuilding()
        {
            if (null != SelectedBuilding)
            {
                //если в здании есть охранение - снять выделение с него
                if (SelectedBuilding.IsSecured)
                {
                    SelectedDivision = null;
                }

                SelectedBuilding = null;
            }
        }

        //********************************************************************************

        #region Обработчики рисования

        /// <summary>Рисовать всё
        /// </summary>
        /// <param name="grf">графика, на которой рисовать</param>
        /// <returns></returns>
        public void drawAll()
        {
            graphics.DrawMap(Map);
            int left, top;

            //нарисовать подразделения игрока 0
            foreach (var division in Players[0].Divisions)
            {
                left = division.Coordinates.X * GameGraphics.CellSize;
                top = division.Coordinates.Y * GameGraphics.CellSize;
                graphics.DrawDivision(division, left, top, GameGraphics.CellSize, division == SelectedDivision);
            }

            //нарисовать подразделения игрока 1
            foreach (var division in Players[1].Divisions)
            {
                left = division.Coordinates.X * GameGraphics.CellSize;
                top = division.Coordinates.Y * GameGraphics.CellSize;
                graphics.DrawDivision(division, left, top, GameGraphics.CellSize, division == SelectedDivision);
            }

            //нарисовать здания игрока 0
            foreach (var building in Players[0].Buildings)
            {
                left = building.Coordinates.X * GameGraphics.CellSize;
                top = building.Coordinates.Y * GameGraphics.CellSize;

                //если есть охранение у здания, стереть уже нарисованного юнита
                if (building.IsSecured)
                    graphics.DrawCell(Map.Field[building.Coordinates.X, building.Coordinates.Y]);

                graphics.DrawBuilding(building, left, top, GameGraphics.CellSize, building == SelectedBuilding);
            }

            //нарисовать здания игрока 1
            foreach (var building in Players[1].Buildings)
            {
                left = building.Coordinates.X * GameGraphics.CellSize;
                top = building.Coordinates.Y * GameGraphics.CellSize;

                //если есть охранение у здания, стереть уже нарисованного юнита
                if (building.IsSecured)
                    graphics.DrawCell(Map.Field[building.Coordinates.X, building.Coordinates.Y]);

                graphics.DrawBuilding(building, left, top, GameGraphics.CellSize, building == SelectedBuilding);
            }

            //нарисовать крест, если он есть
            if (KrestCoords.X != -1)
                graphics.DrawCross(KrestCoords.X, KrestCoords.Y);

            /*//нарисовать путь
            if (Players[0].SelectedDivisionId != -1)
            {
                drawPutManager(grf, PlayerCurrent, Players[0].SelectedDivisionId, false);
                //drawFlagManager(grf, 
            }
            else if (Players[1].SelectedDivisionId != -1)
            {
                drawPutManager(grf, PlayerCurrent, Players[1].SelectedDivisionId, false);
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
            if (KrestCoords.X != -1)
                graphics.DrawCell(Map.Field[KrestCoords.X, KrestCoords.Y]);

            KrestCoords.X = -1;
            KrestCoords.Y = -1;

            //если есть проложенный путь, стираем его
            if (bellman.WayParams.BestWay.Count > 0)
            {
                for (int k = 0; k < bellman.WayParams.BestWay.Count; k++)
                {
                    //перерисовать поле
                    i = bellman.WayParams.BestWay[k].Coordinates.X;
                    j = bellman.WayParams.BestWay[k].Coordinates.Y;
                    graphics.DrawCell(Map.Field[i, j]);
                }

                bellman.WayParams.BestWay.Clear();
            }

            //бежим по игрокам, перерисовываем юнитов и здания
            foreach (var player in Players)
            {
                foreach (var division in player.Divisions)
                {
                    //если юнит выделен, снимаем выделение
                    if (division == SelectedDivision)
                    {
                        SelectedDivision = null;
                        division.removeFlag();
                    }

                    //перерисовать юнит
                    i = division.Coordinates.X;
                    j = division.Coordinates.Y;
                    graphics.DrawCell(Map.Field[i, j]); //рисуем ячейку поля
                    graphics.DrawDivision(division, i * GameGraphics.CellSize, j * GameGraphics.CellSize, GameGraphics.CellSize, false);
                }

                foreach (var building in player.Buildings)
                {
                    //если здание выделено, снимаем выделение
                    if (building == SelectedBuilding)
                    {
                        DeselectBuilding();
                    }

                    //перерисовать юнит
                    i = building.Coordinates.X;
                    j = building.Coordinates.Y;
                    var division = player.GetDivisionAtCoordinates(i, j);

                    /*//если есть подразделение с этими координатами (у здания нет охранения)
                    if (null == division)
                    {
                        Players[k].Buildings[kk].IsSecured = false;
                        Players[k].Buildings[kk].SecurityDivision = null;
                    }
                    else //если есть
                    {
                        Players[k].Buildings[kk].IsSecured = true;
                        Players[k].Buildings[kk].SecurityDivision = division;
                    }*/

                    graphics.DrawCell(Map.Field[i, j]); //рисуем ячейку поля
                    graphics.DrawBuilding(building, i * GameGraphics.CellSize, j * GameGraphics.CellSize, GameGraphics.CellSize, false);
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
                graphics.DrawCross(i, j);
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

            graphics.DrawFlag(i, j, strAtak, strRedBlue);
        }

        /// <summary>Рисовать путь для подразделения
        /// </summary>
        /// <param name="igrok">ид игрока, хозяина подразделения</param>
        /// <param name="division">подразделение</param>
        /// <param name="countPut">надо ли считать путь заново</param>
        /// <returns>Возвращает (false), если путь не найден</returns>
        private bool drawPutManager(int igrok, Division division, bool countPut)
        {
            //просчитать путь, если надо
            if (countPut)
            {
                bellman = new Bellman(Map);
                bellman.BellmanPoiskPuti(division, division.Target);
            }

            //если путь найден
            if (bellman.WayParams.BestWay.Count > 0)
            {
                //просчитать путь для юнита на один день (для рисования на карте)
                var oneDayPut = bellman.WayParams.BestWay.ToList<Cell>();
                division.countOneDayOfElement(ref oneDayPut);

                //нарисовать путь
                graphics.DrawWay(bellman.WayParams.BestWay, oneDayPut);

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
            /*SelectedUnitInfo.type = Div.Type.ToString();
            SelectedUnitInfo.name = Div.Name;
            SelectedUnitInfo.coords = Div.Coordinates;
            SelectedUnitInfo.igrokId = Div.PlayerId;

            SelectedUnitInfo.health = -1; //нет такого поля
            SelectedUnitInfo.powerAntiAir = Div.PowerAntiAir;
            SelectedUnitInfo.powerAntiBron = Div.PowerAntiBron;
            SelectedUnitInfo.powerAntiInf = Div.PowerAntiInf;

            SelectedUnitInfo.armourFromBron = Div.ArmourFromBron;
            SelectedUnitInfo.armourFromInf = Div.ArmourFromInf;

            SelectedUnitInfo.level = Div.Level;
            SelectedUnitInfo.obzor = Div.RadiusView;
            SelectedUnitInfo.radius = Div.RadiusAttack;

            SelectedUnitInfo.suplies = Div.Suplies;
            SelectedUnitInfo.steps = Div.Steps;*/

            /*SelectedUnitInfo.playerId = elem.PlayerId;
            SelectedUnitInfo.elemId = elem.Id;
            SelectedUnitInfo.buildId = -1;

            SelectedUnitInfo.units = elem.Units;*/
        }

        /// <summary>Заполнение информации о здании
        /// </summary>
        /// <param name="building">здание, о котором собираем информацию</param>
        /// <returns></returns>
        public void setUnitInfo(Building building)
        {
            /*SelectedUnitInfo.type = building.Type.ToString();
            SelectedUnitInfo.name = building.Name;
            SelectedUnitInfo.coords = building.Coordinates;
            SelectedUnitInfo.igrokId = building.PlayerId;

            SelectedUnitInfo.health = building.Health;
            SelectedUnitInfo.powerAntiAir = -1; //нет такого поля
            SelectedUnitInfo.powerAntiBron = -1; //нет такого поля
            SelectedUnitInfo.powerAntiInf = -1; //нет такого поля

            SelectedUnitInfo.armourFromBron = -1; //нет такого поля
            SelectedUnitInfo.armourFromInf = -1; //нет такого поля

            SelectedUnitInfo.level = UnitLevel.None; //нет такого поля
            SelectedUnitInfo.obzor = building.RadiusView;
            SelectedUnitInfo.radius = building.RadiusAttack;

            SelectedUnitInfo.suplies = -1; //нет такого поля
            SelectedUnitInfo.steps = -1; //нет такого поля*/

            /*SelectedUnitInfo.playerId = building.PlayerId;
            SelectedUnitInfo.elemId = -1;
            SelectedUnitInfo.buildId = building.Id;

            //если есть охранение
            if (building.IsSecured)
                SelectedUnitInfo.units = building.SecurityDivision.Units;
            else
                SelectedUnitInfo.units = null;*/
        }

        //----------------------

        /// <summary>Выделить подразделение и собрать информацию о нём
        /// </summary>
        /// <param name="igrokId">ид игрока, хозяина подразделения</param>
        /// <param name="division">подразделение</param>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns></returns>
        private void clickEM_getElemInfo(int igrokId, Division division, int i, int j)
        {
            //снять выделение со всего
            deselectAll();

            //выделить юнит
            SelectDivision(division);
            //заполнить структуру с информацией о юните, чтобы передать гую
            setUnitInfo(division);
            //перерисовать землю под юнитом
            graphics.DrawCell(Map.Field[i, j]);
            //перерисовать выделенный юнит
            graphics.DrawDivision(division, i * GameGraphics.CellSize, j * GameGraphics.CellSize, GameGraphics.CellSize, true);
        }

        /// <summary>Выделить здание и собрать информацию о нём
        /// </summary>
        /// <param name="igrokId">ид игрока, хозяина здания</param>
        /// <param name="building">здание</param>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns></returns>
        private void clickEM_getBuildInfo(int igrokId, Building building, int i, int j)
        {
            //снять выделение со всего
            deselectAll();

            //выделить здание
            SelectBuilding(building);

            //если есть охранение - собрать о нём информацию
            if (building.IsSecured)
                setUnitInfo(SelectedDivision);
            else //иначе - о здании
                setUnitInfo(building);

            //перерисовать землю под зданием
            graphics.DrawCell(Map.Field[i, j]);
            //перерисовать выделенное здание
            graphics.DrawBuilding(building, i * GameGraphics.CellSize, j * GameGraphics.CellSize, GameGraphics.CellSize, true);
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
            //запомнить индекс выделенного юнита
            var oldSelected = SelectedDivision;

            //снять выделение со всего и заново выделить юнит
            deselectAll();
            SelectDivision(oldSelected);

            //перерисовать юнит (уже с выделением)
            
            //для запоминания координат
            var tmp = oldSelected.Coordinates.Clone();
            graphics.DrawCell(Map.Field[tmp.X, tmp.Y]);
            graphics.DrawDivision(oldSelected, tmp.X * GameGraphics.CellSize, tmp.Y * GameGraphics.CellSize, GameGraphics.CellSize, true);

            //установить флаг на нажатую клетку
            oldSelected.setFlag(i, j);

            //просчитать путь, и если он существует нарисовать его и флаг
            if (drawPutManager(igrokId, oldSelected, true))
            {
                bool redBlue = false;

                //если юнит за день дойдёт до флага, то красный
                if ((oldSelected.Target.X == oldSelected.DayTarget.X) &&
                    (oldSelected.Target.Y == oldSelected.DayTarget.Y))
                    redBlue = true;

                //нарисовать флаг (координаты, флаг/крест, поле0/подразд1/здание2, добавление/атака, красный/синий)
                drawFlagManager(i, j, true, toFEB, !enemieClick, redBlue);
            }
            else
            {
                //нарисовать крест
                KrestCoords.X = i;
                KrestCoords.Y = j;
                graphics.DrawCross(i, j);
            }
        }

        /// <summary>Просчитать путь до здания, поставить флаг (захват, атака или присоединение)
        /// </summary>
        /// <param name="igrokId">ид игрока, хозяина выделенного подразделения</param>
        /// <param name="building">здание</param>
        /// <param name="enemieClick">щелчок по зданию врага</param>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns></returns>
        private void clickEM_countPutToBuild(int igrokId, Building building, bool enemieClick, int i, int j)
        {
            //запомнить нидекс выделенного юнита
            var oldSelected = SelectedDivision;

            //снять выделение со всего и заново выделить юнит
            deselectAll();
            SelectDivision(oldSelected);

            //перерисовать юнит

            //для запоминания координат
            var tmp = oldSelected.Coordinates.Clone();
            //Map.DrawCell(grf, tmp.x, tmp.y);
            graphics.DrawDivision(oldSelected, tmp.X * GameGraphics.CellSize, tmp.Y * GameGraphics.CellSize, GameGraphics.CellSize, true);

            //установить флаг
            oldSelected.setFlag(i, j);

            //просчитать путь, и если он существует
            if (drawPutManager(igrokId, oldSelected, true))
            {
                bool redBlue = false;

                if ((oldSelected.Target.X == oldSelected.DayTarget.X) &&
                    (oldSelected.Target.Y == oldSelected.DayTarget.Y))
                    redBlue = true;

                //нарисовать флаг

                //если нажатие по зданию врага
                if (enemieClick)
                {
                    //если есть охранение - поставить флаг атаки
                    if (building.IsSecured)
                        drawFlagManager(i, j, true, 1, !enemieClick, redBlue);
                    else //поставить флаг захвата
                        drawFlagManager(i, j, true, 2, !enemieClick, redBlue);
                }
                else
                {
                    //если есть охранение - поставить флаг добавления
                    if (building.IsSecured)
                        drawFlagManager(i, j, true, 1, !enemieClick, redBlue);
                    else //поставить флаг защиты здания
                        drawFlagManager(i, j, true, 2, !enemieClick, redBlue);
                }
            }
            else
            {
                //нарисовать крест
                graphics.DrawCross(i, j);
                KrestCoords.X = i;
                KrestCoords.Y = j;
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
            var oldSelected = SelectedDivision;
            //запомнить координаты выделенного юнитаюнита
            tmp = oldSelected.Coordinates.Clone();

            //если путь был найден
            if (bellman.WayParams.BestWay.Count > 0)
            {
                //сдвинуть юнит
                oldSelected.pushElement(bellman.WayParams.BestWay);
                
                //если юнит сместился (!)
                if ((tmp.X != oldSelected.Coordinates.X) ||
                    (tmp.Y != oldSelected.Coordinates.Y))
                {
                    //стереть юнит со старого места
                    graphics.DrawCell(Map.Field[tmp.X, tmp.Y]);

                    //если на старом месте нет здания - освободить старую ячейку
                    var building = Players[igrokId].GetBuildingAtCoordinates(tmp.X, tmp.Y);
                    if (null == building)
                        Map.Field[tmp.X, tmp.Y].Object = null;
                    else //иначе - освободить здание
                    {
                        building.SecurityDivision = null;
                        building.IsSecured = false;
                    }

                    //нарисовать юнит на новом месте
                    tmp.X = oldSelected.Coordinates.X;
                    tmp.Y = oldSelected.Coordinates.Y;

                    //занять новую ячейку
                    Map.Field[tmp.X, tmp.Y].Object = oldSelected;

                    //временно сохранить путь
                    List<Cell> tmpPut = bellman.WayParams.BestWay.ToList<Cell>();

                    //убрать из путь часть, которую уже прошли
                    while (tmpPut.Count > 0)
                    {
                        if ((tmpPut[0].Coordinates.X == tmp.X) && (tmpPut[0].Coordinates.Y == tmp.Y))
                            break;

                        tmpPut.RemoveAt(0);
                    }

                    //выделить юнит заново и собрать информацию о нём
                    clickEM_getElemInfo(igrokId, oldSelected, tmp.X, tmp.Y);

                    //загрузить путь из временной памяти
                    bellman.WayParams.BestWay = tmpPut.ToList<Cell>();

                    //установить флаг
                    oldSelected.setFlag(i, j);

                    //нарисовать путь без пересчёта и нарисавать флаг
                    if (drawPutManager(igrokId, oldSelected, false))
                    {
                        //если юнит НЕ дошёл до флага за день
                        if ((oldSelected.Target.X != oldSelected.DayTarget.X) ||
                            (oldSelected.Target.Y != oldSelected.DayTarget.Y))
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
        /// <param name="division">подразделение, на которое нажали</param>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns>Возвращает сигналы обмена с GUI</returns>
        private Signals ClickDivisionManager(int igrok, int enemie, bool enemieClick, Division division, int i, int j)
        {
            int switchInt; //варианты движения юнита

            if (!enemieClick)
                switchInt = ClickMyDivision(division);
            else
                switchInt = ClickEnemieDivision(division.Coordinates);

            //вызвать обработчик нажатия на свой юнит
            switch (switchInt)
            {
                case 1: //передать информацию о выделенном юните

                    //если щёлкнули по врагу - собрать о его юните информацию
                    if (enemieClick) igrok = enemie;

                    //выделить юнита, заполнить структуру
                    clickEM_getElemInfo(igrok, division, i, j);

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

                    int oldSelectInd = SelectedDivision.Id;

                    //если атакуем противника
                    if (!enemieClick)
                    {
                        //если координаты юнита совпадают с координатами целевого юнита
                        if ((Players[igrok].Divisions[oldSelectInd].Coordinates.X == division.Coordinates.X) &&
                            (Players[igrok].Divisions[oldSelectInd].Coordinates.Y == division.Coordinates.Y))
                        {
                            return achievementTag(Players[igrok].Divisions[oldSelectInd], division);
                        }
                    }
                    else
                    {
                        //если координаты юнита совпадают с координатами целевого юнита
                        if ((Players[igrok].Divisions[oldSelectInd].Coordinates.X == division.Coordinates.X) &&
                            (Players[igrok].Divisions[oldSelectInd].Coordinates.Y == division.Coordinates.Y))
                        {
                            return achievementTag(Players[igrok].Divisions[oldSelectInd], division);
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
        /// <param name="building">здание, на которое нажали</param>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns>Возвращает сигналы обмена с GUI</returns>
        private Signals ClickBuildingManager(int igrok, int enemie, bool enemieClick, Building building, int i, int j)
        {
            int switchInt;
            int oldSelectInd; //индекс уже выделенного юнита
            Coordinates tmp; //для запоминания координат

            if (!enemieClick)
                switchInt = ClickMyBuilding(building);
            else
                switchInt = ClickEnemieBuilding(building.Coordinates);

            //вызвать обработчик нажатия на свой юнит
            switch (switchInt)
            {
                case 1: //передать информацию о выделенном юните

                    //если щёлкнули по врагу - собрать о его юните информацию
                    if (enemieClick) igrok = enemie;

                    //выделить здание, заполнить структуру
                    clickEM_getBuildInfo(igrok, building, i, j);

                    //готова информация о единице
                    return Signals.s03_READY_UNIT_INFO;
                case 2: //поставить флаг, просчитать путь

                    //просчитать путь до здания, поставить флаг (захват, атака или присоединение)
                    clickEM_countPutToBuild(igrok, building, enemieClick, i, j);

                    break;
                case 3: //продвинуть выделенный юнит к данному

                    //захватываем здание или нападаем на охранение здания?
                    int toFEB = 2;

                    if (enemieClick)
                    {
                        if (building.IsSecured)
                            toFEB = 1;
                    }
                    else
                    {
                        if (building.IsSecured)
                            toFEB = 1;
                    }

                    //продвинуть выделенный элемент к данному зданию
                    clickEM_pushElemToObject(igrok, enemieClick, toFEB, i, j);

                    //---

                    oldSelectInd = SelectedDivision.Id;
                    tmp = Players[igrok].Divisions[oldSelectInd].Coordinates.Clone();

                    //если двигаем к своему зданию
                    if (!enemieClick)
                    {
                        //если координаты юнита совпадают с координатами целевого здания
                        if ((Players[igrok].Divisions[oldSelectInd].Coordinates.X == building.Coordinates.X) &&
                            (Players[igrok].Divisions[oldSelectInd].Coordinates.Y == building.Coordinates.Y))
                        {
                            Signals tmpSig = achievementTag(Players[igrok].Divisions[oldSelectInd], building);

                            graphics.DrawCell(Map.Field[tmp.X, tmp.Y]);
                            graphics.DrawBuilding(building, tmp.X * GameGraphics.CellSize, tmp.Y * GameGraphics.CellSize, GameGraphics.CellSize,
                                building == SelectedBuilding);
                            return tmpSig;
                        }
                    }
                    else
                    {
                        //если координаты юнита совпадают с координатами целевого здания
                        if ((Players[igrok].Divisions[oldSelectInd].Coordinates.X == building.Coordinates.X) &&
                            (Players[igrok].Divisions[oldSelectInd].Coordinates.Y == building.Coordinates.Y))
                        {
                            Signals tmpSig = achievementTag(Players[igrok].Divisions[oldSelectInd], building);

                            graphics.DrawCell(Map.Field[tmp.X, tmp.Y]);
                            graphics.DrawBuilding(Players[igrok].Buildings[Players[igrok].Buildings.Count - 1], tmp.X * GameGraphics.CellSize, tmp.Y * GameGraphics.CellSize, GameGraphics.CellSize,
                                Players[igrok].Buildings[Players[igrok].Buildings.Count - 1] == SelectedBuilding);
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
        /// <param name="division">выделенное подразделение</param>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns>Возвращает сигналы обмена с GUI</returns>
        private Signals clickEmptyFieldManager(int igrok, Division division, int i, int j)
        {
            //если на этом месте стоит флаг - продвинуть юнит
            if ((division.Target.X == i) &&
                (division.Target.Y == j))
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
            if (thisElem.PlayerId == tagElem.PlayerId)
            {
                //присоединить юниты
                int newUnitId = Players[thisElem.PlayerId].addElementToElement(thisElem.Id, tagElem.Id);
                SelectedDivision = Players[thisElem.PlayerId].Divisions[newUnitId];
                setUnitInfo(Players[thisElem.PlayerId].Divisions[newUnitId]);
            }
            else
            {
                //заполняем структуру информации об атаке
                AttackInfo.igrokAttacked = thisElem.PlayerId;
                AttackInfo.igrokDefended = tagElem.PlayerId;
                AttackInfo.elemAttacked = thisElem.Id;
                AttackInfo.elemDefended = tagElem.Id;

                //атака всегда отнимает шаги до минимума
                thisElem.Steps = 0;
                tagElem.Steps = 0;

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
            Building tmp = null;

            //если целевое здание - это здание того же игрока
            if (thisElem.PlayerId == tagBuild.PlayerId)
            {
                //если в здании есть охранение
                if (Players[thisElem.PlayerId].Buildings[tagBuild.Id].IsSecured)
                {
                    //если типы юнитов совпадают
                    if (thisElem.Type == Players[tagBuild.PlayerId].Buildings[tagBuild.Id].SecurityDivision.Type)
                    {
                        //присоединить юниты
                        var ind = Players[thisElem.PlayerId].addElementToElement(thisElem.Id, Players[thisElem.PlayerId].Buildings[tagBuild.Id].SecurityDivision.Id);
                        SelectedDivision = Players[thisElem.PlayerId].Divisions[ind];
                    }
                    else //иначе - всё плохо
                        return Signals.s02_ALL_IS_BD;
                }
                else
                {
                    //поставить на охрану
                    Players[tagBuild.PlayerId].Buildings[tagBuild.Id].SecurityDivision = thisElem;
                    Players[tagBuild.PlayerId].Buildings[tagBuild.Id].IsSecured = true;

                    //встать на охранение здания - отнимает все шаги
                    Players[thisElem.PlayerId].Divisions[thisElem.Id].Steps = 0;
                }

                tmp = tagBuild;
            }
            else
            {
                //если в здании есть охранение
                if (Players[tagBuild.PlayerId].Buildings[tagBuild.Id].IsSecured)
                {
                    //заполняем структуру информации об атаке
                    AttackInfo.igrokAttacked = thisElem.PlayerId;
                    AttackInfo.igrokDefended = Players[tagBuild.PlayerId].Buildings[tagBuild.Id].SecurityDivision.PlayerId;
                    AttackInfo.elemAttacked = thisElem.Id;
                    AttackInfo.elemDefended = Players[tagBuild.PlayerId].Buildings[tagBuild.Id].SecurityDivision.Id;

                    //атака всегда отнимает шаги до минимума
                    thisElem.Steps = 0;
                    Players[tagBuild.PlayerId].Buildings[tagBuild.Id].SecurityDivision.Steps = 0;

                    return Signals.s04_ATTACK;
                }
                else
                {
                    Building tmpBuild;

                    //захват постройки
                    tmp = tagBuild;
                    tmpBuild = tagBuild.copyBuilding();
                    Players[thisElem.PlayerId].Buildings.Add(tmpBuild);
                    Players[thisElem.PlayerId].recountIds();
                    Players[tagBuild.PlayerId].Buildings.Remove(tmp);
                    Players[tagBuild.PlayerId].recountIds();

                    //захват всегда отнимает все шаги
                    thisElem.Steps = 0;

                    //поставить юнита на охранение
                    tmp = Players[thisElem.PlayerId].Buildings[Players[thisElem.PlayerId].Buildings.Count - 1];
                    tmp.SecurityDivision = thisElem;
                    tmp.IsSecured = true;
                }
            }

            SelectBuilding(tmp);

            return Signals.s03_READY_UNIT_INFO;
        }

        //----------------------

        /// <summary>Обработчик нажатия на зону боевых действий
        /// </summary>
        /// <param name="x">координата по высоте (!)</param>
        /// <param name="y">координата по ширине (!)</param>
        /// <returns>Возвращает сигналы обмена с GUI</returns>
        public Signals ZonaClick(int x, int y)
        {
            int i = x / GameGraphics.CellSize;
            int j = y / GameGraphics.CellSize;

            //если координаты за границами карты
            if (i < 0 || i > Map.Width - 1) return Signals.s05_OUT_OF_RANGE;
            if (j < 0 || j > Map.Height-1) return Signals.s05_OUT_OF_RANGE;

            //проверяем, по чему щёлкнули...

            //PlayerCurrent = 1; //!!!!!!!! дебаг !!!!!!!!

            //если ходит игрок 0
            if (PlayerCurrent == 0)
            {
                //--- здание игрока 0 ---

                var building = Players[0].GetBuildingAtCoordinates(i, j);

                if (null != building)
                    return ClickBuildingManager(0, 1, false, building, i, j);

                //--- здание игрока 1 ---

                building = Players[1].GetBuildingAtCoordinates(i, j);

                if (null != building)
                    return ClickBuildingManager(0, 1, true, building, i, j);

                //--- если щёлкнули по юниту игрока 0 ---

                var division = Players[0].GetDivisionAtCoordinates(i, j);

                if (null != division)
                    return ClickDivisionManager(0, 1, false, division, i, j);

                //--- если щёлкнули по юниту игрока 1 ---

                division = Players[1].GetDivisionAtCoordinates(i, j);

                if (null != division)
                    return ClickDivisionManager(0, 1, true, division, i, j);

                //--- попали на пустую клетку ---

                //если выделен юнит игрока 0
                division = SelectedDivision;

                if (null != division && 0 == division.PlayerId)
                    return clickEmptyFieldManager(0, division, i, j);
            }
            else //если ходит игрок 1 (PlayerCurrent == 1)
            {
                //--- если щёлкнули по юниту игрока 0 ---

                var division = Players[0].GetDivisionAtCoordinates(i, j);

                if (null != division)
                    return ClickDivisionManager(1, 0, true, division, i, j);

                //--- если щёлкнули по юниту игрока 1 ---

                division = Players[1].GetDivisionAtCoordinates(i, j);

                if (null != division)
                    return ClickDivisionManager(1, 0, false, division, i, j);

                //--- здание игрока 0 ---

                var building = Players[0].GetBuildingAtCoordinates(i, j);

                if (null != building)
                    return ClickBuildingManager(1, 0, true, building, i, j);

                //--- здание игрока 1 ---

                building = Players[1].GetBuildingAtCoordinates(i, j);

                if (null != building)
                    return ClickBuildingManager(1, 0, false, building, i, j);

                //--- попали на пустую клетку ---

                //если выделен юнит игрока 1
                division = SelectedDivision;

                if (null != division && 1 == division.PlayerId)
                    return clickEmptyFieldManager(1, division, i, j);
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
            while ((elem1.Units.Count > 0) && (elem2.Units.Count > 0))
            {
                //- ПРЯМАЯ АТАКА -

                //случайно выбираем подразделение
                elem = rand.Next(0, podderzh1.Count);

                //если это АТАКУЮЩЕЕ подразделение атакующего игрока
                if (elem == 0)
                {
                    //случайно выбираем юнита из атакующего подразделения
                    indUnit1 = rand.Next(0, elem1.Units.Count - 1);

                    //случайно выбираем юнита из атакуемого подразделения
                    indUnit2 = rand.Next(0, elem2.Units.Count - 1);

                    //атакуем
                    sui1 = elem1.Units[indUnit1];
                    sui2 = elem2.Units[indUnit2];
                    unitAtakUnit(ref sui1, ref sui2);
                    elem1.Units[indUnit1] = sui1;
                    elem2.Units[indUnit2] = sui2;
                }
                else //если это подразделение ПОДДЕРЖКИ
                {
                    //случайно выбираем юнита из выбранного подразделения поддержки
                    indUnit1 = rand.Next(0, podderzh1[elem-1].Units.Count - 1);

                    //случайно выбираем юнита из атакуемого подразделения
                    indUnit2 = rand.Next(0, elem2.Units.Count - 1);

                    //атакуем
                    sui1 = podderzh1[elem - 1].Units[indUnit1];
                    sui2 = elem2.Units[indUnit2];
                    unitAtakUnit(ref sui1, ref sui2);
                    podderzh1[elem - 1].Units[indUnit1] = sui1;
                    elem2.Units[indUnit2] = sui2;
                }

                //удалить юнита, если его убили
                if (elem2.Units[indUnit2].unit.Health == Health.Dead)
                    elem2.Units.RemoveAt(indUnit2);

                //если врага убили - конец цикла
                if (elem2.Units.Count < 1)
                    break;

                //- ОТВЕТНАЯ АТАКА -

                //случайно выбираем подразделение
                elem = rand.Next(0, podderzh2.Count);

                //если это АТАКУЮЩЕЕ подразделение защищающегося игрока
                if (elem == 0)
                {
                    //случайно выбираем юнита из атакующего подразделения
                    indUnit2 = rand.Next(0, elem2.Units.Count - 1);

                    //случайно выбираем юнита из атакуемого подразделения
                    indUnit1 = rand.Next(0, elem1.Units.Count - 1);

                    //атакуем
                    sui1 = elem2.Units[indUnit2];
                    sui2 = elem1.Units[indUnit1];
                    unitAtakUnit(ref sui1, ref sui2);
                    elem2.Units[indUnit2] = sui1;
                    elem1.Units[indUnit1] = sui2;
                }
                else //если это подразделение ПОДДЕРЖКИ
                {
                    //случайно выбираем юнита из выбранного подразделения поддержки
                    indUnit2 = rand.Next(0, podderzh2[elem - 1].Units.Count - 1);

                    //случайно выбираем юнита из атакуемого подразделения
                    indUnit1 = rand.Next(0, elem1.Units.Count - 1);

                    //атакуем
                    sui1 = podderzh2[elem - 1].Units[indUnit2];
                    sui2 = elem1.Units[indUnit1];
                    unitAtakUnit(ref sui1, ref sui2);
                    podderzh2[elem - 1].Units[indUnit2] = sui1;
                    elem1.Units[indUnit1] = sui2;
                }

                //удалить юнита, если его убили
                if (elem1.Units[indUnit1].unit.Health == Health.Dead)
                    elem1.Units.RemoveAt(indUnit1);

                //если врага убили - конец цикла
                if (elem1.Units.Count < 1)
                    break;

                //----------

                //если у нападающего кончились патроны - он отступает
                if(elem1.Units[indUnit1].unit.Suplies == 0)
                {
                    elem1_none_supl = true;
                    recedeElem(elem1); //отступить
                    break;
                }
            } //конец цикла

            //----------

            int win = 0; //ид победителя (0 - ничья, 1 - атакующий, 2 - атакуемый)

            if (elem1.Units.Count > 0)
            {
                win = 1;
                elem1.recountParams();

                //пересчитать показатели поддержки
                for (int k = 0; k < podderzh1.Count; k++)
                    podderzh1[k].recountParams();
            }

            if (elem2.Units.Count > 0)
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
            level = getLevelVes(structUnit2.unit.Level);

            //по типу атакующего юнита определяем защиту
            switch (structUnit1.unit.Type)
            {
                case DivisionType.Infantry:
                    armour = (double)structUnit2.unit.ArmourFromInf;
                    break;
                case DivisionType.Aviation:
                case DivisionType.Vehicle:
                case DivisionType.Artillery:
                case DivisionType.Ship:
                default:
                    armour = (double)structUnit2.unit.ArmourFromBron;
                    break;
            }

            //определяем защиту атакуемого юнита
            armour *= (double)structUnit2.count * (rand.NextDouble() * (1 - level) + level);

            //----------

            //выбираем уровень атакующего юнита
            level = getLevelVes(structUnit1.unit.Level);

            //по типу атакуемого юнита определяем мощь атаки
            switch (structUnit2.unit.Type)
            {
                case DivisionType.Infantry:
                    attack_power = (double)structUnit1.unit.PowerAntiInf;
                    break;
                case DivisionType.Aviation:
                    attack_power = (double)structUnit1.unit.PowerAntiAir;
                    break;
                case DivisionType.Vehicle:
                case DivisionType.Artillery:
                case DivisionType.Ship:
                default:
                    attack_power = (double)structUnit1.unit.PowerAntiBron;
                    break;
            }

            //определяем мощь атакующего юнита
            attack_power *= (double)structUnit1.count *
                                (rand.NextDouble() * (1 - level) + level);

            //если патронов у юнита не хватает
            if (structUnit1.unit.Suplies < attack_power)
            {
                attack_power = structUnit1.unit.Suplies;
                structUnit1.unit.Suplies = 0;
            }
            else
            {
                structUnit1.unit.Suplies -= (int)attack_power;
            }

            //----------

            //подсчёт повреждения для атакуемого юнита
            wound = armour - attack_power;
            if (wound <= 0)
            {
                structUnit2.count = 0;
                structUnit2.unit.Health = Health.Dead;
            }
            else if ((wound / (double)structUnit2.unit.ArmourFromInf) < 1)
            {
                structUnit2.count = 1;
                structUnit2.unit.Health = Health.Wounded;
            }
            else
            {
                structUnit2.count = (int)(wound / (double)structUnit2.unit.ArmourFromInf);
            }
        }

        //Отступить подразделению на ближайшую свободную клетку
        private void recedeElem(Division elem)
        {
            bool fl = true;
            var coords = elem.Coordinates.Clone();

            //лево
            if ((!Map.Field[coords.X, coords.Y - 1].Occupied) &&
                (Map.Field[coords.X, coords.Y - 1].Passable))
            {
                //если вода, а юнит не плавает
                if ((Map.Field[coords.X, coords.Y - 1].Type == CellType.Water) &&
                    (!elem.CanStepAqua))
                    fl = false;

                //если не вода, а юнит только плавает
                if ((Map.Field[coords.X, coords.Y - 1].Type != CellType.Water) &&
                    (!elem.CanStepLand))
                    fl = false;

                if (fl)
                {
                    elem.Coordinates.Y -= 1;
                    return;
                }
            }

            fl = true;

            //верх
            if ((!Map.Field[coords.X - 1, coords.Y].Occupied) &&
                (Map.Field[coords.X - 1, coords.Y].Passable))
            {
                //если вода, а юнит не плавает
                if ((Map.Field[coords.X - 1, coords.Y].Type == CellType.Water) &&
                    (!elem.CanStepAqua))
                    fl = false;

                //если не вода, а юнит только плавает
                if ((Map.Field[coords.X - 1, coords.Y].Type != CellType.Water) &&
                    (!elem.CanStepLand))
                    fl = false;

                if (fl)
                {
                    elem.Coordinates.X -= 1;
                    return;
                }
            }

            fl = true;

            //право
            if ((!Map.Field[coords.X, coords.Y + 1].Occupied) &&
                (Map.Field[coords.X, coords.Y + 1].Passable))
            {
                //если вода, а юнит не плавает
                if ((Map.Field[coords.X, coords.Y + 1].Type == CellType.Water) &&
                    (!elem.CanStepAqua))
                    fl = false;

                //если не вода, а юнит только плавает
                if ((Map.Field[coords.X, coords.Y + 1].Type != CellType.Water) &&
                    (!elem.CanStepLand))
                    fl = false;

                if (fl)
                {
                    elem.Coordinates.Y += 1;
                    return;
                }
            }

            fl = true;

            //вниз
            if ((!Map.Field[coords.X + 1, coords.Y].Occupied) &&
                (Map.Field[coords.X + 1, coords.Y].Passable))
            {
                //если вода, а юнит не плавает
                if ((Map.Field[coords.X + 1, coords.Y].Type == CellType.Water) &&
                    (!elem.CanStepAqua))
                    fl = false;

                //если не вода, а юнит только плавает
                if ((Map.Field[coords.X + 1, coords.Y].Type != CellType.Water) &&
                    (!elem.CanStepLand))
                    fl = false;

                if (fl)
                {
                    elem.Coordinates.X += 1;
                    return;
                }
            }
        }

        /// <summary>Обработчик нажатия по своему подразделению
        /// </summary>
        /// <param name="index">индекс подразделения</param>
        /// <returns>Возвращает команды: 1 - собрать информацию об этом подразделении,
        /// 2 - поставить флаг, просчитать и проложить путь,
        /// 3 - продвинуть выделенное подразделение</returns>
        public int ClickMyDivision(Division division)
        {
            //если ЕСТЬ выделенный юнит и щёлкнули НЕ по нему
            if ((SelectedDivision != null) && (SelectedDivision != division) && SelectedDivision.PlayerId == PlayerCurrent)
            {
                //если флаг выделенного юнита указывает сюда
                if ((SelectedDivision.Target.X == division.Coordinates.X) &&
                    (SelectedDivision.Target.Y == division.Coordinates.Y))
                {
                    //продвинуть выделенный юнит
                    return 3;
                }
                else
                {
                    //если типы юнитов не совпадают - выделить нового юнита
                    if (SelectedDivision.Type != division.Type)
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
        public int ClickEnemieDivision(Coordinates enemie)
        {
            //если ЕСТЬ выделенный юнит
            //if (SelectedDivisionId != -1)
            if (SelectedDivision != null && SelectedDivision.PlayerId == PlayerCurrent)
            {
                //если флаг выделенного юнита указывает сюда
                //if ((Divisions[SelectedDivisionId].Target.X == enemie.X) &&
                //    (Divisions[SelectedDivisionId].Target.Y == enemie.Y))
                if ((SelectedDivision.Target.X == enemie.X) &&
                    (SelectedDivision.Target.Y == enemie.Y))
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
        /// <param name="building">здание</param>
        /// <returns>Возвращает команды: 1 - собрать информацию о здании
        /// или подразделении на охранении,
        /// 2 - поставить флаг, просчитать и проложить путь,
        /// 3 - продвинуть выделенное подразделение</returns>
        public int ClickMyBuilding(Building building)
        {
            // TODO: проверить, что здание принадлежит игроку

            //int ohrInd = -1;

            //если есть охранение
            //if (Buildings[index].IsSecured)
            //    ohrInd = Buildings[index].SecurityDivision.Id;

            //если ЕСТЬ выделенный юнит и щёлкнули НЕ по нему
            //if ((SelectedDivisionId != -1) && (SelectedDivisionId != ohrInd))
            if ((SelectedDivision != null) && (SelectedDivision != building.SecurityDivision) && SelectedDivision.PlayerId == PlayerCurrent)
            {
                //если флаг выделенного юнита указывает сюда
                //if ((Divisions[SelectedDivisionId].Target.X == Buildings[index].Coordinates.X) &&
                //    (Divisions[SelectedDivisionId].Target.Y == Buildings[index].Coordinates.Y))
                if ((SelectedDivision.Target.X == building.Coordinates.X) &&
                    (SelectedDivision.Target.Y == building.Coordinates.Y))
                {
                    //продвинуть выделенный юнит
                    return 3;
                }
                else
                {
                    //если есть охранение в здании
                    if (building.IsSecured)
                    {
                        //если типы юнита и охранения не совпадают - выделить здание и его охранение
                        //if (Divisions[SelectedDivisionId].Type != Buildings[index].SecurityDivision.Type)
                        if (SelectedDivision.Type != building.SecurityDivision.Type)
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
        public int ClickEnemieBuilding(Coordinates enemie)
        {
            //если ЕСТЬ выделенный юнит
            //if (SelectedDivisionId != -1)
            if (SelectedDivision != null && SelectedDivision.PlayerId == PlayerCurrent)
            {
                //если флаг выделенного юнита указывает сюда
                //if ((Divisions[SelectedDivisionId].Target.X == enemie.X) &&
                //    (Divisions[SelectedDivisionId].Target.Y == enemie.Y))
                if ((SelectedDivision.Target.X == enemie.X) &&
                    (SelectedDivision.Target.Y == enemie.Y))
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
    }
}

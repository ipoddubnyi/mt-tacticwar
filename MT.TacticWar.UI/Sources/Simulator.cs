using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Types;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Serialization;
using MT.TacticWar.Core.Algorithm;

namespace MT.TacticWar.UI
{
    // Симулятор игры - то, что контактирует с граф. интерфейсом и делает все просчёты
    public class Simulator
    {
        public Mission Game { get; set; }

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

        private Bellman bellman { get; set; }
        private List<Cell> BestWay { get; set; }

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

            Game = MissionLoader.LoadGame(misPath);

            PlayerCurrent = 0;

            bellman = new Bellman(Game.Map);
            BestWay = new List<Cell>();

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
            graphics.DrawMap(Game.Map);

            //нарисовать подразделения игрока 0
            foreach (var division in Game.Players[0].Divisions)
            {
                graphics.DrawDivision(division, division == SelectedDivision);
            }

            //нарисовать подразделения игрока 1
            foreach (var division in Game.Players[1].Divisions)
            {
                graphics.DrawDivision(division, division == SelectedDivision);
            }

            //нарисовать здания игрока 0
            foreach (var building in Game.Players[0].Buildings)
            {
                //если есть охранение у здания, стереть уже нарисованного юнита
                if (building.IsSecured)
                    graphics.DrawCell(Game.Map.Field[building.Position.X, building.Position.Y]);

                graphics.DrawBuilding(building, building == SelectedBuilding);
            }

            //нарисовать здания игрока 1
            foreach (var building in Game.Players[1].Buildings)
            {
                //если есть охранение у здания, стереть уже нарисованного юнита
                if (building.IsSecured)
                    graphics.DrawCell(Game.Map.Field[building.Position.X, building.Position.Y]);

                graphics.DrawBuilding(building, building == SelectedBuilding);
            }

            //нарисовать крест, если он есть
            if (KrestCoords.X != -1)
                graphics.DrawCross(KrestCoords.X, KrestCoords.Y);

            /*//нарисовать путь
            if (Game.Players[0].SelectedDivisionId != -1)
            {
                drawPutManager(grf, PlayerCurrent, Game.Players[0].SelectedDivisionId, false);
                //drawFlagManager(grf, 
            }
            else if (Game.Players[1].SelectedDivisionId != -1)
            {
                drawPutManager(grf, PlayerCurrent, Game.Players[1].SelectedDivisionId, false);
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
                graphics.DrawCell(Game.Map.Field[KrestCoords.X, KrestCoords.Y]);

            KrestCoords.X = -1;
            KrestCoords.Y = -1;

            //если есть проложенный путь, стираем его
            if (BestWay.Count > 0)
            {
                for (int k = 0; k < BestWay.Count; k++)
                {
                    //перерисовать поле
                    i = BestWay[k].Coordinates.X;
                    j = BestWay[k].Coordinates.Y;
                    graphics.DrawCell(Game.Map.Field[i, j]);
                }

                BestWay.Clear();
            }

            //бежим по игрокам, перерисовываем юнитов и здания
            foreach (var player in Game.Players)
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
                    i = division.Position.X;
                    j = division.Position.Y;
                    graphics.DrawCell(Game.Map.Field[i, j]); //рисуем ячейку поля
                    graphics.DrawDivision(division, false);
                }

                foreach (var building in player.Buildings)
                {
                    //если здание выделено, снимаем выделение
                    if (building == SelectedBuilding)
                    {
                        DeselectBuilding();
                    }

                    //перерисовать юнит
                    i = building.Position.X;
                    j = building.Position.Y;
                    /*var division = player.GetDivisionAtCoordinates(i, j);

                    //если есть подразделение с этими координатами (у здания нет охранения)
                    if (null == division)
                    {
                        Game.Players[k].Buildings[kk].IsSecured = false;
                        Game.Players[k].Buildings[kk].SecurityDivision = null;
                    }
                    else //если есть
                    {
                        Game.Players[k].Buildings[kk].IsSecured = true;
                        Game.Players[k].Buildings[kk].SecurityDivision = division;
                    }*/

                    graphics.DrawCell(Game.Map.Field[i, j]); //рисуем ячейку поля
                    graphics.DrawBuilding(building, false);
                }
            }

            return Signals.s01_ALL_IS_GD;
        }

        /// <summary>Рисовать флаг
        /// </summary>
        /// <param name="x">координата по высоте</param>
        /// <param name="y">координата по ширине</param>
        /// <param name="flagKrest">флаг (true) или крест (false)</param>
        /// <param name="isFEB">флаг на поле (0), на подразделении (1), на здании (2)</param>
        /// <param name="addAtak">добавление (true) или атака (false)</param>
        /// <param name="oneDay">Можно ли пройти за 1 ход</param>
        /// <returns></returns>
        private void drawFlagManager(int x, int y, bool flagKrest, /*int isFEB, bool addAtak,*/ MoveType moveType, bool oneDay)
        {
            if (flagKrest)
            {
                // нарисовать флаг
                /*MoveType moveType;

                if (isFEB == 1) // если это подразделение
                    moveType = addAtak ? MoveType.Join : MoveType.Attack;
                else if (isFEB == 2) // если это здание
                    moveType = addAtak ? MoveType.Defend : MoveType.Capture;
                else // если это поле
                    moveType = MoveType.Go;*/

                graphics.DrawFlag(x, y, moveType, oneDay);
            }
            else
            {
                // нарисовать крест
                graphics.DrawCross(x, y);
                return;
            }
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
                bellman = new Bellman(Game.Map);
                BestWay = bellman.BellmanPoiskPuti(division, division.Target);
            }

            //если путь найден
            if (BestWay.Count > 0)
            {
                //просчитать путь для юнита на один день (для рисования на карте)
                var oneDayPut = BestWay.ToList<Cell>();
                division.countOneDayOfElement(ref oneDayPut);

                //нарисовать путь
                graphics.DrawWay(BestWay, oneDayPut);

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
            SelectedUnitInfo.coords = Div.Position;
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
            SelectedUnitInfo.coords = building.Position;
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
        /// <param name="division">подразделение</param>
        /// <returns></returns>
        private void clickEM_getElemInfo(Division division)
        {
            //снять выделение со всего
            deselectAll();

            //выделить юнит
            SelectDivision(division);
            //заполнить структуру с информацией о юните, чтобы передать гую
            setUnitInfo(division);
            //перерисовать землю под юнитом
            int x = division.Position.X;
            int y = division.Position.Y;
            graphics.DrawCell(Game.Map.Field[x, y]);
            //перерисовать выделенный юнит
            graphics.DrawDivision(division, true);
        }

        /// <summary>Выделить здание и собрать информацию о нём
        /// </summary>
        /// <param name="building">здание</param>
        /// <returns></returns>
        private void clickEM_getBuildInfo(Building building)
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
            int x = building.Position.X;
            int y = building.Position.Y;
            graphics.DrawCell(Game.Map.Field[x, y]);
            //перерисовать выделенное здание
            graphics.DrawBuilding(building, true);
        }

        /// <summary>Просчитать путь до подразделения, поставить флаг (атака или присоединение)
        /// </summary>
        /// <param name="igrokId">ид игрока, хозяина выделенного подразделения</param>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns></returns>
        private void clickEM_countPutToObject(int igrokId, MoveType moveType, int i, int j)
        {
            //запомнить индекс выделенного юнита
            var oldSelected = SelectedDivision;

            //снять выделение со всего и заново выделить юнит
            deselectAll();
            SelectDivision(oldSelected);

            //перерисовать юнит (уже с выделением)
            
            //для запоминания координат
            var tmp = oldSelected.Position.Clone();
            graphics.DrawCell(Game.Map.Field[tmp.X, tmp.Y]);
            graphics.DrawDivision(oldSelected, true);

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
                drawFlagManager(i, j, true, moveType, redBlue);
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
            //var tmp = oldSelected.Position.Clone();
            //Map.DrawCell(grf, tmp.x, tmp.y);
            graphics.DrawDivision(oldSelected, true);

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
                        drawFlagManager(i, j, true, MoveType.Attack, redBlue);
                    else //поставить флаг захвата
                        drawFlagManager(i, j, true, MoveType.Capture, redBlue);
                }
                else
                {
                    //если есть охранение - поставить флаг добавления
                    if (building.IsSecured)
                        drawFlagManager(i, j, true, MoveType.Join, redBlue);
                    else //поставить флаг защиты здания
                        drawFlagManager(i, j, true, MoveType.Defend, redBlue);
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
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns></returns>
        private void clickEM_pushElemToObject(int igrokId, MoveType moveType, int i, int j)
        {
            Coordinates tmp; //для запоминания координат

            //запомнить нидекс выделенного юнита
            var oldSelected = SelectedDivision;
            //запомнить координаты выделенного юнитаюнита
            tmp = oldSelected.Position.Clone();

            //если путь был найден
            if (BestWay.Count > 0)
            {
                //сдвинуть юнит
                oldSelected.pushElement(BestWay);
                
                //если юнит сместился (!)
                if ((tmp.X != oldSelected.Position.X) ||
                    (tmp.Y != oldSelected.Position.Y))
                {
                    //стереть юнит со старого места
                    graphics.DrawCell(Game.Map.Field[tmp.X, tmp.Y]);

                    //если на старом месте нет здания - освободить старую ячейку
                    var building = Game.Players[igrokId].GetBuildingAtCoordinates(tmp.X, tmp.Y);
                    if (null == building)
                        Game.Map.Field[tmp.X, tmp.Y].Object = null;
                    else //иначе - освободить здание
                    {
                        building.SecurityDivision = null;
                        building.IsSecured = false;
                    }

                    //нарисовать юнит на новом месте
                    tmp.X = oldSelected.Position.X;
                    tmp.Y = oldSelected.Position.Y;

                    //занять новую ячейку
                    Game.Map.Field[tmp.X, tmp.Y].Object = oldSelected;

                    //временно сохранить путь
                    var tmpPut = new List<Cell>(BestWay);

                    //убрать из путь часть, которую уже прошли
                    while (tmpPut.Count > 0)
                    {
                        if ((tmpPut[0].Coordinates.X == tmp.X) && (tmpPut[0].Coordinates.Y == tmp.Y))
                            break;

                        tmpPut.RemoveAt(0);
                    }

                    //выделить юнит заново и собрать информацию о нём
                    clickEM_getElemInfo(oldSelected);

                    //загрузить путь из временной памяти
                    BestWay = tmpPut.ToList<Cell>();

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
                            drawFlagManager(i, j, true, moveType, false);
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
                switchInt = ClickEnemieDivision(division.Position);

            MoveType moveType;

            //вызвать обработчик нажатия на свой юнит
            switch (switchInt)
            {
                case 1: //передать информацию о выделенном юните

                    //если щёлкнули по врагу - собрать о его юните информацию
                    if (enemieClick) igrok = enemie;

                    //выделить юнита, заполнить структуру
                    clickEM_getElemInfo(division);

                    //готова информация о единице
                    return Signals.s03_READY_UNIT_INFO;
                case 2: //поставить флаг, просчитать путь
                    moveType = enemieClick ? MoveType.Attack : MoveType.Join;

                    //считаем путь до элемента, рисуем его и флаг
                    clickEM_countPutToObject(igrok, moveType, i, j);
                    break;
                case 3: //продвинуть выделенный юнит к данному
                    moveType = enemieClick ? MoveType.Attack : MoveType.Join;

                    //продвинуть выделенный элемент к данному элементу
                    clickEM_pushElemToObject(igrok, moveType, i, j);

                    //---

                    int oldSelectInd = SelectedDivision.Id;

                    //если атакуем противника
                    if (!enemieClick)
                    {
                        //если координаты юнита совпадают с координатами целевого юнита
                        if (Game.Players[igrok].Divisions[oldSelectInd].Position.Equals(division.Position))
                        {
                            return achievementTag(Game.Players[igrok].Divisions[oldSelectInd], division);
                        }
                    }
                    else
                    {
                        //если координаты юнита совпадают с координатами целевого юнита
                        if (Game.Players[igrok].Divisions[oldSelectInd].Position.Equals(division.Position))
                        {
                            return achievementTag(Game.Players[igrok].Divisions[oldSelectInd], division);
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
                switchInt = ClickEnemieBuilding(building.Position);

            //вызвать обработчик нажатия на свой юнит
            switch (switchInt)
            {
                case 1: //передать информацию о выделенном юните

                    //если щёлкнули по врагу - собрать о его юните информацию
                    if (enemieClick) igrok = enemie;

                    //выделить здание, заполнить структуру
                    clickEM_getBuildInfo(building);

                    //готова информация о единице
                    return Signals.s03_READY_UNIT_INFO;
                case 2: //поставить флаг, просчитать путь

                    //просчитать путь до здания, поставить флаг (захват, атака или присоединение)
                    clickEM_countPutToBuild(igrok, building, enemieClick, i, j);

                    break;
                case 3: //продвинуть выделенный юнит к данному

                    //захватываем здание или нападаем на охранение здания?
                    MoveType moveType;
                    if (enemieClick)
                        moveType = building.IsSecured ? MoveType.Attack : MoveType.Capture;
                    else
                        moveType = building.IsSecured ? MoveType.Join : MoveType.Defend;

                    //продвинуть выделенный элемент к данному зданию
                    clickEM_pushElemToObject(igrok, moveType, i, j);

                    //---

                    oldSelectInd = SelectedDivision.Id;
                    tmp = Game.Players[igrok].Divisions[oldSelectInd].Position.Clone();

                    //если двигаем к своему зданию
                    if (!enemieClick)
                    {
                        //если координаты юнита совпадают с координатами целевого здания
                        if (Game.Players[igrok].Divisions[oldSelectInd].Position.Equals(building.Position))
                        {
                            Signals tmpSig = achievementTag(Game.Players[igrok].Divisions[oldSelectInd], building);

                            graphics.DrawCell(Game.Map.Field[tmp.X, tmp.Y]);
                            graphics.DrawBuilding(building, building == SelectedBuilding);
                            return tmpSig;
                        }
                    }
                    else
                    {
                        //если координаты юнита совпадают с координатами целевого здания
                        if (Game.Players[igrok].Divisions[oldSelectInd].Position.Equals(building.Position))
                        {
                            Signals tmpSig = achievementTag(Game.Players[igrok].Divisions[oldSelectInd], building);

                            graphics.DrawCell(Game.Map.Field[tmp.X, tmp.Y]);
                            graphics.DrawBuilding(Game.Players[igrok].Buildings[Game.Players[igrok].Buildings.Count - 1], 
                                Game.Players[igrok].Buildings[Game.Players[igrok].Buildings.Count - 1] == SelectedBuilding);
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
                clickEM_pushElemToObject(igrok, MoveType.Go, i, j);

                //обновить информацию
                return Signals.s03_READY_UNIT_INFO;
            }
            else
            {
                //считаем путь до поля и рисуем его
                clickEM_countPutToObject(igrok, MoveType.Go, i, j);
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
                int newUnitId = Game.Players[thisElem.PlayerId].addElementToElement(thisElem.Id, tagElem.Id);
                SelectedDivision = Game.Players[thisElem.PlayerId].Divisions[newUnitId];
                setUnitInfo(Game.Players[thisElem.PlayerId].Divisions[newUnitId]);
            }
            else
            {
                //заполняем структуру информации об атаке
                AttackInfo.PlayerAttacked = thisElem.PlayerId;
                AttackInfo.PlayerDefended = tagElem.PlayerId;
                AttackInfo.DivisionAttacked = thisElem.Id;
                AttackInfo.DivisionDefended = tagElem.Id;

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
                if (Game.Players[thisElem.PlayerId].Buildings[tagBuild.Id].IsSecured)
                {
                    //если типы юнитов совпадают
                    if (thisElem.Type == Game.Players[tagBuild.PlayerId].Buildings[tagBuild.Id].SecurityDivision.Type)
                    {
                        //присоединить юниты
                        var ind = Game.Players[thisElem.PlayerId].addElementToElement(thisElem.Id, Game.Players[thisElem.PlayerId].Buildings[tagBuild.Id].SecurityDivision.Id);
                        SelectedDivision = Game.Players[thisElem.PlayerId].Divisions[ind];
                    }
                    else //иначе - всё плохо
                        return Signals.s02_ALL_IS_BD;
                }
                else
                {
                    //поставить на охрану
                    Game.Players[tagBuild.PlayerId].Buildings[tagBuild.Id].SecurityDivision = thisElem;
                    Game.Players[tagBuild.PlayerId].Buildings[tagBuild.Id].IsSecured = true;

                    //встать на охранение здания - отнимает все шаги
                    Game.Players[thisElem.PlayerId].Divisions[thisElem.Id].Steps = 0;
                }

                tmp = tagBuild;
            }
            else
            {
                //если в здании есть охранение
                if (Game.Players[tagBuild.PlayerId].Buildings[tagBuild.Id].IsSecured)
                {
                    //заполняем структуру информации об атаке
                    AttackInfo.PlayerAttacked = thisElem.PlayerId;
                    AttackInfo.PlayerDefended = Game.Players[tagBuild.PlayerId].Buildings[tagBuild.Id].SecurityDivision.PlayerId;
                    AttackInfo.DivisionAttacked = thisElem.Id;
                    AttackInfo.DivisionDefended = Game.Players[tagBuild.PlayerId].Buildings[tagBuild.Id].SecurityDivision.Id;

                    //атака всегда отнимает шаги до минимума
                    thisElem.Steps = 0;
                    Game.Players[tagBuild.PlayerId].Buildings[tagBuild.Id].SecurityDivision.Steps = 0;

                    return Signals.s04_ATTACK;
                }
                else
                {
                    Building tmpBuild;

                    //захват постройки
                    tmp = tagBuild;
                    tmpBuild = tagBuild.Copy();
                    Game.Players[thisElem.PlayerId].Buildings.Add(tmpBuild);
                    Game.Players[thisElem.PlayerId].recountIds();
                    Game.Players[tagBuild.PlayerId].Buildings.Remove(tmp);
                    Game.Players[tagBuild.PlayerId].recountIds();

                    //захват всегда отнимает все шаги
                    thisElem.Steps = 0;

                    //поставить юнита на охранение
                    tmp = Game.Players[thisElem.PlayerId].Buildings[Game.Players[thisElem.PlayerId].Buildings.Count - 1];
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
            if (i < 0 || i > Game.Map.Width - 1) return Signals.s05_OUT_OF_RANGE;
            if (j < 0 || j > Game.Map.Height-1) return Signals.s05_OUT_OF_RANGE;

            //проверяем, по чему щёлкнули...

            //PlayerCurrent = 1; //!!!!!!!! дебаг !!!!!!!!

            //если ходит игрок 0
            if (PlayerCurrent == 0)
            {
                //--- здание игрока 0 ---

                var building = Game.Players[0].GetBuildingAtCoordinates(i, j);

                if (null != building)
                    return ClickBuildingManager(0, 1, false, building, i, j);

                //--- здание игрока 1 ---

                building = Game.Players[1].GetBuildingAtCoordinates(i, j);

                if (null != building)
                    return ClickBuildingManager(0, 1, true, building, i, j);

                //--- если щёлкнули по юниту игрока 0 ---

                var division = Game.Players[0].GetDivisionAtCoordinates(i, j);

                if (null != division)
                    return ClickDivisionManager(0, 1, false, division, i, j);

                //--- если щёлкнули по юниту игрока 1 ---

                division = Game.Players[1].GetDivisionAtCoordinates(i, j);

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

                var division = Game.Players[0].GetDivisionAtCoordinates(i, j);

                if (null != division)
                    return ClickDivisionManager(1, 0, true, division, i, j);

                //--- если щёлкнули по юниту игрока 1 ---

                division = Game.Players[1].GetDivisionAtCoordinates(i, j);

                if (null != division)
                    return ClickDivisionManager(1, 0, false, division, i, j);

                //--- здание игрока 0 ---

                var building = Game.Players[0].GetBuildingAtCoordinates(i, j);

                if (null != building)
                    return ClickBuildingManager(1, 0, true, building, i, j);

                //--- здание игрока 1 ---

                building = Game.Players[1].GetBuildingAtCoordinates(i, j);

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
            var coords = elem.Position.Clone();

            //лево
            if ((!Game.Map.Field[coords.X, coords.Y - 1].Occupied) &&
                (Game.Map.Field[coords.X, coords.Y - 1].Passable))
            {
                //если вода, а юнит не плавает
                if ((Game.Map.Field[coords.X, coords.Y - 1].Type == CellType.Water) &&
                    (!elem.CanStepAqua))
                    fl = false;

                //если не вода, а юнит только плавает
                if ((Game.Map.Field[coords.X, coords.Y - 1].Type != CellType.Water) &&
                    (!elem.CanStepLand))
                    fl = false;

                if (fl)
                {
                    elem.Position.Y -= 1;
                    return;
                }
            }

            fl = true;

            //верх
            if ((!Game.Map.Field[coords.X - 1, coords.Y].Occupied) &&
                (Game.Map.Field[coords.X - 1, coords.Y].Passable))
            {
                //если вода, а юнит не плавает
                if ((Game.Map.Field[coords.X - 1, coords.Y].Type == CellType.Water) &&
                    (!elem.CanStepAqua))
                    fl = false;

                //если не вода, а юнит только плавает
                if ((Game.Map.Field[coords.X - 1, coords.Y].Type != CellType.Water) &&
                    (!elem.CanStepLand))
                    fl = false;

                if (fl)
                {
                    elem.Position.X -= 1;
                    return;
                }
            }

            fl = true;

            //право
            if ((!Game.Map.Field[coords.X, coords.Y + 1].Occupied) &&
                (Game.Map.Field[coords.X, coords.Y + 1].Passable))
            {
                //если вода, а юнит не плавает
                if ((Game.Map.Field[coords.X, coords.Y + 1].Type == CellType.Water) &&
                    (!elem.CanStepAqua))
                    fl = false;

                //если не вода, а юнит только плавает
                if ((Game.Map.Field[coords.X, coords.Y + 1].Type != CellType.Water) &&
                    (!elem.CanStepLand))
                    fl = false;

                if (fl)
                {
                    elem.Position.Y += 1;
                    return;
                }
            }

            fl = true;

            //вниз
            if ((!Game.Map.Field[coords.X + 1, coords.Y].Occupied) &&
                (Game.Map.Field[coords.X + 1, coords.Y].Passable))
            {
                //если вода, а юнит не плавает
                if ((Game.Map.Field[coords.X + 1, coords.Y].Type == CellType.Water) &&
                    (!elem.CanStepAqua))
                    fl = false;

                //если не вода, а юнит только плавает
                if ((Game.Map.Field[coords.X + 1, coords.Y].Type != CellType.Water) &&
                    (!elem.CanStepLand))
                    fl = false;

                if (fl)
                {
                    elem.Position.X += 1;
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
                if ((SelectedDivision.Target.X == division.Position.X) &&
                    (SelectedDivision.Target.Y == division.Position.Y))
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
                //if ((Divisions[SelectedDivisionId].Target.X == Buildings[index].Position.X) &&
                //    (Divisions[SelectedDivisionId].Target.Y == Buildings[index].Position.Y))
                if ((SelectedDivision.Target.X == building.Position.X) &&
                    (SelectedDivision.Target.Y == building.Position.Y))
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

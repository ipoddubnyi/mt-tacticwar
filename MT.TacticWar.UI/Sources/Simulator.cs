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

        private Fog fog;

        //параметры игры
        // - системные параметры
        //    * ширина ячейки поля ?в переменной Map?
        //
        // - число сделанных ходов
        // - кто ходит сейчас
        public int PlayerCurrent; //-1 - никто, 0 - игрок 0, 1 - игрок 1
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
            Game = MissionLoader.LoadGame(misPath);
            PlayerCurrent = 0;

            BestWay = new List<Cell>();
            KrestCoords = Coordinates.Empty;

            SelectedDivision = null;
            SelectedBuilding = null;
        }

        public void InitGraphics(Graphics grf)
        {
            graphics = new GameGraphics(grf);
        }

        public void PassStep()
        {
            DeselectAll();
            PlayerCurrent = (PlayerCurrent + 1) % Game.Players.Length;
            Game.Players[PlayerCurrent].ResetDivisionsParams();
        }

        public void SelectDivision(Division division)
        {
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

        public void DrawAll()
        {
            fog = new Fog(Game.Map.Width, Game.Map.Height, Game.Players[PlayerCurrent]);

            graphics.DrawMap(Game.Map);
            //graphics.DrawPlayersObjects(Game.Players, Game.Map, SelectedDivision, SelectedBuilding);
            graphics.DrawPlayersObjects(Game.Players, PlayerCurrent, SelectedDivision, SelectedBuilding, fog);

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

            graphics.DrawFog(fog);
        }

        public void DeselectAll()
        {
            int x, y;

            // стереть крест
            if (KrestCoords.X != -1)
                graphics.DrawCellOne(Game.Map[KrestCoords.X, KrestCoords.Y], fog);

            KrestCoords = Coordinates.Empty;

            // стереть проложенный путь
            if (BestWay.Count > 0)
            {
                for (int k = 0; k < BestWay.Count; k++)
                {
                    x = BestWay[k].Coordinates.X;
                    y = BestWay[k].Coordinates.Y;
                    graphics.DrawCellOne(Game.Map[x, y], fog);
                }

                // перерисовать целевую клетку, включая объект
                var target = BestWay[BestWay.Count - 1];
                if (null != target.Object)
                {
                    if (target.Object is Division)
                    {
                        var division = target.Object as Division;
                        x = division.Position.X;
                        y = division.Position.Y;
                        graphics.DrawCellOne(Game.Map.Field[x, y], fog);
                        if (!fog[x, y])
                            graphics.DrawDivision(division, false);
                    }
                    else if (target.Object is Building)
                    {
                        var building = target.Object as Building;
                        x = building.Position.X;
                        y = building.Position.Y;
                        graphics.DrawCellOne(Game.Map.Field[x, y], fog);
                        if (!fog[x, y])
                            graphics.DrawBuilding(building, false);
                    }
                }

                BestWay.Clear();
            }

            // перерисовать выделенное подразделение
            if (null != SelectedDivision)
            {
                x = SelectedDivision.Position.X;
                y = SelectedDivision.Position.Y;
                graphics.DrawCell(Game.Map.Field[x, y]);

                if (SelectedDivision.IsSecuring)
                    graphics.DrawBuilding(SelectedDivision.SecuredBuilding, false);
                else
                    graphics.DrawDivision(SelectedDivision, false);

                // TODO: сделать сохранение цели
                // чтобы при повторном выделении юнита,
                // пересчитывался короткий путь к цели
                SelectedDivision.RemoveTarget();

                SelectedDivision = null;
            }

            // перерисовать выделенное строение
            if (null != SelectedBuilding)
            {
                x = SelectedBuilding.Position.X;
                y = SelectedBuilding.Position.Y;
                graphics.DrawCell(Game.Map.Field[x, y]);
                graphics.DrawBuilding(SelectedBuilding, false);
                SelectedBuilding = null;
            }

            // TODO: после атаки с отступлением пропадает противник
        }

        private List<Cell> GetBestWay(Division division, Coordinates target)
        {
            return new Bellman(Game.Map).BellmanPoiskPuti(division, target);
        }

        #endregion

        #region Обработчики нажатий

        private void SelectAndDrawDivision(Division division)
        {
            DeselectAll();
            SelectDivision(division);

            graphics.DrawCell(Game.Map[division.Position]);
            //var area = fog.UpdateArea(division.Position, division.RadiusView, true);
            //graphics.DrawArea(Game.Map, area, fog);
            graphics.DrawDivision(division, true);
        }

        private void SelectAndDrawBuilding(Building building)
        {
            DeselectAll();
            SelectBuilding(building);

            graphics.DrawCell(Game.Map[building.Position]);
            graphics.DrawBuilding(building, true);
        }

        private void FindAndDrawWayTo(MoveType moveType, Coordinates target)
        {
            SelectAndDrawDivision(SelectedDivision);

            BestWay = GetBestWay(SelectedDivision, target);
            if (BestWay.Count > 0)
            {
                SelectedDivision.SetTarget(target);

                var dayIndex = SelectedDivision.GetOneDayIndex(BestWay);
                var isOneday = dayIndex == BestWay.Count - 1;

                graphics.DrawWay(BestWay, dayIndex);
                graphics.DrawFlag(target, moveType, isOneday);
            }
            else
            {
                //нарисовать крест
                KrestCoords = target.Clone();
                graphics.DrawCross(KrestCoords);
            }
        }

        private void MoveAndDrawDivision(MoveType moveType, Coordinates target)
        {
            //запомнить координаты выделенного юнита
            var positionOld = SelectedDivision.Position.Clone();

            //если путь был найден
            if (BestWay.Count <= 1)
                return;

            //сдвинуть юнит
            SelectedDivision.Move(BestWay);

            //если юнит сместился (!)
            if (positionOld.Equals(SelectedDivision.Position))
                return;

            // обновляем туман войны
            var areaOld = fog.UpdateArea(positionOld, SelectedDivision.RadiusView, false);
            var areaNew = fog.UpdateArea(SelectedDivision.Position, SelectedDivision.RadiusView, true);
            graphics.DrawArea(Game, areaOld, fog);
            graphics.DrawArea(Game, areaNew, fog);

            //если на старом месте нет здания - освободить старую ячейку
            var building = SelectedDivision.SecuredBuilding;
            if (null == building)
                Game.Map[positionOld].Object = null;
            else //иначе - освободить здание
                building.RemoveSecurity();

            //занять новую ячейку
            Game.Map[SelectedDivision.Position].Object = SelectedDivision;

            //убрать из путь часть, которую уже прошли
            var tmpPut = CutWayPart(BestWay, SelectedDivision.Position);

            //выделить юнит заново и собрать информацию о нём
            SelectAndDrawDivision(SelectedDivision);

            //загрузить путь из временной памяти
            BestWay = new List<Cell>(tmpPut);

            // перерисовать здание, если оно было
            if (null != building)
                graphics.DrawBuilding(building, false);


            //нарисовать путь без пересчёта и нарисавать флаг
            if (BestWay.Count > 0)
            {
                //установить флаг
                SelectedDivision.SetTarget(target);

                var dayIndex = SelectedDivision.GetOneDayIndex(BestWay);
                var isOneday = dayIndex == BestWay.Count - 1;

                // если юнит НЕ дошёл до цели за день
                if (!isOneday)
                {
                    graphics.DrawWay(BestWay, dayIndex);
                    graphics.DrawFlag(target, moveType, false);
                }

                //иначе флаг будет поверх присоединённого или атакуемого юнита
            }
        }

        private List<Cell> CutWayPart(List<Cell> way, Coordinates pt)
        {
            var wayCut = new List<Cell>(way);

            while (wayCut.Count > 0)
            {
                if (wayCut[0].Coordinates.Equals(pt))
                    break;

                wayCut.RemoveAt(0);
            }

            return wayCut;
        }

        //----------------------

        private MoveType GetMoveType(IObject obj, bool isEnemy)
        {
            if (obj is Division)
                return isEnemy ? MoveType.Attack : MoveType.Join;

            if (obj is Building)
            {
                var building = obj as Building;
                if (isEnemy)
                    return building.IsSecured ? MoveType.Attack : MoveType.Capture;
                else
                    return building.IsSecured ? MoveType.Join : MoveType.Defend;
            }

            throw new Exception("Неизвестный тип объекта.");
        }

        /// <summary>Обработчик нажатия на подразделение</summary>
        private Signals ClickOnDivision(Division division)
        {
            var isEnemy = division.PlayerId != PlayerCurrent;
            var command = isEnemy ? ClickEnemieDivision(division) : ClickMyDivision(division);

            MoveType moveType;
            switch (command)
            {
                case ClickResult.Select:
                    SelectAndDrawDivision(division);
                    return Signals.READY_UNIT_INFO;
                case ClickResult.FindWay:
                    moveType = GetMoveType(division, isEnemy);
                    FindAndDrawWayTo(moveType, division.Position);
                    break;
                case ClickResult.Move:
                    moveType = GetMoveType(division, isEnemy);
                    MoveAndDrawDivision(moveType, division.Position);

                    //если координаты юнита совпадают с координатами целевого юнита
                    if (SelectedDivision.Position.Equals(division.Position))
                        return achievementTag(SelectedDivision, division);

                    return Signals.READY_UNIT_INFO;
            }

            return Signals.SUCCESS;
        }

        /// <summary>Обработчик нажатия на здание</summary>
        private Signals ClickOnBuilding(Building building)
        {
            var isEnemy = building.PlayerId != PlayerCurrent;
            var command = isEnemy ? ClickEnemieBuilding(building) : ClickMyBuilding(building);

            MoveType moveType;
            switch (command)
            {
                case ClickResult.Select:
                    SelectAndDrawBuilding(building);
                    return Signals.READY_UNIT_INFO;
                case ClickResult.FindWay:
                    moveType = GetMoveType(building, isEnemy);
                    FindAndDrawWayTo(moveType, building.Position);
                    break;
                case ClickResult.Move:
                    moveType = GetMoveType(building, isEnemy);
                    MoveAndDrawDivision(moveType, building.Position);

                    //если координаты юнита совпадают с координатами целевого здания
                    if (SelectedDivision.Position.Equals(building.Position))
                    {
                        // TODO: разобраться
                        var tmpSig = achievementTag(SelectedDivision, building);
                        graphics.DrawCell(Game.Map[building.Position]);
                        graphics.DrawBuilding(building, building == SelectedBuilding);
                        return tmpSig;
                    }

                    return Signals.READY_UNIT_INFO;
            }

            return Signals.SUCCESS;
        }

        /// <summary>Обработчик попадания на пустую клетку</summary>
        private Signals ClickOnEmptyCell(int x, int y)
        {
            if (null == SelectedDivision)
                return Signals.SUCCESS;

            if (SelectedDivision.PlayerId != PlayerCurrent)
                return Signals.SUCCESS;

            // если эта точка определа как цель выделенного подразделения
            if (SelectedDivision.Target.Equals(x, y))
            {
                MoveAndDrawDivision(MoveType.Go, new Coordinates(x, y));

                // TODO: когда подразделение перемещается в тумане войны и натыкается на соперника
                //если координаты юнита совпадают с координатами целевого юнита
                var obj = Game.GetObjectAt(SelectedDivision.Position, PlayerCurrent);
                if (null != obj)
                    return achievementTag(SelectedDivision, obj);

                return Signals.READY_UNIT_INFO;
            }

            FindAndDrawWayTo(MoveType.Go, new Coordinates(x, y));
            return Signals.SUCCESS;
        }

        //----------------------

        public Signals achievementTag(Division thisElem, IObject tagObj)
        {
            if (tagObj is Division)
                return achievementTag(thisElem, tagObj as Division);

            if (tagObj is Building)
                return achievementTag(thisElem, tagObj as Building);

            throw new Exception("Неизвестный объект.");
        }

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

                return Signals.ATTACK;
            }

            return Signals.READY_UNIT_INFO;
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
                        return Signals.FAILURE;
                }
                else
                {
                    //поставить на охрану
                    Game.Players[tagBuild.PlayerId].Buildings[tagBuild.Id].AddSecurity(thisElem);

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

                    return Signals.ATTACK;
                }
                else
                {
                    Building tmpBuild;

                    //захват постройки
                    tmp = tagBuild;
                    tmpBuild = tagBuild.Copy();
                    Game.Players[thisElem.PlayerId].Buildings.Add(tmpBuild);
                    //Game.Players[thisElem.PlayerId].recountIds();
                    Game.Players[tagBuild.PlayerId].Buildings.Remove(tmp);
                    //Game.Players[tagBuild.PlayerId].recountIds();

                    //захват всегда отнимает все шаги
                    thisElem.Steps = 0;

                    //поставить юнита на охранение
                    tmp = Game.Players[thisElem.PlayerId].Buildings[Game.Players[thisElem.PlayerId].Buildings.Count - 1];
                    tmp.AddSecurity(thisElem);
                }
            }

            SelectBuilding(tmp);

            return Signals.READY_UNIT_INFO;
        }

        //----------------------

        /// <summary>Обработчик нажатия на зону боевых действий</summary>
        /// <param name="left">координата в пикселях</param>
        /// <param name="top">координата в пикселях</param>
        /// <returns>Возвращает сигналы обмена с GUI</returns>
        public Signals ZonaClick(int left, int top)
        {
            int x = left / GameGraphics.CellSize;
            int y = top / GameGraphics.CellSize;

            if (x < 0 || x > Game.Map.Width - 1)
                return Signals.OUT_OF_RANGE;

            if (y < 0 || y > Game.Map.Height - 1)
                return Signals.OUT_OF_RANGE;

            // !!!!!!!! дебаг !!!!!!!!
            // PlayerCurrent = 1;

            // TODO: учесть ситуацию,
            // когда из-за тумана войны не видно цели,
            // но когда туда перемещается юнит,
            // там может оказаться объект другого игрока

            // если нет тумана войны
            if (!fog[x, y])
            {
                // щелчок по подразделению
                var division = Game.GetDivisionAt(x, y);
                if (null != division)
                    return ClickOnDivision(division);

                // щелчок по строению
                var building = Game.GetBuildingAt(x, y);
                if (null != building)
                    return ClickOnBuilding(building);
            }

            // щелчок по пустой клетке
            return ClickOnEmptyCell(x, y);
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
                elem1.ResetParams();

                //пересчитать показатели поддержки
                for (int k = 0; k < podderzh1.Count; k++)
                    podderzh1[k].ResetParams();
            }

            if (elem2.Units.Count > 0)
            {
                win = 2;
                elem2.ResetParams();

                //пересчитать показатели поддержки
                for (int k = 0; k < podderzh2.Count; k++)
                    podderzh2[k].ResetParams();
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

        /// <summary>Обработчик нажатия по своему подразделению</summary>
        private ClickResult ClickMyDivision(Division division)
        {
            if (SelectedDivision == null)
                return ClickResult.Select;

            if (SelectedDivision == division)
                return ClickResult.Select;

            if (SelectedDivision.PlayerId != PlayerCurrent)
                return ClickResult.Select;

            //если флаг выделенного юнита указывает сюда
            if (SelectedDivision.Target.Equals(division.Position))
            {
                //продвинуть выделенный юнит
                return ClickResult.Move;
            }

            //если типы юнитов не совпадают - выделить нового юнита
            if (SelectedDivision.Type != division.Type)
                return ClickResult.Select;

            //поставить флаг, просчитать путь
            return ClickResult.FindWay;
        }

        /// <summary>Обработчик нажатия по чужому подразделению</summary>
        private ClickResult ClickEnemieDivision(Division division)
        {
            if (SelectedDivision == null)
                return ClickResult.Select;

            if (SelectedDivision.PlayerId != PlayerCurrent)
                return ClickResult.Select;

            //если флаг выделенного юнита указывает сюда
            if (SelectedDivision.Target.Equals(division.Position))
            {
                //продвинуть выделенный юнит
                return ClickResult.Move;
            }

            //поставить флаг, просчитать путь
            return ClickResult.FindWay;
        }

        /// <summary>Обработчик нажатия по своему зданию</summary>
        private ClickResult ClickMyBuilding(Building building)
        {
            if (SelectedDivision == null)
                return ClickResult.Select;

            if (SelectedDivision == building.SecurityDivision)
                return ClickResult.Select;

            if (SelectedDivision.PlayerId != PlayerCurrent)
                return ClickResult.Select;

            // если флаг выделенного юнита указывает сюда
            if (SelectedDivision.Target.Equals(building.Position))
            {
                // продвинуть выделенный юнит
                return ClickResult.Move;
            }

            // если есть охранение в здании
            if (building.IsSecured)
            {
                // если типы юнита и охранения не совпадают - выделить здание и его охранение
                if (SelectedDivision.Type != building.SecurityDivision.Type)
                    return ClickResult.Select;
            }

            // поставить флаг, просчитать путь
            return ClickResult.FindWay;
        }

        /// <summary>Обработчик нажатия по чужому зданию</summary>
        private ClickResult ClickEnemieBuilding(Building building)
        {
            if (SelectedDivision == null)
                return ClickResult.Select;

            if (SelectedDivision.PlayerId != PlayerCurrent)
                return ClickResult.Select;

            // если флаг выделенного юнита указывает сюда
            if (SelectedDivision.Target.Equals(building.Position))
            {
                // продвинуть выделенный юнит
                return ClickResult.Move;
            }

            // поставить флаг, просчитать путь
            return ClickResult.FindWay;
        }

        private enum ClickResult
        {
            /// <summary>
            /// Передать информацию о выделенном юните.
            /// </summary>
            Select = 1,

            /// <summary>
            /// Поставить флаг, просчитать путь.
            /// </summary>
            FindWay = 2,

            /// <summary>
            /// Продвинуть выделенный юнит к данному.
            /// </summary>
            Move = 3
        }
    }
}

using System;
using System.Collections.Generic;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Serialization;
using MT.TacticWar.Gameplay.Routers;
using MT.TacticWar.Gameplay.Battles;

namespace MT.TacticWar.Gameplay
{
    // Симулятор игры - то, что контактирует с граф. интерфейсом и делает все просчёты
    public class Game
    {
        public Mission Mission { get; set; }

        private Fog fog;

        //параметры игры
        // - системные параметры
        //    * ширина ячейки поля ?в переменной Map?
        //
        // - число сделанных ходов
        // - кто ходит сейчас
        public int PlayerCurrent; //-1 - никто, 0 - игрок 0, 1 - игрок 1
        // - набранные очки ?
        // - информация об атаке
        public BattleInfo AttackInfo;
        // - графика (где рисуется поле боя)
        public IGraphics Graphics { get; private set; }

        //!!!! временная переменная (пока не знаю, как сделать иначе)
        public Coordinates cross; //координаты установленного креста

        public Division SelectedDivision { get; set; }
        public Building SelectedBuilding { get; set; }

        private List<Cell> BestWay { get; set; }

        public Game(string misPath, string plr0Name, string plr1Name, bool plr0AI, bool plr1AI)
        {
            Mission = MissionLoader.LoadGame(misPath);
            PlayerCurrent = 0;

            BestWay = new List<Cell>();
            cross = Coordinates.Empty;

            SelectedDivision = null;
            SelectedBuilding = null;
        }

        public Game(Mission mission, string plr0Name, string plr1Name, bool plr0AI, bool plr1AI)
        {
            Mission = mission;
            PlayerCurrent = 0;

            BestWay = new List<Cell>();
            cross = Coordinates.Empty;

            SelectedDivision = null;
            SelectedBuilding = null;
        }

        public void InitGraphics(IGraphics graphics)
        {
            Graphics = graphics;
        }

        public void PassStep()
        {
            DeselectAll();
            PlayerCurrent = (PlayerCurrent + 1) % Mission.Players.Length;
            Mission.Players[PlayerCurrent].ResetDivisionsParams();
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
            fog = new Fog(Mission.Map.Width, Mission.Map.Height, Mission.Players[PlayerCurrent]);

            Graphics.DrawMap(Mission.Map);
            //graphics.DrawPlayersObjects(Mission.Players, Mission.Map, SelectedDivision, SelectedBuilding);
            Graphics.DrawPlayersObjects(Mission.Players, PlayerCurrent, SelectedDivision, SelectedBuilding, fog);

            //нарисовать крест, если он есть
            if (cross.X != -1)
                Graphics.DrawCross(cross);

            /*//нарисовать путь
            if (Mission.Players[0].SelectedDivisionId != -1)
            {
                drawPutManager(grf, PlayerCurrent, Mission.Players[0].SelectedDivisionId, false);
                //drawFlagManager(grf, 
            }
            else if (Mission.Players[1].SelectedDivisionId != -1)
            {
                drawPutManager(grf, PlayerCurrent, Mission.Players[1].SelectedDivisionId, false);
                //drawFlagManager(grf, 
            }*/

            Graphics.DrawFog(fog);
        }

        public void DeselectAll()
        {
            int x, y;

            // стереть крест
            if (cross.X != -1)
            {
                Graphics.DrawArea(Mission, cross, fog);
            }

            cross = Coordinates.Empty;

            // стереть проложенный путь
            if (BestWay.Count > 0)
            {
                for (int i = 0; i < BestWay.Count; i++)
                {
                    Graphics.DrawArea(Mission, BestWay[i].Coordinates, fog);
                }

                BestWay.Clear();
            }

            // перерисовать выделенное подразделение
            if (null != SelectedDivision)
            {
                Graphics.DrawArea(Mission, SelectedDivision.Position, fog);

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
                Graphics.DrawCell(Mission.Map.Field[x, y]);
                Graphics.DrawBuilding(SelectedBuilding, false);
                SelectedBuilding = null;
            }
        }

        private List<Cell> GetBestWay(Division division, Coordinates target)
        {
            return new Bellman(Mission.Map, fog).FindPath(division, target);
        }

        #endregion

        #region Обработчики нажатий

        private void SelectAndDrawDivision(Division division)
        {
            DeselectAll();
            SelectDivision(division);

            Graphics.DrawCell(Mission.Map[division.Position]);
            //var area = fog.UpdateArea(division.Position, division.RadiusView, true);
            //graphics.DrawArea(Mission.Map, area, fog);
            Graphics.DrawDivision(division, true);
        }

        private void SelectAndDrawBuilding(Building building)
        {
            DeselectAll();
            SelectBuilding(building);

            Graphics.DrawCell(Mission.Map[building.Position]);
            Graphics.DrawBuilding(building, true);
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

                Graphics.DrawWay(BestWay, dayIndex);
                Graphics.DrawFlag(target, moveType, isOneday);
            }
            else
            {
                //нарисовать крест
                cross = target.Copy();
                Graphics.DrawCross(cross);
            }
        }

        private void MoveAndDrawDivision(MoveType moveType, Coordinates target)
        {
            // запомнить координаты выделенного юнита
            var positionOld = SelectedDivision.Position.Copy();

            // если путь был найден
            if (BestWay.Count <= 1)
                return;

            // сдвинуть юнит
            SelectedDivision.Move(BestWay);

            // если юнит сместился (!)
            if (positionOld.Equals(SelectedDivision.Position))
                return;

            // обновляем туман войны
            var areaOld = fog.UpdateArea(positionOld, SelectedDivision.RadiusView, false);
            var areaNew = fog.UpdateArea(SelectedDivision.Position, SelectedDivision.RadiusView, true);

            // если на старом месте нет здания - освободить старую ячейку
            var building = SelectedDivision.SecuredBuilding;
            if (null == building)
                Mission.Map[positionOld].Object = null;
            else //иначе - освободить здание
                building.RemoveSecurity();

            //занять новую ячейку
            Mission.Map[SelectedDivision.Position].Object = SelectedDivision;

            //убрать из путь часть, которую уже прошли
            var tmpPut = CutWayPart(BestWay, SelectedDivision.Position);

            //выделить юнит заново и собрать информацию о нём
            SelectAndDrawDivision(SelectedDivision);

            // перерисовать туман войны
            Graphics.DrawArea(Mission, areaOld, fog);
            Graphics.DrawArea(Mission, areaNew, fog);

            //загрузить путь из временной памяти
            BestWay = new List<Cell>(tmpPut);

            // перерисовать здание, если оно было
            if (null != building)
                Graphics.DrawBuilding(building, false);

            // пересчитать путь, т.к.
            // на новой позиции могли обнаружить помеху,
            // скрытую до этого в тумане войны
            BestWay = GetBestWay(SelectedDivision, target);
            if (BestWay.Count > 0)
            {
                //установить флаг
                SelectedDivision.SetTarget(target);

                var dayIndex = SelectedDivision.GetOneDayIndex(BestWay);
                var isOneday = dayIndex == BestWay.Count - 1;

                // если юнит НЕ дошёл до цели за день
                if (!isOneday)
                {
                    Graphics.DrawWay(BestWay, dayIndex);
                    Graphics.DrawFlag(target, moveType, false);
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
        private Signal ClickOnDivision(Division division)
        {
            var isEnemy = division.Player.Id != PlayerCurrent;
            var command = isEnemy ? ClickEnemieDivision(division) : ClickMyDivision(division);

            MoveType moveType;
            switch (command)
            {
                case ClickResult.Select:
                    SelectAndDrawDivision(division);
                    return Signal.READY_UNIT_INFO;
                case ClickResult.FindWay:
                    moveType = GetMoveType(division, isEnemy);
                    FindAndDrawWayTo(moveType, division.Position);
                    break;
                case ClickResult.Move:
                    moveType = GetMoveType(division, isEnemy);
                    MoveAndDrawDivision(moveType, division.Position);

                    //если координаты юнита совпадают с координатами целевого юнита
                    if (SelectedDivision.Position.Equals(division.Position))
                        return ReachTheGoal(SelectedDivision, division);

                    return Signal.READY_UNIT_INFO;
            }

            return Signal.SUCCESS;
        }

        /// <summary>Обработчик нажатия на здание</summary>
        private Signal ClickOnBuilding(Building building)
        {
            var isEnemy = building.Player.Id != PlayerCurrent;
            var command = isEnemy ? ClickEnemieBuilding(building) : ClickMyBuilding(building);

            MoveType moveType;
            switch (command)
            {
                case ClickResult.Select:
                    SelectAndDrawBuilding(building);
                    return Signal.READY_UNIT_INFO;
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
                        var tmpSig = ReachTheGoal(SelectedDivision, building);
                        Graphics.DrawCell(Mission.Map[building.Position]);
                        Graphics.DrawBuilding(building, building == SelectedBuilding);
                        return tmpSig;
                    }

                    return Signal.READY_UNIT_INFO;
            }

            return Signal.SUCCESS;
        }

        /// <summary>Обработчик попадания на пустую клетку</summary>
        private Signal ClickOnEmptyCell(int x, int y)
        {
            if (null == SelectedDivision)
                return Signal.SUCCESS;

            if (SelectedDivision.Player.Id != PlayerCurrent)
                return Signal.SUCCESS;

            // если эта точка определа как цель выделенного подразделения
            if (SelectedDivision.Target.Equals(x, y))
            {
                MoveAndDrawDivision(MoveType.Go, new Coordinates(x, y));

                // TODO: когда подразделение перемещается в тумане войны и натыкается на соперника
                //если координаты юнита совпадают с координатами целевого юнита
                var obj = Mission.GetObjectAt(SelectedDivision.Position, PlayerCurrent);
                if (null != obj)
                    return ReachTheGoal(SelectedDivision, obj);

                return Signal.READY_UNIT_INFO;
            }

            FindAndDrawWayTo(MoveType.Go, new Coordinates(x, y));
            return Signal.SUCCESS;
        }

        //----------------------

        public Signal ReachTheGoal(Division divisionThis, IObject objectTag)
        {
            if (objectTag is Division)
                return ReachTheGoal(divisionThis, objectTag as Division);

            if (objectTag is Building)
                return ReachTheGoal(divisionThis, objectTag as Building);

            throw new Exception("Неизвестный объект.");
        }

        /// <summary>Обработчик достижения цели (подразделения)</summary>
        public Signal ReachTheGoal(Division divisionThis, Division divisionTag)
        {
            // если целевое подразделение - того же игрока
            if (divisionThis.Player == divisionTag.Player)
            {
                // если типы подразделений совпадают
                if (divisionThis.Type != divisionTag.Type)
                    return Signal.FAILURE;

                // войти в его состав
                if (!divisionTag.AttachDivision(divisionThis))
                    return Signal.FAILURE; // TODO: наверное, надо сделать отступление

                SelectAndDrawDivision(divisionTag);
            }
            else
            {
                // заполняем структуру информации об атаке
                AttackInfo.DivisionAttacker = divisionThis;
                AttackInfo.DivisionDefender = divisionTag;
                AttackInfo.BuildingToCapture = null;

                //атака всегда отнимает шаги до минимума
                divisionThis.Steps = 0;
                divisionTag.Steps = 0;

                return Signal.ATTACK;
            }

            return Signal.READY_UNIT_INFO;
        }

        /// <summary>Обработчик достижения цели (здания)</summary>
        public Signal ReachTheGoal(Division divisionThis, Building buildingTag)
        {
            // если целевое здание - того же игрока
            if (divisionThis.Player == buildingTag.Player)
            {
                // если в здании есть охранение
                if (buildingTag.IsSecured)
                {
                    var divisionTag = buildingTag.SecurityDivision;

                    // если типы подразделений совпадают
                    if (divisionThis.Type != divisionTag.Type)
                        return Signal.FAILURE;

                    // войти в его состав
                    if (!divisionTag.AttachDivision(divisionThis))
                        return Signal.FAILURE; // TODO: наверное, надо сделать отступление

                    SelectAndDrawBuilding(buildingTag);
                }
                else
                {
                    // поставить на охрану
                    buildingTag.AddSecurity(divisionThis);

                    // встать на охранение здания - отнимает все шаги
                    divisionThis.Steps = 0;

                    SelectAndDrawBuilding(buildingTag);
                }
            }
            else
            {
                // если в здании есть охранение
                if (buildingTag.IsSecured)
                {
                    var divisionTagEnemy = buildingTag.SecurityDivision;

                    // заполняем структуру информации об атаке
                    AttackInfo.DivisionAttacker = divisionThis;
                    AttackInfo.DivisionDefender = divisionTagEnemy;
                    AttackInfo.BuildingToCapture = buildingTag;

                    // атака всегда отнимает шаги до минимума
                    divisionThis.Steps = 0;
                    divisionTagEnemy.Steps = 0;

                    return Signal.ATTACK;
                }
                else
                {
                    // захват постройки
                    buildingTag.Capture(divisionThis);
                    SelectAndDrawBuilding(buildingTag);
                }
            }

            return Signal.READY_UNIT_INFO;
        }

        //----------------------

        /// <summary>Обработчик нажатия на зону боевых действий</summary>
        /// <param name="left">координата в пикселях</param>
        /// <param name="top">координата в пикселях</param>
        /// <returns>Возвращает сигналы обмена с GUI</returns>
        public Signal ZonaClick(int left, int top)
        {
            int x = left / Graphics.CellSize;
            int y = top / Graphics.CellSize;

            if (x < 0 || x > Mission.Map.Width - 1)
                return Signal.OUT_OF_RANGE;

            if (y < 0 || y > Mission.Map.Height - 1)
                return Signal.OUT_OF_RANGE;

            // !!!!!!!! дебаг !!!!!!!!
            // PlayerCurrent = 1;

            // TODO: учесть ситуацию,
            // когда из-за тумана войны не видно цели,
            // но когда туда перемещается юнит,
            // там может оказаться объект другого игрока

            // если нет тумана войны
            if (!fog[x, y])
            {
                // TODO: подумать и переделать
                // сначала проверяем щелчок по зданию,
                // т.к. в здании может быть охранение
                // и тогда попадём не в тот обработчик

                // щелчок по строению
                var building = Mission.GetBuildingAt(x, y);
                if (null != building)
                    return ClickOnBuilding(building);

                // щелчок по подразделению
                var division = Mission.GetDivisionAt(x, y);
                if (null != division)
                    return ClickOnDivision(division);
            }

            // щелчок по пустой клетке
            return ClickOnEmptyCell(x, y);
        }

        #endregion

        public BattleResult BattleBegin(Division div1, Division div2, List<Division> support1, List<Division> support2, Building bldToCapture)
        {
            // битва становится главной целью
            BestWay.Clear();
            div1.Target = Coordinates.Empty;

            var result = new Battle(Mission).Run(div1, div2, support1, support2);

            // если атакующий проиграл, снять с него выделение
            if (BattleResult.Lose == result)
                SelectedDivision = null;

            if (BattleResult.Win == result)
            {
                // если был захват постройки - занять её
                if (null != bldToCapture)
                {
                    bldToCapture.Capture(div1);
                    SelectAndDrawBuilding(bldToCapture);
                }
            }

            return result;
        }

        public void BattleRecede(Division division)
        {
            // битва становится главной целью
            BestWay.Clear();
            division.Target = Coordinates.Empty;

            // TODO: добавить штраф за отступление
            new Battle(Mission).RecedeDivision(division);
        }

        /// <summary>Обработчик нажатия по своему подразделению</summary>
        private ClickResult ClickMyDivision(Division division)
        {
            if (SelectedDivision == null)
                return ClickResult.Select;

            if (SelectedDivision == division)
                return ClickResult.Select;

            if (SelectedDivision.Player.Id != PlayerCurrent)
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

            if (SelectedDivision.Player.Id != PlayerCurrent)
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

            if (SelectedDivision.Player.Id != PlayerCurrent)
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

            if (SelectedDivision.Player.Id != PlayerCurrent)
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
    }
}

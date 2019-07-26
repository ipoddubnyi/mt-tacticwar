using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Serialization;
using MT.TacticWar.Core.Algorithm;
using MT.TacticWar.Core.Battle;

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
        // - информация об атаке
        public AttackInfo AttackInfo;
        // - графика (где рисуется поле боя)
        public GameGraphics Graphics { get; private set; }

        //!!!! временная переменная (пока не знаю, как сделать иначе)
        public Coordinates KrestCoords; //координаты установленного креста

        public Division SelectedDivision { get; set; }
        public Building SelectedBuilding { get; set; }

        private List<Cell> BestWay { get; set; }

        public Simulator(string misPath, string plr0Name, string plr1Name, bool plr0AI, bool plr1AI)
        {
            Game = MissionLoader.LoadGame(misPath);
            PlayerCurrent = 0;

            BestWay = new List<Cell>();
            KrestCoords = Coordinates.Empty;

            SelectedDivision = null;
            SelectedBuilding = null;
        }

        public Simulator(Mission mission, string plr0Name, string plr1Name, bool plr0AI, bool plr1AI)
        {
            Game = mission;
            PlayerCurrent = 0;

            BestWay = new List<Cell>();
            KrestCoords = Coordinates.Empty;

            SelectedDivision = null;
            SelectedBuilding = null;
        }

        public void InitGraphics(Graphics grf, int cellsize)
        {
            Graphics = new GameGraphics(grf, cellsize);
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

            Graphics.DrawMap(Game.Map);
            //graphics.DrawPlayersObjects(Game.Players, Game.Map, SelectedDivision, SelectedBuilding);
            Graphics.DrawPlayersObjects(Game.Players, PlayerCurrent, SelectedDivision, SelectedBuilding, fog);

            //нарисовать крест, если он есть
            if (KrestCoords.X != -1)
                Graphics.DrawCross(KrestCoords.X, KrestCoords.Y);

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

            Graphics.DrawFog(fog);
        }

        public void DeselectAll()
        {
            int x, y;

            // стереть крест
            if (KrestCoords.X != -1)
                Graphics.DrawCellOne(Game.Map[KrestCoords.X, KrestCoords.Y], fog);

            KrestCoords = Coordinates.Empty;

            // стереть проложенный путь
            if (BestWay.Count > 0)
            {
                for (int k = 0; k < BestWay.Count; k++)
                {
                    x = BestWay[k].Coordinates.X;
                    y = BestWay[k].Coordinates.Y;
                    Graphics.DrawCellOne(Game.Map[x, y], fog);
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
                        Graphics.DrawCellOne(Game.Map.Field[x, y], fog);
                        if (!fog[x, y])
                            Graphics.DrawDivision(division, false);
                    }
                    else if (target.Object is Building)
                    {
                        var building = target.Object as Building;
                        x = building.Position.X;
                        y = building.Position.Y;
                        Graphics.DrawCellOne(Game.Map.Field[x, y], fog);
                        if (!fog[x, y])
                            Graphics.DrawBuilding(building, false);
                    }
                }

                BestWay.Clear();
            }

            // перерисовать выделенное подразделение
            if (null != SelectedDivision)
            {
                x = SelectedDivision.Position.X;
                y = SelectedDivision.Position.Y;
                Graphics.DrawCell(Game.Map.Field[x, y]);

                if (SelectedDivision.IsSecuring)
                    Graphics.DrawBuilding(SelectedDivision.SecuredBuilding, false);
                else
                    Graphics.DrawDivision(SelectedDivision, false);

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
                Graphics.DrawCell(Game.Map.Field[x, y]);
                Graphics.DrawBuilding(SelectedBuilding, false);
                SelectedBuilding = null;
            }
        }

        private List<Cell> GetBestWay(Division division, Coordinates target)
        {
            return new Bellman(Game.Map, fog).BellmanPoiskPuti(division, target);
        }

        #endregion

        #region Обработчики нажатий

        private void SelectAndDrawDivision(Division division)
        {
            DeselectAll();
            SelectDivision(division);

            Graphics.DrawCell(Game.Map[division.Position]);
            //var area = fog.UpdateArea(division.Position, division.RadiusView, true);
            //graphics.DrawArea(Game.Map, area, fog);
            Graphics.DrawDivision(division, true);
        }

        private void SelectAndDrawBuilding(Building building)
        {
            DeselectAll();
            SelectBuilding(building);

            Graphics.DrawCell(Game.Map[building.Position]);
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
                KrestCoords = target.Clone();
                Graphics.DrawCross(KrestCoords);
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

            // перерисовать туман войны
            Graphics.DrawArea(Game, areaOld, fog);
            Graphics.DrawArea(Game, areaNew, fog);

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
        private Signals ClickOnDivision(Division division)
        {
            var isEnemy = division.Player.Id != PlayerCurrent;
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
                        return ReachTheGoal(SelectedDivision, division);

                    return Signals.READY_UNIT_INFO;
            }

            return Signals.SUCCESS;
        }

        /// <summary>Обработчик нажатия на здание</summary>
        private Signals ClickOnBuilding(Building building)
        {
            var isEnemy = building.Player.Id != PlayerCurrent;
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
                        var tmpSig = ReachTheGoal(SelectedDivision, building);
                        Graphics.DrawCell(Game.Map[building.Position]);
                        Graphics.DrawBuilding(building, building == SelectedBuilding);
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

            if (SelectedDivision.Player.Id != PlayerCurrent)
                return Signals.SUCCESS;

            // если эта точка определа как цель выделенного подразделения
            if (SelectedDivision.Target.Equals(x, y))
            {
                MoveAndDrawDivision(MoveType.Go, new Coordinates(x, y));

                // TODO: когда подразделение перемещается в тумане войны и натыкается на соперника
                //если координаты юнита совпадают с координатами целевого юнита
                var obj = Game.GetObjectAt(SelectedDivision.Position, PlayerCurrent);
                if (null != obj)
                    return ReachTheGoal(SelectedDivision, obj);

                return Signals.READY_UNIT_INFO;
            }

            FindAndDrawWayTo(MoveType.Go, new Coordinates(x, y));
            return Signals.SUCCESS;
        }

        //----------------------

        public Signals ReachTheGoal(Division divisionThis, IObject objectTag)
        {
            if (objectTag is Division)
                return ReachTheGoal(divisionThis, objectTag as Division);

            if (objectTag is Building)
                return ReachTheGoal(divisionThis, objectTag as Building);

            throw new Exception("Неизвестный объект.");
        }

        /// <summary>Обработчик достижения цели (подразделения)</summary>
        public Signals ReachTheGoal(Division divisionThis, Division divisionTag)
        {
            // если целевое подразделение - того же игрока
            if (divisionThis.Player == divisionTag.Player)
            {
                // если типы подразделений совпадают
                if (divisionThis.Type != divisionTag.Type)
                    return Signals.FAILURE;

                // войти в его состав
                if (!divisionTag.AttachDivision(divisionThis))
                    return Signals.FAILURE; // TODO: наверное, надо сделать отступление

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

                return Signals.ATTACK;
            }

            return Signals.READY_UNIT_INFO;
        }

        /// <summary>Обработчик достижения цели (здания)</summary>
        public Signals ReachTheGoal(Division divisionThis, Building buildingTag)
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
                        return Signals.FAILURE;

                    // войти в его состав
                    if (!divisionTag.AttachDivision(divisionThis))
                        return Signals.FAILURE; // TODO: наверное, надо сделать отступление

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

                    return Signals.ATTACK;
                }
                else
                {
                    // захват постройки
                    buildingTag.Capture(divisionThis);
                    SelectAndDrawBuilding(buildingTag);
                }
            }

            return Signals.READY_UNIT_INFO;
        }

        //----------------------

        /// <summary>Обработчик нажатия на зону боевых действий</summary>
        /// <param name="left">координата в пикселях</param>
        /// <param name="top">координата в пикселях</param>
        /// <returns>Возвращает сигналы обмена с GUI</returns>
        public Signals ZonaClick(int left, int top)
        {
            int x = left / Graphics.CellSize;
            int y = top / Graphics.CellSize;

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
                // TODO: подумать и переделать
                // сначала проверяем щелчок по зданию,
                // т.к. в здании может быть охранение
                // и тогда попадём не в тот обработчик

                // щелчок по строению
                var building = Game.GetBuildingAt(x, y);
                if (null != building)
                    return ClickOnBuilding(building);

                // щелчок по подразделению
                var division = Game.GetDivisionAt(x, y);
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

            var result = new Battle(Game).Run(div1, div2, support1, support2);

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
            new Battle(Game).RecedeDivision(division);
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

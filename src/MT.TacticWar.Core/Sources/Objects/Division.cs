using System;
using System.Collections.Generic;
using System.Linq;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Objects
{
    public class Division : IObject
    {
        public int Id { get; protected set; }

        public Coordinates Position { get; set; }

        public Coordinates Target { get; set; }   //координаты места назначения

        public string Name;        //имя
        public DivisionType Type; //тип подразделения
        public Player Player { get; set; }        // игрок

        public int PowerAntiInf;   //общая мощь против пехоты и артиллерии
        public int PowerAntiTank;  //общая мощь против бронетехники и кораблей
        public int PowerAntiAir;   //общая мощь против воздуха

        public int ArmourFromInf;  //общая защита от пехоты
        public int ArmourFromTank; //общая защита от любой техники

        public int Supply;        //число патронов и снарядов

        public int RadiusAttack;         //радиус действия (для артиллерии)
        public int RadiusView;          //радиус обзора

        public int Experience;      //опыт

        public int Steps;          //число шагов (равно числу шагов самого медленного юнита)
        public bool CanStepLand;      //ходит ли по земле
        public bool CanStepAqua;      //ходит ли по воде

        public List<Unit> Units;    //список юнитов

        public Building SecuredBuilding { get; set; } //охраняемое здание
        public bool IsSecuring => null != SecuredBuilding;

        public Division(Player player, int id, int type, string name, int x, int y, List<Unit> units)
        {
            //тип подразделения
            Type = (DivisionType)type;

            //координаты на зоне БД
            Position = new Coordinates(x, y);

            //координаты места назначения
            Target = Coordinates.Empty;

            Id = id;             //номер подразделения
            Name = name;        //имя
            Player = player;        //ид игрока

            //список юнитов
            Units = units; //new List<StructUnits>();

            SecuredBuilding = null;

            //пересчитать показатели
            ResetParams();
        }

        //Продвинуть подразделение к цели на этот день
        //!!!!!!!!!! Возврат: true - достигли цели
        public void Move(List<Cell> way)
        {
            //просчитать путь для юнита на один день (для рисования на карте)
            //Cell[] tmpArr = new Cell[put.Count];
            //put.CopyTo(tmpArr);
            var tmpArr = new List<Cell>(way);
            var oneday = GetOneDayWay(tmpArr);

            //бежим по точкам пути
            for (int k = 0; k < (oneday.Count - 1); k++)
            {
                Steps -= oneday[k].PassCost;

                //если юниту хватает шагов, чтобы пройти по данной ячейке
                //if (Steps < 0)
                //    k = put.Count; //иначе - завершаем цикл
            }

            var dayTarget = oneday.Last().Coordinates.Clone();
            Position = dayTarget.Clone();
        }

        //Просчитать часть пути, которую юнит пройдёт за один день
        private List<Cell> GetOneDayWay(List<Cell> wayall)
        {
            int index = GetOneDayIndex(wayall);
            return wayall.GetRange(0, index + 1);
        }

        public int GetOneDayIndex(List<Cell> wayall)
        {
            int curSteps = Steps; //шаги в текущем ходе
            int index = 0;

            for (int i = 0; i < wayall.Count; i++)
            {
                //если юниту не хватает шагов, чтобы пройти по данной ячейке
                if (curSteps < 0)
                    break;

                index = i; //запоминаем ячейку по списку
                curSteps -= wayall[i].PassCost;
            }

            return index;
        }

        public void SetTarget(int x, int y)
        {
            SetTarget(new Coordinates(x, y));
        }

        public void SetTarget(Coordinates target)
        {
            Target = target.Clone();
        }

        public void RemoveTarget()
        {
            Target = Coordinates.Empty;
        }

        // Пересчитать показатели подразделения
        public void ResetParams()
        {
            PowerAntiInf = 0;      //средняя мощь против пехоты и артиллерии
            PowerAntiAir = 0;      //средняя мощь против воздуха
            PowerAntiTank = 0;     //средняя мощь против бронетехники и кораблей

            ArmourFromInf = 0;     //средняя защита от пехоты
            ArmourFromTank = 0;    //средняя защита от любой техники

            Supply = 0;           //число патронов и снарядов
            RadiusAttack = int.MaxValue; //радиус действия (для артиллерии)
            RadiusView = 0;             //радиус обзора

            Experience = 0;          //средний опыт

            Steps = int.MaxValue;  //число шагов (равно числу шагов самого медленного юнита)
            CanStepLand = true;       //ходит ли по земле
            CanStepAqua = true;       //ходит ли по воде

            foreach (var unit in Units)
            {
                //считаем средние следующих величин
                PowerAntiInf += unit.PowerAntiInf;
                PowerAntiAir += unit.PowerAntiAir;
                PowerAntiTank += unit.PowerAntiTank;

                ArmourFromInf += unit.ArmourFromInf;
                ArmourFromTank += unit.ArmourFromTank;

                Experience += unit.Experience;

                //сумма патронов
                Supply += unit.Supply;

                //выбираем минимальный радиус атаки
                if (unit.RadiusAttack < RadiusAttack)
                    RadiusAttack = unit.RadiusAttack;

                //выбираем максимальный обзор
                if (unit.RadiusView > RadiusView)
                    RadiusView = unit.RadiusView;

                //выбираем минимальное число шагов
                if (unit.Steps < Steps)
                    Steps = unit.Steps;

                //если хоть 1 юнит не ходит по земле - никто не ходит
                if (!unit.StepLand)
                    CanStepLand = false;

                //если хоть 1 юнит не плавает - никто не плавает
                if (!unit.StepAqua)
                    CanStepAqua = false;
            }

            //

            PowerAntiInf /= Units.Count;
            PowerAntiAir /= Units.Count;
            PowerAntiTank /= Units.Count;

            ArmourFromInf /= Units.Count;
            ArmourFromTank /= Units.Count;

            Experience /= Units.Count;
        }

        /// <summary>Присоединить подразделение</summary>
        /// <param name="guest">Подразделение, которое присоединяют</param>
        public bool AttachDivision(Division guest)
        {
            // если типы подразделений не совпадают
            if (Type != guest.Type)
                return false;

            // добавить все юниты добавляемого подразделения в новый
            foreach (var unit in guest.Units)
            {
                Units.Add(unit);
            }

            // число шагов нового подразделения = минимуму из числа шагов составных подразделений
            int steps = Math.Min(Steps, guest.Steps);

            // расформировываем добавляемое подразделение
            guest.Destroy();

            // пересчитать показатели нового подразделения
            ResetParams();

            // изменяем число шагов
            Steps = steps;

            return true;
        }

        public void Destroy()
        {
            Player.Divisions.Remove(this);
        }

        // Чинить войска
        // Если нет сломанной техники и раненых - false
        public bool RepairUnits()
        {
            bool res = false;

            foreach (var unit in Units)
            {
                // если есть раненые
                if (unit.Health < 100 && unit.Health > 0)
                {
                    res = true;
                    unit.Repair();
                }
            }

            return res;
        }

        public bool CanStep(CellType cell)
        {
            // если в ячейке вода, а юнит земной
            if (CellType.Water == cell && !CanStepAqua)
                return false;

            // если в ячейке НЕ вода, а юнит водный
            if (CellType.Water != cell && !CanStepLand)
                return false;

            return true;
        }
    }
}

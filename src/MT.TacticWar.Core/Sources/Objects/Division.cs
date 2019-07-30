using System;
using System.Collections.Generic;
using System.Linq;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Objects
{
    public class Division : IObject
    {
        public Player Player { get; protected set; }
        public int Id { get; protected set; }
        public virtual string Type => "Подразделение";
        public string Name { get; protected set; }
        public Coordinates Position { get; set; }
        public List<Unit> Units { get; protected set; }

        public Coordinates Target { get; set; }
        public Building SecuredBuilding { get; set; } //охраняемое здание
        public bool IsSecuring => null != SecuredBuilding;

        public int PowerAntiInf;        //общая мощь против пехоты и артиллерии
        public int PowerAntiTank;       //общая мощь против бронетехники и кораблей
        public int PowerAntiAir;        //общая мощь против воздуха

        public int ArmourFromInf;       //общая защита от пехоты
        public int ArmourFromTank;      //общая защита от любой техники

        public int Supply;              //число патронов и снарядов

        public int RadiusAttack;        //радиус действия (для артиллерии)
        public int RadiusView;          //радиус обзора

        public int Experience;          //опыт

        public int Steps;               //число шагов (равно числу шагов самого медленного юнита)
        public bool CanStepLand { get; private set; }        //ходит ли по земле
        public bool CanStepAqua;        //ходит ли по воде

        public Division(Player player, int id, string name, int x, int y)
        {
            Player = player;
            Id = id;
            Name = name;
            Position = new Coordinates(x, y);
            Units = new List<Unit>();

            Target = Coordinates.Empty;
            SecuredBuilding = null;

            //if (Units.Count > 0)
            //    ResetParams(); // пересчитать показатели
        }

        public void AddUnits(List<Unit> units)
        {
            Units = units;
            if (Units.Count > 0)
                ResetParams(); // пересчитать показатели
        }

        public bool CompareTypes(Division division)
        {
            return GetType() == division.GetType();
        }

        /// <summary>Продвинуть подразделение к цели на этот день</summary>
        /// <param name="way">Путь, по которому продвигать</param>
        public virtual void Move(List<Cell> way)
        {
            if (0 == way.Count)
                return;

            Coordinates last = null;
            var target = way[way.Count - 1].Coordinates;

            foreach (var cell in way)
            {
                last = cell.Coordinates;

                // последнюю ячейку не считем
                if (last.Equals(target))
                    break;

                // если встретили объект
                if (cell.Occupied && !cell.Coordinates.Equals(Position))
                    break;

                // если закончились шаги
                if (Steps < cell.PassCost)
                    break;

                Steps -= cell.PassCost;
            }

            if (null != last)
                Position = last.Copy();
        }

        // Получить часть пути, которую юнит пройдёт за один день
        public List<Cell> GetOneDayWay(List<Cell> wayall)
        {
            int index = GetOneDayIndex(wayall);
            return wayall.GetRange(0, index + 1);
        }

        public virtual int GetOneDayIndex(List<Cell> wayall)
        {
            int curSteps = Steps; // шаги в текущем ходе
            int index = 0;

            for (int i = 0; i < wayall.Count; i++)
            {
                // если юниту не хватает шагов, чтобы пройти по данной ячейке
                if (curSteps < 0)
                    break;

                index = i; // запоминаем ячейку по списку
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
            Target = target.Copy();
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
            if (GetType() == guest.GetType())
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
            if (IsSecuring)
                SecuredBuilding.RemoveSecurity();

            Player.Divisions.Remove(this);
        }

        public void RepairUnits()
        {
            foreach (var unit in Units)
            {
                unit.Repair();
            }
        }

        public void EquipUnits()
        {
            foreach (var unit in Units)
            {
                unit.Equip();
            }
        }

        /// <summary>Может ли пройти по ячейке</summary>
        public virtual bool CanStep(Cell cell)
        {
            // если в ячейке вода, а юнит земной
            if (CellType.Water == cell.Type && !CanStepAqua)
                return false;

            // если в ячейке НЕ вода, а юнит водный
            if (CellType.Water != cell.Type && !CanStepLand)
                return false;

            return true;
        }

        /// <summary>Может ли остановиться в ячейке</summary>
        public virtual bool CanStop(Cell cell)
        {
            return CanStep(cell);
        }

        public virtual bool CanSecure(Building building)
        {
            return true;
        }

        public virtual bool CanCapture(Building building)
        {
            return true;
        }
    }
}

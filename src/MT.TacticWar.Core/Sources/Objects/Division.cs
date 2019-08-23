using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Objects
{
    public abstract class Division : IObject
    {
        public Player Player { get; protected set; }
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public Coordinates Position { get; set; }
        public List<Unit> Units { get; protected set; }

        public Coordinates Target { get; protected set; }
        public Building SecuredBuilding { get; set; }
        public bool IsSecuring => null != SecuredBuilding;

        public int Experience { get; protected set; }
        public int SupplyCurrent { get; protected set; }
        public int StepsCurrent { get; protected set; }
        public string Type => GetDivisionType(GetType());

        public UnitParameters Parameters { get; protected set; }

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

        public void CompleteWithUnits(IEnumerable<Unit> units)
        {
            Units = new List<Unit>(units);
            if (Units.Count > 0)
                ResetParams(true);
        }

        public bool CompareTypes(Division division)
        {
            return GetType() == division.GetType();
        }

        public void NullSteps()
        {
            StepsCurrent = 0;
        }

        // Пересчитать показатели подразделения
        public void ResetParams(bool resetSteps = false)
        {
            int count = Units.Count;

            if (0 == count)
                return;

            int sumExperience = 0;
            int sumSupplyCurrent = 0;

            int minSteps = int.MaxValue;
            int sumSupply = 0;
            int sumCost = 0;

            int minRadiusAttack = int.MaxValue;
            int maxRadiusView = 0;

            int sumPowerAntiInf = 0;
            int sumPowerAntiAir = 0;
            int sumPowerAntiTank = 0;

            int sumArmourFromInf = 0;
            int sumArmourFromTank = 0;
            int sumArmourFromAir = 0;

            bool canStepLand = true;
            bool canStepAqua = true;

            foreach (var unit in Units)
            {
                sumExperience += unit.Experience;
                sumSupplyCurrent += unit.SupplyCurrent;

                if (unit.Parameters.Steps < minSteps)
                    minSteps = unit.Parameters.Steps;

                sumSupply += unit.Parameters.Supply;
                sumCost += unit.Parameters.Cost;

                if (unit.Parameters.RadiusAttack < minRadiusAttack)
                    minRadiusAttack = unit.Parameters.RadiusAttack;

                if (unit.Parameters.RadiusView > maxRadiusView)
                    maxRadiusView = unit.Parameters.RadiusView;

                sumPowerAntiInf += unit.Parameters.PowerAntiInf;
                sumPowerAntiAir += unit.Parameters.PowerAntiAir;
                sumPowerAntiTank += unit.Parameters.PowerAntiTank;

                sumArmourFromInf += unit.Parameters.ArmourFromInf;
                sumArmourFromTank += unit.Parameters.ArmourFromTank;
                sumArmourFromAir += unit.Parameters.ArmourFromAir;

                if (!unit.Parameters.CanStepLand)
                    canStepLand = false;

                if (!unit.Parameters.CanStepAqua)
                    canStepAqua = false;
            }

            // считаем характеристики подразделения

            Experience = sumExperience / count;
            SupplyCurrent = sumSupplyCurrent;

            Parameters = new UnitParameters()
            {
                Steps = minSteps,
                Supply = sumSupply,
                Cost = sumCost,

                RadiusAttack = minRadiusAttack,
                RadiusView = maxRadiusView,

                PowerAntiInf = sumPowerAntiInf / count,
                PowerAntiTank = sumPowerAntiTank / count,
                PowerAntiAir = sumPowerAntiAir / count,

                ArmourFromInf = sumArmourFromInf / count,
                ArmourFromTank = sumArmourFromTank / count,
                ArmourFromAir = sumArmourFromAir / count,

                CanStepLand = canStepLand,
                CanStepAqua = canStepAqua
            };

            if (resetSteps)
                StepsCurrent = minSteps;
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

                int passcost = GetStepCost(cell); //cell.PassCost

                // если закончились шаги
                if (StepsCurrent < passcost)
                    break;

                StepsCurrent -= passcost;
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
            int curSteps = StepsCurrent; // шаги в текущем ходе
            int index = 0;

            for (int i = 0; i < wayall.Count; i++)
            {
                // если юниту не хватает шагов, чтобы пройти по данной ячейке
                if (curSteps < 0)
                    break;

                index = i; // запоминаем ячейку по списку
                curSteps -= GetStepCost(wayall[i]); //wayall[i].PassCost;
            }

            return index;
        }

        public void SetTarget(Coordinates target)
        {
            Target = target.Copy();
        }

        public void RemoveTarget()
        {
            Target = Coordinates.Empty;
        }

        public virtual int GetStepCost(Cell cell)
        {
            int divbonus = int.MaxValue;
            foreach (var unit in Units)
            {
                int bonus = unit.GetStepBonus(cell);
                if (bonus < divbonus)
                    divbonus = bonus;
            }

            return cell.PassCost - divbonus;
        }

        /// <summary>Присоединить подразделение</summary>
        /// <param name="guest">Подразделение, которое присоединяют</param>
        public bool AttachDivision(Division guest)
        {
            // если типы подразделений не совпадают
            if (!CompareTypes(guest))
                return false;

            // добавить все юниты добавляемого подразделения в новый
            foreach (var unit in guest.Units)
            {
                Units.Add(unit);
            }

            // число шагов нового подразделения = минимуму из числа шагов составных подразделений
            int steps = Math.Min(StepsCurrent, guest.StepsCurrent);

            // расформировываем добавляемое подразделение
            guest.Destroy();

            // пересчитать показатели нового подразделения
            ResetParams();

            // изменяем число шагов
            StepsCurrent = steps;

            return true;
        }

        public void Destroy()
        {
            if (IsSecuring)
                SecuredBuilding.RemoveSecurity();

            Player.Divisions.Remove(this);
        }

        /// <summary>Активировать функции юнитов. Например, лечение, построение мостов и т.п.</summary>
        public virtual void Activate(Mission mission)
        {
            foreach (var unit in Units)
                unit.Activate(mission);
        }

        public void RepairUnits(int medkit = Unit.HealthMax)
        {
            foreach (var unit in Units)
            {
                medkit = Math.Min(medkit, Unit.HealthMax - unit.Health);

                if (!Player.CanBuy(medkit))
                    continue;

                unit.Repair(medkit);
                Player.Buy(medkit, $"Лечение юнита {unit} ({unit.Id})");
            }
        }

        public void EquipUnits()
        {
            foreach (var unit in Units)
            {
                int weapon = unit.Parameters.Supply - unit.SupplyCurrent;

                if (!Player.CanBuy(weapon))
                    continue;

                unit.Equip(weapon);
                Player.Buy(weapon, $"Вооружение юнита {unit} ({unit.Id})");
            }
        }

        /// <summary>Может ли пройти по ячейке</summary>
        public virtual bool CanStep(Cell cell)
        {
            // если в ячейке вода, а юнит земной
            if (cell is IWater && Parameters.CanStepAqua)
                return true;

            // если в ячейке НЕ вода, а юнит водный
            if (cell is ILand && Parameters.CanStepLand)
                return true;

            return false;
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

        public bool IsInActiveRange(Coordinates pt)
        {
            int xMin = Position.X - Parameters.RadiusAttack;
            int xMax = Position.X + Parameters.RadiusAttack;
            int yMin = Position.Y - Parameters.RadiusAttack;
            int yMax = Position.Y + Parameters.RadiusAttack;

            return pt.X >= xMin && pt.X <= xMax && pt.Y >= yMin && pt.Y <= yMax;
        }

        //

        public static string GetDivisionType(Type type)
        {
            var attributes = type.GetCustomAttributes(typeof(DivisionAttribute), false);
            var branch = attributes[0] as DivisionAttribute;
            return branch?.Name;
        }

        public static string GetDivisionCode(Type type)
        {
            var attributes = type.GetCustomAttributes(typeof(DivisionAttribute), false);
            var branch = attributes[0] as DivisionAttribute;
            return branch?.Code;
        }

        public static string GetDivisionCode(Division division)
        {
            return GetDivisionCode(division.GetType());
        }
    }
}

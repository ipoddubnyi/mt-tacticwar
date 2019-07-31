using System;
using System.Collections.Generic;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Gameplay.Battles
{
    public class Battle
    {
        private Mission mission;
        private Map map;
        private Random rand;

        public Battle(Mission mission)
        {
            this.mission = mission;
            map = mission.Map;
            rand = new Random(Guid.NewGuid().GetHashCode());
        }

        public BattleResult Run(Division divisionA, Division divisionD, List<Division> supportA, List<Division> supportD)
        {
            // если у нападающего кончатся патроны
            bool none_supply = false;

            var cellA = map[divisionA.Position];
            var cellD = map[divisionD.Position];

            // пока есть юниты в обоих подразделениях
            while (divisionA.Units.Count > 0 && divisionD.Units.Count > 0)
            {
                // прямая атака
                if (Attack(divisionA, divisionD, supportA, cellA, cellD))
                    break;

                // ответная атака
                if (Attack(divisionD, divisionA, supportD, cellD, cellA))
                    break;

                // если у нападающего кончились патроны - он отступает
                divisionA.ResetParams();
                if (divisionA.Supply == 0)
                {
                    none_supply = true;
                    RecedeDivision(divisionA); // отступить
                    break;
                }
            }

            //----------

            // пересчитать показатели поддержки
            for (int i = 0; i < supportA.Count; i++)
                supportA[i].ResetParams();

            // пересчитать показатели поддержки
            for (int i = 0; i < supportD.Count; i++)
                supportD[i].ResetParams();

            var result = BattleResult.Draw;
            if (0 == divisionD.Units.Count)
            {
                divisionD.Destroy();
                result = BattleResult.Win;

                // обнуляем шаги у вступивших в битву
                divisionA.ResetParams();
                divisionA.NullSteps();
            }
            else if (0 == divisionA.Units.Count)
            {
                divisionA.Destroy();
                result = BattleResult.Lose;

                // обнуляем шаги у вступивших в битву
                divisionD.ResetParams();
                divisionD.NullSteps();
            }
            else
            {
                // обнуляем шаги у вступивших в битву
                divisionA.ResetParams();
                divisionA.NullSteps();
                divisionD.ResetParams();
                divisionD.NullSteps();
            }

            // если у нападающего кончились патроны - ничья
            if (none_supply) result = BattleResult.Draw;

            return result;
        }

        private bool Attack(Division division1, Division division2, List<Division> support1, Cell cell1, Cell cell2)
        {
            Unit unit1, unit2;
            bool supportAttack = false;
            Division supportDiv = null;

            // случайно выбираем подразделение
            var indexDiv = rand.Next(0, support1.Count + 1);

            // если это АТАКУЮЩЕЕ подразделение, а не поддержка
            if (0 == indexDiv)
            {
                // случайно выбираем юнита из атакующего подразделения
                int index1 = rand.Next(0, division1.Units.Count);
                unit1 = division1.Units[index1];

                // случайно выбираем юнита из атакуемого подразделения
                int index2 = rand.Next(0, division2.Units.Count);
                unit2 = division2.Units[index2];
            }
            else // если это подразделение ПОДДЕРЖКИ
            {
                supportAttack = true;
                supportDiv = support1[indexDiv - 1];

                // случайно выбираем юнита из выбранного подразделения поддержки
                int index1 = rand.Next(0, supportDiv.Units.Count);
                unit1 = supportDiv.Units[index1];

                // случайно выбираем юнита из атакуемого подразделения
                int index2 = rand.Next(0, division2.Units.Count);
                unit2 = division2.Units[index2];
            }

            // атакуем
            UnitVsUnit(unit1, unit2, cell1, cell2);

            // удалить юнита, если его убили
            if (unit2.Health <= 0)
                division2.Units.Remove(unit2);

            // если погиб
            if (0 == division2.Units.Count)
                return true;

            if (supportAttack)
            {
                // если поддержка не авиа (артиллерия, тяжёлый корабль),
                // ответить не получится
                if (!(supportDiv is IAviation))
                    return false;
            }

            // ответка
            UnitVsUnit(unit2, unit1, cell2, cell1);

            if (supportAttack)
            {
                // удалить юнита, если его убили
                if (unit1.Health <= 0)
                    supportDiv.Units.Remove(unit1);

                // если поддержка уничтожена
                if (0 == supportDiv.Units.Count)
                {
                    support1.Remove(supportDiv);
                    supportDiv.Destroy();
                }
            }
            else
            {
                // удалить юнита, если его убили
                if (unit1.Health <= 0)
                    division1.Units.Remove(unit1);

                // если уничтожен
                if (0 == division1.Units.Count)
                    return true;
            }

            return false;
        }

        // Считаем защиту юнита
        private void UnitVsUnit(Unit unit1, Unit unit2, Cell cell1, Cell cell2)
        {
            // power = power * (rand * (1 - exp) + exp)
            // если опыт 1, power будет максимальным
            // если опыт 0, power будет полностью зависеть от rand

            var power = GetUnitPower(unit1, unit2.Division, cell1);
            var armour = GetUnitArmour(unit2, unit1.Division, cell2);

            // подсчёт повреждения
            var wound = power - armour;
            if (wound < 0) wound = 0;

            // TODO: была ещё такая формула ранения, подумать о ней:
            //if ((wound / (double)unit2.ArmourFromInf) < 1)

            unit1.Supply -= (int)power;
            unit2.Health -= (int)wound;
            if (unit2.Health < 0) unit2.Health = 0;
        }

        private double GetUnitPower(Unit unit, Division enemy, Cell cell)
        {
            // мощь атаки в зависимости от типа противника
            var power = (double)(unit.GetPowerAnti(enemy) + unit.GetPowerBonus(cell));

            // коэффициент опыта
            var exp = unit.Experience / 100.0;

            //определяем мощь атакующего юнита
            power = power * (rand.NextDouble() * (1 - exp) + exp);

            // если у юнита не хватает патронов
            if (unit.Supply < power)
                power = unit.Supply;

            return power;
        }

        private double GetUnitArmour(Unit unit, Division enemy, Cell cell)
        {
            // защита юнита в зависимости от типа противника
            var armour = (double)(unit.GetArmourFrom(enemy) + unit.GetArmourBonus(cell));

            // коэффициент опыта
            var exp = unit.Experience / 100.0;

            // определяем защиту атакуемого юнита
            return armour * (rand.NextDouble() * (1 - exp) + exp);
        }

        /// <summary>Отступить подразделению на ближайшую свободную клетку</summary>
        public void RecedeDivision(Division division)
        {
            var position = division.Position.Copy();
            var positions = new List<Coordinates>();

            // лево
            if (CanRecedeTo(division, position.X - 1, position.Y))
                positions.Add(new Coordinates(position.X - 1, position.Y));

            // верх
            if (CanRecedeTo(division, position.X, position.Y - 1))
                positions.Add(new Coordinates(position.X, position.Y - 1));

            // право
            if (CanRecedeTo(division, position.X + 1, position.Y))
                positions.Add(new Coordinates(position.X + 1, position.Y));

            // вниз
            if (CanRecedeTo(division, position.X, position.Y + 1))
                positions.Add(new Coordinates(position.X, position.Y + 1));

            // TODO: отступать в сторону своих войски или ворот

            // случайно выбираем, куда отступать
            var rand = new Random(Guid.NewGuid().GetHashCode());
            var ind = rand.Next(0, positions.Count);
            division.Position = positions[ind];
        }

        private bool CanRecedeTo(Division division, int x, int y)
        {
            if (map[x, y].Occupied || !map[x, y].Passable)
                return false;

            if (!division.CanStep(map[x, y]))
                return false;

            return true;
        }

    }
}

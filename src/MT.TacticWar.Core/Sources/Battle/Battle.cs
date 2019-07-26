using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Battle
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

        public BattleResult Run(Division div1, Division div2, List<Division> support1, List<Division> support2)
        {
            var rand = new Random(Guid.NewGuid().GetHashCode());

            int elem;
            int indUnit1, indUnit2;

            Unit sui1, sui2;
            bool elem1_none_supl = false; //если у нападающего кончатся патроны

            //пока есть юниты в обоих подразделениях
            while ((div1.Units.Count > 0) && (div2.Units.Count > 0))
            {
                //- ПРЯМАЯ АТАКА -

                //случайно выбираем подразделение
                elem = rand.Next(0, support1.Count);

                //если это АТАКУЮЩЕЕ подразделение атакующего игрока
                if (elem == 0)
                {
                    //случайно выбираем юнита из атакующего подразделения
                    indUnit1 = rand.Next(0, div1.Units.Count);

                    //случайно выбираем юнита из атакуемого подразделения
                    indUnit2 = rand.Next(0, div2.Units.Count);

                    //атакуем
                    sui1 = div1.Units[indUnit1];
                    sui2 = div2.Units[indUnit2];
                    UnitVsUnit(ref sui1, ref sui2);
                    div1.Units[indUnit1] = sui1;
                    div2.Units[indUnit2] = sui2;
                }
                else //если это подразделение ПОДДЕРЖКИ
                {
                    //случайно выбираем юнита из выбранного подразделения поддержки
                    indUnit1 = rand.Next(0, support1[elem - 1].Units.Count);

                    //случайно выбираем юнита из атакуемого подразделения
                    indUnit2 = rand.Next(0, div2.Units.Count);

                    //атакуем
                    sui1 = support1[elem - 1].Units[indUnit1];
                    sui2 = div2.Units[indUnit2];
                    UnitVsUnit(ref sui1, ref sui2);
                    support1[elem - 1].Units[indUnit1] = sui1;
                    div2.Units[indUnit2] = sui2;
                }

                //удалить юнита, если его убили
                if (div2.Units[indUnit2].Health == 0)
                    div2.Units.RemoveAt(indUnit2);

                //если врага убили - конец цикла
                if (div2.Units.Count < 1)
                    break;

                //- ОТВЕТНАЯ АТАКА -

                //случайно выбираем подразделение
                elem = rand.Next(0, support2.Count);

                //если это АТАКУЮЩЕЕ подразделение защищающегося игрока
                if (elem == 0)
                {
                    //случайно выбираем юнита из атакующего подразделения
                    indUnit2 = rand.Next(0, div2.Units.Count);

                    //случайно выбираем юнита из атакуемого подразделения
                    indUnit1 = rand.Next(0, div1.Units.Count);

                    //атакуем
                    sui1 = div2.Units[indUnit2];
                    sui2 = div1.Units[indUnit1];
                    UnitVsUnit(ref sui1, ref sui2);
                    div2.Units[indUnit2] = sui1;
                    div1.Units[indUnit1] = sui2;
                }
                else //если это подразделение ПОДДЕРЖКИ
                {
                    //случайно выбираем юнита из выбранного подразделения поддержки
                    indUnit2 = rand.Next(0, support2[elem - 1].Units.Count);

                    //случайно выбираем юнита из атакуемого подразделения
                    indUnit1 = rand.Next(0, div1.Units.Count);

                    //атакуем
                    sui1 = support2[elem - 1].Units[indUnit2];
                    sui2 = div1.Units[indUnit1];
                    UnitVsUnit(ref sui1, ref sui2);
                    support2[elem - 1].Units[indUnit2] = sui1;
                    div1.Units[indUnit1] = sui2;
                }

                //удалить юнита, если его убили
                if (div1.Units[indUnit1].Health == 0)
                    div1.Units.RemoveAt(indUnit1);

                //если врага убили - конец цикла
                if (div1.Units.Count < 1)
                    break;

                //----------

                //если у нападающего кончились патроны - он отступает
                div1.ResetParams();
                //if (div1.Units[indUnit1].unit.Supply == 0)
                if (div1.Supply == 0)
                {
                    elem1_none_supl = true;
                    RecedeDivision(div1); //отступить
                    break;
                }
            } //конец цикла

            //----------

            //пересчитать показатели поддержки
            for (int i = 0; i < support1.Count; i++)
                support1[i].ResetParams();

            //пересчитать показатели поддержки
            for (int i = 0; i < support2.Count; i++)
                support2[i].ResetParams();

            var result = BattleResult.Draw;
            if (0 == div2.Units.Count)
            {
                div2.Destroy();
                result = BattleResult.Win;

                // обнуляем шаги у вступивших в битву
                div1.ResetParams();
                div1.Steps = 0;
            }
            else if (0 == div1.Units.Count)
            {
                div1.Destroy();
                result = BattleResult.Lose;

                // обнуляем шаги у вступивших в битву
                div2.ResetParams();
                div2.Steps = 0;
            }
            else
            {
                // обнуляем шаги у вступивших в битву
                div1.ResetParams();
                div1.Steps = 0;
                div2.ResetParams();
                div2.Steps = 0;
            }

            //если у нападающего кончились патроны - ничья
            if (elem1_none_supl) result = 0;

            return result;
        }

        // Считаем защиту юнита
        private void UnitVsUnit(ref Unit unit1, ref Unit unit2)
        {
            // power = power * (rand * (1 - exp) + exp)
            // если опыт 1, power будет максимальным
            // если опыт 0, power будет полностью зависеть от rand

            var power = GetUnitPower(unit1, unit2.DivisionType);
            var armour = GetUnitArmour(unit2, unit1.DivisionType);

            // подсчёт повреждения
            var wound = power - armour;
            if (wound < 0) wound = 0;

            // TODO: была ещё такая формула ранения, подумать о ней:
            //if ((wound / (double)unit2.ArmourFromInf) < 1)

            unit1.Supply -= (int)power;
            unit2.Health -= (int)wound;
            if (unit2.Health < 0) unit2.Health = 0;
        }

        private double GetUnitPower(Unit unit, DivisionType enemyType)
        {
            // мощь атаки в зависимости от типа противника
            var power = (double)unit.GetPowerAnti(enemyType);

            // коэффициент опыта
            var exp = unit.Experience / 100.0;

            //определяем мощь атакующего юнита
            power = power * (rand.NextDouble() * (1 - exp) + exp);

            // если у юнита не хватает патронов
            if (unit.Supply < power)
                power = unit.Supply;

            return power;
        }

        private double GetUnitArmour(Unit unit, DivisionType enemyType)
        {
            // защита юнита в зависимости от типа противника
            var armour = (double)unit.GetArmourFrom(enemyType);

            // коэффициент опыта
            var exp = unit.Experience / 100.0;

            // определяем защиту атакуемого юнита
            return armour * (rand.NextDouble() * (1 - exp) + exp);
        }

        /// <summary>Отступить подразделению на ближайшую свободную клетку</summary>
        public void RecedeDivision(Division division)
        {
            var position = division.Position.Clone();
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

            // если вода, а юнит не плавает
            if (map[x, y].Type.Equals(CellType.Water) && !division.CanStepAqua)
                return false;

            // если не вода, а юнит только плавает
            if (!map[x, y].Type.Equals(CellType.Water) && !division.CanStepLand)
                return false;

            return true;
        }

    }
}

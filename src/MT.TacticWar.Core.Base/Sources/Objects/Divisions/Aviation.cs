using System.Collections.Generic;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    [Division("Авиация", Code = "aviation")]
    public class Aviation : Division, IAviation, ISupport
    {
        public Aviation(Player player, int id, string name, int x, int y) :
            base(player, id, name, x, y)
        {
        }

        public override void Move(List<Cell> way)
        {
            if (0 == way.Count)
                return;

            // можно ли добраться за 1 шаг
            var dayIndex = GetOneDayIndex(way);
            if (dayIndex != way.Count - 1)
                return;

            var last = way[dayIndex].Coordinates;
            Position = last.Copy();
            StepsCurrent -= way.Count - 1;
        }

        public override int GetOneDayIndex(List<Cell> wayall)
        {
            int curSteps = StepsCurrent; // шаги в текущем ходе
            int index = 0;

            for (int i = 0; i < wayall.Count; i++)
            {
                // если юниту не хватает шагов, чтобы пройти по данной ячейке
                if (curSteps < 0)
                    break;

                index = i; // запоминаем ячейку по списку
                curSteps -= 1; // в воздухе тип ячейки не имеет значения
            }

            return index;
        }

        public override bool CanStep(Cell cell)
        {
            return true;
        }

        public override bool CanStop(Cell cell)
        {
            if (null != cell.Object)
            {
                if (cell.Object is Building && cell.Object is Airfield)
                {
                    return true; //!(cell.Object as Building).IsSecured;
                }
            }

            return false;
        }

        public override bool CanSecure(Building building)
        {
            return building is Airfield;
        }

        public override bool CanCapture(Building building)
        {
            return building is Airfield;
        }
    }
}

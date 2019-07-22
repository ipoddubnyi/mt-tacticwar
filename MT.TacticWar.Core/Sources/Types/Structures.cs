using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core
{
    #region Для земли и ориентации

    // Направления, с которыми клетка уже имела контакт
    public class Directions
    {
        public bool Left { get; set; }
        public bool Top { get; set; }
        public bool Right { get; set; }
        public bool Bottom { get; set; }

        // Приоритет направления (более выгодное).
        // 1 - лево, 2 - верх, 3 - право, 4 - низ
        public int Priority { get; set; }

        public Directions()
        {
            NullDirections();
            Priority = 0;
        }

        public void NullDirections()
        {
            Left = false;
            Top = false;
            Right = false;
            Bottom = false;
        }
    }

    #endregion

    #region Для юнитов

    //Структура боевых единиц
    public struct StructUnits
    {
        public Unit unit;      //юнит
        public int count;       //число таких юнитов
        //public bool selected;   //выделены ли эти юниты
    }

    #endregion
}

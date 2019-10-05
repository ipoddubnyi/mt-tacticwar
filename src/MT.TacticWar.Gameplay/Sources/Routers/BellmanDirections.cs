
namespace MT.TacticWar.Gameplay.Routers
{
    internal enum Direction
    {
        Left,
        Top,
        Right,
        Bottom
    }

    // Направления, с которыми клетка уже имела контакт
    internal class BellmanDirections
    {
        public bool Left { get; set; }
        public bool Top { get; set; }
        public bool Right { get; set; }
        public bool Bottom { get; set; }

        // Приоритет направления (более выгодное).
        public Direction Priority { get; set; }

        public BellmanDirections()
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
}

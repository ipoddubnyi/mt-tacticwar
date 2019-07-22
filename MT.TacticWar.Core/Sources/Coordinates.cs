using System.Diagnostics;

namespace MT.TacticWar.Core
{
    [DebuggerDisplay("({X}, {Y})")]
    public class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coordinates Clone()
        {
            return new Coordinates(X, Y);
        }

        public bool Equals(Coordinates coord)
        {
            return Equals(coord.X, coord.Y);
        }

        public bool Equals(int x, int y)
        {
            return X == x && Y == y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}


namespace MT.TacticWar.Core
{
    public class Gate
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Gate(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }
    }
}

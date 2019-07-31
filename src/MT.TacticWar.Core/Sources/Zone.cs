
namespace MT.TacticWar.Core
{
    public class Zone
    {
        public int Id { get; private set; }
        public Coordinates[] Points { get; private set; }

        public Zone(int id, Coordinates[] points)
        {
            Id = id;
            Points = points;
        }

        public bool IsInZone(Coordinates pt)
        {
            foreach (var point in Points)
            {
                if (point.Equals(pt))
                    return true;
            }
            return false;
        }
    }
}

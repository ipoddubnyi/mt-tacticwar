using System.Linq;

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

        public bool Include(Coordinates pt)
        {
            foreach (var point in Points)
            {
                if (point.Equals(pt))
                    return true;
            }
            return false;
        }

        public void Add(Coordinates pt)
        {
            if (!Include(pt))
                Points = Points.Append(pt).ToArray();
        }

        public void Remove(Coordinates pt)
        {
            if (Include(pt))
                Points = Points.Where(point => !point.Equals(pt)).ToArray();
        }
    }
}

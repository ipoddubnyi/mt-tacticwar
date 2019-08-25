using System;
using System.Collections.Generic;
using System.Linq;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core
{
    public static class Extensions
    {
        public static Player GetById(this IEnumerable<Player> players, int id)
        {
            foreach (var player in players)
            {
                if (player.Id == id)
                    return player;
            }

            return null;
        }

        public static Division GetById(this IEnumerable<Division> divisions, int id)
        {
            foreach (var div in divisions)
            {
                if (div.Id == id)
                    return div;
            }

            return null;
        }

        public static Division GetAt(this IEnumerable<Division> divisions, Coordinates position)
        {
            foreach (var div in divisions)
            {
                if (div.Position.Equals(position))
                    return div;
            }

            return null;
        }

        public static Building GetById(this IEnumerable<Building> buildings, int id)
        {
            foreach (var bld in buildings)
            {
                if (bld.Id == id)
                    return bld;
            }

            return null;
        }

        public static Building GetAt(this IEnumerable<Building> buildings, Coordinates position)
        {
            foreach (var bld in buildings)
            {
                if (bld.Position.Equals(position))
                    return bld;
            }

            return null;
        }

        public static Unit GetById(this IEnumerable<Unit> units, int id)
        {
            foreach (var unit in units)
            {
                if (unit.Id == id)
                    return unit;
            }

            return null;
        }

        public static Unit GetAt(this IEnumerable<Unit> units, Coordinates position)
        {
            foreach (var unit in units)
            {
                if (unit.Division.Position.Equals(position))
                    return unit;
            }

            return null;
        }

        public static Zone GetById(this IEnumerable<Zone> zones, int id)
        {
            foreach (var zone in zones)
            {
                if (zone.Id == id)
                    return zone;
            }

            return null;
        }

        public static Zone GetAt(this IEnumerable<Zone> zones, Coordinates point)
        {
            foreach (var zone in zones)
            {
                if (zone.Include(point))
                    return zone;
            }

            return null;
        }

        public static IEnumerable<Zone> SetById(this IEnumerable<Zone> zones, Zone zone)
        {
            if (null != zones.GetById(zone.Id))
                zones = zones.Where(zn => zn.Id != zone.Id).ToArray();

            zones = zones.Append(zone);
            var a = zones.ToArray();
            return zones;
        }

        public static IEnumerable<Zone> SortById(this IEnumerable<Zone> zones)
        {
            return zones.OrderBy(z => z.Id);
        }

        public static Gate GetById(this IEnumerable<Gate> gates, int id)
        {
            foreach (var gate in gates)
            {
                if (gate.Id == id)
                    return gate;
            }

            return null;
        }

        public static Gate GetAt(this IEnumerable<Gate> gates, Coordinates point)
        {
            foreach (var gate in gates)
            {
                if (gate.Equals(point))
                    return gate;
            }

            return null;
        }

        public static IEnumerable<Gate> SortById(this IEnumerable<Gate> gates)
        {
            return gates.OrderBy(g => g.Id);
        }
    }
}

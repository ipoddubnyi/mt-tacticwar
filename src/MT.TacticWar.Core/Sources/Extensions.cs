using System;
using System.Collections.Generic;
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
    }
}

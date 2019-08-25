using System;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Utils
{
    public class DivisionСopier
    {
        private readonly Division division;

        public DivisionСopier(Division division)
        {
            this.division = division;
        }

        public Division Copy(Player player, int x, int y)
        {
            return Copy(player, division.Id, division.Name, x, y);
        }

        public Division Copy(Player player, int id, string name, int x, int y)
        {
            var newdivision = Activator.CreateInstance(
                division.GetType(),
                player, id, name, x, y
            ) as Division;

            var units = new Unit[division.Units.Count];
            division.Units.CopyTo(units);

            newdivision.CompleteWithUnits(units);
            newdivision.Player.Divisions.Add(newdivision);
            return newdivision;
        }
    }
}

using System.Collections.Generic;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.UI.Editor
{
    public class DivisionEditor
    {
        private Division division;
        private Player player;
        private int id;
        private string name;

        public Coordinates Position => division.Position;
        public Player Player => player; // division.Player;
        public int Id => id; //division.Id;
        public string Name => name; // division.Name;
        public List<Unit> Units => division.Units;

        public DivisionEditor(Division division)
        {
            this.division = division;
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetDivisionCode()
        {
            return ObjectFactory.GetDivisionCode(division);
        }

        public void Destroy()
        {
            division.Destroy();
        }

        public Division CreateDivision(int x, int y)
        {
            var code = ObjectFactory.GetDivisionCode(division);
            var newdivision = ObjectFactory.CreateDivision(code, Player, Id, Name, x, y);
            var units = new Unit[division.Units.Count];
            division.Units.CopyTo(units);
            newdivision.CompleteWithUnits(units);
            newdivision.Player.Divisions.Add(newdivision);
            return newdivision;
        }

        public static implicit operator Division(DivisionEditor de)
        {
            return de?.division;
        }
    }
}

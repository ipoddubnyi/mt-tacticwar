using System.Collections.Generic;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.UI.Editor
{
    public class BuildingEditor
    {
        private Building building;
        private Player player;
        private int id;
        private string name;

        public Coordinates Position => building.Position;
        public Player Player => player; // division.Player;
        public int Id => id; //division.Id;
        public string Name => name; // division.Name;
        //public List<Unit> Units => division.Units;

        public BuildingEditor(Building building)
        {
            this.building = building;
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
            return ""; // ObjectFactory.GetDivisionCode(division);
        }

        public void Destroy()
        {
            building.Destroy();
        }

        public Building CreateBuilding(int x, int y)
        {
            /*var code = ObjectFactory.GetDivisionCode(division);
            var newdivision = ObjectFactory.CreateDivision(code, Player, Id, Name, x, y);
            var units = new Unit[division.Units.Count];
            division.Units.CopyTo(units);
            newdivision.CompleteWithUnits(units);
            newdivision.Player.Divisions.Add(newdivision);
            return newdivision;*/
            return null;
        }

        public static implicit operator Building(BuildingEditor be)
        {
            return be?.building;
        }
    }
}

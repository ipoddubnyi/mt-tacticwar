using System.Collections.Generic;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.UI.Editor
{
    public class BuildingEditor : IObjectEditor
    {
        private Building building;

        public Coordinates Position => building.Position;
        public string Type => building.Type;
        public Player Player { get; private set; }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DivisionEditor Security { get; set; }

        public BuildingEditor(Building building)
        {
            this.building = building;
            Player = building.Player;
            Id = building.Id;
            Name = building.Name;

            if (building.IsSecured)
                Security = new DivisionEditor(building.SecurityDivision);
        }

        public void SetPlayer(Player player)
        {
            Player = player;
            if (null != Security)
                Security.SetPlayer(player);
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public string GetBuildingCode()
        {
            return ObjectFactory.GetBuildingCode(building);
        }

        public void Destroy()
        {
            building.Destroy();
        }

        public Building CreateBuilding(int x, int y)
        {
            var code = ObjectFactory.GetBuildingCode(building);
            var security = Security?.CreateDivision(x, y);
            var newbuilding = ObjectFactory.CreateBuilding(
                code, Player, Id, Name, x, y, building.Health, security
            );
            if (null != security)
                newbuilding.Player.Divisions.Add(security);
            newbuilding.Player.Buildings.Add(newbuilding);
            return newbuilding;
        }

        public static implicit operator Building(BuildingEditor be)
        {
            return be?.building;
        }
    }
}

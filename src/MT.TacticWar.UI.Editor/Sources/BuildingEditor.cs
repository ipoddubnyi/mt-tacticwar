﻿using System.Collections.Generic;
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
        private Player player;
        public Player Player
        {
            get => player;
            set
            {
                player = value;
                if (null != Security)
                    Security.Player = player;
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
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

        public string GetBuildingCode()
        {
            return Building.GetBuildingCode(building);
        }

        public void Destroy()
        {
            building.Destroy();
        }

        public Building CreateBuilding(int x, int y)
        {
            var code = Building.GetBuildingCode(building);
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

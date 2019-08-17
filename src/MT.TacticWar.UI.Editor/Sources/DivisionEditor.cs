﻿using System.Collections.Generic;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.UI.Editor
{
    public class DivisionEditor : IObjectEditor
    {
        private Division division;

        public Coordinates Position => division.Position;
        public string Type => division.Type;
        public Player Player { get; private set; }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Unit> Units => division.Units;

        public DivisionEditor(Division division)
        {
            this.division = division;
            Player = division.Player;
            Id = division.Id;
            Name = division.Name;
        }

        public void SetPlayer(Player player)
        {
            Player = player;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public void SetName(string name)
        {
            Name = name;
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

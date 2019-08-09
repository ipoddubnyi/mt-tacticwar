﻿using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core
{
    public class Mission
    {
        public string Name { get; private set; }
        public string Briefing { get; private set; }
        public Player[] Players { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public int Cycles { get; private set; }
        public Zone[] Zones { get; private set; }
        public Script[] Scripts { get; private set; }
        public Map Map { get; private set; }
        public List<ISituation> Situations { get; private set; }

        public Mission(string name, string briefing, Player[] players, Map map) :
            this(name, briefing, players, new Zone[0], new Script[0], map)
        {
        }

        public Mission(string name, string briefing, Player[] players, Zone[] zones, Script[] scripts, Map map)
        {
            if (0 == players.Length)
                throw new Exception("В миссии должны быть игроки.");

            Name = name;
            Briefing = briefing;
            Players = players;
            CurrentPlayer = Players[0];
            Cycles = 0;
            Zones = zones;
            Scripts = scripts;
            Map = map;
            Situations = new List<ISituation>();

            Map.OccupateCells(Players);
        }

        public Player NextPlayer()
        {
            for (int i = 0; i < Players.Length; ++i)
            {
                if (Players[i] == CurrentPlayer)
                {
                    if (i == Players.Length - 1)
                    {
                        CurrentPlayer = Players[0];
                        Cycles += 1;
                    }
                    else
                    {
                        CurrentPlayer = Players[i + 1];
                    }

                    if (!CurrentPlayer.IsNeutral)
                        break;
                }
            }

            return CurrentPlayer;
        }

        public Division GetDivisionAt(Coordinates pt)
        {
            return GetDivisionAt(pt.X, pt.Y);
        }

        public Division GetDivisionAt(int x, int y)
        {
            foreach (var player in Players)
            {
                var division = player.GetDivisionAt(x, y);

                if (null != division)
                    return division;
            }

            return null;
        }

        public Building GetBuildingAt(Coordinates pt)
        {
            return GetBuildingAt(pt.X, pt.Y);
        }

        public Building GetBuildingAt(int x, int y)
        {
            foreach (var player in Players)
            {
                var building = player.GetBuildingAt(x, y);

                if (null != building)
                    return building;
            }

            return null;
        }

        public IObject GetObjectAt(Coordinates pt, Player playerExclude)
        {
            foreach (var player in Players)
            {
                if (player == playerExclude)
                    continue;

                var division = player.GetDivisionAt(pt.X, pt.Y);
                if (null != division)
                    return division;

                var building = player.GetBuildingAt(pt.X, pt.Y);
                if (null != building)
                    return building;
            }

            return null;
        }

        public void ExecuteScripts()
        {
            Situations.Clear();

            foreach (var script in Scripts)
            {
                if (script.Condition.Check(this))
                    Situations.Add(script.Statement.Execute(this));
            }
        }
    }
}

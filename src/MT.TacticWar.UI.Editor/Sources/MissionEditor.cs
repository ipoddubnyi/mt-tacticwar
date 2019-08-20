﻿using MT.TacticWar.Core;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.UI.Editor
{
    public class MissionEditor : Mission
    {
        public MissionEditor(string name, string briefing, Player[] players, Map map) : 
            base(name, briefing, players, map)
        {
        }

        public MissionEditor(Mission mission) :
            base(mission.Name, mission.Briefing, mission.Players, mission.Zones, mission.Scripts, mission.Map)
        {
        }

        public void SetPlayers(Player[] players)
        {
            Players = players;
        }

        public void SetScripts(Script[] scripts)
        {
            Scripts = scripts;
        }
    }
}
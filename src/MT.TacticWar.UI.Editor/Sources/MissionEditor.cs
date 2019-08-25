using System.Collections.Generic;
using System.Linq;
using MT.TacticWar.Core;
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
            base(mission.Name, mission.Briefing, mission.Players, mission.Zones, mission.Reinforcement, mission.Scripts, mission.Map)
        {
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetBriefing(string briefing)
        {
            Briefing = briefing;
        }

        public void SetPlayers(Player[] players)
        {
            Players = players;
        }

        public void SetScripts(Script[] scripts)
        {
            Scripts = scripts;
        }

        public void SetZones(IEnumerable<Zone> zones)
        {
            Zones = zones.ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Landscape;

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
    }
}

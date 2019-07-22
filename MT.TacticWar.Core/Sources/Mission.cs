using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Types;

namespace MT.TacticWar.Core
{
    public class Mission
    {
        public string Name { get; private set; }
        public string Briefing { get; private set; }
        public MissionMode Mode { get; private set; }

        public Map Map { get; set; }

        public Player[] Players { get; set; }

        private MissionManage manage;

        public Mission(string name, string briefing, MissionMode mode, Player[] players, Map map)
        {
            Name = name;
            Briefing = briefing;
            Mode = mode;
            Players = players;
            Map = map;

            Map.OccupateCells(Players);
        }
    }
}

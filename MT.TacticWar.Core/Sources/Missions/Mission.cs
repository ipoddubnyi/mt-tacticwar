using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

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

        public IObject GetObjectAt(Coordinates pt, int playerExclude)
        {
            foreach (var player in Players)
            {
                if (player.Id == playerExclude)
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
    }
}

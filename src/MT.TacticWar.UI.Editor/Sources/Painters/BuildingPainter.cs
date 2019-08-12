using MT.TacticWar.Core.Landscape;
using MT.TacticWar.UI.Graphics;

namespace MT.TacticWar.UI.Editor.Painters
{
    class BuildingPainter : IPainter
    {
        private readonly GameGraphics graphics;
        private readonly Map map;
        private readonly BuildingEditor building;

        private int x;
        private int y;

        public BuildingPainter(GameGraphics graphics, Map map, BuildingEditor building)
        {
            Stop();
            this.graphics = graphics;
            this.map = map;
            this.building = building;
        }

        public void Start(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Stop()
        {
            x = -1;
            y = -1;
        }

        public bool IsActive()
        {
            return false;
        }

        public bool TryMove(int x, int y)
        {
            if (this.x != x || this.y != y)
            {
                this.x = x;
                this.y = y;
                return true;
            }

            return false;
        }

        public void Paint()
        {
            var newbuilding = building.CreateBuilding(x, y);

            // если на этом месте есть юнит - стереть его
            if (map[x, y].Occupied)
                map[x, y].Object.Destroy();

            map.OccupateCell(newbuilding);
            graphics.DrawBuilding(newbuilding, false);
        }
    }
}

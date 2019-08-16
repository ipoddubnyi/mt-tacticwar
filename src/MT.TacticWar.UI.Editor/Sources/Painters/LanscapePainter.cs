using MT.TacticWar.Core.Base.Landscape;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.UI.Graphics;

namespace MT.TacticWar.UI.Editor.Painters
{
    class LanscapePainter : IPainter
    {
        private readonly GameGraphics graphics;
        private readonly Map map;
        private readonly Schema schema;
        private readonly char celltype;

        private bool active; // непрерывное рисование
        private int x;
        private int y;

        public LanscapePainter(GameGraphics graphics, Map map, Schema schema, char cellcode)
        {
            Stop();
            this.graphics = graphics;
            this.map = map;
            this.schema = schema;
            this.celltype = cellcode;
        }

        public void Start(int x, int y)
        {
            this.x = x;
            this.y = y;
            active = true;
        }

        public void Stop()
        {
            active = false;
            x = -1;
            y = -1;
        }

        public bool IsActive()
        {
            return active;
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
            var cell = LandscapeFactory.CreateCell(schema, celltype, x, y);

            if (map[x, y].Occupied)
            {
                var obj = map[x, y].Object;
                map.SetCell(x, y, cell);
                map.OccupateCell(obj);

                graphics.DrawCell(cell);
                if (obj is Building)
                    graphics.DrawBuilding(obj as Building, false);
                else if (obj is Division)
                    graphics.DrawDivision(obj as Division, false);
            }
            else
            {
                map.SetCell(x, y, cell);
                graphics.DrawCell(cell);
            }
        }
    }
}

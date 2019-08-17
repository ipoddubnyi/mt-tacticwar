using MT.TacticWar.Core.Landscape;
using MT.TacticWar.UI.Graphics;

namespace MT.TacticWar.UI.Editor.Painters
{
    class DivisionPainter : IPainter
    {
        private readonly GameGraphics graphics;
        private readonly Map map;
        public DivisionEditor Division { get; private set; }

        private int x;
        private int y;

        public DivisionPainter(GameGraphics graphics, Map map, DivisionEditor division)
        {
            Stop();
            this.graphics = graphics;
            this.map = map;
            Division = division;
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
            var newdivision = Division.CreateDivision(x, y);

            // если на этом месте есть юнит - стереть его
            if (map[x, y].Occupied)
            {
                map[x, y].Object.Destroy();
                graphics.DrawCell(map[x, y]);
            }

            map.OccupateCell(newdivision);
            graphics.DrawDivision(newdivision, false);
        }
    }
}

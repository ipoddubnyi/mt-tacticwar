using MT.TacticWar.Core;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.UI.Graphics;

namespace MT.TacticWar.UI.Editor.Painters
{
    class DivisionPainter : IPainter
    {
        private readonly GameGraphics graphics;
        private readonly Map map;
        private readonly Division division;
        private readonly Player player;
        private readonly int id;
        private readonly string name;

        private int x;
        private int y;

        public DivisionPainter(GameGraphics graphics, Map map, Division division, Player player, int id, string name)
        {
            Stop();
            this.graphics = graphics;
            this.map = map;
            this.division = division;
            this.player = player;
            this.id = id;
            this.name = name;
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
            var code = ObjectFactory.GetDivisionCode(division);
            var newdivision = ObjectFactory.CreateDivision(code, player, id, name, x, y);
            var units = new Unit[division.Units.Count];
            division.Units.CopyTo(units);
            newdivision.CompleteWithUnits(units);

            // если на этом месте есть юнит - стереть его
            if (map[x, y].Occupied)
                map[x, y].Object.Destroy();

            player.Divisions.Add(newdivision);
            map.OccupateCell(newdivision);
            graphics.DrawDivision(newdivision, false);
        }
    }
}

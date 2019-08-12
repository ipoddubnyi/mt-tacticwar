using System;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.UI.Graphics;

namespace MT.TacticWar.UI.Editor.Painters
{
    class PassabilityPainter : IPainter
    {
        private readonly GameGraphics graphics;
        private readonly Map map;
        private readonly bool passable;

        private bool active; // непрерывное рисование
        private int x;
        private int y;

        public PassabilityPainter(GameGraphics graphics, Map map, bool passable)
        {
            Stop();
            this.graphics = graphics;
            this.map = map;
            this.passable = passable;
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
            if (passable)
            {
                map[x, y].Passable = true;
                graphics.DrawCell(map[x, y]);
            }
            else
            {
                map[x, y].Passable = false;
                graphics.DrawCross(new Coordinates(x, y));
            }
        }
    }
}

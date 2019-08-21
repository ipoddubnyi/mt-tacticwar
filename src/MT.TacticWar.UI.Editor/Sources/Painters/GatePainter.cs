using MT.TacticWar.Core;
using MT.TacticWar.UI.Graphics;

namespace MT.TacticWar.UI.Editor.Painters
{
    class GatePainter : IPainter
    {
        private readonly GameGraphics graphics;
        private readonly MissionEditor mission;
        private Player player;
        private int gateId;
        private bool clear;

        private int x;
        private int y;

        public GatePainter(GameGraphics graphics, MissionEditor mission, Player player, int gateId, bool clear = false)
        {
            Stop();
            this.graphics = graphics;
            this.mission = mission;
            this.player = player;
            this.gateId = gateId;
            this.clear = clear;
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
            if (clear)
            {
                PaintClear();
                graphics.DrawCell(mission.Map[x, y]);
            }
            else
            {
                PaintClear();
                PaintAdd();
                graphics.DrawGate(gateId, x, y);
            }
        }

        private void PaintClear()
        {
            var point = new Coordinates(x, y);
            foreach (var player in mission.Players)
            {
                var old = player.Gates.GetAt(point);
                if (null != old)
                {
                    player.Gates.Remove(old);
                    break;
                }
            }
        }

        private void PaintAdd()
        {
            var old = player.Gates.GetById(gateId);
            if (null != old)
            {
                player.Gates.Remove(old);
                graphics.DrawCell(mission.Map[old.X, old.Y]);
            }

            var gate = new Gate(gateId, x, y);
            player.Gates.Add(gate);
        }
    }
}

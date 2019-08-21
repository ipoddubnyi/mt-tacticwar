using MT.TacticWar.Core;
using MT.TacticWar.UI.Graphics;
using System.Collections.Generic;

namespace MT.TacticWar.UI.Editor.Painters
{
    class ZonePainter : IPainter
    {
        private readonly GameGraphics graphics;
        private readonly MissionEditor mission;
        public int ZoneId { get; private set; }
        private bool clear;
        private Zone zone;

        private int x;
        private int y;

        public ZonePainter(GameGraphics graphics, MissionEditor mission, int zoneId, bool clear = false)
        {
            Stop();
            this.graphics = graphics;
            this.mission = mission;
            ZoneId = zoneId;
            this.clear = clear;

            zone = mission.Zones.GetById(ZoneId);
            if (null == zone)
                zone = new Zone(ZoneId, new Coordinates[0]);
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
                graphics.DrawZone(ZoneId, x, y);
            }
        }

        private void PaintClear()
        {
            var point = new Coordinates(x, y);
            var old = mission.Zones.GetAt(point);
            if (null != old)
            {
                old.Remove(point);
                mission.SetZones(mission.Zones.SetById(old));
            }
        }

        private void PaintAdd()
        {
            zone.Add(new Coordinates(x, y));
            mission.SetZones(mission.Zones.SetById(zone));
        }
    }
}

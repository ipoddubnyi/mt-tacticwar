﻿using System.Collections.Generic;
using MT.TacticWar.Core;
using MT.TacticWar.UI.Graphics;

namespace MT.TacticWar.UI.Editor.Painters
{
    class ZonePainter : IPainter
    {
        private readonly GameGraphics graphics;
        private readonly MissionEditor mission;
        private int zoneId;
        private bool clear;
        private Zone zone;

        private bool active; // непрерывное рисование
        private int x;
        private int y;

        public ZonePainter(GameGraphics graphics, MissionEditor mission, int zoneId, bool clear = false)
        {
            Stop();
            this.graphics = graphics;
            this.mission = mission;
            this.zoneId = zoneId;
            this.clear = clear;

            zone = mission.Zones.GetById(this.zoneId);
            if (null == zone)
                zone = new Zone(this.zoneId, new Coordinates[0]);
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
            if (clear)
            {
                PaintClear();
                graphics.DrawCell(mission.Map[x, y]);
            }
            else
            {
                PaintClear();
                PaintAdd();
                graphics.DrawZone(zoneId, x, y);
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

using System;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Base.Landscape;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.UI.Graphics;

namespace MT.TacticWar.UI.Editor
{
    /// <summary>Рисовальщик ландшафта.</summary>
    class LanscapePainter
    {
        int mode = 0;
        bool passable;

        private readonly string schema;
        private readonly Map map;
        private readonly GameGraphics graphics;

        private bool set;       // рисовать, если установлен тип ячейки
        private bool active;    // пока активен, рисует непрерывно
        private char cellType;  // рисует ячейку данного типа
        private int cellX;      // рисует ячейку с данными координатами
        private int cellY;

        public LanscapePainter(string schema, Map map, GameGraphics graphics)
        {
            Stop();
            Reset();
            this.schema = schema;
            this.map = map;
            this.graphics = graphics;
        }

        public void SetModeLandscape(char type)
        {
            mode = 0;
            cellType = type;
            set = true;
        }

        public void SetModePassable(bool passable)
        {
            mode = 1;
            this.passable = passable;
            set = true;
        }

        public void Reset()
        {
            set = false;
        }

        public bool IsSet()
        {
            return set;
        }

        public void Start(int x, int y)
        {
            cellX = x;
            cellY = y;
            active = true;
        }

        public void Stop()
        {
            active = false;
            cellX = -1;
            cellY = -1;
        }

        public bool IsActive()
        {
            return active;
        }

        /// <returns>Изменились ли координаты.</returns>
        public bool TryMove(int x, int y)
        {
            if (cellX != x || cellY != y)
            {
                cellX = x;
                cellY = y;
                return true;
            }

            return false;
        }

        public void Paint()
        {
            if (1 == mode)
                PaintCross();
            else
                PaintLanscape();
        }

        private void PaintLanscape()
        {
            var cell = LandscapeFactory.CreateCell(schema, cellType, cellX, cellY);
            map.SetCell(cellX, cellY, cell);
            graphics.DrawCell(cell);
        }

        private void PaintCross()
        {
            if (passable)
            {
                map[cellX, cellY].Passable = true;
                graphics.DrawCell(map[cellX, cellY]);
            }
            else
            {
                map[cellX, cellY].Passable = false;
                graphics.DrawCross(new Coordinates(cellX, cellY));
            }
        }
    }
}

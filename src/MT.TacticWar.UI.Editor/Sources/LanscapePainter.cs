using MT.TacticWar.Core.Base.Landscape;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.UI.Graphics;

namespace MT.TacticWar.UI.Editor
{
    /// <summary>Рисовальщик ландшафта.</summary>
    class LanscapePainter
    {
        private readonly string schema;
        private readonly Map map;
        private readonly GameGraphics graphics;

        private bool active;    // пока активен, рисует непрерывно
        private char cellType;  // рисует ячейку данного типа
        private int cellX;      // рисует ячейку с данными координатами
        private int cellY;

        public LanscapePainter(string schema, Map map, GameGraphics graphics)
        {
            Stop();
            this.schema = schema;
            this.map = map;
            this.graphics = graphics;
        }

        public void Start(char type, int x, int y)
        {
            cellType = type;
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
            var cell = LandscapeFactory.CreateCell(schema, cellType, cellX, cellY);
            map.SetCell(cellX, cellY, cell);
            graphics.DrawCell(cell);
        }
    }
}

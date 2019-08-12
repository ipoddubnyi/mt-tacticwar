using MT.TacticWar.Core.Base.Landscape;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.UI.Editor
{
    public class MapEditor : Map
    {
        public string Schema { get; private set; }

        public MapEditor(string name, int width, int height, string schema) :
            base(name, width, height)
        {
            Schema = schema;
            InitCells();
        }

        public MapEditor(Map map, string schema) :
            base(map.Name, map.Width, map.Height, map.Field)
        {
            Schema = schema;
        }

        public void InitCells()
        {
            Field = new Cell[Width, Height];
            for (int y = 0; y < Height; ++y)
                for (int x = 0; x < Width; ++x)
                    Field[x, y] = LandscapeFactory.CreateCell(Schema, '-', x, y);
        }
    }
}

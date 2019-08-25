using MT.TacticWar.Core;
using MT.TacticWar.Core.Base.Landscape;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.UI.Editor
{
    public class MapEditor : Map
    {
        //public string Schema { get; private set; }

        public MapEditor(string name, string descr, int width, int height, string schema) :
            base(name, descr, width, height, LandscapeFactory.CreateSchema(schema))
        {
            Field = new Cell[Width, Height];
            for (int y = 0; y < Height; ++y)
                for (int x = 0; x < Width; ++x)
                    Field[x, y] = LandscapeFactory.CreateCell(Schema, '-', x, y);
        }

        public MapEditor(Map map) :
            base(map.Name, map.Description, map.Width, map.Height, map.Schema, map.Field)
        {
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }
    }
}

using MT.TacticWar.Core;

namespace MT.TacticWar.UI.Editor
{
    public interface IObjectEditor
    {
        Player Player { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        Coordinates Position { get; }

        void Destroy();
    }
}

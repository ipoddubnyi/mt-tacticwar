using MT.TacticWar.Core;

namespace MT.TacticWar.UI.Editor
{
    public interface IObjectEditor
    {
        string Name { get; }
        Coordinates Position { get; }

        void SetPlayer(Player player);
        void SetId(int id);
        void SetName(string name);
        void Destroy();
    }
}

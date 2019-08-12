
namespace MT.TacticWar.Core.Objects
{
    public interface IObject
    {
        int Id { get; }
        Coordinates Position { get; }
        void Destroy();
    }
}

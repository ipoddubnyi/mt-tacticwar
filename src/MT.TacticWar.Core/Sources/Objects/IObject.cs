
namespace MT.TacticWar.Core.Objects
{
    public interface IObject
    {
        /*int Id;
        string Name;
        int PlayerId;
        int Health;*/

        int Id { get; }

        Coordinates Position { get; set; }
    }
}

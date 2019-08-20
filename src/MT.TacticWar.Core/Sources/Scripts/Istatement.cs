
namespace MT.TacticWar.Core.Scripts
{
    public interface IStatement
    {
        ISituation Execute(Mission mission);
    }
}


namespace MT.TacticWar.Core.Types.Mission
{
    /// <summary>
    /// Состояние игры.
    /// </summary>
    public enum MissionStatus
    {
        InProgress,         // игра ещё не окончена
        MissionComplete,    // победа игрока 1, поражение игрока 2
        MissionFailed,      // поражение игрока 1, победа игрока 2
        MissionDraw         // ничья
    }
}

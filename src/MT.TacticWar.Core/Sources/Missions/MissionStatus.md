
namespace MT.TacticWar.Core
{
    /// <summary>
    /// Состояние игры.
    /// </summary>
    public enum MissionStatus
    {
        /// <summary>
        /// Игра ещё не окончена
        /// </summary>
        InProgress,

        /// <summary>
        /// Победа игрока 1, поражение игрока 2
        /// </summary>
        MissionComplete,

        /// <summary>
        /// Поражение игрока 1, победа игрока 2
        /// </summary>
        MissionFailed,

        /// <summary>
        /// Ничья
        /// </summary>
        MissionDraw
    }
}

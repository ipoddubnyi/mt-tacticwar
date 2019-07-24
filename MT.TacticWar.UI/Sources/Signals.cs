
namespace MT.TacticWar.UI
{
    /// <summary>
    /// Сигналы для обмена графики и симулятора.
    /// </summary>
    public enum Signals
    {
        /// <summary>
        /// Без информации.
        /// </summary>
        NONE = 0,

        /// <summary>
        /// Всё хорошо.
        /// </summary>
        SUCCESS = 1,

        /// <summary>
        /// Всё плохо.
        /// </summary>
        FAILURE = 2,

        /// <summary>
        /// Информация о юнитах готова.
        /// </summary>
        READY_UNIT_INFO = 3,

        /// <summary>
        /// Атака юнитов, их индексы в структуре.
        /// </summary>
        ATTACK = 4,

        /// <summary>
        /// Индексы вне границ массива.
        /// </summary>
        OUT_OF_RANGE = 5
    }
}


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
        s00_NONE,

        /// <summary>
        /// Всё хорошо.
        /// </summary>
        s01_ALL_IS_GD,

        /// <summary>
        /// Всё плохо.
        /// </summary>
        s02_ALL_IS_BD,

        /// <summary>
        /// Информация о юнитах готова.
        /// </summary>
        s03_READY_UNIT_INFO,

        /// <summary>
        /// Атака юнитов, их индексы в структуре.
        /// </summary>
        s04_ATTACK,

        /// <summary>
        /// Индексы вне границ массива.
        /// </summary>
        s05_OUT_OF_RANGE
    }
}

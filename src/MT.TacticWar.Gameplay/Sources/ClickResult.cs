
namespace MT.TacticWar.Gameplay
{
    enum ClickResult
    {
        /// <summary>
        /// Передать информацию о выделенном юните.
        /// </summary>
        Select = 1,

        /// <summary>
        /// Поставить флаг, просчитать путь.
        /// </summary>
        FindWay = 2,

        /// <summary>
        /// Продвинуть выделенный юнит к данному.
        /// </summary>
        Move = 3
    }
}


namespace MT.TacticWar.Core.Objects
{
    /// <summary>
    /// Уровни повышений подразделений.
    /// </summary>
    public enum UnitLevel
    {
        /// <summary>
        /// Без уровня.
        /// </summary>
        None,

        /// <summary>
        /// Новобранец (изначально у подразделений).
        /// </summary>
        Recruit,

        /// <summary>
        /// Воин (после первого боя).
        /// </summary>
        Warrior,

        /// <summary>
        /// Ветеран (после нескольких боёв).
        /// </summary>
        Veteran,

        /// <summary>
        /// Герой.
        /// </summary>
        Hero
    }
}

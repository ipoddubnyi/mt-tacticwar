
namespace MT.TacticWar.Core.Objects
{
    public enum BuildingType
    {
        /// <summary>
        /// Завод (ремонт техники, постройка новой).
        /// </summary>
        Factory,

        /// <summary>
        /// Призывной пункт, казарма, госпиталь (доукомплектование пехотой).
        /// </summary>
        Barracks,

        /// <summary>
        /// Склад (вооружение, продовольствие).
        /// </summary>
        Storehouse,

        /// <summary>
        /// Радар (увеличивает обзор за счёт большого радиуса обзора).
        /// </summary>
        Radar,

        /// <summary>
        /// Аэродром (для поддержки авиации).
        /// </summary>
        Airfield,

        /// <summary>
        /// Порт (для поддержки кораблей).
        /// </summary>
        Port
    }
}

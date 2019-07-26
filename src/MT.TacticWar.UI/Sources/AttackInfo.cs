using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.UI
{
    // Структура с информацией об атаке
    public struct AttackInfo
    {
        public Division DivisionAttacker { get; set; }
        public Division DivisionDefender { get; set; }
        public Building BuildingToCapture { get; set; }
    }
}

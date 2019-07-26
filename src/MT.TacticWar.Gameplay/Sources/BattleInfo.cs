using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Gameplay
{
    // Структура с информацией о битве
    public struct BattleInfo
    {
        public Division DivisionAttacker { get; set; }
        public Division DivisionDefender { get; set; }
        public Building BuildingToCapture { get; set; }
    }
}

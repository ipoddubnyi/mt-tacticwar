using System.Collections.Generic;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Gameplay
{
    // Структура с информацией о битве
    public struct BattleInfo
    {
        public Division DivisionAttacker { get; set; }
        public Division DivisionDefender { get; set; }
        public List<Division> SupportDivisionsAttacker { get; set; }
        public List<Division> SupportDivisionsDefender { get; set; }
        public Building BuildingToCapture { get; set; }
    }
}

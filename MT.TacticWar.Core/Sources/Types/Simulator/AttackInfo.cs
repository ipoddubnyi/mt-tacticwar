
namespace MT.TacticWar.Core.Types
{
    // Структура с информацией об атаке
    public struct AttackInfo
    {
        public int PlayerAttacked;   //ид атакующего игрока
        public int PlayerDefended;   //ид атакуемого игрока

        public int DivisionAttacked;    //ид атакующего юнита
        public int DivisionDefended;    //ид атакуемого юнита
    }
}

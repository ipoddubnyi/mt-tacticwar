
namespace MT.TacticWar.Core.Types.Simulator
{
    // Структура с информацией об атаке
    public struct AttackInfo
    {
        public int igrokAttacked;   //ид атакующего игрока
        public int igrokDefended;   //ид атакуемого игрока

        public int elemAttacked;    //ид атакующего юнита
        public int elemDefended;    //ид атакуемого юнита
    }
}

using System;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    public struct DivisionVariant
    {
        public string Code;
        public Type Type;

        public Division Create(Player player, int id, string name, int x, int y)
        {
            return (Division)Activator.CreateInstance(Type, player, id, name, x, y);
        }

        public override string ToString()
        {
            return Division.GetBranchName(Type);
        }
    }
}

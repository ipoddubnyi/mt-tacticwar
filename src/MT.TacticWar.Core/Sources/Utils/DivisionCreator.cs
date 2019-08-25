using System;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Utils
{
    public class DivisionCreator
    {
        public Type Type;

        public DivisionCreator(Type type)
        {
            Type = type;
        }

        public Division Create(Player player, int id, string name, int x, int y)
        {
            return (Division)Activator.CreateInstance(Type, player, id, name, x, y);
        }

        public string GetCode()
        {
            return Division.GetDivisionCode(Type);
        }

        public override string ToString()
        {
            return Division.GetDivisionType(Type);
        }
    }
}

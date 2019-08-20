using System;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    public struct BuildingVariant
    {
        public string Code;
        public Type Type;

        public Building Create(Player player, int id, string name, int x, int y, int health, Division security)
        {
            return (Building)Activator.CreateInstance(Type, player, id, name, x, y, health, security);
        }

        public override string ToString()
        {
            return Building.GetBuildingType(Type);
        }
    }
}

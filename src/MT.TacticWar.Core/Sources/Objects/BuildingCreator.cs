using System;

namespace MT.TacticWar.Core.Objects
{
    public class BuildingCreator
    {
        public Type Type;

        public BuildingCreator(Type type)
        {
            Type = type;
        }

        public Building Create(Player player, int id, string name, int x, int y, int health, Division security)
        {
            return (Building)Activator.CreateInstance(Type, player, id, name, x, y, health, security);
        }

        public string GetCode()
        {
            return Building.GetBuildingCode(Type);
        }

        public override string ToString()
        {
            return Building.GetBuildingType(Type);
        }
    }
}

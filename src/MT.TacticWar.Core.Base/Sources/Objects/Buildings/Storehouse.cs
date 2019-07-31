﻿using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    public class Storehouse : Building
    {
        private const int MaxRadiusActive = 0;
        private const int MaxRadiusView = 1;

        public override string Type => "Склад";

        public Storehouse(Player player, int id, string name, int x, int y, int health, Division security) :
            base(player, id, name, x, y, health, MaxRadiusActive, MaxRadiusView, security)
        {
        }

        public override void Activate(Mission mission)
        {
            var area = mission.Map.GetArea(Position, RadiusActive);
            foreach (var pt in area)
            {
                var division = Player.Divisions.GetAt(pt);
                if (null != division)
                {
                    // TODO: ограничить количество припасов на складе
                    division.EquipUnits();
                }
            }
        }
    }
}
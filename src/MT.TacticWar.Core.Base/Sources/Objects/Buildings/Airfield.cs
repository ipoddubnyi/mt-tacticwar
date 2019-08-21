using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    [Building("Аэродром", Code = "airfield")]
    public class Airfield : Building
    {
        private const int MaxRadiusActive = 0;
        private const int MaxRadiusView = 1;

        public Airfield(Player player, int id, string name, int x, int y, int health, Division security) :
            base(player, id, name, x, y, health, MaxRadiusActive, MaxRadiusView, security)
        {
        }

        public override void Activate(Mission mission)
        {
            var area = mission.Map.GetArea(Position, RadiusActive);
            foreach (var pt in area)
            {
                var division = Player.Divisions.GetAt(pt);
                if (null != division && division is Aviation)
                {
                    division.RepairUnits();
                    division.EquipUnits();
                }
            }
        }
    }
}

using MT.TacticWar.Core.Base.Landscape.Summer;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    [Unit("Асфальтоукладчик", typeof(Engineers), Code = "asphaltbuilder")]
    public class RoadBuilder : Unit
    {
        private const int AsphaltCost = 200;

        public RoadBuilder(int id, Division division, string name = null,
            int experience = ExperienceRecruit, int health = HealthMax, int? supply = null) :
            base(id, division, name, experience, health, supply)
        {
            Parameters = new UnitParameters()
            {
                Steps = 6,
                Supply = 1200,
                Cost = 1200,

                RadiusAttack = 0,
                RadiusView = 1,

                PowerAntiInf = 10,
                PowerAntiTank = 0,
                PowerAntiAir = 0,

                ArmourFromInf = 10,
                ArmourFromTank = 5,
                ArmourFromAir = 5,

                CanStepLand = true,
                CanStepAqua = false
            };

            if (string.IsNullOrEmpty(name))
                Name = "Асфальтоукладчик";

            if (!supply.HasValue)
                SupplyCurrent = Parameters.Supply;
        }

        public override void Activate(Mission mission)
        {
            var cell = mission.Map[Division.Position];
            if (cell is ILand && !(cell is Road) && !(cell is Bridge) && !(cell is IRails))
            {
                if (SupplyCurrent < AsphaltCost)
                    return;

                if (!Division.Player.CanBuy(AsphaltCost))
                    return;

                // TODO: добавить проверку, есть ли дорога в текущей схеме
                var road = new Road(Division.Position.X, Division.Position.Y)
                {
                    Object = Division
                };
                mission.Map.SetCell(road);

                SupplyCurrent -= AsphaltCost;
                Division.Player.Buy(AsphaltCost, $"Строительство дороги {road.Coordinates}");
            }
        }
    }
}

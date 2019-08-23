using MT.TacticWar.Core.Base.Landscape.Summer;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    [Unit("Путеукладчик", typeof(Engineers), Code = "railbuilder")]
    public class RailroadBuilder : Unit
    {
        private const int RailCost = 200;

        public RailroadBuilder(int id, Division division, string name = null,
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
                Name = "Путеукладчик";

            if (!supply.HasValue)
                SupplyCurrent = Parameters.Supply;
        }

        public override void Activate(Mission mission)
        {
            var cell = mission.Map[Division.Position];
            if (cell is ILand && !(cell is IRails))
            {
                if (SupplyCurrent < RailCost)
                    return;

                if (!Division.Player.CanBuy(RailCost))
                    return;

                // TODO: добавить проверку, есть ли ж/д в текущей схеме
                Cell rails;
                if (cell is Bridge)
                {
                    rails = new RailwayBridge(Division.Position.X, Division.Position.Y)
                    {
                        Object = Division
                    };
                }
                else
                {
                    rails = new Railroad(Division.Position.X, Division.Position.Y)
                    {
                        Object = Division
                    };
                }
                mission.Map.SetCell(rails);

                SupplyCurrent -= RailCost;
                Division.Player.Buy(RailCost, $"Строительство ж/д {rails.Coordinates}");
            }
        }
    }
}

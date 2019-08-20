using MT.TacticWar.Core.Base.Landscape.Summer;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Units
{
    [Unit("Мостоукладчик", typeof(Engineers))]
    public class BridgeBuilder : Unit
    {
        private const int BridgeCost = 500;

        public BridgeBuilder(int id, Division division, string name = null,
            int experience = ExperienceRecruit, int health = HealthMax, int? supply = null) :
            base(id, division, name, experience, health, supply)
        {
            Parameters = new UnitParameters()
            {
                Steps = 6,
                Supply = 3000,
                Cost = 2000,

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
                Name = "Мостоукладчик";

            if (!supply.HasValue)
                SupplyCurrent = Parameters.Supply;
        }

        public override void Activate(Mission mission)
        {
            if (mission.Map[Division.Position] is IWater)
            {
                if (SupplyCurrent < BridgeCost)
                    return;

                if (!Division.Player.CanBuy(BridgeCost))
                    return;

                // TODO: добавить проверку, есть ли мост в текущей схеме
                var bridge = new Bridge(Division.Position.X, Division.Position.Y)
                {
                    Object = Division
                };
                mission.Map.SetCell(bridge);

                SupplyCurrent -= BridgeCost;
                Division.Player.Buy(BridgeCost, $"Возведение моста {bridge.Coordinates}");
            }
        }
    }
}

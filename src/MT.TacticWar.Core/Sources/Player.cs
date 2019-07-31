using System.Collections.Generic;
using MT.TacticWar.Core.Players;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core
{
    public class Player
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Team { get; private set; }
        public string Color { get; private set; }
        public PlayerRank Rank { get; private set; }        // уровень игрока. В зависимости от него игрок может формировать новые подразделения
        public int Money { get; private set; }              // ресурсы, за которые игрок может ремонтировать войска и покупать новое вооружение
        public PlayerIntelligence AI { get; private set; }
        public bool IsNeutral => -1 == Team;

        public List<Division> Divisions { get; set; }
        public List<Building> Buildings { get; set; }
        public List<Gate> Gates { get; set; }               // ворота для выхода подкреплений


        public Player(int id, string name, int team, string color, PlayerRank rank, int money, bool ai)
        {
            Id = id;
            Name = name;
            Team = team;
            Color = color;
            Rank = rank;
            Money = money;

            AI = ai ? PlayerIntelligence.AI : PlayerIntelligence.Human;
            Divisions = new List<Division>();
            Buildings = new List<Building>();
        }

        public Division GetDivisionAt(int x, int y)
        {
            return Divisions.GetAt(new Coordinates(x, y));
        }

        public Building GetBuildingAt(int x, int y)
        {
            return Buildings.GetAt(new Coordinates(x, y));
        }

        public Unit GetUnitById(int id)
        {
            foreach (var division in Divisions)
            {
                var unit = division.Units.GetById(id);
                if (null != unit)
                    return unit;

            }

            return null;
        }

        public void ResetDivisionsParams()
        {
            foreach (var division in Divisions)
            {
                division.ResetParams();
            }
        }

        public void ActivateBuildings(Mission mission)
        {
            foreach (var building in Buildings)
            {
                building.Activate(mission);
            }
        }

        public List<Division> GetSupportDivisions(Coordinates pt)
        {
            var support = new List<Division>();
            foreach (var division in Divisions)
            {
                if (division is ISupport)
                {
                    if (!division.Position.Equals(pt))
                    {
                        if (division.IsInActiveRange(pt))
                        {
                            if (division.Steps > 0)
                                support.Add(division);
                        }
                    }
                }
            }
            return support;
        }
    }
}

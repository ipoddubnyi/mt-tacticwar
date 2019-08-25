using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialPlayer
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("team")]
        public int Team { get; set; }

        [XmlAttribute("color")]
        public string Color { get; set; }

        [XmlAttribute("money")]
        public int Money { get; set; }

        [XmlAttribute("ai")]
        public bool AI { get; set; }

        [XmlArray("divisions")]
        [XmlArrayItem("division")]
        public SerialDivision[] Divisions { get; set; }

        [XmlArray("buildings")]
        [XmlArrayItem("building")]
        public SerialBuilding[] Buildings { get; set; }

        [XmlArray("gates")]
        [XmlArrayItem("gate")]
        public SerialGate[] Gates { get; set; }

        public SerialPlayer()
        {
        }

        public SerialPlayer(Player player)
        {
            Id = player.Id;
            Name = player.Name;
            Team = player.Team;
            Color = player.Color;
            Money = player.Money;
            AI = player.AI;

            Divisions = SerialDivision.CreateFrom(player.Divisions).ToArray();
            Buildings = SerialBuilding.CreateFrom(player.Buildings).ToArray();
            Gates = SerialGate.CreateFrom(player.Gates.SortById()).ToArray();
        }

        public Player Create(SerialMissionTypes types)
        {
            var player = new Player(Id, Name, Team, Color, Money)
            {
                AI = AI
            };

            player.Divisions = SerialDivision.Create(Divisions, player, types).ToList();
            player.Buildings = SerialBuilding.Create(Buildings, player).ToList();
            player.Gates = SerialGate.Create(Gates).ToList();

            return player;
        }

        public static IEnumerable<Player> Create(IEnumerable<SerialPlayer> splayers,
            SerialMissionTypes types)
        {
            foreach (var splayer in splayers)
                yield return splayer.Create(types);
        }

        public static IEnumerable<SerialPlayer> CreateFrom(IEnumerable<Player> players)
        {
            foreach (var player in players)
                yield return new SerialPlayer(player);
        }
    }
}

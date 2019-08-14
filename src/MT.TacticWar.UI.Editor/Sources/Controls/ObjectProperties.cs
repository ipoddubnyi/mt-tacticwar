using System;
using System.Windows.Forms;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core;

namespace MT.TacticWar.UI.Editor.Controls
{
    public partial class ObjectProperties : UserControl
    {
        public Player ObjectPlayer => (Player)comboObjectPlayer.SelectedItem;
        public int ObjectId => (int)numObjectId.Value;
        public string ObjectName => txtObjectName.Text;

        public event EventHandler Changed;

        public ObjectProperties()
        {
            InitializeComponent();
        }

        public void SetPlayersDataSource(Player[] players)
        {
            comboObjectPlayer.DataSource = null;
            comboObjectPlayer.Items.Clear();
            comboObjectPlayer.DataSource = new BindingSource(players, null);
        }

        public void SetDivision(DivisionEditor division)
        {
            comboObjectPlayer.SelectedItem = division.Player;
            numObjectId.Value = division.Id;
            txtObjectName.Text = division.Name;
        }

        public void SetBuilding(BuildingEditor building)
        {
            comboObjectPlayer.SelectedItem = building.Player;
            numObjectId.Value = building.Id;
            txtObjectName.Text = building.Name;
        }

        private void ComboBuildingPlayer_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var handler = Changed;
            handler?.Invoke(sender, e);
        }

        private void NumBuildingId_ValueChanged(object sender, EventArgs e)
        {
            var handler = Changed;
            handler?.Invoke(sender, e);
        }

        private void TxtBuildingName_TextChanged(object sender, EventArgs e)
        {
            var handler = Changed;
            handler?.Invoke(sender, e);
        }
    }
}

using System;
using System.Windows.Forms;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core;

namespace MT.TacticWar.UI.Editor.Controls
{
    public partial class DivisionProperties : UserControl
    {
        public Player DivisionPlayer => (Player)comboDivisionPlayer.SelectedItem;
        public int DivisionId => (int)numDivisionId.Value;
        public string DivisionName => txtDivisionName.Text;

        public event EventHandler Changed;

        public DivisionProperties()
        {
            InitializeComponent();
        }

        public void SetPlayersDataSource(Player[] players)
        {
            comboDivisionPlayer.DataSource = null;
            comboDivisionPlayer.Items.Clear();
            comboDivisionPlayer.DataSource = new BindingSource(players, null);
        }

        public void SetDivision(DivisionEditor division)
        {
            comboDivisionPlayer.SelectedItem = division.Player;
            numDivisionId.Value = division.Id;
            txtDivisionName.Text = division.Name;
        }

        private void ComboDivisionPlayer_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var handler = Changed;
            handler?.Invoke(sender, e);
        }

        private void NumDivisionId_ValueChanged(object sender, EventArgs e)
        {
            var handler = Changed;
            handler?.Invoke(sender, e);
        }

        private void TxtDivisionName_TextChanged(object sender, EventArgs e)
        {
            var handler = Changed;
            handler?.Invoke(sender, e);
        }
    }
}

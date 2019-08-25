using System;
using System.Text;
using System.Windows.Forms;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Utils;

namespace MT.TacticWar.UI.Editor.Dialogs
{
    public partial class DialogBuildingEditor : Form
    {
        public Player[] Players { get; private set; }
        public BuildingEditor Building { get; private set; }
        private DivisionEditor Security { get; set; }
        public Player SelectedPlayer
        {
            get => comboBuildingPlayer.SelectedItem as Player;
            set => comboBuildingPlayer.SelectedItem = value;
        }
        public bool CanChangePlayer
        {
            get => comboBuildingPlayer.Enabled;
            set => comboBuildingPlayer.Enabled = value;
        }

        public DialogBuildingEditor(Player[] players, BuildingEditor building = null)
        {
            InitializeComponent();

            Players = players;

            comboBuildingPlayer.DataSource = null;
            comboBuildingPlayer.Items.Clear();
            comboBuildingPlayer.DataSource = Players;
            comboBuildingPlayer.SelectedIndex = 0;

            comboBuildingType.Items.Clear();
            foreach (var bld in ObjectFactory.Buildings)
                comboBuildingType.Items.Add(bld);

            if (null == building)
            {
                comboBuildingType.SelectedIndex = 0;
                comboBuildingType.Enabled = true;
                ComboBuildingType_SelectedIndexChanged(null, null);
            }
            else
            {
                comboBuildingType.Enabled = false;

                var bldCode = building.GetBuildingCode();
                foreach (BuildingCreator bld in comboBuildingType.Items)
                {
                    if (bld.GetCode().Equals(bldCode))
                        comboBuildingType.SelectedItem = bld;
                }

                Building = building;
                Security = building.Security;

                comboBuildingPlayer.SelectedItem = building.Player;
                numBuildingId.Value = building.Id;
                txtBuildingName.Text = building.Name;
                ShowSecurityInfo(Security);
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateEntries())
                DialogResult = DialogResult.None;

            Building.Player = comboBuildingPlayer.SelectedItem as Player;
            Building.Id = (int)numBuildingId.Value;
            Building.Name = txtBuildingName.Text;
            Building.Security = Security;
        }

        private bool ValidateEntries()
        {
            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ComboBuildingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != comboBuildingType.SelectedItem)
            {
                var bld = (BuildingCreator)comboBuildingType.SelectedItem;
                var building = bld.Create(null, 0, "", -1, -1, 100, null);
                Building = new BuildingEditor(building);
                txtBuildingName.Text = building.Type;
            }
        }

        private void BtnSecurityEdit_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogDivisionEditor(Players, Security))
            {
                dialog.SelectedPlayer = comboBuildingPlayer.SelectedItem as Player;
                dialog.CanChangePlayer = false;
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    Security = dialog.Division;
                    ShowSecurityInfo(Security);
                }
            }
        }

        private void BtnSecurityRemove_Click(object sender, EventArgs e)
        {
            if (null != Security)
            {
                Security = null;
                ShowSecurityInfo(Security);
            }
        }

        private void ShowSecurityInfo(DivisionEditor division)
        {
            var sb = new StringBuilder();

            if (null != division)
            {
                sb.AppendFormat("Игрок: {0}{1}", division.Player, Environment.NewLine);
                sb.AppendFormat("Id: {0}{1}", division.Id, Environment.NewLine);
                sb.AppendFormat("Тип: {0}{1}", division.Type, Environment.NewLine);
                sb.AppendFormat("Имя: {0}{1}", division.Name, Environment.NewLine);
                sb.AppendLine();
                sb.AppendLine("Юниты:");
                foreach (var unit in division.Units)
                {
                    sb.Append("- ");
                    sb.AppendLine(unit.Name);
                }
            }

            txtSecurityInfo.Text = sb.ToString();
        }
    }
}

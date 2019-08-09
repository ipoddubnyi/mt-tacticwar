using System;
using System.Windows.Forms;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Base.Units;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.UI.Editor.Dialogs
{
    public partial class DialogDivisionNew : Form
    {
        private const int PlayersCountMin = 2;
        private const int PlayersCountMax = 4;

        public int PlayersCount { get; private set; }
        public string MissionName { get; private set; }
        public string MissionBriefing { get; private set; }

        public Division NewDivision { get; private set; }

        public DialogDivisionNew()
        {
            InitializeComponent();

            var divTypes = ObjectFactory.GetAvailableDivisionTypes();
            comboDivisionType.Items.Clear();
            foreach (var type in divTypes)
            {
                comboDivisionType.Items.Add(type.Value);
            }
            comboDivisionType.SelectedIndex = 0;

            /*comboDivisionType.DataSource = new BindingSource(divTypes, null);
            comboDivisionType.DisplayMember = "Key";
            comboDivisionType.ValueMember = "Value";*/
        }

        private void DialogMapNew_Load(object sender, EventArgs e)
        {
            PlayersCount = 2;
            MissionName = "";
            MissionBriefing = "";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateEntries())
                DialogResult = DialogResult.None;
        }

        private bool ValidateEntries()
        {
            /*if (0 == txtMissionName.Text.Length)
            {
                ShowError("Название миссии не может быть пустым.");
                return false;
            }

            if (!int.TryParse(comboPlayersCount.SelectedItem.ToString(), out int players))
            {
                ShowError("Неверное число игроков.");
                return false;
            }

            if (players < PlayersCountMin || players > PlayersCountMax)
            {
                ShowError($"Число игроков должно быть от {PlayersCountMin} до {PlayersCountMax}.");
                return false;
            }

            PlayersCount = players;
            MissionName = txtMissionName.Text;
            MissionBriefing = txtMissionBriefing.Text;*/

            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ComboDivisionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var units = UnitFactory.GetAvailableUnits(comboDivisionType.SelectedValue.ToString());
            var units = UnitFactory.GetAvailableUnits(comboDivisionType.SelectedItem.ToString());
            listUnitsAll.Items.Clear();
            foreach (var unit in units)
            {
                listUnitsAll.Items.Add(unit);
            }
            //listUnitsAll.DataSource = new BindingSource(units, null);
            //listUnitsAll.DisplayMember = "Key";
            //listUnitsAll.ValueMember = "Value";

            listUnitsDivision.Items.Clear();

            //NewDivision = ObjectFactory.CreateDivision(comboDivisionType.SelectedValue.ToString(), null, 0, "", 0, 0);
            NewDivision = ObjectFactory.CreateDivision(comboDivisionType.SelectedItem.ToString(), null, 0, "", 0, 0);
        }

        private void BtnUnitAdd_Click(object sender, EventArgs e)
        {
            if (null != listUnitsAll.SelectedItem)
            {
                var uv = (UnitVariant)listUnitsAll.SelectedItem;
                var unit = uv.Create(int.Parse(txtUnitIdCommon.Text), NewDivision);
                unit.Update(txtUnitNameCommon.Text,
                    int.Parse(txtUnitExperienceCommon.Text),
                    int.Parse(txtUnitHealthCommon.Text),
                    int.Parse(txtUnitSupplyCommon.Text)
                );

                listUnitsDivision.Items.Add(
                    unit
                );
            }
        }

        private void BtnUnitRemove_Click(object sender, EventArgs e)
        {
            if (null != listUnitsDivision.SelectedItem)
            {
                listUnitsDivision.Items.Remove(listUnitsDivision.SelectedItem);
            }
        }

        private void ListUnitsAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != listUnitsAll.SelectedItem)
            {
                var uv = (UnitVariant)listUnitsAll.SelectedItem;
                var unit = uv.Create(0, NewDivision);
                txtUnitIdCommon.Text = unit.Id.ToString();
                txtUnitNameCommon.Text = unit.Name;
                txtUnitHealthCommon.Text = unit.Health.ToString();
                txtUnitExperienceCommon.Text = unit.Experience.ToString();
                txtUnitSupplyCommon.Text = unit.SupplyCurrent.ToString();
            }
        }

        private void ListUnitsDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != listUnitsDivision.SelectedItem)
            {
                var unit = (Unit)listUnitsDivision.SelectedItem;
                txtUnitIdDivision.Text = unit.Id.ToString();
                txtUnitNameDivision.Text = unit.Name;
                txtUnitHealthDivision.Text = unit.Health.ToString();
                txtUnitExperienceDivision.Text = unit.Experience.ToString();
                txtUnitSupplyDivision.Text = unit.SupplyCurrent.ToString();
            }
        }
    }
}

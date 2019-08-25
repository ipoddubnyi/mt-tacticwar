using System;
using System.Windows.Forms;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Base.Units;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Utils;

namespace MT.TacticWar.UI.Editor.Dialogs
{
    public partial class DialogDivisionEditor : Form
    {
        public Player[] Players { get; private set; }
        public DivisionEditor Division { get; private set; }
        public Player SelectedPlayer
        {
            get => comboDivisionPlayer.SelectedItem as Player;
            set => comboDivisionPlayer.SelectedItem = value;
        }
        public bool CanChangePlayer
        {
            get => comboDivisionPlayer.Enabled;
            set => comboDivisionPlayer.Enabled = value;
        }

        public DialogDivisionEditor(Player[] players, DivisionEditor division = null)
        {
            InitializeComponent();

            Players = players;
            CanChangePlayer = true;

            comboDivisionPlayer.DataSource = null;
            comboDivisionPlayer.Items.Clear();
            comboDivisionPlayer.DataSource = Players;
            comboDivisionPlayer.SelectedIndex = 0;

            comboDivisionType.Items.Clear();
            foreach (var div in ObjectFactory.Divisions)
                comboDivisionType.Items.Add(div);

            if (null == division)
            {
                comboDivisionType.SelectedIndex = 0;
                comboDivisionType.Enabled = true;
                ComboDivisionType_SelectedIndexChanged(null, null);
            }
            else
            {
                comboDivisionType.Enabled = false;

                var divCode = division.GetDivisionCode();
                foreach (DivisionCreator div in comboDivisionType.Items)
                {
                    if (div.GetCode().Equals(divCode))
                        comboDivisionType.SelectedItem = div;
                }

                Division = division;
                listUnitsDivision.Items.Clear();
                foreach (var unit in division.Units)
                {
                    listUnitsDivision.Items.Add(unit);
                }

                comboDivisionPlayer.SelectedItem = division.Player;
                numDivisionId.Value = division.Id;
                txtDivisionName.Text = division.Name;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateEntries())
                DialogResult = DialogResult.None;

            Division.Player = comboDivisionPlayer.SelectedItem as Player;
            Division.Id = (int)numDivisionId.Value;
            Division.Name = txtDivisionName.Text;
        }

        private bool ValidateEntries()
        {
            if (0 == listUnitsDivision.Items.Count)
            {
                ShowError("Необходимо добавить хотя бы одного юнита.");
                return false;
            }

            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ComboDivisionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != comboDivisionType.SelectedItem)
            {
                var div = (DivisionCreator)comboDivisionType.SelectedItem;
                var units = UnitFactory.GetAvailableUnitsForDivision(div.Type);
                listUnitsAll.Items.Clear();
                foreach (var unit in units)
                {
                    listUnitsAll.Items.Add(unit);
                }

                if (listUnitsAll.Items.Count > 0)
                    listUnitsAll.SelectedIndex = 0;

                listUnitsDivision.Items.Clear();


                var division = div.Create(null, 0, "", -1, -1);
                Division = new DivisionEditor(division);

                txtDivisionName.Text = division.Type;
            }
        }

        private void BtnUnitAdd_Click(object sender, EventArgs e)
        {
            if (null != listUnitsAll.SelectedItem)
            {
                var uv = (UnitCreator)listUnitsAll.SelectedItem;
                var unit = uv.Create((int)numUnitIdCommon.Value, Division);
                unit.Update(
                    txtUnitNameCommon.Text,
                    (int)numUnitExperienceCommon.Value,
                    (int)numUnitHealthCommon.Value,
                    (int)numUnitSupplyCommon.Value
                );

                Division.Units.Add(unit);

                listUnitsDivision.Items.Add(
                    unit
                );

                listUnitsDivision.SelectedItem = unit;
            }
        }

        private void BtnUnitRemove_Click(object sender, EventArgs e)
        {
            if (null != listUnitsDivision.SelectedItem)
            {
                var index = listUnitsDivision.SelectedIndex;
                var unit = listUnitsDivision.SelectedItem as Unit;

                Division.Units.Remove(unit);

                listUnitsDivision.Items.Remove(unit);

                // выделяем следующего юнита или предыдущего, если это был последний
                if (index >= listUnitsDivision.Items.Count)
                    index -= 1;
                listUnitsDivision.SelectedIndex = index;

                numUnitIdDivision.Value = 0;
                txtUnitNameDivision.Text = "";
                numUnitHealthDivision.Value = 100;
                numUnitExperienceDivision.Value = 0;
                numUnitSupplyDivision.Value = 1000;
            }
        }

        private void ListUnitsAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != listUnitsAll.SelectedItem)
            {
                var uv = (UnitCreator)listUnitsAll.SelectedItem;
                var unit = uv.Create(0, Division);
                numUnitIdCommon.Value = unit.Id;
                txtUnitNameCommon.Text = unit.Name;
                numUnitHealthCommon.Value = unit.Health;
                numUnitExperienceCommon.Value = unit.Experience;
                numUnitSupplyCommon.Value = unit.SupplyCurrent;
            }
        }

        private void ListUnitsDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != listUnitsDivision.SelectedItem)
            {
                var unit = (Unit)listUnitsDivision.SelectedItem;
                numUnitIdDivision.Value = unit.Id;
                txtUnitNameDivision.Text = unit.Name;
                numUnitHealthDivision.Value = unit.Health;
                numUnitExperienceDivision.Value = unit.Experience;
                numUnitSupplyDivision.Value = unit.SupplyCurrent;
            }
        }

        private void btnUnitDivisionApply_Click(object sender, EventArgs e)
        {
            if (null != listUnitsDivision.SelectedItem)
            {
                var unit = (Unit)listUnitsDivision.SelectedItem;
                unit.Update(
                    txtUnitNameDivision.Text,
                    (int)numUnitExperienceDivision.Value,
                    (int)numUnitHealthDivision.Value,
                    (int)numUnitSupplyDivision.Value
                );

                int index = listUnitsDivision.Items.IndexOf(unit);
                listUnitsDivision.Items.RemoveAt(index);
                listUnitsDivision.Items.Insert(index, unit);
                listUnitsDivision.SelectedIndex = index;
            }
        }
    }
}

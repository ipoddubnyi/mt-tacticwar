using System;
using System.Windows.Forms;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Base.Units;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.UI.Editor.Dialogs
{
    public partial class DialogDivisionEditor : Form
    {
        public Division ResultDivision { get; private set; }

        public DialogDivisionEditor(Division division = null)
        {
            InitializeComponent();

            var divTypes = ObjectFactory.GetAvailableDivisionTypes();
            comboDivisionType.Items.Clear();
            foreach (var type in divTypes)
            {
                comboDivisionType.Items.Add(type.Value);
            }

            if (null == division)
            {
                comboDivisionType.SelectedIndex = 0;
                comboDivisionType.Enabled = true;
                ComboDivisionType_SelectedIndexChanged(null, null);
            }
            else
            {
                comboDivisionType.Enabled = false;
                comboDivisionType.SelectedItem = ObjectFactory.GetDivisionCode(division);

                ResultDivision = division;
                listUnitsDivision.Items.Clear();
                foreach (var unit in division.Units)
                {
                    listUnitsDivision.Items.Add(unit);
                }
            }

            /*comboDivisionType.DataSource = new BindingSource(divTypes, null);
            comboDivisionType.DisplayMember = "Key";
            comboDivisionType.ValueMember = "Value";*/
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateEntries())
                DialogResult = DialogResult.None;
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
            var units = UnitFactory.GetAvailableUnits(comboDivisionType.SelectedItem.ToString());
            listUnitsAll.Items.Clear();
            foreach (var unit in units)
            {
                listUnitsAll.Items.Add(unit);
            }

            if (listUnitsAll.Items.Count > 0)
                listUnitsAll.SelectedIndex = 0;

            listUnitsDivision.Items.Clear();

            ResultDivision = ObjectFactory.CreateDivision(comboDivisionType.SelectedItem.ToString(), null, 0, "", 0, 0);
        }

        private void BtnUnitAdd_Click(object sender, EventArgs e)
        {
            if (null != listUnitsAll.SelectedItem)
            {
                var uv = (UnitVariant)listUnitsAll.SelectedItem;
                var unit = uv.Create((int)numUnitIdCommon.Value, ResultDivision);
                unit.Update(
                    txtUnitNameCommon.Text,
                    (int)numUnitExperienceCommon.Value,
                    (int)numUnitHealthCommon.Value,
                    (int)numUnitSupplyCommon.Value
                );

                ResultDivision.Units.Add(unit);

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
                listUnitsDivision.Items.Remove(listUnitsDivision.SelectedItem);

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
                var uv = (UnitVariant)listUnitsAll.SelectedItem;
                var unit = uv.Create(0, ResultDivision);
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

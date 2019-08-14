using System;
using System.Text;
using System.Windows.Forms;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Base.Units;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.UI.Editor.Dialogs
{
    public partial class DialogBuildingEditor : Form
    {
        public BuildingEditor ResultBuilding { get; private set; }

        public DialogBuildingEditor(BuildingEditor building = null)
        {
            InitializeComponent();

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
                comboBuildingType.SelectedItem = building.GetBuildingCode();

                ResultBuilding = building;
                ShowSecurityInfo(ResultBuilding.Security);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateEntries())
                DialogResult = DialogResult.None;

            if (null != ResultBuilding.Security)
            {
                ResultBuilding.Security.SetId((int)numSecurityId.Value);
                ResultBuilding.Security.SetName(txtSecurityName.Text);
            }
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
                var bld = (BuildingVariant)comboBuildingType.SelectedItem;
                var building = bld.Create(null, 0, "", -1, -1, 100, null);
                ResultBuilding = new BuildingEditor(building);
                ResultBuilding.SetName(building.Type);
            }
        }

        private void BtnSecurityAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogDivisionEditor(ResultBuilding.Security))
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    ResultBuilding.Security = dialog.ResultDivision;
                    ShowSecurityInfo(ResultBuilding.Security);
                }
            }
        }

        private void BtnSecurityRemove_Click(object sender, EventArgs e)
        {
            if (null != ResultBuilding.Security)
            {
                ResultBuilding.Security = null;
                ShowSecurityInfo(null);
            }
        }

        private void ShowSecurityInfo(DivisionEditor division)
        {
            var sb = new StringBuilder();
            int id = 0;
            string name = string.Empty;

            if (null != division)
            {
                sb.AppendLine(division.Type);
                sb.AppendLine();
                sb.AppendLine("Юниты:");
                foreach (var unit in division.Units)
                {
                    sb.Append("- ");
                    sb.AppendLine(unit.Name);
                }

                id = division.Id;
                name = division.Name;
            }

            lblSecurityInfo.Text = sb.ToString();
            numSecurityId.Value = id;
            txtSecurityName.Text = name;
        }
    }
}

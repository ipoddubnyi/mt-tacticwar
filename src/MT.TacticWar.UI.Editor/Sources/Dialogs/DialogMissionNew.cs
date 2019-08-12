using System;
using System.Windows.Forms;

namespace MT.TacticWar.UI.Editor.Dialogs
{
    public partial class DialogMissionNew : Form
    {
        public string MissionName { get; private set; }
        public string MissionBriefing { get; private set; }

        public DialogMissionNew()
        {
            InitializeComponent();
        }

        private void DialogMapNew_Load(object sender, EventArgs e)
        {
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
            if (0 == txtMissionName.Text.Length)
            {
                ShowError("Название миссии не может быть пустым.");
                return false;
            }

            MissionName = txtMissionName.Text;
            MissionBriefing = txtMissionBriefing.Text;

            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

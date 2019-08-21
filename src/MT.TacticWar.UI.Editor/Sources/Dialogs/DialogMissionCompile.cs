using System;
using System.IO;
using System.Windows.Forms;

namespace MT.TacticWar.UI.Editor.Dialogs
{
    public partial class DialogMissionCompile : Form
    {
        public string GameName => txtGameName.Text;
        public string MapFileName => txtMapFileName.Text;
        public string MissionFileName => txtMissionFileName.Text;

        public DialogMissionCompile(MissionEditor mission)
        {
            InitializeComponent();

            txtGameName.Text = mission.Name;
            txtMapFileName.Text = "map";
            txtMissionFileName.Text = "mission";
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateEntries())
                DialogResult = DialogResult.None;
        }

        private bool ValidateEntries()
        {
            if (0 == txtGameName.Text.Length)
            {
                ShowError("Имя миссии не может быть пустым.");
                return false;
            }

            if (0 == txtMapFileName.Text.Length)
            {
                ShowError("Имя файла карты не может быть пустым.");
                return false;
            }

            if (txtMapFileName.Text.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                ShowError("Имя файла карты содержит неразрешённые символы.");
                return false;
            }

            if (0 == txtMissionFileName.Text.Length)
            {
                ShowError("Имя файла миссии не может быть пустым.");
                return false;
            }

            if (txtMissionFileName.Text.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                ShowError("Имя файла миссии содержит неразрешённые символы.");
                return false;
            }

            return true;
        }
    }
}

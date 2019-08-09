using System;
using System.Windows.Forms;

namespace MT.TacticWar.UI.Editor.Dialogs
{
    public partial class DialogMissionNew : Form
    {
        private const int PlayersCountMin = 2;
        private const int PlayersCountMax = 4;

        public int PlayersCount { get; private set; }
        public string MissionName { get; private set; }
        public string MissionBriefing { get; private set; }

        public DialogMissionNew()
        {
            InitializeComponent();

            comboPlayersCount.Items.Clear();
            comboPlayersCount.Items.Add("2");
            comboPlayersCount.SelectedItem = "2";
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
            if (0 == txtMissionName.Text.Length)
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
            MissionBriefing = txtMissionBriefing.Text;

            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

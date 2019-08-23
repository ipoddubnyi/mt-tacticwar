using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MT.TacticWar.Core;

namespace MT.TacticWar.UI.Editor.Dialogs
{
    public partial class DialogPlayers : Form
    {
        private List<Player> players;

        public Player[] Players => players.ToArray();

        public DialogPlayers(IEnumerable<Player> players)
        {
            InitializeComponent();

            this.players = players.ToList();
            UpdateList();
        }

        private void UpdateList()
        {
            listPlayers.DataSource = null;
            listPlayers.Items.Clear();
            listPlayers.DataSource = new BindingSource(players, null);
        }

        private void ListPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != listPlayers.SelectedItem)
            {
                var player = listPlayers.SelectedItem as Player;
                txtName.Text = player.Name;
                numTeam.Enabled = !player.IsNeutral;
                numTeam.Value = player.Team;
                btnColor.BackColor = ColorTranslator.FromHtml(player.Color);
                numMoney.Value = player.Money;
                checkNeutral.Checked = player.IsNeutral;
                checkAI.Checked = player.AI;
            }
        }

        private void BtnAddPlayer_Click(object sender, EventArgs e)
        {
            if (4 == players.Count)
            {
                ShowError("Больше 4 игроков установить нельзя.");
                return;
            }

            int count = players.Count;
            var player = new Player(count, $"Игрок {count + 1}", count + 1, "blue", 50000);
            players.Add(player);
            UpdateList();
            listPlayers.SelectedItem = player;
        }

        private void BtnRemovePlayer_Click(object sender, EventArgs e)
        {
            if (null != listPlayers.SelectedItem)
            {
                if (2 == players.Count)
                {
                    ShowError("Меньше 2 игроков установить нельзя.");
                    return;
                }

                if (DialogResult.Yes == MessageBox.Show(
                    "При удалении игрока также будут удалены все его юниты и строения. Продолжить?",
                    "Удаление игрока",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question))
                {
                    players.Remove(listPlayers.SelectedItem as Player);
                    UpdateList();
                }
            }
        }

        private void BtnUpPlayer_Click(object sender, EventArgs e)
        {
            if (null != listPlayers.SelectedItem)
            {
                var player = listPlayers.SelectedItem as Player;
                int index = players.IndexOf(player);
                if (index > 0)
                {
                    players.Remove(player);
                    players.Insert(index - 1, player);
                }
                UpdateList();
                listPlayers.SelectedItem = player;
            }
        }

        private void BtnDownPlayer_Click(object sender, EventArgs e)
        {
            if (null != listPlayers.SelectedItem)
            {
                var player = listPlayers.SelectedItem as Player;
                int index = players.IndexOf(player);
                if (index < players.Count - 1)
                {
                    players.Remove(player);
                    players.Insert(index + 1, player);
                }
                UpdateList();
                listPlayers.SelectedItem = player;
            }
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                btnColor.BackColor = colorDialog.Color;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateEntries())
                DialogResult = DialogResult.Cancel;
        }

        private bool ValidateEntries()
        {
            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NumTeam_ValueChanged(object sender, EventArgs e)
        {
            checkNeutral.Checked = (-1 == numTeam.Value);
        }

        private void CheckNeutral_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNeutral.Checked)
            {
                numTeam.Enabled = false;
                numTeam.Value = -1;
            }
            else
            {
                numTeam.Enabled = true;
                var player = listPlayers.SelectedItem as Player;
                numTeam.Value = player.Id + 1;
            }
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            if (null != listPlayers.SelectedItem)
            {
                var player = listPlayers.SelectedItem as Player;
                int index = players.IndexOf(player);

                var playernew = new Player(
                    player.Id,
                    txtName.Text,
                    checkNeutral.Checked ? -1 : (int)numTeam.Value,
                    btnColor.BackColor.Name.ToLower(),
                    (int)numMoney.Value)
                {
                    AI = checkAI.Checked
                };

                playernew.Divisions = player.Divisions;
                playernew.Buildings = player.Buildings;
                playernew.Gates = player.Gates;

                players.Remove(player);
                players.Insert(index, playernew);

                UpdateList();
                listPlayers.SelectedItem = playernew;
            }
        }
    }
}

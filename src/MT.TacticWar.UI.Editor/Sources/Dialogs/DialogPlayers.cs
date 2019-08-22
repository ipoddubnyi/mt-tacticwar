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

        private void listPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != listPlayers.SelectedItem)
            {
                var player = listPlayers.SelectedItem as Player;
                txtName.Text = player.Name;
                numTeam.Value = player.Team;
                btnColor.BackColor = ColorTranslator.FromHtml(player.Color);
                numMoney.Value = player.Money;
            }
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            if (4 == players.Count)
            {
                ShowError("Больше 4 игроков установить нельзя.");
                return;
            }

            int count = players.Count;
            var player = new Player(count, $"Игрок {count + 1}", count + 1, "blue", Core.Players.PlayerRank.Soldier, 0, false);
            players.Add(player);
            UpdateList();
            listPlayers.SelectedItem = player;
        }

        private void btnRemovePlayer_Click(object sender, EventArgs e)
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

        private void btnUpPlayer_Click(object sender, EventArgs e)
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

        private void btnDownPlayer_Click(object sender, EventArgs e)
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

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                btnColor.BackColor = colorDialog.Color;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateEntries())
                DialogResult = DialogResult.Cancel;
        }

        private bool ValidateEntries()
        {
            /*if (!int.TryParse(txtSizeWidth.Text, out int width))
            {
                ShowError("Неверное значение ширины карты.");
                return false;
            }

            if (width < WidthMin || width > WidthMax)
            {
                ShowError($"Ширины карты должна быть от {WidthMin} до {WidthMax}.");
                return false;
            }

            if (!int.TryParse(txtSizeHeight.Text, out int height))
            {
                ShowError("Неверное значение высоты карты.");
                return false;
            }

            if (height < HeightMin || height > HeightMax)
            {
                ShowError($"Высоты карты должна быть от {HeightMin} до {HeightMax}.");
                return false;
            }

            if (0 == txtMapName.Text.Length)
            {
                ShowError("Название карты не может быть пустым.");
                return false;
            }

            MapSizeWidth = width;
            MapSizeHeight = height;
            MapSchema = comboMapSchema.SelectedValue.ToString();
            MapName = txtMapName.Text;
            MapDescription = txtMapDescription.Text;*/

            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    (int)numTeam.Value,
                    btnColor.BackColor.Name.ToLower(),
                    player.Rank,
                    (int)numMoney.Value,
                    player.AI == Core.Players.PlayerIntelligence.AI
                );

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

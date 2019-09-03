using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.UI.Editor.Dialogs
{
    public partial class DialogReinforcementList : Form
    {
        private readonly Player[] players;
        private List<Division> reinforcements;
        public Division[] Reinforcements => reinforcements.ToArray();

        public DialogReinforcementList(Player[] players, Division[] reinforcements)
        {
            InitializeComponent();

            this.players = players;
            this.reinforcements = reinforcements.ToList();
            ListScriptsRefresh();
        }

        private void ListScriptsRefresh()
        {
            listReinforcements.DataSource = null;
            listReinforcements.Items.Clear();
            //listReinforcements.DataSource = reinforcements;

            reinforcements = reinforcements.SortById().ToList();
            var dict = new Dictionary<string, Division>();
            foreach (var div in reinforcements)
                dict.Add($"{div.Id}: {div.Name}", div);

            if (dict.Count > 0)
            {
                listReinforcements.DataSource = new BindingSource(dict, null);
                listReinforcements.DisplayMember = "Key";
                listReinforcements.ValueMember = "Value";
            }
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogDivisionEditor(players))
            {
                dialog.CanChangePlayer = false;

                if (DialogResult.OK == dialog.ShowDialog())
                {
                    var division = dialog.Division.CreateReinforcement();
                    reinforcements.Add(division);
                    ListScriptsRefresh();
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (null == listReinforcements.SelectedItem)
            {
                ShowError("Сначала выделите подкрепление.");
                return;
            }

            var division = ((KeyValuePair<string, Division>)listReinforcements.SelectedItem).Value;
            using (var dialog = new DialogDivisionEditor(players, new DivisionEditor(division)))
            {
                dialog.CanChangePlayer = false;

                if (DialogResult.OK == dialog.ShowDialog())
                {
                    division = dialog.Division.CreateReinforcement();
                    reinforcements[listReinforcements.SelectedIndex] = division;
                    ListScriptsRefresh();
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (null == listReinforcements.SelectedItem)
            {
                ShowError("Сначала выделите подкрепление.");
                return;
            }

            if (DialogResult.Yes != MessageBox.Show(
                "Вы уверены, что хотите удалить подкрепление?",
                "Удаление подкрепления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question))
            {
                return;
            }

            reinforcements.RemoveAt(listReinforcements.SelectedIndex);
            ListScriptsRefresh();
        }

        private void ListReinforcements_DoubleClick(object sender, EventArgs e)
        {
            if (null != listReinforcements.SelectedItem)
                BtnEdit_Click(sender, e);
        }
    }
}

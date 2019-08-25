using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.UI.Editor.Dialogs
{
    public partial class DialogScriptList : Form
    {
        private List<Script> scripts;
        public Script[] Scripts => scripts.ToArray();

        public DialogScriptList(Script[] scripts)
        {
            InitializeComponent();

            this.scripts = scripts.ToList();
            ListScriptsRefresh();
        }

        private void ListScriptsRefresh()
        {
            listScripts.DataSource = null;
            listScripts.Items.Clear();
            listScripts.DataSource = scripts;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogScriptEditor())
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    scripts.Add(dialog.Script);
                    ListScriptsRefresh();
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (null == listScripts.SelectedItem)
            {
                ShowError("Сначала выделите скрипт.");
                return;
            }

            using (var dialog = new DialogScriptEditor(listScripts.SelectedItem as Script))
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    scripts[listScripts.SelectedIndex] = dialog.Script;
                    ListScriptsRefresh();
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (null == listScripts.SelectedItem)
            {
                ShowError("Сначала выделите скрипт.");
                return;
            }

            if (DialogResult.Yes != MessageBox.Show(
                "Вы уверены, что хотите удалить скрипт?",
                "Удаление скрипта",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question))
            {
                return;
            }

            scripts.RemoveAt(listScripts.SelectedIndex);
            ListScriptsRefresh();
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            if (listScripts.SelectedIndex < 0)
            {
                ShowError("Сначала выделите скрипт.");
                return;
            }

            var index = listScripts.SelectedIndex;
            if (index > 0)
            {
                var script = scripts[index];
                scripts.RemoveAt(index);
                scripts.Insert(index - 1, script);

                ListScriptsRefresh();
                listScripts.SelectedIndex = index - 1;
            }
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            if (listScripts.SelectedIndex < 0)
            {
                ShowError("Сначала выделите скрипт.");
                return;
            }

            var index = listScripts.SelectedIndex;
            if (index < scripts.Count - 1)
            {
                var script = scripts[index];
                scripts.RemoveAt(index);
                scripts.Insert(index + 1, script);

                ListScriptsRefresh();
                listScripts.SelectedIndex = index + 1;
            }
        }

        private void ListScripts_DoubleClick(object sender, EventArgs e)
        {
            if (null != listScripts.SelectedItem)
                BtnEdit_Click(sender, e);
        }
    }
}

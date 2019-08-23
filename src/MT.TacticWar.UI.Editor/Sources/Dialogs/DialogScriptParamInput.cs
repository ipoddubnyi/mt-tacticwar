using System;
using System.Windows.Forms;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.UI.Editor.Dialogs
{
    public partial class DialogScriptParamInput : Form
    {
        private ScriptArgument argument;
        public string Value => txtParamValue.Text;

        public DialogScriptParamInput(ScriptArgument argument)
        {
            InitializeComponent();

            this.argument = argument;
            txtParamValue.Text = argument.Value;
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
            if (!argument.CheckPossible(txtParamValue.Text))
            {
                ShowError("Значение не соответствует требованиям.");
                return false;
            }

            return true;
        }
    }
}

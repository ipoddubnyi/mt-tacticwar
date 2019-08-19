using System;
using System.Windows.Forms;

namespace MT.TacticWar.UI.Editor.Dialogs
{
    public partial class DialogScriptParamInput : Form
    {
        public string Value => txtParamValue.Text;

        public DialogScriptParamInput(string name, string value)
        {
            InitializeComponent();

            txtParamValue.Text = value;
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
            if (0 == txtParamValue.Text.Length)
            {
                ShowError("Значение не может быть пустым.");
                return false;
            }

            return true;
        }
    }
}

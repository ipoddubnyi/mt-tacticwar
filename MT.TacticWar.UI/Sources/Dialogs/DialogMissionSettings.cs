using System;
using System.Windows.Forms;

namespace MT.TacticWar.UI.Dialogs
{
    public partial class DialogMissionSettings : Form
    {
        // имена игроков
        public string Player1Name { get; private set; }
        public string Player2Name { get; private set; }
        // управление ИИ
        public bool Player1AI { get; private set; }
        public bool Player2AI { get; private set; }

        public DialogMissionSettings()
        {
            InitializeComponent();
        }

        //Начать
        private void BtnStart_Click(object sender, EventArgs e)
        {
            //если оба игрока - ПК
            if (radioPC1.Checked && radioPC2.Checked)
            {
                MessageBox.Show("Оба игрока не могут быть под управлением компьютера",
                            "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //имя игрока 1
            if (radioHuman1.Checked && (txtName1.Text == ""))
            {
                MessageBox.Show("Введите имя игрока 1",
                            "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //имя игрока 2
            if (radioHuman2.Checked && (txtName2.Text == ""))
            {
                MessageBox.Show("Введите имя игрока 2",
                            "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            Player1Name = txtName1.Text;
            Player2Name = txtName2.Text;

            Player1AI = radioPC1.Checked;
            Player2AI = radioPC2.Checked;

            //вернуть результат диалога
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void RadioHuman1_CheckedChanged(object sender, EventArgs e)
        {
            txtName1.Enabled = true;
        }

        private void RadioPC1_CheckedChanged(object sender, EventArgs e)
        {
            txtName1.Enabled = false;
        }

        private void RadioHuman2_CheckedChanged(object sender, EventArgs e)
        {
            txtName2.Enabled = true;
        }

        private void RadioPC2_CheckedChanged(object sender, EventArgs e)
        {
            txtName2.Enabled = false;
        }
    }
}

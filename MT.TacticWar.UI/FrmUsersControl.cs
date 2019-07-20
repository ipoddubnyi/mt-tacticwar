using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MT.TacticWar.UI
{
    public partial class FrmUsersControl : Form
    {
        public FrmUsersControl()
        {
            InitializeComponent();
        }

        //имена игроков
        public string igrk1Name;
        public string igrk2Name;
        //управление ИИ
        public bool igrk1AI;
        public bool igrk2AI;

        //Начать
        private void btnStart_Click(object sender, EventArgs e)
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

            igrk1Name = txtName1.Text;
            igrk2Name = txtName2.Text;

            igrk1AI = radioPC1.Checked;
            igrk2AI = radioPC2.Checked;

            //вернуть результат диалога
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void radioHuman1_CheckedChanged(object sender, EventArgs e)
        {
            txtName1.Enabled = true;
        }

        private void radioPC1_CheckedChanged(object sender, EventArgs e)
        {
            txtName1.Enabled = false;
        }

        private void radioHuman2_CheckedChanged(object sender, EventArgs e)
        {
            txtName2.Enabled = true;
        }

        private void radioPC2_CheckedChanged(object sender, EventArgs e)
        {
            txtName2.Enabled = false;
        }
    }
}

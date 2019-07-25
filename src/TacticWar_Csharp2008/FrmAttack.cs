using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TacticWar
{
    public partial class FrmAttack : Form
    {
        /*
        public TW_Units.CElement elemAtak;
        public TW_Units.CElement elemDef;
        public List<TW_Units.CElement> poddAtak;
        public List<TW_Units.CElement> poddDef;*/

        public string elemAtak_name;
        public string elemDef_name;
        public List<string> elemAtak_units;
        public List<string> elemDef_units;
        public List<string> poddAtak_units;
        public List<string> poddDef_units;
        public int win;

        public FrmAttack()
        {
            InitializeComponent();
        }

        private void FrmAttack_Load(object sender, EventArgs e)
        {
            txtElAtak.Text = elemAtak_name;
            txtElDefend.Text = elemDef_name;

            //атакующее подразделение
            listElAtakU.Items.Clear();

            for (int k = 0; k < elemAtak_units.Count; k++)
            {
                listElAtakU.Items.Add(elemAtak_units[k]);
            }

            //защищающееся подразделение
            listElDefU.Items.Clear();

            for (int k = 0; k < elemDef_units.Count; k++)
            {
                listElDefU.Items.Add(elemDef_units[k]);
            }

            //поддержка атаки
            listElAtakPod.Items.Clear();

            for (int k = 0; k < poddAtak_units.Count; k++)
            {
                listElAtakPod.Items.Add(poddAtak_units[k]);
            }

            //поддержка защиты
            listElDefPod.Items.Clear();

            for (int k = 0; k < poddDef_units.Count; k++)
            {
                listElDefPod.Items.Add(poddDef_units[k]);
            }

            //выдать сообщение о результатах боя
            switch (win)
            {
                case 0:
                    MessageBox.Show("Атакующее подразделение отступило : |", "Результаты боя");
                    btnCount.Text = "Закрыть";
                    return;
                case 1:
                    MessageBox.Show("Атакующее подразделение победило : )", "Результаты боя");
                    btnCount.Text = "Закрыть";
                    return;
                case 2:
                    MessageBox.Show("Атакующее подразделение проиграло : (", "Результаты боя");
                    btnCount.Text = "Закрыть";
                    return;
            }
        }
    }
}

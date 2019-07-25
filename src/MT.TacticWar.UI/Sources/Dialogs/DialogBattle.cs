using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MT.TacticWar.Core.Battle;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.UI.Dialogs
{
    public partial class DialogBattle : Form
    {
        private string DivisionAttackerName { get; set; }
        private string DivisionDefenderName { get; set; }
        private List<string> DivisionAttackerUnits { get; set; }
        private List<string> DivisionDefenderUnits { get; set; }
        private List<string> SupportAttackerUnits { get; set; }
        private List<string> SupportDefenderUnits { get; set; }
        private BattleResult BattleResult { get; set; }

        public DialogBattle()
        {
            InitializeComponent();
        }

        public void SetDivisions(Division attacker, Division defender)
        {
            DivisionAttackerName = attacker.Name;
            DivisionDefenderName = defender.Name;
            DivisionAttackerUnits = new List<string>();
            DivisionDefenderUnits = new List<string>();
            SupportAttackerUnits = new List<string>();
            SupportDefenderUnits = new List<string>();

            foreach (var unit in attacker.Units)
            {
                DivisionAttackerUnits.Add($"{unit.Name} ({unit.Health}%)");
            }

            foreach (var unit in defender.Units)
            {
                DivisionDefenderUnits.Add($"{unit.Name} ({unit.Health}%)");
            }

            BattleResult = BattleResult.Draw;
        }

        public void SetResultWin(Division attacker)
        {
            SetResult(attacker, null, BattleResult.Win);
        }

        public void SetResultLose(Division defender)
        {
            SetResult(null, defender, BattleResult.Lose);
        }

        public void SetResultDraw(Division attacker, Division defender)
        {
            SetResult(attacker, defender, BattleResult.Draw);
        }

        private void SetResult(Division attacker, Division defender, BattleResult result)
        {
            DivisionAttackerUnits = new List<string>();
            DivisionDefenderUnits = new List<string>();
            SupportAttackerUnits = new List<string>();
            SupportDefenderUnits = new List<string>();

            if (null != attacker)
            {
                foreach (var unit in attacker.Units)
                {
                    DivisionAttackerUnits.Add($"{unit.Name} ({unit.Health}%)");
                }
            }

            if (null != defender)
            {
                foreach (var unit in defender.Units)
                {
                    DivisionDefenderUnits.Add($"{unit.Name} ({unit.Health}%)");
                }
            }

            BattleResult = result;
            ShowResultMessage();
        }

        private void DialogBattle_Load(object sender, EventArgs e)
        {
            txtElAtak.Text = DivisionAttackerName;
            txtElDefend.Text = DivisionDefenderName;

            //атакующее подразделение
            listElAtakU.Items.Clear();

            for (int k = 0; k < DivisionAttackerUnits.Count; k++)
            {
                listElAtakU.Items.Add(DivisionAttackerUnits[k]);
            }

            //защищающееся подразделение
            listElDefU.Items.Clear();

            for (int k = 0; k < DivisionDefenderUnits.Count; k++)
            {
                listElDefU.Items.Add(DivisionDefenderUnits[k]);
            }

            //поддержка атаки
            listElAtakPod.Items.Clear();

            for (int k = 0; k < SupportAttackerUnits.Count; k++)
            {
                listElAtakPod.Items.Add(SupportAttackerUnits[k]);
            }

            //поддержка защиты
            listElDefPod.Items.Clear();

            for (int k = 0; k < SupportDefenderUnits.Count; k++)
            {
                listElDefPod.Items.Add(SupportDefenderUnits[k]);
            }

            //выдать сообщение о результатах боя
            //ShowResultMessage();
        }

        public void ShowResultMessage()
        {
            //выдать сообщение о результатах боя
            switch (BattleResult)
            {
                case BattleResult.Draw:
                    MessageBox.Show("Атакующее подразделение отступило : |", "Результаты боя");
                    btnCount.Text = "Закрыть";
                    return;
                case BattleResult.Win:
                    MessageBox.Show("Атакующее подразделение победило : )", "Результаты боя");
                    btnCount.Text = "Закрыть";
                    return;
                case BattleResult.Lose:
                    MessageBox.Show("Атакующее подразделение проиграло : (", "Результаты боя");
                    btnCount.Text = "Закрыть";
                    return;
            }
        }
    }
}

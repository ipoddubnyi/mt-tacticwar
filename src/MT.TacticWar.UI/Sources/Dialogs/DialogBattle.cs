using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Gameplay.Battles;

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

        public void SetDivisions(Division attacker, Division defender, List<Division> supportAttacker, List<Division> supportDefender)
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

            foreach (var div in supportAttacker)
            {
                SupportAttackerUnits.Add($"{div.Name}");
            }

            foreach (var div in supportDefender)
            {
                SupportDefenderUnits.Add($"{div.Name}");
            }

            BattleResult = BattleResult.Draw;
        }

        public void SetResultWin(Division attacker, List<Division> supportAttacker, List<Division> supportDefender)
        {
            SetResult(attacker, null, supportAttacker, supportDefender, BattleResult.Win);
        }

        public void SetResultLose(Division defender, List<Division> supportAttacker, List<Division> supportDefender)
        {
            SetResult(null, defender, supportAttacker, supportDefender, BattleResult.Lose);
        }

        public void SetResultDraw(Division attacker, Division defender, List<Division> supportAttacker, List<Division> supportDefender)
        {
            SetResult(attacker, defender, supportAttacker, supportDefender, BattleResult.Draw);
        }

        private void SetResult(Division attacker, Division defender, List<Division> supportAttacker, List<Division> supportDefender, BattleResult result)
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

            foreach (var div in supportAttacker)
            {
                SupportAttackerUnits.Add($"{div.Name}");
            }

            foreach (var div in supportDefender)
            {
                SupportDefenderUnits.Add($"{div.Name}");
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

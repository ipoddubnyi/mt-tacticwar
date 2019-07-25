using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Battle;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Serialization;
using MT.TacticWar.UI.Dialogs;

namespace MT.TacticWar.UI
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
        }        

        private Simulator SIMUL;
        private const int CellSize = 21;

        private void button3_Click(object sender, EventArgs e)
        {
            var mission = MissionLoader.LoadGame("missions\\Тесты\\");
            LoadMission(mission);
        }

        private void LoadMission(Mission mission)
        {
            using (var dialog = new DialogMissionSettings())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    propertyGrid1.SelectedObject = null;
                    listInfoUnits.Items.Clear();
                    StartSimulator(mission, dialog.Player1Name, dialog.Player2Name, dialog.Player1AI, dialog.Player2AI);
                }
            }
        }

        private void StartSimulator(Mission mission, string plr0Name, string plr1Name, bool plr0AI, bool plr1AI)
        {
            try
            {
                SIMUL = new Simulator(mission, plr0Name, plr1Name, plr0AI, plr1AI);

                // размеры поля боя и окна
                int oldHei = gameMap.Height; //старые координаты для центровки окна
                int oldWid = gameMap.Width;

                gameMap.Height = SIMUL.Game.Map.Height * CellSize + 2;
                gameMap.Width = SIMUL.Game.Map.Width * CellSize + 2;

                Height = gameMap.Height + 80;
                Width = gameMap.Width + propertyGrid1.Width + 50;

                if (oldHei != gameMap.Height)
                    Top -= Math.Abs(oldHei - gameMap.Height + 80) / 2;

                if (oldWid != gameMap.Width)
                    Left -= Math.Abs(oldWid - gameMap.Width + 50) / 2;

                // рисование карты

                SIMUL.InitGraphics(gameMap.CreateGraphics(), CellSize);

                // TODO: исправить двойное обновление картинки при первой загрузке
                SIMUL.DrawAll();

                // TODO: показ брифинга
                //MessageBox.Show(SIMUL.Mission.mBriefing, "Брифинг");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gameMap_MouseClick(object sender, MouseEventArgs e)
        {
            //если нажатие не левой кнопкой
            if (e.Button != MouseButtons.Left)
            {
                SIMUL.DeselectAll();
                ClearSelectedObjectInfo();
            }
            else
            {
                Signals signal;

                signal = SIMUL.ZonaClick(e.X, e.Y);

                //если собрана информация о юните
                switch (signal)
                {
                    case Signals.READY_UNIT_INFO:
                        ShowSelectedObjectInfo();
                        break;
                    case Signals.ATTACK:
                        BattleDivisionVsDivision();
                        break;
                }
            }
        }

        private void ShowSelectedObjectInfo()
        {
            ClearSelectedObjectInfo();

            if (null != SIMUL.SelectedDivision)
            {
                propertyGrid1.SelectedObject = new DivisionInfo(SIMUL.SelectedDivision);

                foreach (var unit in SIMUL.SelectedDivision.Units)
                {
                    listInfoUnits.Items.Add($"{unit.Name} ({unit.Health}%)");
                }
            }
            else if (null != SIMUL.SelectedBuilding)
            {
                propertyGrid1.SelectedObject = new BuildingInfo(SIMUL.SelectedBuilding);
            }
        }

        private void ClearSelectedObjectInfo()
        {
            propertyGrid1.SelectedObject = null;
            listInfoUnits.Items.Clear();
        }

        private void BattleDivisionVsDivision()
        {
            using (var dialog = new DialogBattle())
            {
                dialog.SetDivisions(
                    SIMUL.AttackInfo.DivisionAttacker,
                    SIMUL.AttackInfo.DivisionDefender
                );

                if (DialogResult.OK == dialog.ShowDialog())
                {
                    // TODO: реализовать поддержку
                    var result = SIMUL.BattleBegin(
                        SIMUL.AttackInfo.DivisionAttacker,
                        SIMUL.AttackInfo.DivisionDefender,
                        new List<Division>(),
                        new List<Division>()
                    );

                    switch (result)
                    {
                        case BattleResult.Win:
                            dialog.SetResultWin(SIMUL.AttackInfo.DivisionAttacker);
                            ShowSelectedObjectInfo();
                            break;
                        case BattleResult.Lose:
                            dialog.SetResultLose(SIMUL.AttackInfo.DivisionDefender);
                            ClearSelectedObjectInfo();
                            break;
                        case BattleResult.Draw:
                            dialog.SetResultDraw(SIMUL.AttackInfo.DivisionAttacker, SIMUL.AttackInfo.DivisionDefender);
                            ShowSelectedObjectInfo();
                            break;
                    }

                    // показываем диалог с результатами битвы
                    dialog.ShowDialog();
                }
                else
                {
                    SIMUL.BattleRecede(SIMUL.AttackInfo.DivisionAttacker);

                    // TODO: показываем диалог с результатами битвы
                    //dialog.ShowDialog();
                }
            }

            //перерисовываем поле боя
            SIMUL.DrawAll();
        }

        private void gameMap_Paint(object sender, PaintEventArgs e)
        {
            if(SIMUL != null)
                SIMUL.DrawAll();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //button3_Click(null, null);
        }

        //Меню - Миссия - Загрузить
        private void menuMisLoad_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogMissionLoad())
            {
                var res = dialog.ShowDialog();
                if (res == DialogResult.OK)
                {
                    var mission = dialog.SelectedMission;
                    LoadMission(mission);
                }
            }
        }

        private void BtnEndStep_Click(object sender, EventArgs e)
        {
            var ans = MessageBox.Show(
                "Завершить ход?",
                "Завершение хода",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                gameMap.Visible = false;
                SIMUL.PassStep();

                MessageBox.Show(
                    $"Ход игрока {SIMUL.PlayerCurrent}",
                    "Начало хода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                gameMap.Visible = true;
            }
        }
    }
}

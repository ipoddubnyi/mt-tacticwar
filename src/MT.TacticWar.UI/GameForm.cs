using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Serialization;
using MT.TacticWar.Gameplay;
using MT.TacticWar.Gameplay.Battles;
using MT.TacticWar.UI.Dialogs;

namespace MT.TacticWar.UI
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
        }        

        private Game GAME;
        private const int CellSize = 21;

        private void button3_Click(object sender, EventArgs e)
        {
            var mission = MissionLoader.LoadGame("missions\\Тесты\\");
            LoadMission(mission);
        }

        private void LoadMission(Mission mission)
        {
            // TODO: вернуть диалог с настройками перед миссией
            //using (var dialog = new DialogMissionSettings())
            {
                //if (dialog.ShowDialog() == DialogResult.OK)
                {
                    propertyGrid1.SelectedObject = null;
                    listInfoUnits.Items.Clear();
                    //StartSimulator(mission, dialog.Player1Name, dialog.Player2Name, dialog.Player1AI, dialog.Player2AI);
                    StartSimulator(mission, "", "", false, false);
                }
            }
        }

        private void StartSimulator(Mission mission, string plr0Name, string plr1Name, bool plr0AI, bool plr1AI)
        {
            try
            {
                GAME = new Game(mission, plr0Name, plr1Name, plr0AI, plr1AI);

                var resize = ResizeControls(GAME.Mission.Map.Width, GAME.Mission.Map.Height);

                var graphics = new GameGraphics(gameMap.CreateGraphics(), CellSize);
                GAME.InitGraphics(graphics);

                if (!resize)
                {
                    // TODO: исправить двойное обновление картинки при первой загрузке
                    GAME.DrawAll();

                    // TODO: показ брифинга
                    //MessageBox.Show(GAME.Mission.mBriefing, "Брифинг");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ResizeControls(int mapWidth, int mapHeight)
        {
            int widthOld = gameMap.Width;
            int heightOld = gameMap.Height;
            int widthNew = mapWidth * CellSize + 2;
            int heightNew = mapHeight * CellSize + 2;

            gameMap.Width = widthNew;
            gameMap.Height = heightNew;

            bool resize = false;
            int formWidth = gameMap.Width + propertyGrid1.Width + 50;
            int formHeight = gameMap.Height + 80;
            if (Width != formWidth || Height != formHeight)
            {
                Width = formWidth;
                Height = formHeight;
                resize = true;
            }

            if (heightOld != gameMap.Height)
                Top -= Math.Abs(heightOld - gameMap.Height + 80) / 2;

            if (widthOld != gameMap.Width)
                Left -= Math.Abs(widthOld - gameMap.Width + 50) / 2;

            return resize;
        }

        private void gameMap_MouseClick(object sender, MouseEventArgs e)
        {
            //если нажатие не левой кнопкой
            if (e.Button != MouseButtons.Left)
            {
                GAME.DeselectAll();
                ClearSelectedObjectInfo();
            }
            else
            {
                Signal signal;

                signal = GAME.ZonaClick(e.X, e.Y);

                //если собрана информация о юните
                switch (signal)
                {
                    case Signal.READY_UNIT_INFO:
                        ShowSelectedObjectInfo();
                        break;
                    case Signal.ATTACK:
                        BattleDivisionVsDivision();
                        break;
                }
            }
        }

        private void ShowSelectedObjectInfo()
        {
            ClearSelectedObjectInfo();

            if (null != GAME.SelectedDivision)
            {
                propertyGrid1.SelectedObject = new DivisionInfo(GAME.SelectedDivision);

                foreach (var unit in GAME.SelectedDivision.Units)
                {
                    listInfoUnits.Items.Add($"{unit.Name} ({unit.Health}%)");
                }
            }
            else if (null != GAME.SelectedBuilding)
            {
                propertyGrid1.SelectedObject = new BuildingInfo(GAME.SelectedBuilding);
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
                    GAME.AttackInfo.DivisionAttacker,
                    GAME.AttackInfo.DivisionDefender
                );

                if (DialogResult.OK == dialog.ShowDialog())
                {
                    // TODO: реализовать поддержку
                    var result = GAME.BattleBegin(
                        GAME.AttackInfo.DivisionAttacker,
                        GAME.AttackInfo.DivisionDefender,
                        new List<Division>(),
                        new List<Division>(),
                        GAME.AttackInfo.BuildingToCapture
                    );

                    switch (result)
                    {
                        case BattleResult.Win:
                            dialog.SetResultWin(GAME.AttackInfo.DivisionAttacker);
                            ShowSelectedObjectInfo();
                            break;
                        case BattleResult.Lose:
                            dialog.SetResultLose(GAME.AttackInfo.DivisionDefender);
                            ClearSelectedObjectInfo();
                            break;
                        case BattleResult.Draw:
                            dialog.SetResultDraw(GAME.AttackInfo.DivisionAttacker, GAME.AttackInfo.DivisionDefender);
                            ShowSelectedObjectInfo();
                            break;
                    }

                    // показываем диалог с результатами битвы
                    dialog.ShowDialog();
                }
                else
                {
                    GAME.BattleRecede(GAME.AttackInfo.DivisionAttacker);

                    // TODO: показываем диалог с результатами битвы
                    //dialog.ShowDialog();
                }
            }

            //перерисовываем поле боя
            GAME.DrawAll();
        }

        private void gameMap_Paint(object sender, PaintEventArgs e)
        {
            if (GAME != null)
                GAME.DrawAll();
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
                GAME.PassStep();

                MessageBox.Show(
                    $"Ход игрока {GAME.PlayerCurrent}",
                    "Начало хода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                gameMap.Visible = true;
            }
        }
    }
}

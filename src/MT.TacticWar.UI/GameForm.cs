using System;
using System.Drawing;
using GDIGraphics = System.Drawing.Graphics;
using System.Windows.Forms;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Serialization;
using MT.TacticWar.Gameplay;
using MT.TacticWar.Gameplay.Battles;
using MT.TacticWar.UI.Dialogs;
using MT.TacticWar.UI.Graphics;

namespace MT.TacticWar.UI
{
    public partial class GameForm : Form
    {
        private const int CellSize = 21;
        private Game GAME;
        private bool gameloaded = false;

        public GameForm()
        {
            InitializeComponent();
        }        

        private void RunStateFormLoaded()
        {
            gameMap.Enabled = false;
            btnEndStep.Enabled = false;
            gameloaded = false;
            DrawString(gameMap.CreateGraphics(), "Игра окончена", gameMap.Width / 2, gameMap.Height / 2);
        }

        private void RunStateMissionLoaded()
        {
            gameMap.Enabled = true;
            btnEndStep.Enabled = true;
        }

        private void DrawString(GDIGraphics grf, string text, float x, float y)
        {
            using (var drawFont = new Font("Consolas", 10))
            {
                var stringSize = grf.MeasureString(text, drawFont);
                var width = stringSize.Width;
                var height = stringSize.Height;
                x -= width / 2;
                y -= height / 2;

                var rect = new RectangleF(x, y, width, height);
                using (var brush = new SolidBrush(Color.LightGray))
                {
                    grf.FillRectangle(brush, rect);
                }
                using (var brush = new SolidBrush(Color.Black))
                {
                    grf.DrawString(text, drawFont, brush, rect);
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //button3_Click(null, null);
            RunStateFormLoaded();
            menuMisLoad_Click(sender, e);
        }

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
                    RunStateMissionLoaded();
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
                var interaction = new GameInteration();
                GAME.InitInteraction(interaction);

                //if (!resize)
                {
                    // TODO: исправить двойное обновление картинки при первой загрузке
                    GAME.Start();
                    gameloaded = true;
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
                int x = e.X / CellSize;
                int y = e.Y / CellSize;

                var signal = GAME.ZonaClick(x, y);
                AnalizeSignals(signal);
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
                    GAME.AttackInfo.DivisionDefender,
                    GAME.AttackInfo.SupportDivisionsAttacker,
                    GAME.AttackInfo.SupportDivisionsDefender
                );

                if (DialogResult.OK == dialog.ShowDialog())
                {
                    // TODO: реализовать поддержку
                    var result = GAME.BattleBegin(
                        GAME.AttackInfo.DivisionAttacker,
                        GAME.AttackInfo.DivisionDefender,
                        GAME.AttackInfo.SupportDivisionsAttacker,
                        GAME.AttackInfo.SupportDivisionsDefender,
                        GAME.AttackInfo.BuildingToCapture
                    );

                    switch (result)
                    {
                        case BattleResult.Win:
                            dialog.SetResultWin(
                                GAME.AttackInfo.DivisionAttacker,
                                GAME.AttackInfo.SupportDivisionsAttacker,
                                GAME.AttackInfo.SupportDivisionsDefender);
                            ShowSelectedObjectInfo();
                            break;
                        case BattleResult.Lose:
                            dialog.SetResultLose(
                                GAME.AttackInfo.DivisionDefender,
                                GAME.AttackInfo.SupportDivisionsAttacker,
                                GAME.AttackInfo.SupportDivisionsDefender);
                            ClearSelectedObjectInfo();
                            break;
                        case BattleResult.Draw:
                            dialog.SetResultDraw(
                                GAME.AttackInfo.DivisionAttacker,
                                GAME.AttackInfo.DivisionDefender,
                                GAME.AttackInfo.SupportDivisionsAttacker,
                                GAME.AttackInfo.SupportDivisionsDefender);
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
            if (gameloaded)
                GAME.DrawAll();
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
                // проверка до перехода хода
                var signal = GAME.AnalizeSituation();
                if (!AnalizeSignals(signal))
                {
                    gameMap.Visible = false;
                    GAME.NextPlayer();

                    MessageBox.Show(
                        $"Ход игрока {GAME.Mission.CurrentPlayer.Name}",
                        "Начало хода",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    gameMap.Visible = true;

                    // проверка после перехода хода
                    signal = GAME.AnalizeSituation();
                    AnalizeSignals(signal);
                }
            }
        }

        private bool AnalizeSignals(Signal signal)
        {
            bool gamestop = false;
            switch (signal)
            {
                case Signal.READY_UNIT_INFO:
                    ShowSelectedObjectInfo();
                    break;
                case Signal.ATTACK:
                    BattleDivisionVsDivision();
                    break;
                case Signal.GAMEOVER:
                    RunStateFormLoaded();
                    gamestop = true;
                    break;
            }
            return gamestop;
        }
    }
}

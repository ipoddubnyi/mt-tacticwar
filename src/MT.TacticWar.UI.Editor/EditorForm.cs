using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Base.Landscape;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Serialization;
using MT.TacticWar.UI.Editor.Dialogs;
using MT.TacticWar.UI.Editor.Painters;
using MT.TacticWar.UI.Graphics;

namespace MT.TacticWar.UI.Editor
{
    public partial class EditorForm : Form
    {
        private static Color PANEL_CLEAR_COLOR = Color.FromKnownColor(KnownColor.Control);

        private const int CellSize = 21;
        private Mission SelectedMission = null;
        private Map SelectedMap = null;
        private string SelectedMapSchema = "summer";
        private Division SelectedDivision = null;
        private GameGraphics graphics = null;
        private GameGraphics graphicsPreview = null;
        private IPainter painter = null;

        public EditorForm()
        {
            InitializeComponent();

            TabControlLeft.TabPages.Remove(TabMissionInfo);
            TabControlLeft.TabPages.Remove(TabPlayers);
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
        }

        private void TreeViewLoadMap(string schema)
        {
            TreeViewElements.Nodes.Clear();

            var node = new TreeNode("Указатель");
            TreeViewElements.Nodes.Add(node);

            node = new TreeNode("Ландшафт");
            node.Expand();

            var cells = LandscapeFactory.GetAvailableCells(schema);
            foreach (var cell in cells)
            {
                var subnode = new TreeNode(cell.Key)
                {
                    Tag = new TreeViewNodeSelector(() => { SelectDrawCellType(cell.Value); })
                };
                node.Nodes.Add(subnode);
            }

            TreeViewElements.Nodes.Add(node);

            node = new TreeNode("Проходимость")
            {
                Tag = new TreeViewNodeSelector(() => { DrawUnpassableShow(); })
            };
            var subnode2 = new TreeNode("Непроходимая зона")
            {
                Tag = new TreeViewNodeSelector(() => { SelectDrawPassability(false); })
            };
            node.Nodes.Add(subnode2);
            subnode2 = new TreeNode("Проходимая зона")
            {
                Tag = new TreeViewNodeSelector(() => { SelectDrawPassability(true); })
            };
            node.Nodes.Add(subnode2);
            node.Expand();
            TreeViewElements.Nodes.Add(node);
        }

        private void TreeViewAddMission()
        {
            var node = new TreeNode("Объекты игроков");

            var subnode = new TreeNode("Подразделение")
            {
                Tag = new TreeViewNodeSelector(SelectShowDialogDivisionNew)
            };
            node.Nodes.Add(subnode);

            subnode = new TreeNode("Строение")
            {
                //Tag = new TreeViewNodeSelector(SelectShowDialogDivisionNew)
            };
            node.Nodes.Add(subnode);

            node.Expand();
            TreeViewElements.Nodes.Add(node);
        }

        private void SelectDrawCellType(char cellType)
        {
            var cell = LandscapeFactory.CreateCell(SelectedMapSchema, cellType, 1, 1);
            //graphics.DrawCell(cell);
            graphicsPreview.DrawCell(cell);
            painter = new LanscapePainter(graphics, SelectedMap, SelectedMapSchema, cellType);
        }

        private void SelectDrawPassability(bool passable)
        {
            DrawUnpassableShow();
            painter = new PassabilityPainter(graphics, SelectedMap, passable);
        }

        private void SelectShowDialogDivisionSelect()
        {
            panelDivision.Visible = true;
            selector = true;
        }

        private void SelectShowDialogDivisionNew()
        {
            panelDivision.Visible = true;
        }

        private void MenuFileCreateMap_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogMapNew())
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    var cells = new Cell[dialog.MapSizeWidth, dialog.MapSizeHeight];
                    for (int y = 0; y < dialog.MapSizeHeight; ++y)
                    {
                        for (int x = 0; x < dialog.MapSizeWidth; ++x)
                        {
                            cells[x, y] = LandscapeFactory.CreateCell(dialog.MapSchema, '-', x, y);
                        }
                    }

                    SelectedMap = new Map(dialog.MapName, dialog.MapSizeWidth, dialog.MapSizeHeight, cells);
                    SelectedMapSchema = dialog.MapSchema;
                    ResizeControls(PanelEditor, SelectedMap.Width, SelectedMap.Height);
                    graphics = new GameGraphics(PanelEditor.CreateGraphics(), CellSize);
                    graphicsPreview = new GameGraphics(PanelElementPreview.CreateGraphics(), CellSize);
                    TreeViewLoadMap(SelectedMapSchema);

                    txtMapName.Text = dialog.MapName;
                    txtMapDescription.Text = dialog.MapDescription;
                    lblMapSize.Text = $"Размер карты: {dialog.MapSizeWidth}x{dialog.MapSizeHeight}";
                    lblMapSchema.Text = $"Схема карты: {dialog.MapSchema}";

                    DrawAll();
                }
            }
        }

        private void MenuFileOpenMap_Click(object sender, EventArgs e)
        {
            string misFolderPath = @"missions\Дорога";
            SelectedMission = MissionLoader.LoadGame(misFolderPath);
            SelectedMap = SelectedMission.Map;
            SelectedMapSchema = "summer"; // TODO

            ResizeControls(PanelEditor, SelectedMap.Width, SelectedMap.Height);
            graphics = new GameGraphics(PanelEditor.CreateGraphics(), CellSize);
            graphicsPreview = new GameGraphics(PanelElementPreview.CreateGraphics(), CellSize);
            TreeViewLoadMap(SelectedMapSchema);

            txtMapName.Text = SelectedMap.Name;
            txtMapDescription.Text = "";
            lblMapSize.Text = $"Размер карты: {SelectedMap.Width}x{SelectedMap.Height}";
            lblMapSchema.Text = "Схема карты: -";

            DrawAll();
        }

        private void MenuFileCreateMission_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogMissionNew())
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    int playersCount = 2;
                    var players = new Player[playersCount];
                    players[0] = new Player(0, "Игрок 1", 1, "green", Core.Players.PlayerRank.Soldier, 0, false);
                    players[1] = new Player(1, "Игрок 2", 2, "red", Core.Players.PlayerRank.Soldier, 0, false);

                    SelectedMission = new Mission(dialog.MissionName, dialog.MissionBriefing, players, SelectedMap);

                    TreeViewAddMission();
                    TabControlLeft.TabPages.Add(TabMissionInfo);
                    TabControlLeft.TabPages.Add(TabPlayers);

                    txtMissionName.Text = dialog.MissionName;
                    txtMissionBriefing.Text = dialog.MissionBriefing;
                    comboPlayersCount.SelectedItem = playersCount.ToString();

                    comboDivisionPlayer.DataSource = new BindingSource(SelectedMission.Players, null);
                }
            }
        }

        private void DrawAll()
        {
            graphics.DrawMap(SelectedMap);
        }

        private void DrawUnpassableShow()
        {
            for (int y = 0; y < SelectedMap.Height; ++y)
            {
                for (int x = 0; x < SelectedMap.Width; ++x)
                {
                    if (!SelectedMap[x, y].Passable)
                    {
                        graphics.DrawCross(new Coordinates(x, y));
                    }
                }
            }
        }

        private void DrawUnpassableHide()
        {
            for (int y = 0; y < SelectedMap.Height; ++y)
            {
                for (int x = 0; x < SelectedMap.Width; ++x)
                {
                    if (!SelectedMap[x, y].Passable)
                    {
                        graphics.DrawCell(SelectedMap[x, y]);
                    }
                }
            }
        }

        private bool ResizeControls(Panel gameMap, int mapWidth, int mapHeight)
        {
            int widthOld = gameMap.Width;
            int heightOld = gameMap.Height;
            int widthNew = mapWidth * CellSize + 2;
            int heightNew = mapHeight * CellSize + 2;

            gameMap.Width = widthNew;
            gameMap.Height = heightNew;

            bool resize = false;
            int formWidth = gameMap.Width + SplitContainerMain.Panel1.Width;
            int formHeight = gameMap.Height + 100;
            if (Width != formWidth || Height != formHeight)
            {
                Width = formWidth;
                Height = formHeight;
                resize = true;
            }

            /*if (heightOld != gameMap.Height)
                Top -= Math.Abs(heightOld - gameMap.Height + 80) / 2;

            if (widthOld != gameMap.Width)
                Left -= Math.Abs(widthOld - gameMap.Width + 50) / 2;*/

            return resize;
        }

        private void EditorForm_Paint(object sender, PaintEventArgs e)
        {
        }

        private void PanelEditor_Paint(object sender, PaintEventArgs e)
        {
            if (null != SelectedMap)
                DrawAll();
        }

        private void TreeViewElements_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            panelDivision.Visible = false;
            painter = null;
            selector = false;
            DrawUnpassableHide();
        }

        private void TreeViewElements_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (null != graphicsPreview)
            {
                graphicsPreview.Clear(PANEL_CLEAR_COLOR);
                if (null != e.Node.Tag)
                {
                    if (e.Node.Tag is TreeViewNodeSelector)
                    {
                        (e.Node.Tag as TreeViewNodeSelector).Select();
                    }
                }
            }
        }

        private void PanelEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if (null == painter)
                return;

            if (!painter.IsActive())
                return;

            int x = e.X / CellSize;
            int y = e.Y / CellSize;

            if (x < 0 || x > SelectedMap.Width - 1)
                return;

            if (y < 0 || y > SelectedMap.Height - 1)
                return;

            if (painter.TryMove(x, y))
            {
                StatusCoordinates.Text = $"{x}, {y}";
                painter.Paint();
            }
        }

        private void PanelEditor_MouseLeave(object sender, EventArgs e)
        {
            if (null == painter)
                return;

            StatusCoordinates.Text = "";
        }

        private void PanelEditor_MouseDown(object sender, MouseEventArgs e)
        {
            if (null != painter)
            {
                int x = e.X / CellSize;
                int y = e.Y / CellSize;

                if (x < 0 || x > SelectedMap.Width - 1)
                    return;

                if (y < 0 || y > SelectedMap.Height - 1)
                    return;

                painter.Start(x, y);
                painter.Paint();
            }
            else if (selector)
            {
                int x = e.X / CellSize;
                int y = e.Y / CellSize;

                if (x < 0 || x > SelectedMap.Width - 1)
                    return;

                if (y < 0 || y > SelectedMap.Height - 1)
                    return;

                var division = SelectedMission.GetDivisionAt(x, y);
                if (null != division)
                {
                    SelectedDivision = division;
                    graphics.DrawDivision(SelectedDivision, true);
                    return;
                }

                /*var building = SelectedMission.GetBuildingAt(x, y);
                if (null != building)
                {
                    SelectedBuilding = building;
                    return;
                }*/
            }
        }

        bool selector = false;

        private void PanelEditor_MouseUp(object sender, MouseEventArgs e)
        {
            painter?.Stop();
        }

        private void PanelEditor_MouseClick(object sender, MouseEventArgs e)
        {
            if (null == SelectedMission)
                return;

            if (null != painter)
            {
                if (MouseButtons.Right == e.Button)
                    painter = null;

                return;
            }

            int x = e.X / CellSize;
            int y = e.Y / CellSize;

            if (x < 0 || x > SelectedMap.Width - 1)
                return;

            if (y < 0 || y > SelectedMap.Height - 1)
                return;

            var division = SelectedMission.GetDivisionAt(x, y);
            if (null != division)
            {
                if (MouseButtons.Left == e.Button)
                {
                    SelectedDivision = division;
                    graphics.DrawDivision(SelectedDivision, true);
                }
                else if (MouseButtons.Right == e.Button)
                {
                    contextMenuDivision.Tag = division;
                    contextMenuDivision.Show(Cursor.Position);
                }
            }

            /*var building = SelectedMission.GetBuildingAt(x, y);
            if (null != building)
            {
                SelectedBuilding = building;
                return;
            }*/
        }

        private void MenuFileSaveMap_Click(object sender, EventArgs e)
        {
            try
            {
                if (null != SelectedMap)
                {
                    var filePath = @"test\map";
                    MissionSaver.SaveMap(
                        filePath,
                        SelectedMap,
                        "Тест",
                        "Тестирование сохранения",
                        SelectedMapSchema,
                        "1.0"
                    );

                    MessageBox.Show("Сохранено.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPlayerColor_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorSelectDialog.ShowDialog())
            {
                btnPlayerColor.BackColor = colorSelectDialog.Color;
            }
        }

        //

        private void BtnDivisionCreate_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogDivisionEditor())
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    SelectedDivision = dialog.ResultDivision;

                    painter = new DivisionPainter(graphics, SelectedMap,
                        SelectedDivision,
                        (comboDivisionPlayer.SelectedItem as Player),
                        (int)numDivisionId.Value,
                        txtDivisionName.Text
                    );
                }
            }
        }

        private void BtnDivisionUpdate_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogDivisionEditor(SelectedDivision))
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    SelectedDivision = dialog.ResultDivision;

                    painter = new DivisionPainter(graphics, SelectedMap,
                        SelectedDivision,
                        (comboDivisionPlayer.SelectedItem as Player),
                        (int)numDivisionId.Value,
                        txtDivisionName.Text
                    );
                }
            }
        }

        private void ContextMenuDivisionEdit_Click(object sender, EventArgs e)
        {
            if (null != contextMenuDivision.Tag)
            {
                var division = contextMenuDivision.Tag as Division;
                using (var dialog = new DialogDivisionEditor(division))
                {
                    if (DialogResult.OK == dialog.ShowDialog())
                    {
                        division = dialog.ResultDivision;
                    }
                }
            }
        }

        private void ContextMenuDivisionDelete_Click(object sender, EventArgs e)
        {
            if (null != contextMenuDivision.Tag)
            {
                var division = contextMenuDivision.Tag as Division;
                division.Destroy();
                graphics.DrawCell(SelectedMap[division.Position]);
            }
        }

        private void ComboDivisionPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: избавиться от повторов.
            // Лучше свойства подразделения вынести в UserControl.
            if (null != SelectedDivision)
            {
                painter = new DivisionPainter(graphics, SelectedMap,
                    SelectedDivision,
                    (comboDivisionPlayer.SelectedItem as Player),
                    (int)numDivisionId.Value,
                    txtDivisionName.Text
                );
            }
        }

        private void NumDivisionId_ValueChanged(object sender, EventArgs e)
        {
            if (null != SelectedDivision)
            {
                painter = new DivisionPainter(graphics, SelectedMap,
                    SelectedDivision,
                    (comboDivisionPlayer.SelectedItem as Player),
                    (int)numDivisionId.Value,
                    txtDivisionName.Text
                );
            }
        }

        private void TxtDivisionName_TextChanged(object sender, EventArgs e)
        {
            if (null != SelectedDivision)
            {
                painter = new DivisionPainter(graphics, SelectedMap,
                    SelectedDivision,
                    (comboDivisionPlayer.SelectedItem as Player),
                    (int)numDivisionId.Value,
                    txtDivisionName.Text
                );
            }
        }
    }
}

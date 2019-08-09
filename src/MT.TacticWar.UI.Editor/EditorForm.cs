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
using MT.TacticWar.Core.Serialization;
using MT.TacticWar.UI.Editor.Dialogs;
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
        private GameGraphics graphics = null;
        private GameGraphics graphicsPreview = null;
        private LanscapePainter painter = null;

        public EditorForm()
        {
            InitializeComponent();

            TabControlLeft.TabPages.Remove(TabMissionInfo);
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
        }

        private void TreeViewLoadMap(string schema)
        {
            TreeViewElements.Nodes.Clear();

            var node = new TreeNode("Обычный курсор");
            TreeViewElements.Nodes.Add(node);

            node = new TreeNode("Ландшафт");
            node.Expand();

            var cells = LandscapeFactory.GetAvailableCells(schema);
            foreach (var cell in cells)
            {
                var subnode = new TreeNode(cell.Key)
                {
                    Tag = cell.Value
                };
                node.Nodes.Add(subnode);
            }

            TreeViewElements.Nodes.Add(node);
        }

        private void TreeViewAddMission()
        {
            var node = new TreeNode("Строения");
            var subnode = new TreeNode("Новое строение");
            node.Nodes.Add(subnode);
            node.Expand();
            TreeViewElements.Nodes.Add(node);

            node = new TreeNode("Подразделения");
            subnode = new TreeNode("Новое подразделение");
            subnode.Tag = new DialogDivisionNew();
            node.Nodes.Add(subnode);
            node.Expand();
            TreeViewElements.Nodes.Add(node);
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

                    painter = new LanscapePainter(SelectedMapSchema, SelectedMap, graphics);

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

            painter = new LanscapePainter(SelectedMapSchema, SelectedMap, graphics);

            DrawAll();
        }

        private void MenuFileCreateMission_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogMissionNew())
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    var players = new Player[dialog.PlayersCount];
                    for (int i = 0; i < dialog.PlayersCount; ++i)
                    {
                        players[i] = new Player(i, "", 0, "", Core.Players.PlayerRank.Soldier, 0, false);
                    }

                    SelectedMission = new Mission(dialog.MissionName, dialog.MissionBriefing, players, SelectedMap);

                    TreeViewAddMission();
                    TabControlLeft.TabPages.Add(TabMissionInfo);

                    txtMissionName.Text = dialog.MissionName;
                    txtMissionBriefing.Text = dialog.MissionBriefing;
                    comboPlayersCount.SelectedItem = dialog.PlayersCount.ToString();

                    //painter = new LanscapePainter(SelectedMapSchema, SelectedMap, graphics);
                }
            }
        }

        private void DrawAll()
        {
            graphics.DrawMap(SelectedMap);
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

        private void TreeViewElements_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (null != graphicsPreview)
            {
                graphicsPreview.Clear(PANEL_CLEAR_COLOR);
                if (null != e.Node.Tag)
                {
                    if (e.Node.Tag is char)
                    {
                        var cellType = (char)e.Node.Tag;
                        var cell = LandscapeFactory.CreateCell(SelectedMapSchema, cellType, 1, 1);
                        //graphics.DrawCell(cell);

                        graphicsPreview.DrawCell(cell);
                    }
                    else if (e.Node.Tag is DialogDivisionNew)
                    {
                        var dialog = e.Node.Tag as DialogDivisionNew;
                        if (DialogResult.OK == dialog.ShowDialog())
                        {
                            //
                        }
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
            if (null == SelectedMap)
                return;

            if (null != TreeViewElements.SelectedNode)
            {
                var node = TreeViewElements.SelectedNode;
                if (null != node.Tag)
                {
                    int x = e.X / CellSize;
                    int y = e.Y / CellSize;

                    if (x < 0 || x > SelectedMap.Width - 1)
                        return;

                    if (y < 0 || y > SelectedMap.Height - 1)
                        return;

                    painter.Start((char)node.Tag, x, y);
                    painter.Paint();
                }
            }
        }

        private void PanelEditor_MouseUp(object sender, MouseEventArgs e)
        {
            painter?.Stop();
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
    }
}

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
using MT.TacticWar.Core.Serialization;
using MT.TacticWar.UI.Graphics;

namespace MT.TacticWar.UI.Editor
{
    public partial class EditorForm : Form
    {
        private static Color PANEL_CLEAR_COLOR = Color.FromKnownColor(KnownColor.Control);

        private const int CellSize = 21;
        private Mission SelectedMission = null;
        private GameGraphics graphics = null;
        private GameGraphics graphicsPreview = null;

        public EditorForm()
        {
            InitializeComponent();
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
        }

        private void TreeViewElementsLoad()
        {
            TreeViewElements.Nodes.Clear();

            var node = new TreeNode("Ландшафт");
            node.Expand();

            var cells = LandscapeFactory.GetAvailable();
            foreach (var cell in cells)
            {
                var subnode = new TreeNode(cell.Key)
                {
                    Tag = cell.Value
                };
                node.Nodes.Add(subnode);
            }

            TreeViewElements.Nodes.Add(node);

            node = new TreeNode("Строения");
            TreeViewElements.Nodes.Add(node);

            node = new TreeNode("Подразделения");
            TreeViewElements.Nodes.Add(node);
        }

        private void MenuFileCreateMap_Click(object sender, EventArgs e)
        {
            string misFolderPath = @"missions\Дорога";
            SelectedMission = MissionLoader.LoadGame(misFolderPath);

            ResizeControls(PanelEditor, SelectedMission.Map.Width, SelectedMission.Map.Height);
            graphics = new GameGraphics(PanelEditor.CreateGraphics(), CellSize);
            graphicsPreview = new GameGraphics(PanelElementPreview.CreateGraphics(), CellSize);
            TreeViewElementsLoad();

            DrawAll();
        }

        private void DrawAll()
        {
            graphics.DrawMap(SelectedMission.Map);
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
            if (null != SelectedMission)
                DrawAll();
        }

        private void TreeViewElements_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (null != graphicsPreview)
            {
                graphicsPreview.Clear(PANEL_CLEAR_COLOR);
                if (null != e.Node.Tag)
                {
                    var cellType = (char)e.Node.Tag;
                    var cell = LandscapeFactory.CreateCell("summer", cellType, 1, 1);
                    //graphics.DrawCell(cell);

                    graphicsPreview.DrawCell(cell);
                }
            }
        }

        private void PanelEditor_Click(object sender, EventArgs e)
        {
            if (null != TreeViewElements.SelectedNode)
            {
                var node = TreeViewElements.SelectedNode;
                if (null != node.Tag)
                {

                    int x = ((MouseEventArgs)e).X / CellSize;
                    int y = ((MouseEventArgs)e).Y / CellSize;

                    var cellType = (char)node.Tag;
                    var cell = LandscapeFactory.CreateCell("summer", cellType, x, y);

                    SelectedMission.Map.SetCell(x, y, cell);
                    graphics.DrawCell(cell);
                }
            }
        }

        private void PanelEditor_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X / CellSize;
            int y = e.Y / CellSize;
            StatusCoordinates.Text = $"{x}, {y}";
        }

        private void PanelEditor_MouseLeave(object sender, EventArgs e)
        {
            StatusCoordinates.Text = "";
        }

        private void MenuFileSaveMap_Click(object sender, EventArgs e)
        {
            try
            {
                if (null != SelectedMission)
                {
                    var filePath = @"test\map";
                    MissionSaver.SaveMap(
                        filePath,
                        SelectedMission.Map,
                        "Тест",
                        "Тестирование сохранения",
                        "summer",
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

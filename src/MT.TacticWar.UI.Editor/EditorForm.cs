using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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
        private MapEditor SelectedMap = null;
        private MissionEditor SelectedMission = null;
        private DivisionEditor SelectedDivision = null;
        private BuildingEditor SelectedBuilding = null;
        private GameGraphics graphics = null;
        private GameGraphics graphicsPreview = null;
        private IPainter painter = null;
        private bool selector = false;

        private string FilePathMap;
        private string FilePathMission;

        public EditorForm()
        {
            InitializeComponent();

            divisionProperties.Changed += DivisionProperties_Changed;
            buildingProperties.Changed += BuildingProperties_Changed;
            TabControlLeft.TabPages.Remove(TabMissionInfo);
            TabControlLeft.TabPages.Remove(TabMapInfo);
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
        }

        private void UpdateUI(Schema schema, bool missionload = false)
        {
            UpdateUIClear();
            UpdateUIMap(schema);

            if (missionload)
            {
                UpdateUIMission();
            }

            DrawAll();
        }

        private void UpdateUIClear()
        {
            TreeViewElements.Nodes.Clear();
            TabControlLeft.TabPages.Remove(TabMissionInfo);
            TabControlLeft.TabPages.Remove(TabMapInfo);
            SelectedDivision = null;
            SelectedBuilding = null;
        }

        private void UpdateUIMap(Schema schema)
        {
            // показать элементы дерева
            var node = new TreeNode("Указатель")
            {
                Tag = new TreeViewNodeSelector(() => { SelectSelection(); })
            };
            TreeViewElements.Nodes.Add(node);

            node = new TreeNode("Ландшафт");
            node.Expand();

            var cells = LandscapeFactory.GetAvailableCellsForSchema(schema);
            foreach (var cell in cells)
            {
                var subnode = new TreeNode(cell.ToString())
                {
                    Tag = new TreeViewNodeSelector(() => { SelectDrawCellType(cell); })
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

            // показать таб
            TabControlLeft.TabPages.Add(TabMapInfo);

            // показать информацию на табе
            SetMapInfo(SelectedMap);
        }

        private void UpdateUIMission()
        {
            // показать элементы дерева
            var node = new TreeNode("Объекты игроков");

            var subnode = new TreeNode("Подразделение")
            {
                Tag = new TreeViewNodeSelector(SelectShowDialogDivisionNew)
            };
            node.Nodes.Add(subnode);

            subnode = new TreeNode("Строение")
            {
                Tag = new TreeViewNodeSelector(SelectShowDialogBuildingNew)
            };
            node.Nodes.Add(subnode);

            node.Expand();
            TreeViewElements.Nodes.Add(node);

            // показать таб
            TabControlLeft.TabPages.Add(TabMissionInfo);

            // показать информацию на табе
            SetMissionInfo(SelectedMission);
        }

        private void SelectSelection()
        {
            selector = true;
        }

        private void SelectDrawCellType(CellVariant cellvar)
        {
            var cell = cellvar.Create(1, 1);
            //graphics.DrawCell(cell);
            graphicsPreview.DrawCell(cell);
            painter = new LanscapePainter(graphics, SelectedMap, SelectedMap.Schema, cellvar.Code);
        }

        private void SelectDrawPassability(bool passable)
        {
            DrawUnpassableShow();
            painter = new PassabilityPainter(graphics, SelectedMap, passable);
        }

        private void SelectShowDialogDivisionNew()
        {
            panelDivision.Visible = true;
        }

        private void SelectShowDialogBuildingNew()
        {
            panelBuilding.Visible = true;
        }

        private void SetMapInfo(MapEditor map)
        {
            txtMapName.Text = map.Name;
            txtMapDescription.Text = map.Description;
            txtMapVersion.Text = "1.0";
            lblMapSize.Text = $"Размер карты: {map.Width}x{map.Height}";
            lblMapSchema.Text = $"Схема карты: {map.Schema}";
        }

        private void SetMissionInfo(MissionEditor mission)
        {
            txtMissionName.Text = mission.Name;
            txtMissionBriefing.Text = mission.Briefing;

            divisionProperties.SetPlayersDataSource(mission.Players);
            buildingProperties.SetPlayersDataSource(mission.Players);
        }

        private void DrawAll()
        {
            graphics.DrawMap(SelectedMap);
            if (null != SelectedMission)
                graphics.DrawPlayersObjects(SelectedMission.Players, null, null);
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
            /*int formWidth = gameMap.Width + SplitContainerMain.Panel1.Width;
            int formHeight = gameMap.Height + 100;
            if (Width != formWidth || Height != formHeight)
            {
                Width = formWidth;
                Height = formHeight;
                resize = true;
            }*/

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
            panelBuilding.Visible = false;
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

            int x = e.X / CellSize;
            int y = e.Y / CellSize;

            if (x < 0 || x > SelectedMap.Width - 1)
                return;

            if (y < 0 || y > SelectedMap.Height - 1)
                return;

            StatusCoordinates.Text = $"{x}, {y}";

            if (!painter.IsActive())
                return;

            if (painter.TryMove(x, y))
            {
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
                    SelectedDivision = new DivisionEditor(division);
                    graphics.DrawDivision(SelectedDivision, true);
                    return;
                }

                var building = SelectedMission.GetBuildingAt(x, y);
                if (null != building)
                {
                    SelectedBuilding = new BuildingEditor(building);
                    graphics.DrawBuilding(SelectedBuilding, true);
                    return;
                }
            }
        }

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
                    SelectedDivision = new DivisionEditor(division);
                    ShowDivisionInfo(SelectedDivision);
                    graphics.DrawDivision(SelectedDivision, true);
                }
                else if (MouseButtons.Right == e.Button)
                {
                    // TODO: сделать, чтобы объект стирался
                    //contextMenuDivision.Tag = new DivisionEditor(division);
                    //contextMenuDivision.Show(Cursor.Position);
                }
                return;
            }

            var building = SelectedMission.GetBuildingAt(x, y);
            if (null != building)
            {
                if (MouseButtons.Left == e.Button)
                {
                    SelectedBuilding = new BuildingEditor(building);
                    lblSelectedBuildingStatus.Text = $"Строение: {SelectedBuilding.Name}";
                    graphics.DrawBuilding(SelectedBuilding, true);
                }
                else if (MouseButtons.Right == e.Button)
                {
                    // TODO: сделать, чтобы объект стирался
                    //contextMenuDivision.Tag = new BuildingEditor(building);
                    //contextMenuDivision.Show(Cursor.Position);
                }
                return;
            }
        }

        #region Меню Карта

        private void MenuMapNew_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogMapNew())
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    SelectedMap = new MapEditor(dialog.MapName, dialog.MapDescription, dialog.MapSizeWidth, dialog.MapSizeHeight, dialog.MapSchema.Code);

                    ResizeControls(PanelEditor, SelectedMap.Width, SelectedMap.Height);
                    graphics = new GameGraphics(PanelEditor.CreateGraphics(), CellSize);
                    graphicsPreview = new GameGraphics(PanelElementPreview.CreateGraphics(), CellSize);

                    UpdateUI(SelectedMap.Schema);
                }
            }
        }

        private void MenuMapOpen_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                dialog.RestoreDirectory = true;

                if (DialogResult.OK == dialog.ShowDialog())
                {
                    FilePathMap = dialog.FileName;
                    SelectedMap = new MapEditor(MissionLoader.LoadMap(dialog.FileName));

                    ResizeControls(PanelEditor, SelectedMap.Width, SelectedMap.Height);
                    graphics = new GameGraphics(PanelEditor.CreateGraphics(), CellSize);
                    graphicsPreview = new GameGraphics(PanelElementPreview.CreateGraphics(), CellSize);

                    UpdateUI(SelectedMap.Schema);
                }
            }
        }

        private void MenuMapSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(FilePathMap))
                {
                    MenuMapSaveAs_Click(sender, e);
                    return;
                }

                if (!ValidateSaveMap())
                    return;
                
                MissionSaver.SaveMap(
                    FilePathMap,
                    SelectedMap,
                    txtMapName.Text,
                    txtMapDescription.Text,
                    txtMapVersion.Text
                );

                MessageBox.Show(
                    "Карта успешно сохранена.",
                    "Сохранение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuMapSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateSaveMap())
                    return;

                using (var dialog = new SaveFileDialog())
                {
                    dialog.InitialDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                    dialog.RestoreDirectory = true;

                    if (DialogResult.OK != dialog.ShowDialog())
                        return;

                    FilePathMap = dialog.FileName;

                    MissionSaver.SaveMap(
                        FilePathMap,
                        SelectedMap,
                        txtMapName.Text,
                        txtMapDescription.Text,
                        txtMapVersion.Text
                    );

                    MessageBox.Show(
                        "Карта успешно сохранена.",
                        "Сохранение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateSaveMap()
        {
            try
            {
                if (null == SelectedMap)
                    throw new Exception("Карта не создана.");

                if (0 == txtMapName.Text.Length)
                    throw new Exception("Имя карты не может быть пустым.");

                if (!Version.TryParse(txtMapVersion.Text, out Version result))
                    throw new Exception("Версия карты задана в неверном формате.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        #endregion

        #region Меню Миссия

        private void MenuMissionNew_Click(object sender, EventArgs e)
        {
            if (null == SelectedMap)
            {
                MessageBox.Show("Сначала нужно создать/загрузить карту.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var dialog = new DialogMissionNew())
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    int playersCount = 2;
                    var players = new Player[playersCount];
                    players[0] = new Player(0, "Игрок 1", 1, "green", Core.Players.PlayerRank.Soldier, 0, false);
                    players[1] = new Player(1, "Игрок 2", 2, "red", Core.Players.PlayerRank.Soldier, 0, false);

                    SelectedMission = new MissionEditor(dialog.MissionName, dialog.MissionBriefing, players, SelectedMap);
                    UpdateUI(SelectedMap.Schema, true);
                }
            }
        }

        private void MenuMissionOpen_Click(object sender, EventArgs e)
        {
            if (null == SelectedMap)
            {
                MessageBox.Show("Сначала нужно создать/загрузить карту.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                dialog.RestoreDirectory = true;

                if (DialogResult.OK == dialog.ShowDialog())
                {
                    FilePathMission = dialog.FileName;
                    SelectedMission = new MissionEditor(MissionLoader.LoadMission(dialog.FileName, SelectedMap));
                    UpdateUI(SelectedMap.Schema, true);
                }
            }
        }

        private void MenuMissionSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(FilePathMission))
                {
                    MenuMissionSaveAs_Click(sender, e);
                    return;
                }

                if (!ValidateSaveMission())
                    return;

                MissionSaver.SaveMission(
                    FilePathMission,
                    SelectedMission,
                    txtMissionName.Text,
                    txtMissionBriefing.Text,
                    txtMissionVersion.Text
                );

                MessageBox.Show(
                    "Миссия успешно сохранена.",
                    "Сохранение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuMissionSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateSaveMission())
                    return;

                using (var dialog = new SaveFileDialog())
                {
                    dialog.InitialDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                    dialog.RestoreDirectory = true;

                    if (DialogResult.OK != dialog.ShowDialog())
                        return;

                    FilePathMission = dialog.FileName;

                    MissionSaver.SaveMission(
                        FilePathMission,
                        SelectedMission,
                        txtMissionName.Text,
                        txtMissionBriefing.Text,
                        txtMissionVersion.Text
                    );

                    MessageBox.Show(
                        "Миссия успешно сохранена.",
                        "Сохранение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuMissionCompile_Click(object sender, EventArgs e)
        {
            //
        }

        private bool ValidateSaveMission()
        {
            try
            {
                if (null == SelectedMission)
                    throw new Exception("Миссия не создана.");

                if (0 == txtMissionName.Text.Length)
                    throw new Exception("Имя миссии не может быть пустым.");

                if (!Version.TryParse(txtMissionVersion.Text, out Version result))
                    throw new Exception("Версия миссии задана в неверном формате.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        #endregion

        //

        /*private void ContextMenuDivisionEdit_Click(object sender, EventArgs e)
        {
            if (null != contextMenuDivision.Tag)
            {
                if (contextMenuDivision.Tag is DivisionEditor)
                {
                    var division = contextMenuDivision.Tag as DivisionEditor;
                    using (var dialog = new DialogDivisionEditor(division))
                    {
                        if (DialogResult.OK == dialog.ShowDialog())
                        {
                            contextMenuDivision.Tag = dialog.ResultDivision;
                        }
                    }
                }
                else if (contextMenuDivision.Tag is BuildingEditor)
                {
                    var bulding = contextMenuDivision.Tag as BuildingEditor;
                    using (var dialog = new DialogBuildingEditor(bulding))
                    {
                        if (DialogResult.OK == dialog.ShowDialog())
                        {
                            contextMenuDivision.Tag = dialog.ResultBuilding;
                        }
                    }
                }
            }
        }

        private void ContextMenuDivisionDelete_Click(object sender, EventArgs e)
        {
            if (null != contextMenuDivision.Tag)
            {
                if (contextMenuDivision.Tag is DivisionEditor)
                {
                    var division = contextMenuDivision.Tag as DivisionEditor;
                    division.Destroy();
                    graphics.DrawCell(SelectedMap[division.Position]);
                }
                else if (contextMenuDivision.Tag is BuildingEditor)
                {
                    var building = contextMenuDivision.Tag as BuildingEditor;
                    building.Destroy();
                    graphics.DrawCell(SelectedMap[building.Position]);
                }
            }
        }*/

        private void BtnDivisionCreate_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogDivisionEditor())
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    SelectedDivision = dialog.ResultDivision;
                    ShowDivisionInfo(SelectedDivision);

                    SelectedDivision.SetPlayer(divisionProperties.ObjectPlayer);
                    SelectedDivision.SetId(divisionProperties.ObjectId);
                    //SelectedDivision.SetName(divisionProperties.DivisionName);
                    divisionProperties.SetDivision(SelectedDivision);

                    painter = new DivisionPainter(graphics, SelectedMap, SelectedDivision);
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
                    ShowDivisionInfo(SelectedDivision);
                    divisionProperties.SetDivision(SelectedDivision);

                    painter = new DivisionPainter(graphics, SelectedMap, SelectedDivision);
                }
            }
        }

        private void BtnDivisionDelete_Click(object sender, EventArgs e)
        {
            //
        }

        private void ShowDivisionInfo(Division division)
        {
            var sb = new StringBuilder();

            sb.AppendLine(division.Type);
            sb.AppendLine();
            sb.AppendLine("Юниты:");
            foreach (var unit in division.Units)
            {
                sb.Append("- ");
                sb.AppendLine(unit.Name);
            }

            lblSelectedDivisionStatus.Text = sb.ToString();
        }

        private void DivisionProperties_Changed(object sender, EventArgs e)
        {
            if (null != SelectedDivision)
            {
                SelectedDivision.SetPlayer(divisionProperties.ObjectPlayer);
                SelectedDivision.SetId(divisionProperties.ObjectId);
                SelectedDivision.SetName(divisionProperties.ObjectName);

                painter = new DivisionPainter(graphics, SelectedMap, SelectedDivision);
            }
        }

        private void BtnBuildingCreate_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogBuildingEditor())
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    SelectedBuilding = dialog.ResultBuilding;
                    lblSelectedBuildingStatus.Text = $"Строение: {SelectedBuilding.Name}";

                    SelectedBuilding.SetPlayer(buildingProperties.ObjectPlayer);
                    SelectedBuilding.SetId(buildingProperties.ObjectId);
                    //SelectedBuilding.SetName(buildingProperties.DivisionName);
                    buildingProperties.SetBuilding(SelectedBuilding);

                    painter = new BuildingPainter(graphics, SelectedMap, SelectedBuilding);
                }
            }
        }

        private void BtnBuildingUpdate_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogBuildingEditor(SelectedBuilding))
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    SelectedBuilding = dialog.ResultBuilding;
                    lblSelectedBuildingStatus.Text = $"Строение: {SelectedBuilding.Name}";
                    buildingProperties.SetBuilding(SelectedBuilding);

                    painter = new BuildingPainter(graphics, SelectedMap, SelectedBuilding);
                }
            }
        }

        private void BtnBuildingDelete_Click(object sender, EventArgs e)
        {
            //
        }

        private void ShowBuildingInfo(Building building)
        {
            var sb = new StringBuilder();

            sb.AppendLine(building.Type);
            sb.AppendLine();
            if (building.IsSecured)
            {
                sb.AppendLine("Охранение:");
                sb.AppendLine(building.SecurityDivision.Type);
            }
            else
            {
                sb.AppendLine("Без охранения");
            }

            lblSelectedBuildingStatus.Text = sb.ToString();
        }

        private void BuildingProperties_Changed(object sender, EventArgs e)
        {
            if (null != SelectedBuilding)
            {
                SelectedBuilding.SetPlayer(buildingProperties.ObjectPlayer);
                SelectedBuilding.SetId(buildingProperties.ObjectId);
                SelectedBuilding.SetName(buildingProperties.ObjectName);

                painter = new BuildingPainter(graphics, SelectedMap, SelectedBuilding);
            }
        }

        private void BtnMissionPlayers_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogPlayers(SelectedMission.Players))
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    SelectedMission.SetPlayers(dialog.Players);
                    divisionProperties.SetPlayersDataSource(SelectedMission.Players);
                    buildingProperties.SetPlayersDataSource(SelectedMission.Players);
                    DrawAll();
                }
            }
        }
    }
}

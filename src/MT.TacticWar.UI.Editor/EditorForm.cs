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
        private IObjectEditor SelectedObject = null;
        private GameGraphics graphics = null;
        private GameGraphics graphicsPreview = null;
        private IPainter painter = null;

        private string FilePathMap;
        private string FilePathMission;

        public EditorForm()
        {
            InitializeComponent();

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
            SelectedObject = null;
        }

        private void UpdateUIMap(Schema schema)
        {
            // показать элементы дерева
            var node = new TreeNode("Указатель")
            {
                Tag = new TreeViewNodeSelector()
            };
            TreeViewElements.Nodes.Add(node);

            node = new TreeNode("Ландшафт");
            node.Expand();

            var cells = LandscapeFactory.GetSchemaCellTypes(schema);
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
            var subnode2 = new TreeNode("Непроходимая ячейка")
            {
                Tag = new TreeViewNodeSelector(() => { SelectDrawPassability(false); })
            };
            node.Nodes.Add(subnode2);
            subnode2 = new TreeNode("Проходимая ячейка")
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
                Tag = new TreeViewNodeSelector(SelectShowObjectToolset)
            };
            node.Nodes.Add(subnode);

            subnode = new TreeNode("Строение")
            {
                Tag = new TreeViewNodeSelector(SelectShowObjectToolset)
            };
            node.Nodes.Add(subnode);

            node.Expand();
            TreeViewElements.Nodes.Add(node);

            node = new TreeNode("Зоны")
            {
                Tag = new TreeViewNodeSelector(SelectDrawZone)
            };
            node.Expand();
            TreeViewElements.Nodes.Add(node);

            node = new TreeNode("Ворота")
            {
                Tag = new TreeViewNodeSelector(SelectDrawGate)
            };
            node.Expand();
            TreeViewElements.Nodes.Add(node);

            // показать таб
            TabControlLeft.TabPages.Add(TabMissionInfo);

            // показать информацию на табе
            SetMissionInfo(SelectedMission);
        }

        private void SelectDrawCellType(CellCreator creator)
        {
            var code = creator.GetCellCode();
            var cell = LandscapeFactory.CreateCell(SelectedMap.Schema, code, 1, 1);
            graphicsPreview.DrawCell(cell);
            painter = new LanscapePainter(graphics, SelectedMap, SelectedMap.Schema, code);
        }

        private void SelectDrawPassability(bool passable)
        {
            DrawUnpassableShow();
            painter = new PassabilityPainter(graphics, SelectedMap, passable);
        }

        private void SelectShowObjectToolset()
        {
            panelObjectToolset.Visible = true;
        }

        private void SelectDrawZone()
        {
            panelZoneToolset.Visible = true;
            DrawZonesShow();
        }

        private void SelectDrawGate()
        {
            panelGateToolset.Visible = true;
            DrawGatesShow();
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
            GatePlayersRefresh();
        }

        private void DrawAll()
        {
            if (null != SelectedMap)
                graphics.DrawMap(SelectedMap);

            if (null != SelectedMission)
                graphics.DrawPlayersObjects(SelectedMission.Players, null, null);

            if (panelZoneToolset.Visible)
                DrawZonesShow();

            if (panelGateToolset.Visible)
                DrawGatesShow();
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

        private void DrawZonesShow()
        {
            foreach (var zone in SelectedMission.Zones)
            {
                foreach (var pt in zone.Points)
                {
                    graphics.DrawZone(zone.Id, pt.X, pt.Y);
                }
            }
        }

        private void DrawGatesShow()
        {
            if (null == comboGatePlayer.SelectedItem)
                return;

            var player = comboGatePlayer.SelectedItem as Player;
            //foreach (var player in SelectedMission.Players)
            {
                foreach (var gate in player.Gates)
                {
                    graphics.DrawGate(gate.Id, gate.X, gate.Y);
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
            DrawAll();
        }

        private void TreeViewElements_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            panelObjectToolset.Visible = false;
            panelZoneToolset.Visible = false;
            panelGateToolset.Visible = false;
            StatusStatus.Text = "";
            painter = null;
            //DrawUnpassableHide();
            DrawAll();
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
            if (null == painter)
                return;

            int x = e.X / CellSize;
            int y = e.Y / CellSize;

            if (x < 0 || x > SelectedMap.Width - 1)
                return;

            if (y < 0 || y > SelectedMap.Height - 1)
                return;

            painter.Start(x, y);
            painter.Paint();
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

            var building = SelectedMission.GetBuildingAt(x, y);
            if (null != building)
            {
                if (MouseButtons.Left == e.Button)
                {
                    DrawObject(SelectedObject, false);
                    SelectedObject = new BuildingEditor(building);
                    ShowBuildingInfo(SelectedObject as BuildingEditor);
                    DrawObject(SelectedObject, true);
                }
                else if (MouseButtons.Right == e.Button)
                {
                    // TODO: сделать, чтобы объект стирался
                    //DeselectObject();
                }
                return;
            }

            var division = SelectedMission.GetDivisionAt(x, y);
            if (null != division)
            {
                if (MouseButtons.Left == e.Button)
                {
                    DrawObject(SelectedObject, false);
                    SelectedObject = new DivisionEditor(division);
                    ShowDivisionInfo(SelectedObject as DivisionEditor);
                    DrawObject(SelectedObject, true);
                }
                else if (MouseButtons.Right == e.Button)
                {
                    // TODO: сделать, чтобы объект стирался
                    //DeselectObject();
                }
                return;
            }
        }

        private void DrawObject(IObjectEditor obj, bool selected)
        {
            if (null == obj)
                return;

            if (obj is DivisionEditor)
            {
                var div = obj as DivisionEditor;
                graphics.DrawDivision(div, selected);
            }

            if (obj is BuildingEditor)
            {
                var bld = obj as BuildingEditor;
                graphics.DrawBuilding(bld, selected);
            }
        }

        #region Меню Карта

        private void MenuMapNew_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogMapNew())
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    SelectedMap = new MapEditor(dialog.MapName, dialog.MapDescription, dialog.MapSizeWidth, dialog.MapSizeHeight, dialog.MapSchema.GetCode());

                    ResizeControls(PanelEditor, SelectedMap.Width, SelectedMap.Height);
                    graphics = new GameGraphics(PanelEditor.CreateGraphics(), CellSize);
                    graphicsPreview = new GameGraphics(PanelElementPreview.CreateGraphics(), CellSize);

                    UpdateUI(SelectedMap.Schema);
                }
            }
        }

        private void MenuMapOpen_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dialog = new OpenFileDialog())
                {
                    dialog.InitialDirectory = Path.Combine(
                        Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                        "missions");
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    dialog.InitialDirectory = Path.Combine(
                        Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                        "missions");
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

            try
            {
                using (var dialog = new OpenFileDialog())
                {
                    dialog.InitialDirectory = Path.Combine(
                        Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                        "missions");
                    dialog.RestoreDirectory = true;

                    if (DialogResult.OK == dialog.ShowDialog())
                    {
                        FilePathMission = dialog.FileName;
                        SelectedMission = new MissionEditor(MissionLoader.LoadMission(dialog.FileName, SelectedMap));
                        UpdateUI(SelectedMap.Schema, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    dialog.InitialDirectory = Path.Combine(
                        Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                        "missions");
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
            try
            {
                if (!ValidateSaveMap())
                    return;

                if (!ValidateSaveMission())
                    return;

                using (var dialog = new DialogMissionCompile(SelectedMission))
                {
                    if (DialogResult.OK != dialog.ShowDialog())
                        return;

                    MissionSaver.SaveGame(
                        dialog.GameName,
                        dialog.MapFileName,
                        dialog.MissionFileName,
                        SelectedMission,
                        txtMapVersion.Text,
                        txtMissionVersion.Text
                    );

                    MessageBox.Show(
                        "Миссия успешно собрана.",
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

        private void MenuEditorRefresh_Click(object sender, EventArgs e)
        {
            DrawAll();
        }

        //

        private void BtnObjectNewDivision_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogDivisionEditor(SelectedMission.Players))
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    var division = dialog.Division;
                    ShowDivisionInfo(division);

                    painter = new DivisionPainter(graphics, SelectedMap, division);
                }
            }
        }

        private void BtnObjectNewBuilding_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogBuildingEditor(SelectedMission.Players))
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    var building = dialog.Building;
                    ShowBuildingInfo(building);

                    painter = new BuildingPainter(graphics, SelectedMap, building);
                }
            }
        }

        private void BtnObjectUpdate_Click(object sender, EventArgs e)
        {
            if (null == SelectedObject)
            {
                MessageBox.Show("Сначала выделите объект.");
                return;
            }

            if (SelectedObject is DivisionEditor)
                BtnObjectUpdateDivision();
            else if (SelectedObject is BuildingEditor)
                BtnObjectUpdateBuilding();
        }

        private void BtnObjectUpdateDivision()
        {
            using (var dialog = new DialogDivisionEditor(SelectedMission.Players, SelectedObject as DivisionEditor))
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    var division = dialog.Division;

                    // заменяем объект на новый (мог смениться игрок)
                    painter = new DivisionPainter(graphics, SelectedMap, division);
                    painter.TryMove(division.Position.X, division.Position.Y);
                    painter.Paint();
                    painter = null;

                    // выделяем новый объект
                    var divisionnew = SelectedMission.GetDivisionAt(division.Position);
                    if (null != divisionnew)
                    {
                        SelectedObject = new DivisionEditor(divisionnew);
                        ShowDivisionInfo(SelectedObject as DivisionEditor);
                        DrawObject(SelectedObject, true);
                    }
                }
            }
        }

        private void BtnObjectUpdateBuilding()
        {
            using (var dialog = new DialogBuildingEditor(SelectedMission.Players, SelectedObject as BuildingEditor))
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    var building = dialog.Building;

                    // заменяем объект на новый (мог смениться игрок)
                    painter = new BuildingPainter(graphics, SelectedMap, building);
                    painter.TryMove(building.Position.X, building.Position.Y);
                    painter.Paint();
                    painter = null;

                    // выделяем новый объект
                    var buildingnew = SelectedMission.GetBuildingAt(building.Position);
                    if (null != buildingnew)
                    {
                        SelectedObject = new BuildingEditor(buildingnew);
                        ShowBuildingInfo(SelectedObject as BuildingEditor);
                        DrawObject(SelectedObject, true);
                    }
                }
            }
        }

        private void BtnObjectDelete_Click(object sender, EventArgs e)
        {
            if (null == SelectedObject)
            {
                MessageBox.Show("Сначала выделите объект.");
                return;
            }

            DeleteObject(SelectedObject);
            SelectedObject = null;
            txtObjectStatus.Text = string.Empty;
        }

        private void ShowDivisionInfo(DivisionEditor division)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Игрок: {0}{1}", division.Player, Environment.NewLine);
            sb.AppendFormat("Id: {0}{1}", division.Id, Environment.NewLine);
            sb.AppendFormat("Тип: {0}{1}", division.Type, Environment.NewLine);
            sb.AppendFormat("Имя: {0}{1}", division.Name, Environment.NewLine);
            sb.AppendLine();
            sb.AppendLine("Юниты:");
            foreach (var unit in division.Units)
            {
                sb.Append("- ");
                sb.AppendLine(unit.Name);
            }

            txtObjectStatus.Text = sb.ToString();
            panelObjectToolset.Visible = true;
        }

        private void ShowBuildingInfo(BuildingEditor building)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Игрок: {0}{1}", building.Player, Environment.NewLine);
            sb.AppendFormat("Id: {0}{1}", building.Id, Environment.NewLine);
            sb.AppendFormat("Тип: {0}{1}", building.Type, Environment.NewLine);
            sb.AppendFormat("Имя: {0}{1}", building.Name, Environment.NewLine);
            sb.AppendLine();
            if (null != building.Security)
            {
                sb.AppendLine("Охранение:");
                sb.AppendLine(building.Security.Type);
            }
            else
            {
                sb.AppendLine("Без охранения");
            }

            txtObjectStatus.Text = sb.ToString();
            panelObjectToolset.Visible = true;
        }

        private void DeselectObject()
        {
            DrawObject(SelectedObject, false);
            SelectedObject = null;
        }

        private void DeleteObject(IObjectEditor obj)
        {
            if (null != obj)
            {
                var pos = obj.Position;
                obj.Destroy();
                SelectedMap[pos].Object = null;
                graphics.DrawCell(SelectedMap[pos]);
            }
        }

        private void BtnMissionPlayers_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogPlayers(SelectedMission.Players))
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    SelectedMission.SetPlayers(dialog.Players);
                    GatePlayersRefresh();
                    DrawAll();
                }
            }
        }

        private void GatePlayersRefresh()
        {
            // TODO: отрефакторить
            comboGatePlayer.DataSource = null;
            comboGatePlayer.Items.Clear();
            comboGatePlayer.DataSource = SelectedMission.Players;
            comboGatePlayer.SelectedIndex = 0;
        }

        private void BtnMissionScripts_Click(object sender, EventArgs e)
        {
            using (var dialog = new DialogScriptList(SelectedMission.Scripts))
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    SelectedMission.SetScripts(dialog.Scripts);
                }
            }
        }

        private void BtnZoneAdd_Click(object sender, EventArgs e)
        {
            var zoneId = (int)numZoneId.Value;
            painter = new ZonePainter(graphics, SelectedMission, zoneId);
            StatusStatus.Text = "Рисование зон";
        }

        private void BtnZoneRemove_Click(object sender, EventArgs e)
        {
            painter = new ZonePainter(graphics, SelectedMission, -1, true);
            StatusStatus.Text = "Стирание зон";
        }

        private void NumZoneId_ValueChanged(object sender, EventArgs e)
        {
            BtnZoneAdd_Click(sender, e);
        }

        private void BtnGateAdd_Click(object sender, EventArgs e)
        {
            var gateId = (int)numGateId.Value;
            painter = new GatePainter(graphics, SelectedMission, comboGatePlayer.SelectedItem as Player, gateId);
            StatusStatus.Text = "Рисование ворот";
        }

        private void BtnGateRemove_Click(object sender, EventArgs e)
        {
            painter = new GatePainter(graphics, SelectedMission, null, -1, true);
            StatusStatus.Text = "Стирание ворот";
        }

        private void ComboGatePlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawAll();
            BtnGateAdd_Click(sender, e);
        }

        private void NumGateId_ValueChanged(object sender, EventArgs e)
        {
            BtnGateAdd_Click(sender, e);
        }
    }
}

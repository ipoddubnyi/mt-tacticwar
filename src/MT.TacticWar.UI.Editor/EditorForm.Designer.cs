namespace MT.TacticWar.UI.Editor
{
    partial class EditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileCreateMap = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileOpenMap = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSaveMap = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileCreateMission = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileOpenMission = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSaveMission = new System.Windows.Forms.ToolStripMenuItem();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.StatusCoordinates = new System.Windows.Forms.ToolStripStatusLabel();
            this.TabControlLeft = new System.Windows.Forms.TabControl();
            this.TabEditor = new System.Windows.Forms.TabPage();
            this.SplitContainerLeft = new System.Windows.Forms.SplitContainer();
            this.TreeViewElements = new System.Windows.Forms.TreeView();
            this.PanelElementPreview = new System.Windows.Forms.Panel();
            this.TabMapInfo = new System.Windows.Forms.TabPage();
            this.lblMapSchema = new System.Windows.Forms.Label();
            this.lblMapSize = new System.Windows.Forms.Label();
            this.txtMapDescription = new System.Windows.Forms.TextBox();
            this.lblMapName = new System.Windows.Forms.Label();
            this.lblMapDescription = new System.Windows.Forms.Label();
            this.txtMapName = new System.Windows.Forms.TextBox();
            this.TabMissionInfo = new System.Windows.Forms.TabPage();
            this.btnMissionPlayers = new System.Windows.Forms.Button();
            this.lblMissionName = new System.Windows.Forms.Label();
            this.txtMissionName = new System.Windows.Forms.TextBox();
            this.txtMissionBriefing = new System.Windows.Forms.TextBox();
            this.lblMissionBriefing = new System.Windows.Forms.Label();
            this.flowLayoutRight = new System.Windows.Forms.FlowLayoutPanel();
            this.panelDivision = new System.Windows.Forms.Panel();
            this.btnDivisionDelete = new System.Windows.Forms.Button();
            this.lblSelectedDivisionStatus = new System.Windows.Forms.Label();
            this.btnDivisionUpdate = new System.Windows.Forms.Button();
            this.btnDivisionCreate = new System.Windows.Forms.Button();
            this.panelBuilding = new System.Windows.Forms.Panel();
            this.btnBuildingDelete = new System.Windows.Forms.Button();
            this.lblSelectedBuildingStatus = new System.Windows.Forms.Label();
            this.btnBuildingUpdate = new System.Windows.Forms.Button();
            this.btnBuildingCreate = new System.Windows.Forms.Button();
            this.PanelEditor = new System.Windows.Forms.Panel();
            this.MenuFileSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileCompileMission = new System.Windows.Forms.ToolStripMenuItem();
            this.divisionProperties = new MT.TacticWar.UI.Editor.Controls.ObjectProperties();
            this.buildingProperties = new MT.TacticWar.UI.Editor.Controls.ObjectProperties();
            this.Menu.SuspendLayout();
            this.Status.SuspendLayout();
            this.TabControlLeft.SuspendLayout();
            this.TabEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerLeft)).BeginInit();
            this.SplitContainerLeft.Panel1.SuspendLayout();
            this.SplitContainerLeft.Panel2.SuspendLayout();
            this.SplitContainerLeft.SuspendLayout();
            this.TabMapInfo.SuspendLayout();
            this.TabMissionInfo.SuspendLayout();
            this.flowLayoutRight.SuspendLayout();
            this.panelDivision.SuspendLayout();
            this.panelBuilding.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.Menu.Size = new System.Drawing.Size(926, 24);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "menuStrip1";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileCreateMap,
            this.MenuFileOpenMap,
            this.MenuFileSaveMap,
            this.MenuFileSeparator1,
            this.MenuFileCreateMission,
            this.MenuFileOpenMission,
            this.MenuFileSaveMission,
            this.MenuFileSeparator2,
            this.MenuFileCompileMission});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(48, 20);
            this.MenuFile.Text = "&Файл";
            // 
            // MenuFileCreateMap
            // 
            this.MenuFileCreateMap.Name = "MenuFileCreateMap";
            this.MenuFileCreateMap.Size = new System.Drawing.Size(217, 22);
            this.MenuFileCreateMap.Text = "Создать карту";
            this.MenuFileCreateMap.Click += new System.EventHandler(this.MenuFileCreateMap_Click);
            // 
            // MenuFileOpenMap
            // 
            this.MenuFileOpenMap.Name = "MenuFileOpenMap";
            this.MenuFileOpenMap.Size = new System.Drawing.Size(217, 22);
            this.MenuFileOpenMap.Text = "Открыть карту";
            this.MenuFileOpenMap.Click += new System.EventHandler(this.MenuFileOpenMap_Click);
            // 
            // MenuFileSaveMap
            // 
            this.MenuFileSaveMap.Name = "MenuFileSaveMap";
            this.MenuFileSaveMap.Size = new System.Drawing.Size(217, 22);
            this.MenuFileSaveMap.Text = "Сохранить карту";
            this.MenuFileSaveMap.Click += new System.EventHandler(this.MenuFileSaveMap_Click);
            // 
            // MenuFileSeparator1
            // 
            this.MenuFileSeparator1.Name = "MenuFileSeparator1";
            this.MenuFileSeparator1.Size = new System.Drawing.Size(214, 6);
            // 
            // MenuFileCreateMission
            // 
            this.MenuFileCreateMission.Name = "MenuFileCreateMission";
            this.MenuFileCreateMission.Size = new System.Drawing.Size(217, 22);
            this.MenuFileCreateMission.Text = "Создать миссию";
            this.MenuFileCreateMission.Click += new System.EventHandler(this.MenuFileCreateMission_Click);
            // 
            // MenuFileOpenMission
            // 
            this.MenuFileOpenMission.Name = "MenuFileOpenMission";
            this.MenuFileOpenMission.Size = new System.Drawing.Size(217, 22);
            this.MenuFileOpenMission.Text = "Открыть миссию";
            this.MenuFileOpenMission.Click += new System.EventHandler(this.MenuFileOpenMission_Click);
            // 
            // MenuFileSaveMission
            // 
            this.MenuFileSaveMission.Name = "MenuFileSaveMission";
            this.MenuFileSaveMission.Size = new System.Drawing.Size(217, 22);
            this.MenuFileSaveMission.Text = "Сохранить миссию";
            // 
            // Status
            // 
            this.Status.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusCoordinates});
            this.Status.Location = new System.Drawing.Point(0, 443);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(926, 22);
            this.Status.TabIndex = 2;
            this.Status.Text = "statusStrip1";
            // 
            // StatusCoordinates
            // 
            this.StatusCoordinates.Name = "StatusCoordinates";
            this.StatusCoordinates.Size = new System.Drawing.Size(0, 17);
            // 
            // TabControlLeft
            // 
            this.TabControlLeft.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TabControlLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TabControlLeft.Controls.Add(this.TabEditor);
            this.TabControlLeft.Controls.Add(this.TabMapInfo);
            this.TabControlLeft.Controls.Add(this.TabMissionInfo);
            this.TabControlLeft.Location = new System.Drawing.Point(0, 26);
            this.TabControlLeft.Margin = new System.Windows.Forms.Padding(2);
            this.TabControlLeft.Multiline = true;
            this.TabControlLeft.Name = "TabControlLeft";
            this.TabControlLeft.SelectedIndex = 0;
            this.TabControlLeft.Size = new System.Drawing.Size(227, 415);
            this.TabControlLeft.TabIndex = 4;
            // 
            // TabEditor
            // 
            this.TabEditor.Controls.Add(this.SplitContainerLeft);
            this.TabEditor.Location = new System.Drawing.Point(23, 4);
            this.TabEditor.Margin = new System.Windows.Forms.Padding(2);
            this.TabEditor.Name = "TabEditor";
            this.TabEditor.Padding = new System.Windows.Forms.Padding(2);
            this.TabEditor.Size = new System.Drawing.Size(200, 407);
            this.TabEditor.TabIndex = 0;
            this.TabEditor.Text = "Редактор";
            this.TabEditor.UseVisualStyleBackColor = true;
            // 
            // SplitContainerLeft
            // 
            this.SplitContainerLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SplitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainerLeft.Location = new System.Drawing.Point(2, 2);
            this.SplitContainerLeft.Margin = new System.Windows.Forms.Padding(2);
            this.SplitContainerLeft.Name = "SplitContainerLeft";
            this.SplitContainerLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainerLeft.Panel1
            // 
            this.SplitContainerLeft.Panel1.Controls.Add(this.TreeViewElements);
            // 
            // SplitContainerLeft.Panel2
            // 
            this.SplitContainerLeft.Panel2.Controls.Add(this.PanelElementPreview);
            this.SplitContainerLeft.Size = new System.Drawing.Size(196, 403);
            this.SplitContainerLeft.SplitterDistance = 274;
            this.SplitContainerLeft.SplitterWidth = 3;
            this.SplitContainerLeft.TabIndex = 2;
            // 
            // TreeViewElements
            // 
            this.TreeViewElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeViewElements.Location = new System.Drawing.Point(0, 0);
            this.TreeViewElements.Name = "TreeViewElements";
            this.TreeViewElements.Size = new System.Drawing.Size(194, 272);
            this.TreeViewElements.TabIndex = 0;
            this.TreeViewElements.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeViewElements_BeforeSelect);
            this.TreeViewElements.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewElements_AfterSelect);
            // 
            // PanelElementPreview
            // 
            this.PanelElementPreview.BackColor = System.Drawing.SystemColors.Control;
            this.PanelElementPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelElementPreview.Location = new System.Drawing.Point(0, 0);
            this.PanelElementPreview.Name = "PanelElementPreview";
            this.PanelElementPreview.Size = new System.Drawing.Size(194, 124);
            this.PanelElementPreview.TabIndex = 1;
            // 
            // TabMapInfo
            // 
            this.TabMapInfo.Controls.Add(this.lblMapSchema);
            this.TabMapInfo.Controls.Add(this.lblMapSize);
            this.TabMapInfo.Controls.Add(this.txtMapDescription);
            this.TabMapInfo.Controls.Add(this.lblMapName);
            this.TabMapInfo.Controls.Add(this.lblMapDescription);
            this.TabMapInfo.Controls.Add(this.txtMapName);
            this.TabMapInfo.Location = new System.Drawing.Point(23, 4);
            this.TabMapInfo.Margin = new System.Windows.Forms.Padding(2);
            this.TabMapInfo.Name = "TabMapInfo";
            this.TabMapInfo.Padding = new System.Windows.Forms.Padding(2);
            this.TabMapInfo.Size = new System.Drawing.Size(200, 407);
            this.TabMapInfo.TabIndex = 1;
            this.TabMapInfo.Text = "Карта";
            this.TabMapInfo.UseVisualStyleBackColor = true;
            // 
            // lblMapSchema
            // 
            this.lblMapSchema.AutoSize = true;
            this.lblMapSchema.Location = new System.Drawing.Point(4, 319);
            this.lblMapSchema.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMapSchema.Name = "lblMapSchema";
            this.lblMapSchema.Size = new System.Drawing.Size(76, 13);
            this.lblMapSchema.TabIndex = 5;
            this.lblMapSchema.Text = "Схема карты:";
            // 
            // lblMapSize
            // 
            this.lblMapSize.AutoSize = true;
            this.lblMapSize.Location = new System.Drawing.Point(4, 296);
            this.lblMapSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMapSize.Name = "lblMapSize";
            this.lblMapSize.Size = new System.Drawing.Size(83, 13);
            this.lblMapSize.TabIndex = 4;
            this.lblMapSize.Text = "Размер карты:";
            // 
            // txtMapDescription
            // 
            this.txtMapDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMapDescription.Location = new System.Drawing.Point(7, 80);
            this.txtMapDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtMapDescription.Multiline = true;
            this.txtMapDescription.Name = "txtMapDescription";
            this.txtMapDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMapDescription.Size = new System.Drawing.Size(145, 201);
            this.txtMapDescription.TabIndex = 3;
            // 
            // lblMapName
            // 
            this.lblMapName.AutoSize = true;
            this.lblMapName.Location = new System.Drawing.Point(4, 14);
            this.lblMapName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMapName.Name = "lblMapName";
            this.lblMapName.Size = new System.Drawing.Size(94, 13);
            this.lblMapName.TabIndex = 0;
            this.lblMapName.Text = "Название карты:";
            // 
            // lblMapDescription
            // 
            this.lblMapDescription.AutoSize = true;
            this.lblMapDescription.Location = new System.Drawing.Point(4, 63);
            this.lblMapDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMapDescription.Name = "lblMapDescription";
            this.lblMapDescription.Size = new System.Drawing.Size(94, 13);
            this.lblMapDescription.TabIndex = 2;
            this.lblMapDescription.Text = "Описание карты:";
            // 
            // txtMapName
            // 
            this.txtMapName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMapName.Location = new System.Drawing.Point(7, 30);
            this.txtMapName.Margin = new System.Windows.Forms.Padding(2);
            this.txtMapName.Name = "txtMapName";
            this.txtMapName.Size = new System.Drawing.Size(145, 20);
            this.txtMapName.TabIndex = 1;
            this.txtMapName.Text = "Карта местности";
            // 
            // TabMissionInfo
            // 
            this.TabMissionInfo.Controls.Add(this.btnMissionPlayers);
            this.TabMissionInfo.Controls.Add(this.lblMissionName);
            this.TabMissionInfo.Controls.Add(this.txtMissionName);
            this.TabMissionInfo.Controls.Add(this.txtMissionBriefing);
            this.TabMissionInfo.Controls.Add(this.lblMissionBriefing);
            this.TabMissionInfo.Location = new System.Drawing.Point(23, 4);
            this.TabMissionInfo.Margin = new System.Windows.Forms.Padding(2);
            this.TabMissionInfo.Name = "TabMissionInfo";
            this.TabMissionInfo.Size = new System.Drawing.Size(200, 407);
            this.TabMissionInfo.TabIndex = 2;
            this.TabMissionInfo.Text = "Миссия";
            this.TabMissionInfo.UseVisualStyleBackColor = true;
            // 
            // btnMissionPlayers
            // 
            this.btnMissionPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMissionPlayers.Location = new System.Drawing.Point(7, 263);
            this.btnMissionPlayers.Name = "btnMissionPlayers";
            this.btnMissionPlayers.Size = new System.Drawing.Size(146, 23);
            this.btnMissionPlayers.TabIndex = 0;
            this.btnMissionPlayers.Text = "Игроки";
            this.btnMissionPlayers.UseVisualStyleBackColor = true;
            this.btnMissionPlayers.Click += new System.EventHandler(this.BtnMissionPlayers_Click);
            // 
            // lblMissionName
            // 
            this.lblMissionName.AutoSize = true;
            this.lblMissionName.Location = new System.Drawing.Point(4, 14);
            this.lblMissionName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMissionName.Name = "lblMissionName";
            this.lblMissionName.Size = new System.Drawing.Size(101, 13);
            this.lblMissionName.TabIndex = 0;
            this.lblMissionName.Text = "Название миссии:";
            // 
            // txtMissionName
            // 
            this.txtMissionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMissionName.Location = new System.Drawing.Point(7, 30);
            this.txtMissionName.Margin = new System.Windows.Forms.Padding(2);
            this.txtMissionName.Name = "txtMissionName";
            this.txtMissionName.Size = new System.Drawing.Size(145, 20);
            this.txtMissionName.TabIndex = 1;
            // 
            // txtMissionBriefing
            // 
            this.txtMissionBriefing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMissionBriefing.Location = new System.Drawing.Point(7, 80);
            this.txtMissionBriefing.Margin = new System.Windows.Forms.Padding(2);
            this.txtMissionBriefing.Multiline = true;
            this.txtMissionBriefing.Name = "txtMissionBriefing";
            this.txtMissionBriefing.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMissionBriefing.Size = new System.Drawing.Size(145, 162);
            this.txtMissionBriefing.TabIndex = 3;
            // 
            // lblMissionBriefing
            // 
            this.lblMissionBriefing.AutoSize = true;
            this.lblMissionBriefing.Location = new System.Drawing.Point(4, 63);
            this.lblMissionBriefing.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMissionBriefing.Name = "lblMissionBriefing";
            this.lblMissionBriefing.Size = new System.Drawing.Size(54, 13);
            this.lblMissionBriefing.TabIndex = 2;
            this.lblMissionBriefing.Text = "Брифинг:";
            // 
            // flowLayoutRight
            // 
            this.flowLayoutRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutRight.AutoSize = true;
            this.flowLayoutRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutRight.Controls.Add(this.panelDivision);
            this.flowLayoutRight.Controls.Add(this.panelBuilding);
            this.flowLayoutRight.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutRight.Location = new System.Drawing.Point(582, 26);
            this.flowLayoutRight.Name = "flowLayoutRight";
            this.flowLayoutRight.Size = new System.Drawing.Size(344, 411);
            this.flowLayoutRight.TabIndex = 6;
            // 
            // panelDivision
            // 
            this.panelDivision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDivision.Controls.Add(this.btnDivisionDelete);
            this.panelDivision.Controls.Add(this.lblSelectedDivisionStatus);
            this.panelDivision.Controls.Add(this.divisionProperties);
            this.panelDivision.Controls.Add(this.btnDivisionUpdate);
            this.panelDivision.Controls.Add(this.btnDivisionCreate);
            this.panelDivision.Location = new System.Drawing.Point(173, 2);
            this.panelDivision.Margin = new System.Windows.Forms.Padding(2);
            this.panelDivision.Name = "panelDivision";
            this.panelDivision.Size = new System.Drawing.Size(167, 405);
            this.panelDivision.TabIndex = 1;
            this.panelDivision.Visible = false;
            // 
            // btnDivisionDelete
            // 
            this.btnDivisionDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDivisionDelete.Location = new System.Drawing.Point(10, 59);
            this.btnDivisionDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDivisionDelete.Name = "btnDivisionDelete";
            this.btnDivisionDelete.Size = new System.Drawing.Size(145, 19);
            this.btnDivisionDelete.TabIndex = 3;
            this.btnDivisionDelete.Text = "Удалить";
            this.btnDivisionDelete.UseVisualStyleBackColor = true;
            this.btnDivisionDelete.Click += new System.EventHandler(this.BtnDivisionDelete_Click);
            // 
            // lblSelectedDivisionStatus
            // 
            this.lblSelectedDivisionStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedDivisionStatus.Location = new System.Drawing.Point(10, 162);
            this.lblSelectedDivisionStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectedDivisionStatus.Name = "lblSelectedDivisionStatus";
            this.lblSelectedDivisionStatus.Size = new System.Drawing.Size(145, 229);
            this.lblSelectedDivisionStatus.TabIndex = 2;
            this.lblSelectedDivisionStatus.Text = "Подразделение не выбрано";
            // 
            // btnDivisionUpdate
            // 
            this.btnDivisionUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDivisionUpdate.Location = new System.Drawing.Point(10, 35);
            this.btnDivisionUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnDivisionUpdate.Name = "btnDivisionUpdate";
            this.btnDivisionUpdate.Size = new System.Drawing.Size(145, 19);
            this.btnDivisionUpdate.TabIndex = 1;
            this.btnDivisionUpdate.Text = "Изменить";
            this.btnDivisionUpdate.UseVisualStyleBackColor = true;
            this.btnDivisionUpdate.Click += new System.EventHandler(this.BtnDivisionUpdate_Click);
            // 
            // btnDivisionCreate
            // 
            this.btnDivisionCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDivisionCreate.Location = new System.Drawing.Point(10, 11);
            this.btnDivisionCreate.Margin = new System.Windows.Forms.Padding(2);
            this.btnDivisionCreate.Name = "btnDivisionCreate";
            this.btnDivisionCreate.Size = new System.Drawing.Size(145, 19);
            this.btnDivisionCreate.TabIndex = 0;
            this.btnDivisionCreate.Text = "Добавить";
            this.btnDivisionCreate.UseVisualStyleBackColor = true;
            this.btnDivisionCreate.Click += new System.EventHandler(this.BtnDivisionCreate_Click);
            // 
            // panelBuilding
            // 
            this.panelBuilding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBuilding.Controls.Add(this.btnBuildingDelete);
            this.panelBuilding.Controls.Add(this.lblSelectedBuildingStatus);
            this.panelBuilding.Controls.Add(this.buildingProperties);
            this.panelBuilding.Controls.Add(this.btnBuildingUpdate);
            this.panelBuilding.Controls.Add(this.btnBuildingCreate);
            this.panelBuilding.Location = new System.Drawing.Point(2, 2);
            this.panelBuilding.Margin = new System.Windows.Forms.Padding(2);
            this.panelBuilding.Name = "panelBuilding";
            this.panelBuilding.Size = new System.Drawing.Size(167, 405);
            this.panelBuilding.TabIndex = 2;
            this.panelBuilding.Visible = false;
            // 
            // btnBuildingDelete
            // 
            this.btnBuildingDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuildingDelete.Location = new System.Drawing.Point(10, 59);
            this.btnBuildingDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuildingDelete.Name = "btnBuildingDelete";
            this.btnBuildingDelete.Size = new System.Drawing.Size(145, 19);
            this.btnBuildingDelete.TabIndex = 3;
            this.btnBuildingDelete.Text = "Удалить";
            this.btnBuildingDelete.UseVisualStyleBackColor = true;
            this.btnBuildingDelete.Click += new System.EventHandler(this.BtnBuildingDelete_Click);
            // 
            // lblSelectedBuildingStatus
            // 
            this.lblSelectedBuildingStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedBuildingStatus.Location = new System.Drawing.Point(10, 162);
            this.lblSelectedBuildingStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectedBuildingStatus.Name = "lblSelectedBuildingStatus";
            this.lblSelectedBuildingStatus.Size = new System.Drawing.Size(145, 229);
            this.lblSelectedBuildingStatus.TabIndex = 2;
            this.lblSelectedBuildingStatus.Text = "Строение не выбрано";
            // 
            // btnBuildingUpdate
            // 
            this.btnBuildingUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuildingUpdate.Location = new System.Drawing.Point(10, 35);
            this.btnBuildingUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuildingUpdate.Name = "btnBuildingUpdate";
            this.btnBuildingUpdate.Size = new System.Drawing.Size(145, 19);
            this.btnBuildingUpdate.TabIndex = 1;
            this.btnBuildingUpdate.Text = "Изменить";
            this.btnBuildingUpdate.UseVisualStyleBackColor = true;
            this.btnBuildingUpdate.Click += new System.EventHandler(this.BtnBuildingUpdate_Click);
            // 
            // btnBuildingCreate
            // 
            this.btnBuildingCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuildingCreate.Location = new System.Drawing.Point(10, 11);
            this.btnBuildingCreate.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuildingCreate.Name = "btnBuildingCreate";
            this.btnBuildingCreate.Size = new System.Drawing.Size(145, 19);
            this.btnBuildingCreate.TabIndex = 0;
            this.btnBuildingCreate.Text = "Добавить";
            this.btnBuildingCreate.UseVisualStyleBackColor = true;
            this.btnBuildingCreate.Click += new System.EventHandler(this.BtnBuildingCreate_Click);
            // 
            // PanelEditor
            // 
            this.PanelEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelEditor.Location = new System.Drawing.Point(232, 30);
            this.PanelEditor.Name = "PanelEditor";
            this.PanelEditor.Size = new System.Drawing.Size(294, 285);
            this.PanelEditor.TabIndex = 5;
            this.PanelEditor.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelEditor_Paint);
            this.PanelEditor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelEditor_MouseClick);
            this.PanelEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelEditor_MouseDown);
            this.PanelEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelEditor_MouseMove);
            this.PanelEditor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelEditor_MouseUp);
            // 
            // MenuFileSeparator2
            // 
            this.MenuFileSeparator2.Name = "MenuFileSeparator2";
            this.MenuFileSeparator2.Size = new System.Drawing.Size(214, 6);
            // 
            // MenuFileCompileMission
            // 
            this.MenuFileCompileMission.Name = "MenuFileCompileMission";
            this.MenuFileCompileMission.Size = new System.Drawing.Size(217, 22);
            this.MenuFileCompileMission.Text = "Скомпилировать миссию";
            // 
            // divisionProperties
            // 
            this.divisionProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divisionProperties.Location = new System.Drawing.Point(10, 84);
            this.divisionProperties.Margin = new System.Windows.Forms.Padding(4);
            this.divisionProperties.Name = "divisionProperties";
            this.divisionProperties.Size = new System.Drawing.Size(145, 74);
            this.divisionProperties.TabIndex = 0;
            // 
            // buildingProperties
            // 
            this.buildingProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buildingProperties.Location = new System.Drawing.Point(10, 84);
            this.buildingProperties.Margin = new System.Windows.Forms.Padding(4);
            this.buildingProperties.Name = "buildingProperties";
            this.buildingProperties.Size = new System.Drawing.Size(145, 74);
            this.buildingProperties.TabIndex = 0;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 465);
            this.Controls.Add(this.TabControlLeft);
            this.Controls.Add(this.flowLayoutRight);
            this.Controls.Add(this.PanelEditor);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.MinimumSize = new System.Drawing.Size(800, 493);
            this.Name = "EditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TacticWar - Редактор миссий";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.EditorForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EditorForm_Paint);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.TabControlLeft.ResumeLayout(false);
            this.TabEditor.ResumeLayout(false);
            this.SplitContainerLeft.Panel1.ResumeLayout(false);
            this.SplitContainerLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerLeft)).EndInit();
            this.SplitContainerLeft.ResumeLayout(false);
            this.TabMapInfo.ResumeLayout(false);
            this.TabMapInfo.PerformLayout();
            this.TabMissionInfo.ResumeLayout(false);
            this.TabMissionInfo.PerformLayout();
            this.flowLayoutRight.ResumeLayout(false);
            this.panelDivision.ResumeLayout(false);
            this.panelBuilding.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuFileCreateMap;
        private System.Windows.Forms.ToolStripMenuItem MenuFileCreateMission;
        private System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.ToolStripStatusLabel StatusCoordinates;
        private System.Windows.Forms.ToolStripMenuItem MenuFileOpenMap;
        private System.Windows.Forms.ToolStripMenuItem MenuFileSaveMap;
        private System.Windows.Forms.ToolStripSeparator MenuFileSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuFileOpenMission;
        private System.Windows.Forms.ToolStripMenuItem MenuFileSaveMission;
        private System.Windows.Forms.TabControl TabControlLeft;
        private System.Windows.Forms.TabPage TabEditor;
        private System.Windows.Forms.SplitContainer SplitContainerLeft;
        private System.Windows.Forms.TreeView TreeViewElements;
        private System.Windows.Forms.Panel PanelElementPreview;
        private System.Windows.Forms.TabPage TabMapInfo;
        private System.Windows.Forms.Label lblMapSchema;
        private System.Windows.Forms.Label lblMapSize;
        private System.Windows.Forms.TextBox txtMapDescription;
        private System.Windows.Forms.Label lblMapName;
        private System.Windows.Forms.Label lblMapDescription;
        private System.Windows.Forms.TextBox txtMapName;
        private System.Windows.Forms.TabPage TabMissionInfo;
        private System.Windows.Forms.Button btnMissionPlayers;
        private System.Windows.Forms.Label lblMissionName;
        private System.Windows.Forms.TextBox txtMissionName;
        private System.Windows.Forms.TextBox txtMissionBriefing;
        private System.Windows.Forms.Label lblMissionBriefing;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutRight;
        private System.Windows.Forms.Panel panelDivision;
        private System.Windows.Forms.Button btnDivisionDelete;
        private System.Windows.Forms.Label lblSelectedDivisionStatus;
        private Controls.ObjectProperties divisionProperties;
        private System.Windows.Forms.Button btnDivisionUpdate;
        private System.Windows.Forms.Button btnDivisionCreate;
        private System.Windows.Forms.Panel panelBuilding;
        private System.Windows.Forms.Button btnBuildingDelete;
        private System.Windows.Forms.Label lblSelectedBuildingStatus;
        private Controls.ObjectProperties buildingProperties;
        private System.Windows.Forms.Button btnBuildingUpdate;
        private System.Windows.Forms.Button btnBuildingCreate;
        private System.Windows.Forms.Panel PanelEditor;
        private System.Windows.Forms.ToolStripSeparator MenuFileSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuFileCompileMission;
    }
}


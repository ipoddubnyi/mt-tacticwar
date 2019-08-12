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
            this.components = new System.ComponentModel.Container();
            this.TreeViewElements = new System.Windows.Forms.TreeView();
            this.SplitContainerMain = new System.Windows.Forms.SplitContainer();
            this.TabControlLeft = new System.Windows.Forms.TabControl();
            this.TabEditor = new System.Windows.Forms.TabPage();
            this.SplitContainerLeft = new System.Windows.Forms.SplitContainer();
            this.PanelElementPreview = new System.Windows.Forms.Panel();
            this.panelDivision = new System.Windows.Forms.Panel();
            this.lblSelectedDivisionStatus = new System.Windows.Forms.Label();
            this.divisionProperties = new MT.TacticWar.UI.Editor.Controls.DivisionProperties();
            this.btnDivisionUpdate = new System.Windows.Forms.Button();
            this.btnDivisionCreate = new System.Windows.Forms.Button();
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
            this.PanelEditor = new System.Windows.Forms.Panel();
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
            this.colorSelectDialog = new System.Windows.Forms.ColorDialog();
            this.contextMenuDivision = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuDivisionEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuDivisionDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.SplitContainerRight = new System.Windows.Forms.SplitContainer();
            this.panelBuilding = new System.Windows.Forms.Panel();
            this.lblSelectedBuildingStatus = new System.Windows.Forms.Label();
            this.divisionProperties1 = new MT.TacticWar.UI.Editor.Controls.DivisionProperties();
            this.btnBuildingUpdate = new System.Windows.Forms.Button();
            this.btnBuildingCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerMain)).BeginInit();
            this.SplitContainerMain.Panel1.SuspendLayout();
            this.SplitContainerMain.Panel2.SuspendLayout();
            this.SplitContainerMain.SuspendLayout();
            this.TabControlLeft.SuspendLayout();
            this.TabEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerLeft)).BeginInit();
            this.SplitContainerLeft.Panel1.SuspendLayout();
            this.SplitContainerLeft.Panel2.SuspendLayout();
            this.SplitContainerLeft.SuspendLayout();
            this.panelDivision.SuspendLayout();
            this.TabMapInfo.SuspendLayout();
            this.TabMissionInfo.SuspendLayout();
            this.Menu.SuspendLayout();
            this.Status.SuspendLayout();
            this.contextMenuDivision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerRight)).BeginInit();
            this.SplitContainerRight.Panel1.SuspendLayout();
            this.SplitContainerRight.Panel2.SuspendLayout();
            this.SplitContainerRight.SuspendLayout();
            this.panelBuilding.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeViewElements
            // 
            this.TreeViewElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeViewElements.Location = new System.Drawing.Point(0, 0);
            this.TreeViewElements.Margin = new System.Windows.Forms.Padding(4);
            this.TreeViewElements.Name = "TreeViewElements";
            this.TreeViewElements.Size = new System.Drawing.Size(229, 198);
            this.TreeViewElements.TabIndex = 0;
            this.TreeViewElements.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeViewElements_BeforeSelect);
            this.TreeViewElements.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewElements_AfterSelect);
            // 
            // SplitContainerMain
            // 
            this.SplitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerMain.Margin = new System.Windows.Forms.Padding(4);
            this.SplitContainerMain.Name = "SplitContainerMain";
            // 
            // SplitContainerMain.Panel1
            // 
            this.SplitContainerMain.Panel1.Controls.Add(this.TabControlLeft);
            this.SplitContainerMain.Panel1MinSize = 100;
            // 
            // SplitContainerMain.Panel2
            // 
            this.SplitContainerMain.Panel2.Controls.Add(this.SplitContainerRight);
            this.SplitContainerMain.Panel2MinSize = 100;
            this.SplitContainerMain.Size = new System.Drawing.Size(1045, 567);
            this.SplitContainerMain.SplitterDistance = 274;
            this.SplitContainerMain.SplitterWidth = 5;
            this.SplitContainerMain.TabIndex = 1;
            // 
            // TabControlLeft
            // 
            this.TabControlLeft.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TabControlLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControlLeft.Controls.Add(this.TabEditor);
            this.TabControlLeft.Controls.Add(this.TabMapInfo);
            this.TabControlLeft.Controls.Add(this.TabMissionInfo);
            this.TabControlLeft.Location = new System.Drawing.Point(3, 33);
            this.TabControlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TabControlLeft.Multiline = true;
            this.TabControlLeft.Name = "TabControlLeft";
            this.TabControlLeft.SelectedIndex = 0;
            this.TabControlLeft.Size = new System.Drawing.Size(266, 508);
            this.TabControlLeft.TabIndex = 0;
            // 
            // TabEditor
            // 
            this.TabEditor.Controls.Add(this.SplitContainerLeft);
            this.TabEditor.Location = new System.Drawing.Point(25, 4);
            this.TabEditor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TabEditor.Name = "TabEditor";
            this.TabEditor.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TabEditor.Size = new System.Drawing.Size(237, 500);
            this.TabEditor.TabIndex = 0;
            this.TabEditor.Text = "Редактор";
            this.TabEditor.UseVisualStyleBackColor = true;
            // 
            // SplitContainerLeft
            // 
            this.SplitContainerLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SplitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainerLeft.Location = new System.Drawing.Point(3, 2);
            this.SplitContainerLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.SplitContainerLeft.Size = new System.Drawing.Size(231, 496);
            this.SplitContainerLeft.SplitterDistance = 200;
            this.SplitContainerLeft.TabIndex = 2;
            // 
            // PanelElementPreview
            // 
            this.PanelElementPreview.BackColor = System.Drawing.SystemColors.Control;
            this.PanelElementPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelElementPreview.Location = new System.Drawing.Point(0, 0);
            this.PanelElementPreview.Margin = new System.Windows.Forms.Padding(4);
            this.PanelElementPreview.Name = "PanelElementPreview";
            this.PanelElementPreview.Size = new System.Drawing.Size(229, 290);
            this.PanelElementPreview.TabIndex = 1;
            // 
            // panelDivision
            // 
            this.panelDivision.Controls.Add(this.lblSelectedDivisionStatus);
            this.panelDivision.Controls.Add(this.divisionProperties);
            this.panelDivision.Controls.Add(this.btnDivisionUpdate);
            this.panelDivision.Controls.Add(this.btnDivisionCreate);
            this.panelDivision.Location = new System.Drawing.Point(3, 33);
            this.panelDivision.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDivision.Name = "panelDivision";
            this.panelDivision.Size = new System.Drawing.Size(223, 243);
            this.panelDivision.TabIndex = 1;
            this.panelDivision.Visible = false;
            // 
            // lblSelectedDivisionStatus
            // 
            this.lblSelectedDivisionStatus.AutoSize = true;
            this.lblSelectedDivisionStatus.Location = new System.Drawing.Point(10, 13);
            this.lblSelectedDivisionStatus.Name = "lblSelectedDivisionStatus";
            this.lblSelectedDivisionStatus.Size = new System.Drawing.Size(194, 17);
            this.lblSelectedDivisionStatus.TabIndex = 2;
            this.lblSelectedDivisionStatus.Text = "Подразделение не выбрано";
            // 
            // divisionProperties
            // 
            this.divisionProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divisionProperties.Location = new System.Drawing.Point(13, 101);
            this.divisionProperties.Margin = new System.Windows.Forms.Padding(5);
            this.divisionProperties.Name = "divisionProperties";
            this.divisionProperties.Size = new System.Drawing.Size(195, 91);
            this.divisionProperties.TabIndex = 0;
            // 
            // btnDivisionUpdate
            // 
            this.btnDivisionUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDivisionUpdate.Location = new System.Drawing.Point(13, 71);
            this.btnDivisionUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDivisionUpdate.Name = "btnDivisionUpdate";
            this.btnDivisionUpdate.Size = new System.Drawing.Size(193, 23);
            this.btnDivisionUpdate.TabIndex = 1;
            this.btnDivisionUpdate.Text = "Изменить";
            this.btnDivisionUpdate.UseVisualStyleBackColor = true;
            this.btnDivisionUpdate.Click += new System.EventHandler(this.BtnDivisionUpdate_Click);
            // 
            // btnDivisionCreate
            // 
            this.btnDivisionCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDivisionCreate.Location = new System.Drawing.Point(13, 42);
            this.btnDivisionCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDivisionCreate.Name = "btnDivisionCreate";
            this.btnDivisionCreate.Size = new System.Drawing.Size(193, 23);
            this.btnDivisionCreate.TabIndex = 0;
            this.btnDivisionCreate.Text = "Добавить";
            this.btnDivisionCreate.UseVisualStyleBackColor = true;
            this.btnDivisionCreate.Click += new System.EventHandler(this.BtnDivisionCreate_Click);
            // 
            // TabMapInfo
            // 
            this.TabMapInfo.Controls.Add(this.lblMapSchema);
            this.TabMapInfo.Controls.Add(this.lblMapSize);
            this.TabMapInfo.Controls.Add(this.txtMapDescription);
            this.TabMapInfo.Controls.Add(this.lblMapName);
            this.TabMapInfo.Controls.Add(this.lblMapDescription);
            this.TabMapInfo.Controls.Add(this.txtMapName);
            this.TabMapInfo.Location = new System.Drawing.Point(25, 4);
            this.TabMapInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TabMapInfo.Name = "TabMapInfo";
            this.TabMapInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TabMapInfo.Size = new System.Drawing.Size(237, 500);
            this.TabMapInfo.TabIndex = 1;
            this.TabMapInfo.Text = "Карта";
            this.TabMapInfo.UseVisualStyleBackColor = true;
            // 
            // lblMapSchema
            // 
            this.lblMapSchema.AutoSize = true;
            this.lblMapSchema.Location = new System.Drawing.Point(5, 393);
            this.lblMapSchema.Name = "lblMapSchema";
            this.lblMapSchema.Size = new System.Drawing.Size(96, 17);
            this.lblMapSchema.TabIndex = 5;
            this.lblMapSchema.Text = "Схема карты:";
            // 
            // lblMapSize
            // 
            this.lblMapSize.AutoSize = true;
            this.lblMapSize.Location = new System.Drawing.Point(5, 364);
            this.lblMapSize.Name = "lblMapSize";
            this.lblMapSize.Size = new System.Drawing.Size(105, 17);
            this.lblMapSize.TabIndex = 4;
            this.lblMapSize.Text = "Размер карты:";
            // 
            // txtMapDescription
            // 
            this.txtMapDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMapDescription.Location = new System.Drawing.Point(9, 98);
            this.txtMapDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMapDescription.Multiline = true;
            this.txtMapDescription.Name = "txtMapDescription";
            this.txtMapDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMapDescription.Size = new System.Drawing.Size(197, 246);
            this.txtMapDescription.TabIndex = 3;
            // 
            // lblMapName
            // 
            this.lblMapName.AutoSize = true;
            this.lblMapName.Location = new System.Drawing.Point(5, 17);
            this.lblMapName.Name = "lblMapName";
            this.lblMapName.Size = new System.Drawing.Size(120, 17);
            this.lblMapName.TabIndex = 0;
            this.lblMapName.Text = "Название карты:";
            // 
            // lblMapDescription
            // 
            this.lblMapDescription.AutoSize = true;
            this.lblMapDescription.Location = new System.Drawing.Point(5, 78);
            this.lblMapDescription.Name = "lblMapDescription";
            this.lblMapDescription.Size = new System.Drawing.Size(122, 17);
            this.lblMapDescription.TabIndex = 2;
            this.lblMapDescription.Text = "Описание карты:";
            // 
            // txtMapName
            // 
            this.txtMapName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMapName.Location = new System.Drawing.Point(9, 37);
            this.txtMapName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMapName.Name = "txtMapName";
            this.txtMapName.Size = new System.Drawing.Size(197, 22);
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
            this.TabMissionInfo.Location = new System.Drawing.Point(25, 4);
            this.TabMissionInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TabMissionInfo.Name = "TabMissionInfo";
            this.TabMissionInfo.Size = new System.Drawing.Size(237, 500);
            this.TabMissionInfo.TabIndex = 2;
            this.TabMissionInfo.Text = "Миссия";
            this.TabMissionInfo.UseVisualStyleBackColor = true;
            // 
            // btnMissionPlayers
            // 
            this.btnMissionPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMissionPlayers.Location = new System.Drawing.Point(9, 324);
            this.btnMissionPlayers.Margin = new System.Windows.Forms.Padding(4);
            this.btnMissionPlayers.Name = "btnMissionPlayers";
            this.btnMissionPlayers.Size = new System.Drawing.Size(200, 28);
            this.btnMissionPlayers.TabIndex = 0;
            this.btnMissionPlayers.Text = "Игроки";
            this.btnMissionPlayers.UseVisualStyleBackColor = true;
            this.btnMissionPlayers.Click += new System.EventHandler(this.btnMissionPlayers_Click);
            // 
            // lblMissionName
            // 
            this.lblMissionName.AutoSize = true;
            this.lblMissionName.Location = new System.Drawing.Point(5, 17);
            this.lblMissionName.Name = "lblMissionName";
            this.lblMissionName.Size = new System.Drawing.Size(127, 17);
            this.lblMissionName.TabIndex = 0;
            this.lblMissionName.Text = "Название миссии:";
            // 
            // txtMissionName
            // 
            this.txtMissionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMissionName.Location = new System.Drawing.Point(9, 37);
            this.txtMissionName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMissionName.Name = "txtMissionName";
            this.txtMissionName.Size = new System.Drawing.Size(200, 22);
            this.txtMissionName.TabIndex = 1;
            // 
            // txtMissionBriefing
            // 
            this.txtMissionBriefing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMissionBriefing.Location = new System.Drawing.Point(9, 98);
            this.txtMissionBriefing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMissionBriefing.Multiline = true;
            this.txtMissionBriefing.Name = "txtMissionBriefing";
            this.txtMissionBriefing.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMissionBriefing.Size = new System.Drawing.Size(200, 198);
            this.txtMissionBriefing.TabIndex = 3;
            // 
            // lblMissionBriefing
            // 
            this.lblMissionBriefing.AutoSize = true;
            this.lblMissionBriefing.Location = new System.Drawing.Point(5, 78);
            this.lblMissionBriefing.Name = "lblMissionBriefing";
            this.lblMissionBriefing.Size = new System.Drawing.Size(69, 17);
            this.lblMissionBriefing.TabIndex = 2;
            this.lblMissionBriefing.Text = "Брифинг:";
            // 
            // PanelEditor
            // 
            this.PanelEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelEditor.Location = new System.Drawing.Point(4, 31);
            this.PanelEditor.Margin = new System.Windows.Forms.Padding(4);
            this.PanelEditor.Name = "PanelEditor";
            this.PanelEditor.Size = new System.Drawing.Size(523, 510);
            this.PanelEditor.TabIndex = 0;
            this.PanelEditor.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelEditor_Paint);
            this.PanelEditor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelEditor_MouseClick);
            this.PanelEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelEditor_MouseDown);
            this.PanelEditor.MouseLeave += new System.EventHandler(this.PanelEditor_MouseLeave);
            this.PanelEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelEditor_MouseMove);
            this.PanelEditor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelEditor_MouseUp);
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(1045, 28);
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
            this.MenuFileSaveMission});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(59, 24);
            this.MenuFile.Text = "&Файл";
            // 
            // MenuFileCreateMap
            // 
            this.MenuFileCreateMap.Name = "MenuFileCreateMap";
            this.MenuFileCreateMap.Size = new System.Drawing.Size(225, 26);
            this.MenuFileCreateMap.Text = "Создать карту";
            this.MenuFileCreateMap.Click += new System.EventHandler(this.MenuFileCreateMap_Click);
            // 
            // MenuFileOpenMap
            // 
            this.MenuFileOpenMap.Name = "MenuFileOpenMap";
            this.MenuFileOpenMap.Size = new System.Drawing.Size(225, 26);
            this.MenuFileOpenMap.Text = "Открыть карту";
            this.MenuFileOpenMap.Click += new System.EventHandler(this.MenuFileOpenMap_Click);
            // 
            // MenuFileSaveMap
            // 
            this.MenuFileSaveMap.Name = "MenuFileSaveMap";
            this.MenuFileSaveMap.Size = new System.Drawing.Size(225, 26);
            this.MenuFileSaveMap.Text = "Сохранить карту";
            this.MenuFileSaveMap.Click += new System.EventHandler(this.MenuFileSaveMap_Click);
            // 
            // MenuFileSeparator1
            // 
            this.MenuFileSeparator1.Name = "MenuFileSeparator1";
            this.MenuFileSeparator1.Size = new System.Drawing.Size(222, 6);
            // 
            // MenuFileCreateMission
            // 
            this.MenuFileCreateMission.Name = "MenuFileCreateMission";
            this.MenuFileCreateMission.Size = new System.Drawing.Size(225, 26);
            this.MenuFileCreateMission.Text = "Создать миссию";
            this.MenuFileCreateMission.Click += new System.EventHandler(this.MenuFileCreateMission_Click);
            // 
            // MenuFileOpenMission
            // 
            this.MenuFileOpenMission.Name = "MenuFileOpenMission";
            this.MenuFileOpenMission.Size = new System.Drawing.Size(225, 26);
            this.MenuFileOpenMission.Text = "Открыть миссию";
            // 
            // MenuFileSaveMission
            // 
            this.MenuFileSaveMission.Name = "MenuFileSaveMission";
            this.MenuFileSaveMission.Size = new System.Drawing.Size(225, 26);
            this.MenuFileSaveMission.Text = "Сохранить миссию";
            // 
            // Status
            // 
            this.Status.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusCoordinates});
            this.Status.Location = new System.Drawing.Point(0, 545);
            this.Status.Name = "Status";
            this.Status.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.Status.Size = new System.Drawing.Size(1045, 22);
            this.Status.TabIndex = 2;
            this.Status.Text = "statusStrip1";
            // 
            // StatusCoordinates
            // 
            this.StatusCoordinates.Name = "StatusCoordinates";
            this.StatusCoordinates.Size = new System.Drawing.Size(0, 16);
            // 
            // contextMenuDivision
            // 
            this.contextMenuDivision.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuDivision.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuDivisionEdit,
            this.contextMenuDivisionDelete});
            this.contextMenuDivision.Name = "contextMenuDivision";
            this.contextMenuDivision.Size = new System.Drawing.Size(148, 52);
            // 
            // contextMenuDivisionEdit
            // 
            this.contextMenuDivisionEdit.Name = "contextMenuDivisionEdit";
            this.contextMenuDivisionEdit.Size = new System.Drawing.Size(147, 24);
            this.contextMenuDivisionEdit.Text = "Изменить";
            this.contextMenuDivisionEdit.Click += new System.EventHandler(this.ContextMenuDivisionEdit_Click);
            // 
            // contextMenuDivisionDelete
            // 
            this.contextMenuDivisionDelete.Name = "contextMenuDivisionDelete";
            this.contextMenuDivisionDelete.Size = new System.Drawing.Size(147, 24);
            this.contextMenuDivisionDelete.Text = "Удалить";
            this.contextMenuDivisionDelete.Click += new System.EventHandler(this.ContextMenuDivisionDelete_Click);
            // 
            // SplitContainerRight
            // 
            this.SplitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerRight.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainerRight.IsSplitterFixed = true;
            this.SplitContainerRight.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerRight.Name = "SplitContainerRight";
            // 
            // SplitContainerRight.Panel1
            // 
            this.SplitContainerRight.Panel1.Controls.Add(this.PanelEditor);
            // 
            // SplitContainerRight.Panel2
            // 
            this.SplitContainerRight.Panel2.Controls.Add(this.panelBuilding);
            this.SplitContainerRight.Panel2.Controls.Add(this.panelDivision);
            this.SplitContainerRight.Size = new System.Drawing.Size(764, 565);
            this.SplitContainerRight.SplitterDistance = 530;
            this.SplitContainerRight.TabIndex = 0;
            // 
            // panelBuilding
            // 
            this.panelBuilding.Controls.Add(this.lblSelectedBuildingStatus);
            this.panelBuilding.Controls.Add(this.divisionProperties1);
            this.panelBuilding.Controls.Add(this.btnBuildingUpdate);
            this.panelBuilding.Controls.Add(this.btnBuildingCreate);
            this.panelBuilding.Location = new System.Drawing.Point(3, 280);
            this.panelBuilding.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelBuilding.Name = "panelBuilding";
            this.panelBuilding.Size = new System.Drawing.Size(223, 243);
            this.panelBuilding.TabIndex = 2;
            this.panelBuilding.Visible = false;
            // 
            // lblSelectedBuildingStatus
            // 
            this.lblSelectedBuildingStatus.AutoSize = true;
            this.lblSelectedBuildingStatus.Location = new System.Drawing.Point(10, 13);
            this.lblSelectedBuildingStatus.Name = "lblSelectedBuildingStatus";
            this.lblSelectedBuildingStatus.Size = new System.Drawing.Size(153, 17);
            this.lblSelectedBuildingStatus.TabIndex = 2;
            this.lblSelectedBuildingStatus.Text = "Строение не выбрано";
            // 
            // divisionProperties1
            // 
            this.divisionProperties1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divisionProperties1.Location = new System.Drawing.Point(13, 101);
            this.divisionProperties1.Margin = new System.Windows.Forms.Padding(5);
            this.divisionProperties1.Name = "divisionProperties1";
            this.divisionProperties1.Size = new System.Drawing.Size(195, 91);
            this.divisionProperties1.TabIndex = 0;
            // 
            // btnBuildingUpdate
            // 
            this.btnBuildingUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuildingUpdate.Location = new System.Drawing.Point(13, 71);
            this.btnBuildingUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuildingUpdate.Name = "btnBuildingUpdate";
            this.btnBuildingUpdate.Size = new System.Drawing.Size(193, 23);
            this.btnBuildingUpdate.TabIndex = 1;
            this.btnBuildingUpdate.Text = "Изменить";
            this.btnBuildingUpdate.UseVisualStyleBackColor = true;
            this.btnBuildingUpdate.Click += new System.EventHandler(this.BtnBuildingUpdate_Click);
            // 
            // btnBuildingCreate
            // 
            this.btnBuildingCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuildingCreate.Location = new System.Drawing.Point(13, 42);
            this.btnBuildingCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuildingCreate.Name = "btnBuildingCreate";
            this.btnBuildingCreate.Size = new System.Drawing.Size(193, 23);
            this.btnBuildingCreate.TabIndex = 0;
            this.btnBuildingCreate.Text = "Добавить";
            this.btnBuildingCreate.UseVisualStyleBackColor = true;
            this.btnBuildingCreate.Click += new System.EventHandler(this.BtnBuildingCreate_Click);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 567);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.SplitContainerMain);
            this.MainMenuStrip = this.Menu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1061, 600);
            this.Name = "EditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TacticWar - Редактор миссий";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.EditorForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EditorForm_Paint);
            this.SplitContainerMain.Panel1.ResumeLayout(false);
            this.SplitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerMain)).EndInit();
            this.SplitContainerMain.ResumeLayout(false);
            this.TabControlLeft.ResumeLayout(false);
            this.TabEditor.ResumeLayout(false);
            this.SplitContainerLeft.Panel1.ResumeLayout(false);
            this.SplitContainerLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerLeft)).EndInit();
            this.SplitContainerLeft.ResumeLayout(false);
            this.panelDivision.ResumeLayout(false);
            this.panelDivision.PerformLayout();
            this.TabMapInfo.ResumeLayout(false);
            this.TabMapInfo.PerformLayout();
            this.TabMissionInfo.ResumeLayout(false);
            this.TabMissionInfo.PerformLayout();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.contextMenuDivision.ResumeLayout(false);
            this.SplitContainerRight.Panel1.ResumeLayout(false);
            this.SplitContainerRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerRight)).EndInit();
            this.SplitContainerRight.ResumeLayout(false);
            this.panelBuilding.ResumeLayout(false);
            this.panelBuilding.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TreeViewElements;
        private System.Windows.Forms.SplitContainer SplitContainerMain;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuFileCreateMap;
        private System.Windows.Forms.ToolStripMenuItem MenuFileCreateMission;
        private System.Windows.Forms.Panel PanelElementPreview;
        private System.Windows.Forms.Panel PanelEditor;
        private System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.ToolStripStatusLabel StatusCoordinates;
        private System.Windows.Forms.ToolStripMenuItem MenuFileOpenMap;
        private System.Windows.Forms.ToolStripMenuItem MenuFileSaveMap;
        private System.Windows.Forms.ToolStripSeparator MenuFileSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuFileOpenMission;
        private System.Windows.Forms.ToolStripMenuItem MenuFileSaveMission;
        private System.Windows.Forms.SplitContainer SplitContainerLeft;
        private System.Windows.Forms.TabControl TabControlLeft;
        private System.Windows.Forms.TabPage TabEditor;
        private System.Windows.Forms.TabPage TabMapInfo;
        private System.Windows.Forms.TextBox txtMapDescription;
        private System.Windows.Forms.Label lblMapName;
        private System.Windows.Forms.Label lblMapDescription;
        private System.Windows.Forms.TextBox txtMapName;
        private System.Windows.Forms.Label lblMapSchema;
        private System.Windows.Forms.Label lblMapSize;
        private System.Windows.Forms.TabPage TabMissionInfo;
        private System.Windows.Forms.Label lblMissionName;
        private System.Windows.Forms.TextBox txtMissionName;
        private System.Windows.Forms.TextBox txtMissionBriefing;
        private System.Windows.Forms.Label lblMissionBriefing;
        private System.Windows.Forms.ColorDialog colorSelectDialog;
        private System.Windows.Forms.Panel panelDivision;
        private System.Windows.Forms.Button btnDivisionUpdate;
        private System.Windows.Forms.Button btnDivisionCreate;
        private System.Windows.Forms.ContextMenuStrip contextMenuDivision;
        private System.Windows.Forms.ToolStripMenuItem contextMenuDivisionEdit;
        private System.Windows.Forms.ToolStripMenuItem contextMenuDivisionDelete;
        private System.Windows.Forms.Button btnMissionPlayers;
        private Controls.DivisionProperties divisionProperties;
        private System.Windows.Forms.Label lblSelectedDivisionStatus;
        private System.Windows.Forms.SplitContainer SplitContainerRight;
        private System.Windows.Forms.Panel panelBuilding;
        private System.Windows.Forms.Label lblSelectedBuildingStatus;
        private Controls.DivisionProperties divisionProperties1;
        private System.Windows.Forms.Button btnBuildingUpdate;
        private System.Windows.Forms.Button btnBuildingCreate;
    }
}


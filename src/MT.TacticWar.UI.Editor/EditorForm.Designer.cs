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
            this.MenuMap = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMapNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMapOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMapSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMapSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMission = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMissionNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMissionOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMissionSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMissionSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMissionSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MenuMissionCompile = new System.Windows.Forms.ToolStripMenuItem();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.StatusCoordinates = new System.Windows.Forms.ToolStripStatusLabel();
            this.TabControlLeft = new System.Windows.Forms.TabControl();
            this.TabEditor = new System.Windows.Forms.TabPage();
            this.SplitContainerLeft = new System.Windows.Forms.SplitContainer();
            this.TreeViewElements = new System.Windows.Forms.TreeView();
            this.PanelElementPreview = new System.Windows.Forms.Panel();
            this.TabMapInfo = new System.Windows.Forms.TabPage();
            this.txtMapVersion = new System.Windows.Forms.TextBox();
            this.lblMapSchema = new System.Windows.Forms.Label();
            this.lblMapVersion = new System.Windows.Forms.Label();
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
            this.txtMissionVersion = new System.Windows.Forms.TextBox();
            this.lblMissionVersion = new System.Windows.Forms.Label();
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
            this.MenuMap,
            this.MenuMission});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.Menu.Size = new System.Drawing.Size(1235, 28);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "Меню";
            // 
            // MenuMap
            // 
            this.MenuMap.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuMapNew,
            this.MenuMapOpen,
            this.MenuMapSave,
            this.MenuMapSaveAs});
            this.MenuMap.Name = "MenuMap";
            this.MenuMap.Size = new System.Drawing.Size(63, 24);
            this.MenuMap.Text = "&Карта";
            // 
            // MenuMapNew
            // 
            this.MenuMapNew.Name = "MenuMapNew";
            this.MenuMapNew.Size = new System.Drawing.Size(192, 26);
            this.MenuMapNew.Text = "Создать";
            this.MenuMapNew.Click += new System.EventHandler(this.MenuMapNew_Click);
            // 
            // MenuMapOpen
            // 
            this.MenuMapOpen.Name = "MenuMapOpen";
            this.MenuMapOpen.Size = new System.Drawing.Size(192, 26);
            this.MenuMapOpen.Text = "Открыть";
            this.MenuMapOpen.Click += new System.EventHandler(this.MenuMapOpen_Click);
            // 
            // MenuMapSave
            // 
            this.MenuMapSave.Name = "MenuMapSave";
            this.MenuMapSave.Size = new System.Drawing.Size(192, 26);
            this.MenuMapSave.Text = "Сохранить";
            this.MenuMapSave.Click += new System.EventHandler(this.MenuMapSave_Click);
            // 
            // MenuMapSaveAs
            // 
            this.MenuMapSaveAs.Name = "MenuMapSaveAs";
            this.MenuMapSaveAs.Size = new System.Drawing.Size(192, 26);
            this.MenuMapSaveAs.Text = "Сохранить как";
            this.MenuMapSaveAs.Click += new System.EventHandler(this.MenuMapSaveAs_Click);
            // 
            // MenuMission
            // 
            this.MenuMission.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuMissionNew,
            this.MenuMissionOpen,
            this.MenuMissionSave,
            this.MenuMissionSaveAs,
            this.MenuMissionSeparator,
            this.MenuMissionCompile});
            this.MenuMission.Name = "MenuMission";
            this.MenuMission.Size = new System.Drawing.Size(76, 24);
            this.MenuMission.Text = "&Миссия";
            // 
            // MenuMissionNew
            // 
            this.MenuMissionNew.Name = "MenuMissionNew";
            this.MenuMissionNew.Size = new System.Drawing.Size(211, 26);
            this.MenuMissionNew.Text = "Создать";
            this.MenuMissionNew.Click += new System.EventHandler(this.MenuMissionNew_Click);
            // 
            // MenuMissionOpen
            // 
            this.MenuMissionOpen.Name = "MenuMissionOpen";
            this.MenuMissionOpen.Size = new System.Drawing.Size(211, 26);
            this.MenuMissionOpen.Text = "Открыть";
            this.MenuMissionOpen.Click += new System.EventHandler(this.MenuMissionOpen_Click);
            // 
            // MenuMissionSave
            // 
            this.MenuMissionSave.Name = "MenuMissionSave";
            this.MenuMissionSave.Size = new System.Drawing.Size(211, 26);
            this.MenuMissionSave.Text = "Сохранить";
            this.MenuMissionSave.Click += new System.EventHandler(this.MenuMissionSave_Click);
            // 
            // MenuMissionSaveAs
            // 
            this.MenuMissionSaveAs.Name = "MenuMissionSaveAs";
            this.MenuMissionSaveAs.Size = new System.Drawing.Size(211, 26);
            this.MenuMissionSaveAs.Text = "Сохранить как";
            this.MenuMissionSaveAs.Click += new System.EventHandler(this.MenuMissionSaveAs_Click);
            // 
            // MenuMissionSeparator
            // 
            this.MenuMissionSeparator.Name = "MenuMissionSeparator";
            this.MenuMissionSeparator.Size = new System.Drawing.Size(208, 6);
            // 
            // MenuMissionCompile
            // 
            this.MenuMissionCompile.Name = "MenuMissionCompile";
            this.MenuMissionCompile.Size = new System.Drawing.Size(211, 26);
            this.MenuMissionCompile.Text = "Скомпилировать";
            this.MenuMissionCompile.Click += new System.EventHandler(this.MenuMissionCompile_Click);
            // 
            // Status
            // 
            this.Status.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusCoordinates});
            this.Status.Location = new System.Drawing.Point(0, 550);
            this.Status.Name = "Status";
            this.Status.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.Status.Size = new System.Drawing.Size(1235, 22);
            this.Status.TabIndex = 2;
            this.Status.Text = "statusStrip1";
            // 
            // StatusCoordinates
            // 
            this.StatusCoordinates.Name = "StatusCoordinates";
            this.StatusCoordinates.Size = new System.Drawing.Size(0, 16);
            // 
            // TabControlLeft
            // 
            this.TabControlLeft.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TabControlLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TabControlLeft.Controls.Add(this.TabEditor);
            this.TabControlLeft.Controls.Add(this.TabMapInfo);
            this.TabControlLeft.Controls.Add(this.TabMissionInfo);
            this.TabControlLeft.Location = new System.Drawing.Point(0, 32);
            this.TabControlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TabControlLeft.Multiline = true;
            this.TabControlLeft.Name = "TabControlLeft";
            this.TabControlLeft.SelectedIndex = 0;
            this.TabControlLeft.Size = new System.Drawing.Size(303, 511);
            this.TabControlLeft.TabIndex = 4;
            // 
            // TabEditor
            // 
            this.TabEditor.Controls.Add(this.SplitContainerLeft);
            this.TabEditor.Location = new System.Drawing.Point(25, 4);
            this.TabEditor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TabEditor.Name = "TabEditor";
            this.TabEditor.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TabEditor.Size = new System.Drawing.Size(274, 503);
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
            this.SplitContainerLeft.Size = new System.Drawing.Size(268, 499);
            this.SplitContainerLeft.SplitterDistance = 373;
            this.SplitContainerLeft.TabIndex = 2;
            // 
            // TreeViewElements
            // 
            this.TreeViewElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeViewElements.Location = new System.Drawing.Point(0, 0);
            this.TreeViewElements.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TreeViewElements.Name = "TreeViewElements";
            this.TreeViewElements.Size = new System.Drawing.Size(266, 371);
            this.TreeViewElements.TabIndex = 0;
            this.TreeViewElements.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeViewElements_BeforeSelect);
            this.TreeViewElements.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewElements_AfterSelect);
            // 
            // PanelElementPreview
            // 
            this.PanelElementPreview.BackColor = System.Drawing.SystemColors.Control;
            this.PanelElementPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelElementPreview.Location = new System.Drawing.Point(0, 0);
            this.PanelElementPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanelElementPreview.Name = "PanelElementPreview";
            this.PanelElementPreview.Size = new System.Drawing.Size(266, 120);
            this.PanelElementPreview.TabIndex = 1;
            // 
            // TabMapInfo
            // 
            this.TabMapInfo.Controls.Add(this.txtMapVersion);
            this.TabMapInfo.Controls.Add(this.lblMapSchema);
            this.TabMapInfo.Controls.Add(this.lblMapVersion);
            this.TabMapInfo.Controls.Add(this.lblMapSize);
            this.TabMapInfo.Controls.Add(this.txtMapDescription);
            this.TabMapInfo.Controls.Add(this.lblMapName);
            this.TabMapInfo.Controls.Add(this.lblMapDescription);
            this.TabMapInfo.Controls.Add(this.txtMapName);
            this.TabMapInfo.Location = new System.Drawing.Point(25, 4);
            this.TabMapInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TabMapInfo.Name = "TabMapInfo";
            this.TabMapInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TabMapInfo.Size = new System.Drawing.Size(274, 503);
            this.TabMapInfo.TabIndex = 1;
            this.TabMapInfo.Text = "Карта";
            this.TabMapInfo.UseVisualStyleBackColor = true;
            // 
            // txtMapVersion
            // 
            this.txtMapVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMapVersion.Location = new System.Drawing.Point(9, 379);
            this.txtMapVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMapVersion.Name = "txtMapVersion";
            this.txtMapVersion.Size = new System.Drawing.Size(192, 22);
            this.txtMapVersion.TabIndex = 5;
            this.txtMapVersion.Text = "1.0";
            // 
            // lblMapSchema
            // 
            this.lblMapSchema.AutoSize = true;
            this.lblMapSchema.Location = new System.Drawing.Point(5, 448);
            this.lblMapSchema.Name = "lblMapSchema";
            this.lblMapSchema.Size = new System.Drawing.Size(96, 17);
            this.lblMapSchema.TabIndex = 7;
            this.lblMapSchema.Text = "Схема карты:";
            // 
            // lblMapVersion
            // 
            this.lblMapVersion.AutoSize = true;
            this.lblMapVersion.Location = new System.Drawing.Point(5, 359);
            this.lblMapVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMapVersion.Name = "lblMapVersion";
            this.lblMapVersion.Size = new System.Drawing.Size(60, 17);
            this.lblMapVersion.TabIndex = 4;
            this.lblMapVersion.Text = "Версия:";
            // 
            // lblMapSize
            // 
            this.lblMapSize.AutoSize = true;
            this.lblMapSize.Location = new System.Drawing.Point(5, 420);
            this.lblMapSize.Name = "lblMapSize";
            this.lblMapSize.Size = new System.Drawing.Size(105, 17);
            this.lblMapSize.TabIndex = 6;
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
            this.txtMapDescription.Size = new System.Drawing.Size(192, 246);
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
            this.txtMapName.Size = new System.Drawing.Size(192, 22);
            this.txtMapName.TabIndex = 1;
            this.txtMapName.Text = "Карта местности";
            // 
            // TabMissionInfo
            // 
            this.TabMissionInfo.Controls.Add(this.txtMissionVersion);
            this.TabMissionInfo.Controls.Add(this.lblMissionVersion);
            this.TabMissionInfo.Controls.Add(this.btnMissionPlayers);
            this.TabMissionInfo.Controls.Add(this.lblMissionName);
            this.TabMissionInfo.Controls.Add(this.txtMissionName);
            this.TabMissionInfo.Controls.Add(this.txtMissionBriefing);
            this.TabMissionInfo.Controls.Add(this.lblMissionBriefing);
            this.TabMissionInfo.Location = new System.Drawing.Point(25, 4);
            this.TabMissionInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TabMissionInfo.Name = "TabMissionInfo";
            this.TabMissionInfo.Size = new System.Drawing.Size(274, 503);
            this.TabMissionInfo.TabIndex = 2;
            this.TabMissionInfo.Text = "Миссия";
            this.TabMissionInfo.UseVisualStyleBackColor = true;
            // 
            // btnMissionPlayers
            // 
            this.btnMissionPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMissionPlayers.Location = new System.Drawing.Point(9, 372);
            this.btnMissionPlayers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMissionPlayers.Name = "btnMissionPlayers";
            this.btnMissionPlayers.Size = new System.Drawing.Size(195, 28);
            this.btnMissionPlayers.TabIndex = 6;
            this.btnMissionPlayers.Text = "Игроки";
            this.btnMissionPlayers.UseVisualStyleBackColor = true;
            this.btnMissionPlayers.Click += new System.EventHandler(this.BtnMissionPlayers_Click);
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
            this.txtMissionName.Size = new System.Drawing.Size(192, 22);
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
            this.txtMissionBriefing.Size = new System.Drawing.Size(192, 198);
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
            this.flowLayoutRight.Location = new System.Drawing.Point(774, 32);
            this.flowLayoutRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutRight.Name = "flowLayoutRight";
            this.flowLayoutRight.Size = new System.Drawing.Size(460, 504);
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
            this.panelDivision.Location = new System.Drawing.Point(232, 2);
            this.panelDivision.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDivision.Name = "panelDivision";
            this.panelDivision.Size = new System.Drawing.Size(223, 498);
            this.panelDivision.TabIndex = 1;
            this.panelDivision.Visible = false;
            // 
            // btnDivisionDelete
            // 
            this.btnDivisionDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDivisionDelete.Location = new System.Drawing.Point(13, 73);
            this.btnDivisionDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDivisionDelete.Name = "btnDivisionDelete";
            this.btnDivisionDelete.Size = new System.Drawing.Size(193, 23);
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
            this.lblSelectedDivisionStatus.Location = new System.Drawing.Point(13, 199);
            this.lblSelectedDivisionStatus.Name = "lblSelectedDivisionStatus";
            this.lblSelectedDivisionStatus.Size = new System.Drawing.Size(193, 282);
            this.lblSelectedDivisionStatus.TabIndex = 2;
            this.lblSelectedDivisionStatus.Text = "Подразделение не выбрано";
            // 
            // btnDivisionUpdate
            // 
            this.btnDivisionUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDivisionUpdate.Location = new System.Drawing.Point(13, 43);
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
            this.btnDivisionCreate.Location = new System.Drawing.Point(13, 14);
            this.btnDivisionCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDivisionCreate.Name = "btnDivisionCreate";
            this.btnDivisionCreate.Size = new System.Drawing.Size(193, 23);
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
            this.panelBuilding.Location = new System.Drawing.Point(3, 2);
            this.panelBuilding.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelBuilding.Name = "panelBuilding";
            this.panelBuilding.Size = new System.Drawing.Size(223, 498);
            this.panelBuilding.TabIndex = 2;
            this.panelBuilding.Visible = false;
            // 
            // btnBuildingDelete
            // 
            this.btnBuildingDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuildingDelete.Location = new System.Drawing.Point(13, 73);
            this.btnBuildingDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuildingDelete.Name = "btnBuildingDelete";
            this.btnBuildingDelete.Size = new System.Drawing.Size(193, 23);
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
            this.lblSelectedBuildingStatus.Location = new System.Drawing.Point(13, 199);
            this.lblSelectedBuildingStatus.Name = "lblSelectedBuildingStatus";
            this.lblSelectedBuildingStatus.Size = new System.Drawing.Size(193, 282);
            this.lblSelectedBuildingStatus.TabIndex = 2;
            this.lblSelectedBuildingStatus.Text = "Строение не выбрано";
            // 
            // btnBuildingUpdate
            // 
            this.btnBuildingUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuildingUpdate.Location = new System.Drawing.Point(13, 43);
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
            this.btnBuildingCreate.Location = new System.Drawing.Point(13, 14);
            this.btnBuildingCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuildingCreate.Name = "btnBuildingCreate";
            this.btnBuildingCreate.Size = new System.Drawing.Size(193, 23);
            this.btnBuildingCreate.TabIndex = 0;
            this.btnBuildingCreate.Text = "Добавить";
            this.btnBuildingCreate.UseVisualStyleBackColor = true;
            this.btnBuildingCreate.Click += new System.EventHandler(this.BtnBuildingCreate_Click);
            // 
            // PanelEditor
            // 
            this.PanelEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelEditor.Location = new System.Drawing.Point(309, 37);
            this.PanelEditor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanelEditor.Name = "PanelEditor";
            this.PanelEditor.Size = new System.Drawing.Size(391, 350);
            this.PanelEditor.TabIndex = 5;
            this.PanelEditor.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelEditor_Paint);
            this.PanelEditor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelEditor_MouseClick);
            this.PanelEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelEditor_MouseDown);
            this.PanelEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelEditor_MouseMove);
            this.PanelEditor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelEditor_MouseUp);
            // 
            // txtMissionVersion
            // 
            this.txtMissionVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMissionVersion.Location = new System.Drawing.Point(9, 329);
            this.txtMissionVersion.Margin = new System.Windows.Forms.Padding(4);
            this.txtMissionVersion.Name = "txtMissionVersion";
            this.txtMissionVersion.Size = new System.Drawing.Size(192, 22);
            this.txtMissionVersion.TabIndex = 5;
            this.txtMissionVersion.Text = "1.0";
            // 
            // lblMissionVersion
            // 
            this.lblMissionVersion.AutoSize = true;
            this.lblMissionVersion.Location = new System.Drawing.Point(6, 308);
            this.lblMissionVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMissionVersion.Name = "lblMissionVersion";
            this.lblMissionVersion.Size = new System.Drawing.Size(60, 17);
            this.lblMissionVersion.TabIndex = 4;
            this.lblMissionVersion.Text = "Версия:";
            // 
            // divisionProperties
            // 
            this.divisionProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divisionProperties.Location = new System.Drawing.Point(13, 103);
            this.divisionProperties.Margin = new System.Windows.Forms.Padding(5);
            this.divisionProperties.Name = "divisionProperties";
            this.divisionProperties.Size = new System.Drawing.Size(193, 91);
            this.divisionProperties.TabIndex = 0;
            // 
            // buildingProperties
            // 
            this.buildingProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buildingProperties.Location = new System.Drawing.Point(13, 103);
            this.buildingProperties.Margin = new System.Windows.Forms.Padding(5);
            this.buildingProperties.Name = "buildingProperties";
            this.buildingProperties.Size = new System.Drawing.Size(193, 91);
            this.buildingProperties.TabIndex = 0;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 572);
            this.Controls.Add(this.TabControlLeft);
            this.Controls.Add(this.flowLayoutRight);
            this.Controls.Add(this.PanelEditor);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1061, 596);
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
        private System.Windows.Forms.ToolStripMenuItem MenuMap;
        private System.Windows.Forms.ToolStripMenuItem MenuMapNew;
        private System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.ToolStripStatusLabel StatusCoordinates;
        private System.Windows.Forms.ToolStripMenuItem MenuMapOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuMapSave;
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
        private System.Windows.Forms.TextBox txtMapVersion;
        private System.Windows.Forms.Label lblMapVersion;
        private System.Windows.Forms.ToolStripMenuItem MenuMapSaveAs;
        private System.Windows.Forms.ToolStripMenuItem MenuMission;
        private System.Windows.Forms.ToolStripMenuItem MenuMissionNew;
        private System.Windows.Forms.ToolStripMenuItem MenuMissionOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuMissionSave;
        private System.Windows.Forms.ToolStripSeparator MenuMissionSeparator;
        private System.Windows.Forms.ToolStripMenuItem MenuMissionCompile;
        private System.Windows.Forms.ToolStripMenuItem MenuMissionSaveAs;
        private System.Windows.Forms.TextBox txtMissionVersion;
        private System.Windows.Forms.Label lblMissionVersion;
    }
}


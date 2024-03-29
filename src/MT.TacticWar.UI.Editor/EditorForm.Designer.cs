﻿namespace MT.TacticWar.UI.Editor
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
            this.MenuEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEditorRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.StatusStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusSeparator1 = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.btnMissionScripts = new System.Windows.Forms.Button();
            this.txtMissionVersion = new System.Windows.Forms.TextBox();
            this.lblMissionVersion = new System.Windows.Forms.Label();
            this.btnMissionPlayers = new System.Windows.Forms.Button();
            this.lblMissionName = new System.Windows.Forms.Label();
            this.txtMissionName = new System.Windows.Forms.TextBox();
            this.txtMissionBriefing = new System.Windows.Forms.TextBox();
            this.lblMissionBriefing = new System.Windows.Forms.Label();
            this.panelObjectToolset = new System.Windows.Forms.Panel();
            this.txtObjectStatus = new System.Windows.Forms.TextBox();
            this.btnObjectDelete = new System.Windows.Forms.Button();
            this.btnObjectNewBuilding = new System.Windows.Forms.Button();
            this.btnObjectUpdate = new System.Windows.Forms.Button();
            this.btnObjectNewDivision = new System.Windows.Forms.Button();
            this.PanelEditor = new System.Windows.Forms.Panel();
            this.flowToolsRight = new System.Windows.Forms.FlowLayoutPanel();
            this.panelZoneToolset = new System.Windows.Forms.Panel();
            this.lblZoneId = new System.Windows.Forms.Label();
            this.numZoneId = new System.Windows.Forms.NumericUpDown();
            this.btnZoneRemove = new System.Windows.Forms.Button();
            this.btnZoneAdd = new System.Windows.Forms.Button();
            this.panelGateToolset = new System.Windows.Forms.Panel();
            this.comboGatePlayer = new System.Windows.Forms.ComboBox();
            this.lblGatePlayer = new System.Windows.Forms.Label();
            this.lblGateId = new System.Windows.Forms.Label();
            this.numGateId = new System.Windows.Forms.NumericUpDown();
            this.btnGateRemove = new System.Windows.Forms.Button();
            this.btnGateAdd = new System.Windows.Forms.Button();
            this.btnMissionReinforcement = new System.Windows.Forms.Button();
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
            this.panelObjectToolset.SuspendLayout();
            this.flowToolsRight.SuspendLayout();
            this.panelZoneToolset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZoneId)).BeginInit();
            this.panelGateToolset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGateId)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuMap,
            this.MenuMission,
            this.MenuEditor});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.Menu.Size = new System.Drawing.Size(1235, 30);
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
            this.MenuMap.Size = new System.Drawing.Size(63, 26);
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
            this.MenuMission.Size = new System.Drawing.Size(76, 26);
            this.MenuMission.Text = "&Миссия";
            // 
            // MenuMissionNew
            // 
            this.MenuMissionNew.Name = "MenuMissionNew";
            this.MenuMissionNew.Size = new System.Drawing.Size(192, 26);
            this.MenuMissionNew.Text = "Создать";
            this.MenuMissionNew.Click += new System.EventHandler(this.MenuMissionNew_Click);
            // 
            // MenuMissionOpen
            // 
            this.MenuMissionOpen.Name = "MenuMissionOpen";
            this.MenuMissionOpen.Size = new System.Drawing.Size(192, 26);
            this.MenuMissionOpen.Text = "Открыть";
            this.MenuMissionOpen.Click += new System.EventHandler(this.MenuMissionOpen_Click);
            // 
            // MenuMissionSave
            // 
            this.MenuMissionSave.Name = "MenuMissionSave";
            this.MenuMissionSave.Size = new System.Drawing.Size(192, 26);
            this.MenuMissionSave.Text = "Сохранить";
            this.MenuMissionSave.Click += new System.EventHandler(this.MenuMissionSave_Click);
            // 
            // MenuMissionSaveAs
            // 
            this.MenuMissionSaveAs.Name = "MenuMissionSaveAs";
            this.MenuMissionSaveAs.Size = new System.Drawing.Size(192, 26);
            this.MenuMissionSaveAs.Text = "Сохранить как";
            this.MenuMissionSaveAs.Click += new System.EventHandler(this.MenuMissionSaveAs_Click);
            // 
            // MenuMissionSeparator
            // 
            this.MenuMissionSeparator.Name = "MenuMissionSeparator";
            this.MenuMissionSeparator.Size = new System.Drawing.Size(189, 6);
            // 
            // MenuMissionCompile
            // 
            this.MenuMissionCompile.Name = "MenuMissionCompile";
            this.MenuMissionCompile.Size = new System.Drawing.Size(192, 26);
            this.MenuMissionCompile.Text = "Собрать";
            this.MenuMissionCompile.Click += new System.EventHandler(this.MenuMissionCompile_Click);
            // 
            // MenuEditor
            // 
            this.MenuEditor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEditorRefresh});
            this.MenuEditor.Name = "MenuEditor";
            this.MenuEditor.Size = new System.Drawing.Size(86, 26);
            this.MenuEditor.Text = "&Редактор";
            // 
            // MenuEditorRefresh
            // 
            this.MenuEditorRefresh.Name = "MenuEditorRefresh";
            this.MenuEditorRefresh.Size = new System.Drawing.Size(161, 26);
            this.MenuEditorRefresh.Text = "Обновить";
            this.MenuEditorRefresh.Click += new System.EventHandler(this.MenuEditorRefresh_Click);
            // 
            // Status
            // 
            this.Status.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusStatus,
            this.StatusSeparator1,
            this.StatusCoordinates});
            this.Status.Location = new System.Drawing.Point(0, 550);
            this.Status.Name = "Status";
            this.Status.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.Status.Size = new System.Drawing.Size(1235, 22);
            this.Status.TabIndex = 2;
            this.Status.Text = "statusStrip1";
            // 
            // StatusStatus
            // 
            this.StatusStatus.Name = "StatusStatus";
            this.StatusStatus.Size = new System.Drawing.Size(0, 16);
            // 
            // StatusSeparator1
            // 
            this.StatusSeparator1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.StatusSeparator1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.StatusSeparator1.Name = "StatusSeparator1";
            this.StatusSeparator1.Size = new System.Drawing.Size(4, 16);
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
            this.SplitContainerLeft.SplitterDistance = 374;
            this.SplitContainerLeft.TabIndex = 2;
            // 
            // TreeViewElements
            // 
            this.TreeViewElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeViewElements.Location = new System.Drawing.Point(0, 0);
            this.TreeViewElements.Margin = new System.Windows.Forms.Padding(4);
            this.TreeViewElements.Name = "TreeViewElements";
            this.TreeViewElements.Size = new System.Drawing.Size(266, 372);
            this.TreeViewElements.TabIndex = 0;
            this.TreeViewElements.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeViewElements_BeforeSelect);
            this.TreeViewElements.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewElements_AfterSelect);
            // 
            // PanelElementPreview
            // 
            this.PanelElementPreview.BackColor = System.Drawing.SystemColors.Control;
            this.PanelElementPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelElementPreview.Location = new System.Drawing.Point(0, 0);
            this.PanelElementPreview.Margin = new System.Windows.Forms.Padding(4);
            this.PanelElementPreview.Name = "PanelElementPreview";
            this.PanelElementPreview.Size = new System.Drawing.Size(266, 119);
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
            this.txtMapVersion.Margin = new System.Windows.Forms.Padding(4);
            this.txtMapVersion.Name = "txtMapVersion";
            this.txtMapVersion.Size = new System.Drawing.Size(249, 22);
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
            this.txtMapDescription.Size = new System.Drawing.Size(249, 246);
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
            this.txtMapName.Size = new System.Drawing.Size(249, 22);
            this.txtMapName.TabIndex = 1;
            this.txtMapName.Text = "Карта местности";
            // 
            // TabMissionInfo
            // 
            this.TabMissionInfo.Controls.Add(this.btnMissionReinforcement);
            this.TabMissionInfo.Controls.Add(this.btnMissionScripts);
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
            // btnMissionScripts
            // 
            this.btnMissionScripts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMissionScripts.Location = new System.Drawing.Point(9, 438);
            this.btnMissionScripts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMissionScripts.Name = "btnMissionScripts";
            this.btnMissionScripts.Size = new System.Drawing.Size(247, 28);
            this.btnMissionScripts.TabIndex = 8;
            this.btnMissionScripts.Text = "Скрипты";
            this.btnMissionScripts.UseVisualStyleBackColor = true;
            this.btnMissionScripts.Click += new System.EventHandler(this.BtnMissionScripts_Click);
            // 
            // txtMissionVersion
            // 
            this.txtMissionVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMissionVersion.Location = new System.Drawing.Point(9, 329);
            this.txtMissionVersion.Margin = new System.Windows.Forms.Padding(4);
            this.txtMissionVersion.Name = "txtMissionVersion";
            this.txtMissionVersion.Size = new System.Drawing.Size(247, 22);
            this.txtMissionVersion.TabIndex = 5;
            this.txtMissionVersion.Text = "1.0";
            // 
            // lblMissionVersion
            // 
            this.lblMissionVersion.AutoSize = true;
            this.lblMissionVersion.Location = new System.Drawing.Point(5, 308);
            this.lblMissionVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMissionVersion.Name = "lblMissionVersion";
            this.lblMissionVersion.Size = new System.Drawing.Size(60, 17);
            this.lblMissionVersion.TabIndex = 4;
            this.lblMissionVersion.Text = "Версия:";
            // 
            // btnMissionPlayers
            // 
            this.btnMissionPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMissionPlayers.Location = new System.Drawing.Point(9, 372);
            this.btnMissionPlayers.Margin = new System.Windows.Forms.Padding(4);
            this.btnMissionPlayers.Name = "btnMissionPlayers";
            this.btnMissionPlayers.Size = new System.Drawing.Size(247, 28);
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
            this.txtMissionName.Size = new System.Drawing.Size(247, 22);
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
            this.txtMissionBriefing.Size = new System.Drawing.Size(247, 198);
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
            // panelObjectToolset
            // 
            this.panelObjectToolset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelObjectToolset.Controls.Add(this.txtObjectStatus);
            this.panelObjectToolset.Controls.Add(this.btnObjectDelete);
            this.panelObjectToolset.Controls.Add(this.btnObjectNewBuilding);
            this.panelObjectToolset.Controls.Add(this.btnObjectUpdate);
            this.panelObjectToolset.Controls.Add(this.btnObjectNewDivision);
            this.panelObjectToolset.Location = new System.Drawing.Point(461, 2);
            this.panelObjectToolset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelObjectToolset.Name = "panelObjectToolset";
            this.panelObjectToolset.Size = new System.Drawing.Size(223, 516);
            this.panelObjectToolset.TabIndex = 1;
            this.panelObjectToolset.Visible = false;
            // 
            // txtObjectStatus
            // 
            this.txtObjectStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObjectStatus.Location = new System.Drawing.Point(13, 155);
            this.txtObjectStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObjectStatus.Multiline = true;
            this.txtObjectStatus.Name = "txtObjectStatus";
            this.txtObjectStatus.ReadOnly = true;
            this.txtObjectStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObjectStatus.Size = new System.Drawing.Size(199, 344);
            this.txtObjectStatus.TabIndex = 4;
            // 
            // btnObjectDelete
            // 
            this.btnObjectDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnObjectDelete.Location = new System.Drawing.Point(13, 111);
            this.btnObjectDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnObjectDelete.Name = "btnObjectDelete";
            this.btnObjectDelete.Size = new System.Drawing.Size(197, 28);
            this.btnObjectDelete.TabIndex = 3;
            this.btnObjectDelete.Text = "Удалить";
            this.btnObjectDelete.UseVisualStyleBackColor = true;
            this.btnObjectDelete.Click += new System.EventHandler(this.BtnObjectDelete_Click);
            // 
            // btnObjectNewBuilding
            // 
            this.btnObjectNewBuilding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnObjectNewBuilding.Location = new System.Drawing.Point(13, 47);
            this.btnObjectNewBuilding.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnObjectNewBuilding.Name = "btnObjectNewBuilding";
            this.btnObjectNewBuilding.Size = new System.Drawing.Size(197, 28);
            this.btnObjectNewBuilding.TabIndex = 1;
            this.btnObjectNewBuilding.Text = "+ Строение";
            this.btnObjectNewBuilding.UseVisualStyleBackColor = true;
            this.btnObjectNewBuilding.Click += new System.EventHandler(this.BtnObjectNewBuilding_Click);
            // 
            // btnObjectUpdate
            // 
            this.btnObjectUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnObjectUpdate.Location = new System.Drawing.Point(13, 79);
            this.btnObjectUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnObjectUpdate.Name = "btnObjectUpdate";
            this.btnObjectUpdate.Size = new System.Drawing.Size(197, 28);
            this.btnObjectUpdate.TabIndex = 2;
            this.btnObjectUpdate.Text = "Изменить";
            this.btnObjectUpdate.UseVisualStyleBackColor = true;
            this.btnObjectUpdate.Click += new System.EventHandler(this.BtnObjectUpdate_Click);
            // 
            // btnObjectNewDivision
            // 
            this.btnObjectNewDivision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnObjectNewDivision.Location = new System.Drawing.Point(13, 15);
            this.btnObjectNewDivision.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnObjectNewDivision.Name = "btnObjectNewDivision";
            this.btnObjectNewDivision.Size = new System.Drawing.Size(197, 28);
            this.btnObjectNewDivision.TabIndex = 0;
            this.btnObjectNewDivision.Text = "+ Подразделение";
            this.btnObjectNewDivision.UseVisualStyleBackColor = true;
            this.btnObjectNewDivision.Click += new System.EventHandler(this.BtnObjectNewDivision_Click);
            // 
            // PanelEditor
            // 
            this.PanelEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelEditor.Location = new System.Drawing.Point(309, 37);
            this.PanelEditor.Margin = new System.Windows.Forms.Padding(4);
            this.PanelEditor.Name = "PanelEditor";
            this.PanelEditor.Size = new System.Drawing.Size(391, 350);
            this.PanelEditor.TabIndex = 5;
            this.PanelEditor.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelEditor_Paint);
            this.PanelEditor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelEditor_MouseClick);
            this.PanelEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelEditor_MouseDown);
            this.PanelEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelEditor_MouseMove);
            this.PanelEditor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelEditor_MouseUp);
            // 
            // flowToolsRight
            // 
            this.flowToolsRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowToolsRight.AutoSize = true;
            this.flowToolsRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowToolsRight.Controls.Add(this.panelObjectToolset);
            this.flowToolsRight.Controls.Add(this.panelZoneToolset);
            this.flowToolsRight.Controls.Add(this.panelGateToolset);
            this.flowToolsRight.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowToolsRight.Location = new System.Drawing.Point(548, 26);
            this.flowToolsRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowToolsRight.Name = "flowToolsRight";
            this.flowToolsRight.Size = new System.Drawing.Size(687, 520);
            this.flowToolsRight.TabIndex = 6;
            // 
            // panelZoneToolset
            // 
            this.panelZoneToolset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelZoneToolset.Controls.Add(this.lblZoneId);
            this.panelZoneToolset.Controls.Add(this.numZoneId);
            this.panelZoneToolset.Controls.Add(this.btnZoneRemove);
            this.panelZoneToolset.Controls.Add(this.btnZoneAdd);
            this.panelZoneToolset.Location = new System.Drawing.Point(232, 2);
            this.panelZoneToolset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelZoneToolset.Name = "panelZoneToolset";
            this.panelZoneToolset.Size = new System.Drawing.Size(223, 226);
            this.panelZoneToolset.TabIndex = 2;
            this.panelZoneToolset.Visible = false;
            // 
            // lblZoneId
            // 
            this.lblZoneId.AutoSize = true;
            this.lblZoneId.Location = new System.Drawing.Point(11, 31);
            this.lblZoneId.Name = "lblZoneId";
            this.lblZoneId.Size = new System.Drawing.Size(60, 17);
            this.lblZoneId.TabIndex = 0;
            this.lblZoneId.Text = "Id зоны:";
            // 
            // numZoneId
            // 
            this.numZoneId.Location = new System.Drawing.Point(13, 50);
            this.numZoneId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numZoneId.Name = "numZoneId";
            this.numZoneId.Size = new System.Drawing.Size(197, 22);
            this.numZoneId.TabIndex = 1;
            this.numZoneId.ValueChanged += new System.EventHandler(this.NumZoneId_ValueChanged);
            // 
            // btnZoneRemove
            // 
            this.btnZoneRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoneRemove.Location = new System.Drawing.Point(13, 111);
            this.btnZoneRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnZoneRemove.Name = "btnZoneRemove";
            this.btnZoneRemove.Size = new System.Drawing.Size(197, 28);
            this.btnZoneRemove.TabIndex = 3;
            this.btnZoneRemove.Text = "Стирать";
            this.btnZoneRemove.UseVisualStyleBackColor = true;
            this.btnZoneRemove.Click += new System.EventHandler(this.BtnZoneRemove_Click);
            // 
            // btnZoneAdd
            // 
            this.btnZoneAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoneAdd.Location = new System.Drawing.Point(13, 79);
            this.btnZoneAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnZoneAdd.Name = "btnZoneAdd";
            this.btnZoneAdd.Size = new System.Drawing.Size(197, 28);
            this.btnZoneAdd.TabIndex = 2;
            this.btnZoneAdd.Text = "Рисовать";
            this.btnZoneAdd.UseVisualStyleBackColor = true;
            this.btnZoneAdd.Click += new System.EventHandler(this.BtnZoneAdd_Click);
            // 
            // panelGateToolset
            // 
            this.panelGateToolset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGateToolset.Controls.Add(this.comboGatePlayer);
            this.panelGateToolset.Controls.Add(this.lblGatePlayer);
            this.panelGateToolset.Controls.Add(this.lblGateId);
            this.panelGateToolset.Controls.Add(this.numGateId);
            this.panelGateToolset.Controls.Add(this.btnGateRemove);
            this.panelGateToolset.Controls.Add(this.btnGateAdd);
            this.panelGateToolset.Location = new System.Drawing.Point(3, 2);
            this.panelGateToolset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelGateToolset.Name = "panelGateToolset";
            this.panelGateToolset.Size = new System.Drawing.Size(223, 226);
            this.panelGateToolset.TabIndex = 3;
            this.panelGateToolset.Visible = false;
            // 
            // comboGatePlayer
            // 
            this.comboGatePlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboGatePlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGatePlayer.FormattingEnabled = true;
            this.comboGatePlayer.Location = new System.Drawing.Point(13, 49);
            this.comboGatePlayer.Margin = new System.Windows.Forms.Padding(4);
            this.comboGatePlayer.Name = "comboGatePlayer";
            this.comboGatePlayer.Size = new System.Drawing.Size(197, 24);
            this.comboGatePlayer.TabIndex = 1;
            this.comboGatePlayer.SelectedIndexChanged += new System.EventHandler(this.ComboGatePlayer_SelectedIndexChanged);
            // 
            // lblGatePlayer
            // 
            this.lblGatePlayer.AutoSize = true;
            this.lblGatePlayer.Location = new System.Drawing.Point(9, 27);
            this.lblGatePlayer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGatePlayer.Name = "lblGatePlayer";
            this.lblGatePlayer.Size = new System.Drawing.Size(50, 17);
            this.lblGatePlayer.TabIndex = 0;
            this.lblGatePlayer.Text = "Игрок:";
            // 
            // lblGateId
            // 
            this.lblGateId.AutoSize = true;
            this.lblGateId.Location = new System.Drawing.Point(9, 85);
            this.lblGateId.Name = "lblGateId";
            this.lblGateId.Size = new System.Drawing.Size(65, 17);
            this.lblGateId.TabIndex = 2;
            this.lblGateId.Text = "Id ворот:";
            // 
            // numGateId
            // 
            this.numGateId.Location = new System.Drawing.Point(13, 103);
            this.numGateId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numGateId.Name = "numGateId";
            this.numGateId.Size = new System.Drawing.Size(197, 22);
            this.numGateId.TabIndex = 3;
            this.numGateId.ValueChanged += new System.EventHandler(this.NumGateId_ValueChanged);
            // 
            // btnGateRemove
            // 
            this.btnGateRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGateRemove.Location = new System.Drawing.Point(13, 174);
            this.btnGateRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGateRemove.Name = "btnGateRemove";
            this.btnGateRemove.Size = new System.Drawing.Size(197, 28);
            this.btnGateRemove.TabIndex = 5;
            this.btnGateRemove.Text = "Стирать";
            this.btnGateRemove.UseVisualStyleBackColor = true;
            this.btnGateRemove.Click += new System.EventHandler(this.BtnGateRemove_Click);
            // 
            // btnGateAdd
            // 
            this.btnGateAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGateAdd.Location = new System.Drawing.Point(13, 140);
            this.btnGateAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGateAdd.Name = "btnGateAdd";
            this.btnGateAdd.Size = new System.Drawing.Size(197, 28);
            this.btnGateAdd.TabIndex = 4;
            this.btnGateAdd.Text = "Рисовать";
            this.btnGateAdd.UseVisualStyleBackColor = true;
            this.btnGateAdd.Click += new System.EventHandler(this.BtnGateAdd_Click);
            // 
            // btnMissionReinforcement
            // 
            this.btnMissionReinforcement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMissionReinforcement.Location = new System.Drawing.Point(9, 406);
            this.btnMissionReinforcement.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMissionReinforcement.Name = "btnMissionReinforcement";
            this.btnMissionReinforcement.Size = new System.Drawing.Size(247, 28);
            this.btnMissionReinforcement.TabIndex = 7;
            this.btnMissionReinforcement.Text = "Подкрепления";
            this.btnMissionReinforcement.UseVisualStyleBackColor = true;
            this.btnMissionReinforcement.Click += new System.EventHandler(this.BtnMissionReinforcement_Click);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 572);
            this.Controls.Add(this.flowToolsRight);
            this.Controls.Add(this.TabControlLeft);
            this.Controls.Add(this.PanelEditor);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1061, 595);
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
            this.panelObjectToolset.ResumeLayout(false);
            this.panelObjectToolset.PerformLayout();
            this.flowToolsRight.ResumeLayout(false);
            this.panelZoneToolset.ResumeLayout(false);
            this.panelZoneToolset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZoneId)).EndInit();
            this.panelGateToolset.ResumeLayout(false);
            this.panelGateToolset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGateId)).EndInit();
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
        private System.Windows.Forms.Panel panelObjectToolset;
        private System.Windows.Forms.Button btnObjectDelete;
        private System.Windows.Forms.Button btnObjectUpdate;
        private System.Windows.Forms.Button btnObjectNewDivision;
        private System.Windows.Forms.Button btnObjectNewBuilding;
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
        private System.Windows.Forms.TextBox txtObjectStatus;
        private System.Windows.Forms.Button btnMissionScripts;
        private System.Windows.Forms.ToolStripMenuItem MenuEditor;
        private System.Windows.Forms.ToolStripMenuItem MenuEditorRefresh;
        private System.Windows.Forms.FlowLayoutPanel flowToolsRight;
        private System.Windows.Forms.Panel panelZoneToolset;
        private System.Windows.Forms.Label lblZoneId;
        private System.Windows.Forms.NumericUpDown numZoneId;
        private System.Windows.Forms.Button btnZoneRemove;
        private System.Windows.Forms.Button btnZoneAdd;
        private System.Windows.Forms.ToolStripStatusLabel StatusStatus;
        private System.Windows.Forms.ToolStripStatusLabel StatusSeparator1;
        private System.Windows.Forms.Panel panelGateToolset;
        private System.Windows.Forms.Label lblGateId;
        private System.Windows.Forms.NumericUpDown numGateId;
        private System.Windows.Forms.Button btnGateRemove;
        private System.Windows.Forms.Button btnGateAdd;
        private System.Windows.Forms.ComboBox comboGatePlayer;
        private System.Windows.Forms.Label lblGatePlayer;
        private System.Windows.Forms.Button btnMissionReinforcement;
    }
}


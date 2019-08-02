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
            this.TreeViewElements = new System.Windows.Forms.TreeView();
            this.SplitContainerMain = new System.Windows.Forms.SplitContainer();
            this.SplitContainerLeft = new System.Windows.Forms.SplitContainer();
            this.PanelElementPreview = new System.Windows.Forms.Panel();
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
            this.TabControlLeft = new System.Windows.Forms.TabControl();
            this.TabElements = new System.Windows.Forms.TabPage();
            this.TabMapInfo = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerMain)).BeginInit();
            this.SplitContainerMain.Panel1.SuspendLayout();
            this.SplitContainerMain.Panel2.SuspendLayout();
            this.SplitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerLeft)).BeginInit();
            this.SplitContainerLeft.Panel1.SuspendLayout();
            this.SplitContainerLeft.Panel2.SuspendLayout();
            this.SplitContainerLeft.SuspendLayout();
            this.Menu.SuspendLayout();
            this.Status.SuspendLayout();
            this.TabControlLeft.SuspendLayout();
            this.TabElements.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeViewElements
            // 
            this.TreeViewElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeViewElements.Location = new System.Drawing.Point(0, 0);
            this.TreeViewElements.Margin = new System.Windows.Forms.Padding(4);
            this.TreeViewElements.Name = "TreeViewElements";
            this.TreeViewElements.Size = new System.Drawing.Size(192, 275);
            this.TreeViewElements.TabIndex = 0;
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
            this.SplitContainerMain.Panel2.Controls.Add(this.PanelEditor);
            this.SplitContainerMain.Panel2MinSize = 100;
            this.SplitContainerMain.Size = new System.Drawing.Size(1045, 567);
            this.SplitContainerMain.SplitterDistance = 237;
            this.SplitContainerMain.SplitterWidth = 5;
            this.SplitContainerMain.TabIndex = 1;
            // 
            // SplitContainerLeft
            // 
            this.SplitContainerLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SplitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainerLeft.Location = new System.Drawing.Point(3, 3);
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
            this.SplitContainerLeft.Size = new System.Drawing.Size(194, 494);
            this.SplitContainerLeft.SplitterDistance = 277;
            this.SplitContainerLeft.TabIndex = 2;
            // 
            // PanelElementPreview
            // 
            this.PanelElementPreview.BackColor = System.Drawing.SystemColors.Control;
            this.PanelElementPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelElementPreview.Location = new System.Drawing.Point(0, 0);
            this.PanelElementPreview.Margin = new System.Windows.Forms.Padding(4);
            this.PanelElementPreview.Name = "PanelElementPreview";
            this.PanelElementPreview.Size = new System.Drawing.Size(192, 211);
            this.PanelElementPreview.TabIndex = 1;
            // 
            // PanelEditor
            // 
            this.PanelEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelEditor.Location = new System.Drawing.Point(4, 33);
            this.PanelEditor.Margin = new System.Windows.Forms.Padding(4);
            this.PanelEditor.Name = "PanelEditor";
            this.PanelEditor.Size = new System.Drawing.Size(845, 503);
            this.PanelEditor.TabIndex = 0;
            this.PanelEditor.Click += new System.EventHandler(this.PanelEditor_Click);
            this.PanelEditor.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelEditor_Paint);
            this.PanelEditor.MouseLeave += new System.EventHandler(this.PanelEditor_MouseLeave);
            this.PanelEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelEditor_MouseMove);
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
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
            // TabControlLeft
            // 
            this.TabControlLeft.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TabControlLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControlLeft.Controls.Add(this.TabElements);
            this.TabControlLeft.Controls.Add(this.TabMapInfo);
            this.TabControlLeft.Location = new System.Drawing.Point(3, 33);
            this.TabControlLeft.Multiline = true;
            this.TabControlLeft.Name = "TabControlLeft";
            this.TabControlLeft.SelectedIndex = 0;
            this.TabControlLeft.Size = new System.Drawing.Size(229, 508);
            this.TabControlLeft.TabIndex = 0;
            // 
            // TabElements
            // 
            this.TabElements.Controls.Add(this.SplitContainerLeft);
            this.TabElements.Location = new System.Drawing.Point(25, 4);
            this.TabElements.Name = "TabElements";
            this.TabElements.Padding = new System.Windows.Forms.Padding(3);
            this.TabElements.Size = new System.Drawing.Size(200, 500);
            this.TabElements.TabIndex = 0;
            this.TabElements.Text = "Объекты";
            this.TabElements.UseVisualStyleBackColor = true;
            // 
            // TabMapInfo
            // 
            this.TabMapInfo.Location = new System.Drawing.Point(25, 4);
            this.TabMapInfo.Name = "TabMapInfo";
            this.TabMapInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TabMapInfo.Size = new System.Drawing.Size(201, 408);
            this.TabMapInfo.TabIndex = 1;
            this.TabMapInfo.Text = "Карта";
            this.TabMapInfo.UseVisualStyleBackColor = true;
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
            this.MinimumSize = new System.Drawing.Size(1061, 605);
            this.Name = "EditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TacticWar Mission Editor";
            this.Load += new System.EventHandler(this.EditorForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EditorForm_Paint);
            this.SplitContainerMain.Panel1.ResumeLayout(false);
            this.SplitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerMain)).EndInit();
            this.SplitContainerMain.ResumeLayout(false);
            this.SplitContainerLeft.Panel1.ResumeLayout(false);
            this.SplitContainerLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerLeft)).EndInit();
            this.SplitContainerLeft.ResumeLayout(false);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.TabControlLeft.ResumeLayout(false);
            this.TabElements.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage TabElements;
        private System.Windows.Forms.TabPage TabMapInfo;
    }
}


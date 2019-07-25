namespace MT.TacticWar.UI
{
    partial class GameForm
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
            this.gameMap = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMission = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMisLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHlpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.listInfoUnits = new System.Windows.Forms.ListBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.btnEndStep = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameMap
            // 
            this.gameMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameMap.Location = new System.Drawing.Point(16, 33);
            this.gameMap.Margin = new System.Windows.Forms.Padding(4);
            this.gameMap.Name = "gameMap";
            this.gameMap.Size = new System.Drawing.Size(381, 299);
            this.gameMap.TabIndex = 4;
            this.gameMap.Paint += new System.Windows.Forms.PaintEventHandler(this.gameMap_Paint);
            this.gameMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gameMap_MouseClick);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(696, 432);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 0;
            this.button3.Text = "Тест";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuMission,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(969, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "Помощь";
            // 
            // menuFile
            // 
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(57, 24);
            this.menuFile.Text = "Файл";
            // 
            // menuMission
            // 
            this.menuMission.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMisLoad});
            this.menuMission.Name = "menuMission";
            this.menuMission.Size = new System.Drawing.Size(74, 24);
            this.menuMission.Text = "Миссия";
            // 
            // menuMisLoad
            // 
            this.menuMisLoad.Name = "menuMisLoad";
            this.menuMisLoad.Size = new System.Drawing.Size(152, 26);
            this.menuMisLoad.Text = "Загрузить";
            this.menuMisLoad.Click += new System.EventHandler(this.menuMisLoad_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHlpAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(81, 24);
            this.menuHelp.Text = "Помощь";
            // 
            // menuHlpAbout
            // 
            this.menuHlpAbout.Name = "menuHlpAbout";
            this.menuHlpAbout.Size = new System.Drawing.Size(140, 26);
            this.menuHlpAbout.Text = "Об игре";
            // 
            // listInfoUnits
            // 
            this.listInfoUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.listInfoUnits.FormattingEnabled = true;
            this.listInfoUnits.ItemHeight = 16;
            this.listInfoUnits.Location = new System.Drawing.Point(696, 324);
            this.listInfoUnits.Margin = new System.Windows.Forms.Padding(4);
            this.listInfoUnits.Name = "listInfoUnits";
            this.listInfoUnits.Size = new System.Drawing.Size(257, 84);
            this.listInfoUnits.TabIndex = 2;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(696, 33);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(4);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(259, 283);
            this.propertyGrid1.TabIndex = 10;
            // 
            // btnEndStep
            // 
            this.btnEndStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEndStep.Location = new System.Drawing.Point(853, 431);
            this.btnEndStep.Name = "btnEndStep";
            this.btnEndStep.Size = new System.Drawing.Size(100, 29);
            this.btnEndStep.TabIndex = 11;
            this.btnEndStep.Text = "Ход";
            this.btnEndStep.UseVisualStyleBackColor = true;
            this.btnEndStep.Click += new System.EventHandler(this.BtnEndStep_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 473);
            this.Controls.Add(this.btnEndStep);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.gameMap);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.listInfoUnits);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тактическая войнушка";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gameMap;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ListBox listInfoUnits;
        private System.Windows.Forms.ToolStripMenuItem menuMission;
        private System.Windows.Forms.ToolStripMenuItem menuMisLoad;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHlpAbout;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button btnEndStep;
    }
}


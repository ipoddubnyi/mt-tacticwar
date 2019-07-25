namespace TacticWar
{
    partial class FrmLoadMission
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
            this.listMissions = new System.Windows.Forms.ListBox();
            this.lblMissionsList = new System.Windows.Forms.Label();
            this.pnlMapEskiz = new System.Windows.Forms.Panel();
            this.txtBriefing = new System.Windows.Forms.TextBox();
            this.lblBriefing = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblMisName = new System.Windows.Forms.Label();
            this.lblMisMode = new System.Windows.Forms.Label();
            this.lblMapName = new System.Windows.Forms.Label();
            this.lblMapSize = new System.Windows.Forms.Label();
            this.txtMisName = new System.Windows.Forms.TextBox();
            this.txtMisMode = new System.Windows.Forms.TextBox();
            this.txtMapName = new System.Windows.Forms.TextBox();
            this.txtMapSize = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listMissions
            // 
            this.listMissions.FormattingEnabled = true;
            this.listMissions.Location = new System.Drawing.Point(15, 30);
            this.listMissions.Name = "listMissions";
            this.listMissions.Size = new System.Drawing.Size(171, 264);
            this.listMissions.TabIndex = 0;
            this.listMissions.SelectedIndexChanged += new System.EventHandler(this.listMissions_SelectedIndexChanged);
            // 
            // lblMissionsList
            // 
            this.lblMissionsList.AutoSize = true;
            this.lblMissionsList.Location = new System.Drawing.Point(12, 9);
            this.lblMissionsList.Name = "lblMissionsList";
            this.lblMissionsList.Size = new System.Drawing.Size(88, 13);
            this.lblMissionsList.TabIndex = 1;
            this.lblMissionsList.Text = "Список миссий:";
            // 
            // pnlMapEskiz
            // 
            this.pnlMapEskiz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMapEskiz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMapEskiz.Location = new System.Drawing.Point(198, 30);
            this.pnlMapEskiz.Name = "pnlMapEskiz";
            this.pnlMapEskiz.Size = new System.Drawing.Size(100, 100);
            this.pnlMapEskiz.TabIndex = 2;
            this.pnlMapEskiz.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMapEskiz_Paint);
            // 
            // txtBriefing
            // 
            this.txtBriefing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBriefing.Location = new System.Drawing.Point(198, 211);
            this.txtBriefing.Multiline = true;
            this.txtBriefing.Name = "txtBriefing";
            this.txtBriefing.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBriefing.Size = new System.Drawing.Size(201, 83);
            this.txtBriefing.TabIndex = 3;
            // 
            // lblBriefing
            // 
            this.lblBriefing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBriefing.AutoSize = true;
            this.lblBriefing.Location = new System.Drawing.Point(195, 193);
            this.lblBriefing.Name = "lblBriefing";
            this.lblBriefing.Size = new System.Drawing.Size(54, 13);
            this.lblBriefing.TabIndex = 4;
            this.lblBriefing.Text = "Брифинг:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(15, 306);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLoad.Enabled = false;
            this.btnLoad.Location = new System.Drawing.Point(294, 306);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(105, 23);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // lblMisName
            // 
            this.lblMisName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMisName.AutoSize = true;
            this.lblMisName.Location = new System.Drawing.Point(195, 142);
            this.lblMisName.Name = "lblMisName";
            this.lblMisName.Size = new System.Drawing.Size(60, 13);
            this.lblMisName.TabIndex = 7;
            this.lblMisName.Text = "Название:";
            // 
            // lblMisMode
            // 
            this.lblMisMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMisMode.AutoSize = true;
            this.lblMisMode.Location = new System.Drawing.Point(195, 168);
            this.lblMisMode.Name = "lblMisMode";
            this.lblMisMode.Size = new System.Drawing.Size(45, 13);
            this.lblMisMode.TabIndex = 8;
            this.lblMisMode.Text = "Режим:";
            // 
            // lblMapName
            // 
            this.lblMapName.AutoSize = true;
            this.lblMapName.Location = new System.Drawing.Point(304, 30);
            this.lblMapName.Name = "lblMapName";
            this.lblMapName.Size = new System.Drawing.Size(40, 13);
            this.lblMapName.TabIndex = 9;
            this.lblMapName.Text = "Карта:";
            // 
            // lblMapSize
            // 
            this.lblMapSize.AutoSize = true;
            this.lblMapSize.Location = new System.Drawing.Point(304, 74);
            this.lblMapSize.Name = "lblMapSize";
            this.lblMapSize.Size = new System.Drawing.Size(49, 13);
            this.lblMapSize.TabIndex = 10;
            this.lblMapSize.Text = "Размер:";
            // 
            // txtMisName
            // 
            this.txtMisName.Location = new System.Drawing.Point(261, 139);
            this.txtMisName.Name = "txtMisName";
            this.txtMisName.ReadOnly = true;
            this.txtMisName.Size = new System.Drawing.Size(138, 20);
            this.txtMisName.TabIndex = 13;
            // 
            // txtMisMode
            // 
            this.txtMisMode.Location = new System.Drawing.Point(261, 165);
            this.txtMisMode.Name = "txtMisMode";
            this.txtMisMode.ReadOnly = true;
            this.txtMisMode.Size = new System.Drawing.Size(138, 20);
            this.txtMisMode.TabIndex = 13;
            // 
            // txtMapName
            // 
            this.txtMapName.Location = new System.Drawing.Point(307, 46);
            this.txtMapName.Name = "txtMapName";
            this.txtMapName.ReadOnly = true;
            this.txtMapName.Size = new System.Drawing.Size(92, 20);
            this.txtMapName.TabIndex = 13;
            // 
            // txtMapSize
            // 
            this.txtMapSize.Location = new System.Drawing.Point(307, 90);
            this.txtMapSize.Name = "txtMapSize";
            this.txtMapSize.ReadOnly = true;
            this.txtMapSize.Size = new System.Drawing.Size(92, 20);
            this.txtMapSize.TabIndex = 13;
            // 
            // FrmLoadMission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 341);
            this.Controls.Add(this.txtMapSize);
            this.Controls.Add(this.txtMapName);
            this.Controls.Add(this.txtMisMode);
            this.Controls.Add(this.txtMisName);
            this.Controls.Add(this.lblMapSize);
            this.Controls.Add(this.lblMapName);
            this.Controls.Add(this.lblMisMode);
            this.Controls.Add(this.lblMisName);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblBriefing);
            this.Controls.Add(this.txtBriefing);
            this.Controls.Add(this.pnlMapEskiz);
            this.Controls.Add(this.lblMissionsList);
            this.Controls.Add(this.listMissions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLoadMission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Загрузка миссии";
            this.Load += new System.EventHandler(this.FrmLoadMission_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listMissions;
        private System.Windows.Forms.Label lblMissionsList;
        private System.Windows.Forms.Panel pnlMapEskiz;
        private System.Windows.Forms.TextBox txtBriefing;
        private System.Windows.Forms.Label lblBriefing;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblMisName;
        private System.Windows.Forms.Label lblMisMode;
        private System.Windows.Forms.Label lblMapName;
        private System.Windows.Forms.Label lblMapSize;
        private System.Windows.Forms.TextBox txtMisName;
        private System.Windows.Forms.TextBox txtMisMode;
        private System.Windows.Forms.TextBox txtMapName;
        private System.Windows.Forms.TextBox txtMapSize;
    }
}
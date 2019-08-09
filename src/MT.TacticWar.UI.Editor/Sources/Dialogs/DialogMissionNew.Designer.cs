namespace MT.TacticWar.UI.Editor.Dialogs
{
    partial class DialogMissionNew
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
            this.btnOk = new System.Windows.Forms.Button();
            this.lblMissionName = new System.Windows.Forms.Label();
            this.txtMissionName = new System.Windows.Forms.TextBox();
            this.lblMissionBriefing = new System.Windows.Forms.Label();
            this.txtMissionBriefing = new System.Windows.Forms.TextBox();
            this.lblPlayersCount = new System.Windows.Forms.Label();
            this.comboPlayersCount = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(283, 177);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblMissionName
            // 
            this.lblMissionName.AutoSize = true;
            this.lblMissionName.Location = new System.Drawing.Point(35, 48);
            this.lblMissionName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMissionName.Name = "lblMissionName";
            this.lblMissionName.Size = new System.Drawing.Size(76, 17);
            this.lblMissionName.TabIndex = 7;
            this.lblMissionName.Text = "Название:";
            // 
            // txtMissionName
            // 
            this.txtMissionName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMissionName.Location = new System.Drawing.Point(119, 45);
            this.txtMissionName.Margin = new System.Windows.Forms.Padding(4);
            this.txtMissionName.Name = "txtMissionName";
            this.txtMissionName.Size = new System.Drawing.Size(264, 22);
            this.txtMissionName.TabIndex = 8;
            this.txtMissionName.Text = "Задание";
            // 
            // lblMissionBriefing
            // 
            this.lblMissionBriefing.AutoSize = true;
            this.lblMissionBriefing.Location = new System.Drawing.Point(42, 77);
            this.lblMissionBriefing.Name = "lblMissionBriefing";
            this.lblMissionBriefing.Size = new System.Drawing.Size(69, 17);
            this.lblMissionBriefing.TabIndex = 9;
            this.lblMissionBriefing.Text = "Брифинг:";
            // 
            // txtMissionBriefing
            // 
            this.txtMissionBriefing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMissionBriefing.Location = new System.Drawing.Point(119, 74);
            this.txtMissionBriefing.Multiline = true;
            this.txtMissionBriefing.Name = "txtMissionBriefing";
            this.txtMissionBriefing.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMissionBriefing.Size = new System.Drawing.Size(264, 96);
            this.txtMissionBriefing.TabIndex = 10;
            // 
            // lblPlayersCount
            // 
            this.lblPlayersCount.AutoSize = true;
            this.lblPlayersCount.Location = new System.Drawing.Point(46, 16);
            this.lblPlayersCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlayersCount.Name = "lblPlayersCount";
            this.lblPlayersCount.Size = new System.Drawing.Size(65, 17);
            this.lblPlayersCount.TabIndex = 4;
            this.lblPlayersCount.Text = "Игроков:";
            // 
            // comboPlayersCount
            // 
            this.comboPlayersCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboPlayersCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPlayersCount.FormattingEnabled = true;
            this.comboPlayersCount.Location = new System.Drawing.Point(119, 13);
            this.comboPlayersCount.Margin = new System.Windows.Forms.Padding(4);
            this.comboPlayersCount.Name = "comboPlayersCount";
            this.comboPlayersCount.Size = new System.Drawing.Size(264, 24);
            this.comboPlayersCount.TabIndex = 5;
            // 
            // DialogMissionNew
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 218);
            this.Controls.Add(this.txtMissionBriefing);
            this.Controls.Add(this.lblMissionBriefing);
            this.Controls.Add(this.txtMissionName);
            this.Controls.Add(this.lblMissionName);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.comboPlayersCount);
            this.Controls.Add(this.lblPlayersCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogMissionNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новая миссия";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DialogMapNew_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblMissionName;
        private System.Windows.Forms.TextBox txtMissionName;
        private System.Windows.Forms.Label lblMissionBriefing;
        private System.Windows.Forms.TextBox txtMissionBriefing;
        private System.Windows.Forms.Label lblPlayersCount;
        private System.Windows.Forms.ComboBox comboPlayersCount;
    }
}
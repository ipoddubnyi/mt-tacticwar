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
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(283, 151);
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
            this.lblMissionName.Location = new System.Drawing.Point(35, 12);
            this.lblMissionName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMissionName.Name = "lblMissionName";
            this.lblMissionName.Size = new System.Drawing.Size(76, 17);
            this.lblMissionName.TabIndex = 7;
            this.lblMissionName.Text = "Название:";
            // 
            // txtMissionName
            // 
            this.txtMissionName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMissionName.Location = new System.Drawing.Point(119, 10);
            this.txtMissionName.Margin = new System.Windows.Forms.Padding(4);
            this.txtMissionName.Name = "txtMissionName";
            this.txtMissionName.Size = new System.Drawing.Size(264, 22);
            this.txtMissionName.TabIndex = 8;
            this.txtMissionName.Text = "Задание";
            // 
            // lblMissionBriefing
            // 
            this.lblMissionBriefing.AutoSize = true;
            this.lblMissionBriefing.Location = new System.Drawing.Point(43, 42);
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
            this.txtMissionBriefing.Location = new System.Drawing.Point(119, 38);
            this.txtMissionBriefing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMissionBriefing.Multiline = true;
            this.txtMissionBriefing.Name = "txtMissionBriefing";
            this.txtMissionBriefing.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMissionBriefing.Size = new System.Drawing.Size(264, 95);
            this.txtMissionBriefing.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(46, 151);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DialogMissionNew
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(433, 194);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtMissionBriefing);
            this.Controls.Add(this.lblMissionBriefing);
            this.Controls.Add(this.txtMissionName);
            this.Controls.Add(this.lblMissionName);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogMissionNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новая миссия";
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
        private System.Windows.Forms.Button btnCancel;
    }
}
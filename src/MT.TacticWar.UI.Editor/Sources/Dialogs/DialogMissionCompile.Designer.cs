namespace MT.TacticWar.UI.Editor.Dialogs
{
    partial class DialogMissionCompile
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
            this.lblGameName = new System.Windows.Forms.Label();
            this.txtGameName = new System.Windows.Forms.TextBox();
            this.lblMapFileName = new System.Windows.Forms.Label();
            this.txtMapFileName = new System.Windows.Forms.TextBox();
            this.lblMissionFileName = new System.Windows.Forms.Label();
            this.txtMissionFileName = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGameName
            // 
            this.lblGameName.AutoSize = true;
            this.lblGameName.Location = new System.Drawing.Point(12, 21);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(165, 17);
            this.lblGameName.TabIndex = 0;
            this.lblGameName.Text = "Имя собранной миссии:";
            // 
            // txtGameName
            // 
            this.txtGameName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGameName.Location = new System.Drawing.Point(12, 41);
            this.txtGameName.Name = "txtGameName";
            this.txtGameName.Size = new System.Drawing.Size(282, 22);
            this.txtGameName.TabIndex = 1;
            // 
            // lblMapFileName
            // 
            this.lblMapFileName.AutoSize = true;
            this.lblMapFileName.Location = new System.Drawing.Point(12, 77);
            this.lblMapFileName.Name = "lblMapFileName";
            this.lblMapFileName.Size = new System.Drawing.Size(130, 17);
            this.lblMapFileName.TabIndex = 2;
            this.lblMapFileName.Text = "Имя файла карты:";
            // 
            // txtMapFileName
            // 
            this.txtMapFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMapFileName.Location = new System.Drawing.Point(12, 97);
            this.txtMapFileName.Name = "txtMapFileName";
            this.txtMapFileName.Size = new System.Drawing.Size(282, 22);
            this.txtMapFileName.TabIndex = 3;
            // 
            // lblMissionFileName
            // 
            this.lblMissionFileName.AutoSize = true;
            this.lblMissionFileName.Location = new System.Drawing.Point(12, 136);
            this.lblMissionFileName.Name = "lblMissionFileName";
            this.lblMissionFileName.Size = new System.Drawing.Size(137, 17);
            this.lblMissionFileName.TabIndex = 4;
            this.lblMissionFileName.Text = "Имя файла миссии:";
            // 
            // txtMissionFileName
            // 
            this.txtMissionFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMissionFileName.Location = new System.Drawing.Point(12, 156);
            this.txtMissionFileName.Name = "txtMissionFileName";
            this.txtMissionFileName.Size = new System.Drawing.Size(282, 22);
            this.txtMissionFileName.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(191, 202);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(103, 29);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 29);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DialogMissionCompile
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(306, 243);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtMissionFileName);
            this.Controls.Add(this.lblMissionFileName);
            this.Controls.Add(this.txtMapFileName);
            this.Controls.Add(this.lblMapFileName);
            this.Controls.Add(this.txtGameName);
            this.Controls.Add(this.lblGameName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DialogMissionCompile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Сборка миссии";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.TextBox txtGameName;
        private System.Windows.Forms.Label lblMapFileName;
        private System.Windows.Forms.TextBox txtMapFileName;
        private System.Windows.Forms.Label lblMissionFileName;
        private System.Windows.Forms.TextBox txtMissionFileName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
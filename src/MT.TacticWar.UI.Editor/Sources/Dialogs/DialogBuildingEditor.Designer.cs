namespace MT.TacticWar.UI.Editor.Dialogs
{
    partial class DialogBuildingEditor
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
            this.comboBuildingType = new System.Windows.Forms.ComboBox();
            this.lblBuildingType = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSecurityRemove = new System.Windows.Forms.Button();
            this.txtBuildingName = new System.Windows.Forms.TextBox();
            this.lblBuildingName = new System.Windows.Forms.Label();
            this.numBuildingId = new System.Windows.Forms.NumericUpDown();
            this.lblBuildingId = new System.Windows.Forms.Label();
            this.comboBuildingPlayer = new System.Windows.Forms.ComboBox();
            this.lblBuildingPlayer = new System.Windows.Forms.Label();
            this.txtSecurityInfo = new System.Windows.Forms.TextBox();
            this.btnSecurityEdit = new System.Windows.Forms.Button();
            this.groupSecurity = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numBuildingId)).BeginInit();
            this.groupSecurity.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(321, 312);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // comboBuildingType
            // 
            this.comboBuildingType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBuildingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBuildingType.FormattingEnabled = true;
            this.comboBuildingType.Location = new System.Drawing.Point(12, 89);
            this.comboBuildingType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBuildingType.Name = "comboBuildingType";
            this.comboBuildingType.Size = new System.Drawing.Size(409, 24);
            this.comboBuildingType.TabIndex = 7;
            this.comboBuildingType.SelectedIndexChanged += new System.EventHandler(this.ComboBuildingType_SelectedIndexChanged);
            // 
            // lblBuildingType
            // 
            this.lblBuildingType.AutoSize = true;
            this.lblBuildingType.Location = new System.Drawing.Point(12, 70);
            this.lblBuildingType.Name = "lblBuildingType";
            this.lblBuildingType.Size = new System.Drawing.Size(103, 17);
            this.lblBuildingType.TabIndex = 10;
            this.lblBuildingType.Text = "Тип строения:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 312);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSecurityRemove
            // 
            this.btnSecurityRemove.Location = new System.Drawing.Point(18, 66);
            this.btnSecurityRemove.Name = "btnSecurityRemove";
            this.btnSecurityRemove.Size = new System.Drawing.Size(121, 28);
            this.btnSecurityRemove.TabIndex = 19;
            this.btnSecurityRemove.Text = "Удалить";
            this.btnSecurityRemove.UseVisualStyleBackColor = true;
            this.btnSecurityRemove.Click += new System.EventHandler(this.BtnSecurityRemove_Click);
            // 
            // txtBuildingName
            // 
            this.txtBuildingName.Location = new System.Drawing.Point(300, 31);
            this.txtBuildingName.Name = "txtBuildingName";
            this.txtBuildingName.Size = new System.Drawing.Size(121, 22);
            this.txtBuildingName.TabIndex = 43;
            // 
            // lblBuildingName
            // 
            this.lblBuildingName.AutoSize = true;
            this.lblBuildingName.Location = new System.Drawing.Point(300, 9);
            this.lblBuildingName.Name = "lblBuildingName";
            this.lblBuildingName.Size = new System.Drawing.Size(76, 17);
            this.lblBuildingName.TabIndex = 42;
            this.lblBuildingName.Text = "Название:";
            // 
            // numBuildingId
            // 
            this.numBuildingId.Location = new System.Drawing.Point(157, 31);
            this.numBuildingId.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numBuildingId.Name = "numBuildingId";
            this.numBuildingId.Size = new System.Drawing.Size(120, 22);
            this.numBuildingId.TabIndex = 41;
            // 
            // lblBuildingId
            // 
            this.lblBuildingId.AutoSize = true;
            this.lblBuildingId.Location = new System.Drawing.Point(158, 9);
            this.lblBuildingId.Name = "lblBuildingId";
            this.lblBuildingId.Size = new System.Drawing.Size(23, 17);
            this.lblBuildingId.TabIndex = 40;
            this.lblBuildingId.Text = "Id:";
            // 
            // comboBuildingPlayer
            // 
            this.comboBuildingPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBuildingPlayer.FormattingEnabled = true;
            this.comboBuildingPlayer.Location = new System.Drawing.Point(12, 29);
            this.comboBuildingPlayer.Name = "comboBuildingPlayer";
            this.comboBuildingPlayer.Size = new System.Drawing.Size(121, 24);
            this.comboBuildingPlayer.TabIndex = 39;
            // 
            // lblBuildingPlayer
            // 
            this.lblBuildingPlayer.AutoSize = true;
            this.lblBuildingPlayer.Location = new System.Drawing.Point(12, 9);
            this.lblBuildingPlayer.Name = "lblBuildingPlayer";
            this.lblBuildingPlayer.Size = new System.Drawing.Size(50, 17);
            this.lblBuildingPlayer.TabIndex = 38;
            this.lblBuildingPlayer.Text = "Игрок:";
            // 
            // txtSecurityInfo
            // 
            this.txtSecurityInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSecurityInfo.Location = new System.Drawing.Point(145, 32);
            this.txtSecurityInfo.Multiline = true;
            this.txtSecurityInfo.Name = "txtSecurityInfo";
            this.txtSecurityInfo.ReadOnly = true;
            this.txtSecurityInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSecurityInfo.Size = new System.Drawing.Size(244, 123);
            this.txtSecurityInfo.TabIndex = 20;
            // 
            // btnSecurityEdit
            // 
            this.btnSecurityEdit.Location = new System.Drawing.Point(18, 32);
            this.btnSecurityEdit.Name = "btnSecurityEdit";
            this.btnSecurityEdit.Size = new System.Drawing.Size(121, 28);
            this.btnSecurityEdit.TabIndex = 18;
            this.btnSecurityEdit.Text = "Изменить";
            this.btnSecurityEdit.UseVisualStyleBackColor = true;
            this.btnSecurityEdit.Click += new System.EventHandler(this.BtnSecurityEdit_Click);
            // 
            // groupSecurity
            // 
            this.groupSecurity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSecurity.Controls.Add(this.txtSecurityInfo);
            this.groupSecurity.Controls.Add(this.btnSecurityEdit);
            this.groupSecurity.Controls.Add(this.btnSecurityRemove);
            this.groupSecurity.Location = new System.Drawing.Point(12, 128);
            this.groupSecurity.Name = "groupSecurity";
            this.groupSecurity.Size = new System.Drawing.Size(409, 177);
            this.groupSecurity.TabIndex = 44;
            this.groupSecurity.TabStop = false;
            this.groupSecurity.Text = "Охранение";
            // 
            // DialogBuildingEditor
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(433, 354);
            this.Controls.Add(this.groupSecurity);
            this.Controls.Add(this.txtBuildingName);
            this.Controls.Add(this.lblBuildingName);
            this.Controls.Add(this.numBuildingId);
            this.Controls.Add(this.lblBuildingId);
            this.Controls.Add(this.comboBuildingPlayer);
            this.Controls.Add(this.lblBuildingPlayer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblBuildingType);
            this.Controls.Add(this.comboBuildingType);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogBuildingEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор строений";
            ((System.ComponentModel.ISupportInitialize)(this.numBuildingId)).EndInit();
            this.groupSecurity.ResumeLayout(false);
            this.groupSecurity.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox comboBuildingType;
        private System.Windows.Forms.Label lblBuildingType;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSecurityRemove;
        private System.Windows.Forms.TextBox txtBuildingName;
        private System.Windows.Forms.Label lblBuildingName;
        private System.Windows.Forms.NumericUpDown numBuildingId;
        private System.Windows.Forms.Label lblBuildingId;
        private System.Windows.Forms.ComboBox comboBuildingPlayer;
        private System.Windows.Forms.Label lblBuildingPlayer;
        private System.Windows.Forms.TextBox txtSecurityInfo;
        private System.Windows.Forms.Button btnSecurityEdit;
        private System.Windows.Forms.GroupBox groupSecurity;
    }
}
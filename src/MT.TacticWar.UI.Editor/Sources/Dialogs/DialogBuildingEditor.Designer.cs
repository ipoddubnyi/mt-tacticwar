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
            this.lblSecurity = new System.Windows.Forms.Label();
            this.btnSecurityAdd = new System.Windows.Forms.Button();
            this.btnSecurityRemove = new System.Windows.Forms.Button();
            this.lblSecurityInfo = new System.Windows.Forms.Label();
            this.lblSecurityId = new System.Windows.Forms.Label();
            this.numSecurityId = new System.Windows.Forms.NumericUpDown();
            this.lblSecurityName = new System.Windows.Forms.Label();
            this.txtSecurityName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numSecurityId)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(321, 278);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.comboBuildingType.Location = new System.Drawing.Point(12, 34);
            this.comboBuildingType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBuildingType.Name = "comboBuildingType";
            this.comboBuildingType.Size = new System.Drawing.Size(409, 24);
            this.comboBuildingType.TabIndex = 7;
            this.comboBuildingType.SelectedIndexChanged += new System.EventHandler(this.ComboBuildingType_SelectedIndexChanged);
            // 
            // lblBuildingType
            // 
            this.lblBuildingType.AutoSize = true;
            this.lblBuildingType.Location = new System.Drawing.Point(9, 15);
            this.lblBuildingType.Name = "lblBuildingType";
            this.lblBuildingType.Size = new System.Drawing.Size(103, 17);
            this.lblBuildingType.TabIndex = 10;
            this.lblBuildingType.Text = "Тип строения:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 278);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblSecurity
            // 
            this.lblSecurity.AutoSize = true;
            this.lblSecurity.Location = new System.Drawing.Point(9, 88);
            this.lblSecurity.Name = "lblSecurity";
            this.lblSecurity.Size = new System.Drawing.Size(85, 17);
            this.lblSecurity.TabIndex = 16;
            this.lblSecurity.Text = "Охранение:";
            // 
            // btnSecurityAdd
            // 
            this.btnSecurityAdd.Location = new System.Drawing.Point(12, 108);
            this.btnSecurityAdd.Name = "btnSecurityAdd";
            this.btnSecurityAdd.Size = new System.Drawing.Size(100, 28);
            this.btnSecurityAdd.TabIndex = 17;
            this.btnSecurityAdd.Text = "Добавить";
            this.btnSecurityAdd.UseVisualStyleBackColor = true;
            this.btnSecurityAdd.Click += new System.EventHandler(this.BtnSecurityAdd_Click);
            // 
            // btnSecurityRemove
            // 
            this.btnSecurityRemove.Location = new System.Drawing.Point(118, 108);
            this.btnSecurityRemove.Name = "btnSecurityRemove";
            this.btnSecurityRemove.Size = new System.Drawing.Size(100, 28);
            this.btnSecurityRemove.TabIndex = 18;
            this.btnSecurityRemove.Text = "Удалить";
            this.btnSecurityRemove.UseVisualStyleBackColor = true;
            this.btnSecurityRemove.Click += new System.EventHandler(this.BtnSecurityRemove_Click);
            // 
            // lblSecurityInfo
            // 
            this.lblSecurityInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSecurityInfo.Location = new System.Drawing.Point(224, 108);
            this.lblSecurityInfo.Name = "lblSecurityInfo";
            this.lblSecurityInfo.Size = new System.Drawing.Size(197, 151);
            this.lblSecurityInfo.TabIndex = 19;
            // 
            // lblSecurityId
            // 
            this.lblSecurityId.AutoSize = true;
            this.lblSecurityId.Location = new System.Drawing.Point(12, 157);
            this.lblSecurityId.Name = "lblSecurityId";
            this.lblSecurityId.Size = new System.Drawing.Size(19, 17);
            this.lblSecurityId.TabIndex = 20;
            this.lblSecurityId.Text = "Id";
            // 
            // numSecurityId
            // 
            this.numSecurityId.Location = new System.Drawing.Point(98, 155);
            this.numSecurityId.Name = "numSecurityId";
            this.numSecurityId.Size = new System.Drawing.Size(120, 22);
            this.numSecurityId.TabIndex = 21;
            // 
            // lblSecurityName
            // 
            this.lblSecurityName.AutoSize = true;
            this.lblSecurityName.Location = new System.Drawing.Point(12, 186);
            this.lblSecurityName.Name = "lblSecurityName";
            this.lblSecurityName.Size = new System.Drawing.Size(72, 17);
            this.lblSecurityName.TabIndex = 22;
            this.lblSecurityName.Text = "Название";
            // 
            // txtSecurityName
            // 
            this.txtSecurityName.Location = new System.Drawing.Point(98, 183);
            this.txtSecurityName.Name = "txtSecurityName";
            this.txtSecurityName.Size = new System.Drawing.Size(120, 22);
            this.txtSecurityName.TabIndex = 23;
            // 
            // DialogBuildingEditor
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(433, 320);
            this.Controls.Add(this.txtSecurityName);
            this.Controls.Add(this.lblSecurityName);
            this.Controls.Add(this.numSecurityId);
            this.Controls.Add(this.lblSecurityId);
            this.Controls.Add(this.lblSecurityInfo);
            this.Controls.Add(this.btnSecurityRemove);
            this.Controls.Add(this.btnSecurityAdd);
            this.Controls.Add(this.lblSecurity);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblBuildingType);
            this.Controls.Add(this.comboBuildingType);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogBuildingEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор строений";
            ((System.ComponentModel.ISupportInitialize)(this.numSecurityId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox comboBuildingType;
        private System.Windows.Forms.Label lblBuildingType;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSecurity;
        private System.Windows.Forms.Button btnSecurityAdd;
        private System.Windows.Forms.Button btnSecurityRemove;
        private System.Windows.Forms.Label lblSecurityInfo;
        private System.Windows.Forms.Label lblSecurityId;
        private System.Windows.Forms.NumericUpDown numSecurityId;
        private System.Windows.Forms.Label lblSecurityName;
        private System.Windows.Forms.TextBox txtSecurityName;
    }
}
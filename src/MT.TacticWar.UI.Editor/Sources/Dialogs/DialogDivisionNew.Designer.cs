namespace MT.TacticWar.UI.Editor.Dialogs
{
    partial class DialogDivisionNew
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
            this.comboDivisionType = new System.Windows.Forms.ComboBox();
            this.listUnitsAll = new System.Windows.Forms.ListBox();
            this.listUnitsDivision = new System.Windows.Forms.ListBox();
            this.lblDivisionType = new System.Windows.Forms.Label();
            this.lblUnitsAll = new System.Windows.Forms.Label();
            this.lblUnitsDivision = new System.Windows.Forms.Label();
            this.btnUnitAdd = new System.Windows.Forms.Button();
            this.btnUnitRemove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblUnitName = new System.Windows.Forms.Label();
            this.txtUnitNameCommon = new System.Windows.Forms.TextBox();
            this.lblUnitHealth = new System.Windows.Forms.Label();
            this.txtUnitHealthCommon = new System.Windows.Forms.TextBox();
            this.lblUnitExperience = new System.Windows.Forms.Label();
            this.txtUnitExperienceCommon = new System.Windows.Forms.TextBox();
            this.lblUnitSupply = new System.Windows.Forms.Label();
            this.txtUnitSupplyCommon = new System.Windows.Forms.TextBox();
            this.lblUnitId = new System.Windows.Forms.Label();
            this.txtUnitIdCommon = new System.Windows.Forms.TextBox();
            this.txtUnitIdDivision = new System.Windows.Forms.TextBox();
            this.txtUnitNameDivision = new System.Windows.Forms.TextBox();
            this.txtUnitHealthDivision = new System.Windows.Forms.TextBox();
            this.txtUnitExperienceDivision = new System.Windows.Forms.TextBox();
            this.txtUnitSupplyDivision = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(321, 371);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // comboDivisionType
            // 
            this.comboDivisionType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboDivisionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDivisionType.FormattingEnabled = true;
            this.comboDivisionType.Location = new System.Drawing.Point(12, 35);
            this.comboDivisionType.Name = "comboDivisionType";
            this.comboDivisionType.Size = new System.Drawing.Size(409, 24);
            this.comboDivisionType.TabIndex = 7;
            this.comboDivisionType.SelectedIndexChanged += new System.EventHandler(this.ComboDivisionType_SelectedIndexChanged);
            // 
            // listUnitsAll
            // 
            this.listUnitsAll.FormattingEnabled = true;
            this.listUnitsAll.ItemHeight = 16;
            this.listUnitsAll.Location = new System.Drawing.Point(12, 96);
            this.listUnitsAll.Name = "listUnitsAll";
            this.listUnitsAll.Size = new System.Drawing.Size(165, 116);
            this.listUnitsAll.TabIndex = 8;
            this.listUnitsAll.SelectedIndexChanged += new System.EventHandler(this.ListUnitsAll_SelectedIndexChanged);
            // 
            // listUnitsDivision
            // 
            this.listUnitsDivision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listUnitsDivision.FormattingEnabled = true;
            this.listUnitsDivision.ItemHeight = 16;
            this.listUnitsDivision.Location = new System.Drawing.Point(256, 96);
            this.listUnitsDivision.Name = "listUnitsDivision";
            this.listUnitsDivision.Size = new System.Drawing.Size(165, 116);
            this.listUnitsDivision.TabIndex = 9;
            this.listUnitsDivision.SelectedIndexChanged += new System.EventHandler(this.ListUnitsDivision_SelectedIndexChanged);
            // 
            // lblDivisionType
            // 
            this.lblDivisionType.AutoSize = true;
            this.lblDivisionType.Location = new System.Drawing.Point(9, 15);
            this.lblDivisionType.Name = "lblDivisionType";
            this.lblDivisionType.Size = new System.Drawing.Size(144, 17);
            this.lblDivisionType.TabIndex = 10;
            this.lblDivisionType.Text = "Тип подразделения:";
            // 
            // lblUnitsAll
            // 
            this.lblUnitsAll.AutoSize = true;
            this.lblUnitsAll.Location = new System.Drawing.Point(9, 76);
            this.lblUnitsAll.Name = "lblUnitsAll";
            this.lblUnitsAll.Size = new System.Drawing.Size(133, 17);
            this.lblUnitsAll.TabIndex = 11;
            this.lblUnitsAll.Text = "Доступные юниты:";
            // 
            // lblUnitsDivision
            // 
            this.lblUnitsDivision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnitsDivision.AutoSize = true;
            this.lblUnitsDivision.Location = new System.Drawing.Point(253, 76);
            this.lblUnitsDivision.Name = "lblUnitsDivision";
            this.lblUnitsDivision.Size = new System.Drawing.Size(128, 17);
            this.lblUnitsDivision.TabIndex = 12;
            this.lblUnitsDivision.Text = "В подразделении:";
            // 
            // btnUnitAdd
            // 
            this.btnUnitAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnitAdd.Location = new System.Drawing.Point(184, 96);
            this.btnUnitAdd.Name = "btnUnitAdd";
            this.btnUnitAdd.Size = new System.Drawing.Size(66, 23);
            this.btnUnitAdd.TabIndex = 13;
            this.btnUnitAdd.Text = ">>";
            this.btnUnitAdd.UseVisualStyleBackColor = true;
            this.btnUnitAdd.Click += new System.EventHandler(this.BtnUnitAdd_Click);
            // 
            // btnUnitRemove
            // 
            this.btnUnitRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnitRemove.Location = new System.Drawing.Point(184, 126);
            this.btnUnitRemove.Name = "btnUnitRemove";
            this.btnUnitRemove.Size = new System.Drawing.Size(66, 23);
            this.btnUnitRemove.TabIndex = 14;
            this.btnUnitRemove.Text = "<<";
            this.btnUnitRemove.UseVisualStyleBackColor = true;
            this.btnUnitRemove.Click += new System.EventHandler(this.BtnUnitRemove_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 371);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblUnitName
            // 
            this.lblUnitName.AutoSize = true;
            this.lblUnitName.Location = new System.Drawing.Point(183, 249);
            this.lblUnitName.Name = "lblUnitName";
            this.lblUnitName.Size = new System.Drawing.Size(72, 17);
            this.lblUnitName.TabIndex = 18;
            this.lblUnitName.Text = "Название";
            // 
            // txtUnitNameCommon
            // 
            this.txtUnitNameCommon.Location = new System.Drawing.Point(12, 246);
            this.txtUnitNameCommon.Name = "txtUnitNameCommon";
            this.txtUnitNameCommon.Size = new System.Drawing.Size(141, 22);
            this.txtUnitNameCommon.TabIndex = 19;
            // 
            // lblUnitHealth
            // 
            this.lblUnitHealth.AutoSize = true;
            this.lblUnitHealth.Location = new System.Drawing.Point(184, 277);
            this.lblUnitHealth.Name = "lblUnitHealth";
            this.lblUnitHealth.Size = new System.Drawing.Size(71, 17);
            this.lblUnitHealth.TabIndex = 20;
            this.lblUnitHealth.Text = "Здоровье";
            // 
            // txtUnitHealthCommon
            // 
            this.txtUnitHealthCommon.Location = new System.Drawing.Point(12, 274);
            this.txtUnitHealthCommon.Name = "txtUnitHealthCommon";
            this.txtUnitHealthCommon.Size = new System.Drawing.Size(141, 22);
            this.txtUnitHealthCommon.TabIndex = 21;
            // 
            // lblUnitExperience
            // 
            this.lblUnitExperience.AutoSize = true;
            this.lblUnitExperience.Location = new System.Drawing.Point(196, 305);
            this.lblUnitExperience.Name = "lblUnitExperience";
            this.lblUnitExperience.Size = new System.Drawing.Size(44, 17);
            this.lblUnitExperience.TabIndex = 22;
            this.lblUnitExperience.Text = "Опыт";
            // 
            // txtUnitExperienceCommon
            // 
            this.txtUnitExperienceCommon.Location = new System.Drawing.Point(12, 302);
            this.txtUnitExperienceCommon.Name = "txtUnitExperienceCommon";
            this.txtUnitExperienceCommon.Size = new System.Drawing.Size(141, 22);
            this.txtUnitExperienceCommon.TabIndex = 23;
            // 
            // lblUnitSupply
            // 
            this.lblUnitSupply.AutoSize = true;
            this.lblUnitSupply.Location = new System.Drawing.Point(188, 334);
            this.lblUnitSupply.Name = "lblUnitSupply";
            this.lblUnitSupply.Size = new System.Drawing.Size(67, 17);
            this.lblUnitSupply.TabIndex = 24;
            this.lblUnitSupply.Text = "Патроны";
            // 
            // txtUnitSupplyCommon
            // 
            this.txtUnitSupplyCommon.Location = new System.Drawing.Point(12, 331);
            this.txtUnitSupplyCommon.Name = "txtUnitSupplyCommon";
            this.txtUnitSupplyCommon.Size = new System.Drawing.Size(141, 22);
            this.txtUnitSupplyCommon.TabIndex = 25;
            // 
            // lblUnitId
            // 
            this.lblUnitId.AutoSize = true;
            this.lblUnitId.Location = new System.Drawing.Point(209, 221);
            this.lblUnitId.Name = "lblUnitId";
            this.lblUnitId.Size = new System.Drawing.Size(19, 17);
            this.lblUnitId.TabIndex = 16;
            this.lblUnitId.Text = "Id";
            // 
            // txtUnitIdCommon
            // 
            this.txtUnitIdCommon.Location = new System.Drawing.Point(12, 218);
            this.txtUnitIdCommon.Name = "txtUnitIdCommon";
            this.txtUnitIdCommon.Size = new System.Drawing.Size(141, 22);
            this.txtUnitIdCommon.TabIndex = 17;
            // 
            // txtUnitIdDivision
            // 
            this.txtUnitIdDivision.Location = new System.Drawing.Point(280, 218);
            this.txtUnitIdDivision.Name = "txtUnitIdDivision";
            this.txtUnitIdDivision.ReadOnly = true;
            this.txtUnitIdDivision.Size = new System.Drawing.Size(141, 22);
            this.txtUnitIdDivision.TabIndex = 26;
            // 
            // txtUnitNameDivision
            // 
            this.txtUnitNameDivision.Location = new System.Drawing.Point(280, 246);
            this.txtUnitNameDivision.Name = "txtUnitNameDivision";
            this.txtUnitNameDivision.ReadOnly = true;
            this.txtUnitNameDivision.Size = new System.Drawing.Size(141, 22);
            this.txtUnitNameDivision.TabIndex = 27;
            // 
            // txtUnitHealthDivision
            // 
            this.txtUnitHealthDivision.Location = new System.Drawing.Point(280, 274);
            this.txtUnitHealthDivision.Name = "txtUnitHealthDivision";
            this.txtUnitHealthDivision.ReadOnly = true;
            this.txtUnitHealthDivision.Size = new System.Drawing.Size(141, 22);
            this.txtUnitHealthDivision.TabIndex = 28;
            // 
            // txtUnitExperienceDivision
            // 
            this.txtUnitExperienceDivision.Location = new System.Drawing.Point(280, 302);
            this.txtUnitExperienceDivision.Name = "txtUnitExperienceDivision";
            this.txtUnitExperienceDivision.ReadOnly = true;
            this.txtUnitExperienceDivision.Size = new System.Drawing.Size(141, 22);
            this.txtUnitExperienceDivision.TabIndex = 29;
            // 
            // txtUnitSupplyDivision
            // 
            this.txtUnitSupplyDivision.Location = new System.Drawing.Point(280, 331);
            this.txtUnitSupplyDivision.Name = "txtUnitSupplyDivision";
            this.txtUnitSupplyDivision.ReadOnly = true;
            this.txtUnitSupplyDivision.Size = new System.Drawing.Size(141, 22);
            this.txtUnitSupplyDivision.TabIndex = 30;
            // 
            // DialogDivisionNew
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(433, 412);
            this.Controls.Add(this.txtUnitSupplyDivision);
            this.Controls.Add(this.txtUnitExperienceDivision);
            this.Controls.Add(this.txtUnitHealthDivision);
            this.Controls.Add(this.txtUnitNameDivision);
            this.Controls.Add(this.txtUnitIdDivision);
            this.Controls.Add(this.txtUnitIdCommon);
            this.Controls.Add(this.lblUnitId);
            this.Controls.Add(this.txtUnitSupplyCommon);
            this.Controls.Add(this.lblUnitSupply);
            this.Controls.Add(this.txtUnitExperienceCommon);
            this.Controls.Add(this.lblUnitExperience);
            this.Controls.Add(this.txtUnitHealthCommon);
            this.Controls.Add(this.lblUnitHealth);
            this.Controls.Add(this.txtUnitNameCommon);
            this.Controls.Add(this.lblUnitName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUnitRemove);
            this.Controls.Add(this.btnUnitAdd);
            this.Controls.Add(this.lblUnitsDivision);
            this.Controls.Add(this.lblUnitsAll);
            this.Controls.Add(this.lblDivisionType);
            this.Controls.Add(this.listUnitsDivision);
            this.Controls.Add(this.listUnitsAll);
            this.Controls.Add(this.comboDivisionType);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogDivisionNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новое подразделение";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DialogMapNew_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox comboDivisionType;
        private System.Windows.Forms.ListBox listUnitsAll;
        private System.Windows.Forms.ListBox listUnitsDivision;
        private System.Windows.Forms.Label lblDivisionType;
        private System.Windows.Forms.Label lblUnitsAll;
        private System.Windows.Forms.Label lblUnitsDivision;
        private System.Windows.Forms.Button btnUnitAdd;
        private System.Windows.Forms.Button btnUnitRemove;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblUnitName;
        private System.Windows.Forms.TextBox txtUnitNameCommon;
        private System.Windows.Forms.Label lblUnitHealth;
        private System.Windows.Forms.TextBox txtUnitHealthCommon;
        private System.Windows.Forms.Label lblUnitExperience;
        private System.Windows.Forms.TextBox txtUnitExperienceCommon;
        private System.Windows.Forms.Label lblUnitSupply;
        private System.Windows.Forms.TextBox txtUnitSupplyCommon;
        private System.Windows.Forms.Label lblUnitId;
        private System.Windows.Forms.TextBox txtUnitIdCommon;
        private System.Windows.Forms.TextBox txtUnitIdDivision;
        private System.Windows.Forms.TextBox txtUnitNameDivision;
        private System.Windows.Forms.TextBox txtUnitHealthDivision;
        private System.Windows.Forms.TextBox txtUnitExperienceDivision;
        private System.Windows.Forms.TextBox txtUnitSupplyDivision;
    }
}
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
            this.lblUnitExperience = new System.Windows.Forms.Label();
            this.lblUnitSupply = new System.Windows.Forms.Label();
            this.lblUnitId = new System.Windows.Forms.Label();
            this.txtUnitNameDivision = new System.Windows.Forms.TextBox();
            this.btnUnitDivisionApply = new System.Windows.Forms.Button();
            this.numUnitHealthCommon = new System.Windows.Forms.NumericUpDown();
            this.numUnitExperienceCommon = new System.Windows.Forms.NumericUpDown();
            this.numUnitSupplyCommon = new System.Windows.Forms.NumericUpDown();
            this.numUnitIdCommon = new System.Windows.Forms.NumericUpDown();
            this.numUnitIdDivision = new System.Windows.Forms.NumericUpDown();
            this.numUnitHealthDivision = new System.Windows.Forms.NumericUpDown();
            this.numUnitExperienceDivision = new System.Windows.Forms.NumericUpDown();
            this.numUnitSupplyDivision = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitHealthCommon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitExperienceCommon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitSupplyCommon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitIdCommon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitIdDivision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitHealthDivision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitExperienceDivision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitSupplyDivision)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(241, 338);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
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
            this.comboDivisionType.Location = new System.Drawing.Point(9, 28);
            this.comboDivisionType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboDivisionType.Name = "comboDivisionType";
            this.comboDivisionType.Size = new System.Drawing.Size(308, 21);
            this.comboDivisionType.TabIndex = 7;
            this.comboDivisionType.SelectedIndexChanged += new System.EventHandler(this.ComboDivisionType_SelectedIndexChanged);
            // 
            // listUnitsAll
            // 
            this.listUnitsAll.FormattingEnabled = true;
            this.listUnitsAll.Location = new System.Drawing.Point(9, 78);
            this.listUnitsAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listUnitsAll.Name = "listUnitsAll";
            this.listUnitsAll.Size = new System.Drawing.Size(125, 82);
            this.listUnitsAll.TabIndex = 8;
            this.listUnitsAll.SelectedIndexChanged += new System.EventHandler(this.ListUnitsAll_SelectedIndexChanged);
            // 
            // listUnitsDivision
            // 
            this.listUnitsDivision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listUnitsDivision.FormattingEnabled = true;
            this.listUnitsDivision.Location = new System.Drawing.Point(192, 78);
            this.listUnitsDivision.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listUnitsDivision.Name = "listUnitsDivision";
            this.listUnitsDivision.Size = new System.Drawing.Size(125, 82);
            this.listUnitsDivision.TabIndex = 9;
            this.listUnitsDivision.SelectedIndexChanged += new System.EventHandler(this.ListUnitsDivision_SelectedIndexChanged);
            // 
            // lblDivisionType
            // 
            this.lblDivisionType.AutoSize = true;
            this.lblDivisionType.Location = new System.Drawing.Point(7, 12);
            this.lblDivisionType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDivisionType.Name = "lblDivisionType";
            this.lblDivisionType.Size = new System.Drawing.Size(110, 13);
            this.lblDivisionType.TabIndex = 10;
            this.lblDivisionType.Text = "Тип подразделения:";
            // 
            // lblUnitsAll
            // 
            this.lblUnitsAll.AutoSize = true;
            this.lblUnitsAll.Location = new System.Drawing.Point(7, 62);
            this.lblUnitsAll.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnitsAll.Name = "lblUnitsAll";
            this.lblUnitsAll.Size = new System.Drawing.Size(103, 13);
            this.lblUnitsAll.TabIndex = 11;
            this.lblUnitsAll.Text = "Доступные юниты:";
            // 
            // lblUnitsDivision
            // 
            this.lblUnitsDivision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnitsDivision.AutoSize = true;
            this.lblUnitsDivision.Location = new System.Drawing.Point(190, 62);
            this.lblUnitsDivision.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnitsDivision.Name = "lblUnitsDivision";
            this.lblUnitsDivision.Size = new System.Drawing.Size(98, 13);
            this.lblUnitsDivision.TabIndex = 12;
            this.lblUnitsDivision.Text = "В подразделении:";
            // 
            // btnUnitAdd
            // 
            this.btnUnitAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnitAdd.Location = new System.Drawing.Point(138, 78);
            this.btnUnitAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUnitAdd.Name = "btnUnitAdd";
            this.btnUnitAdd.Size = new System.Drawing.Size(50, 19);
            this.btnUnitAdd.TabIndex = 13;
            this.btnUnitAdd.Text = ">>";
            this.btnUnitAdd.UseVisualStyleBackColor = true;
            this.btnUnitAdd.Click += new System.EventHandler(this.BtnUnitAdd_Click);
            // 
            // btnUnitRemove
            // 
            this.btnUnitRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnitRemove.Location = new System.Drawing.Point(138, 102);
            this.btnUnitRemove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUnitRemove.Name = "btnUnitRemove";
            this.btnUnitRemove.Size = new System.Drawing.Size(50, 19);
            this.btnUnitRemove.TabIndex = 14;
            this.btnUnitRemove.Text = "<<";
            this.btnUnitRemove.UseVisualStyleBackColor = true;
            this.btnUnitRemove.Click += new System.EventHandler(this.BtnUnitRemove_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(9, 338);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblUnitName
            // 
            this.lblUnitName.AutoSize = true;
            this.lblUnitName.Location = new System.Drawing.Point(137, 202);
            this.lblUnitName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnitName.Name = "lblUnitName";
            this.lblUnitName.Size = new System.Drawing.Size(57, 13);
            this.lblUnitName.TabIndex = 18;
            this.lblUnitName.Text = "Название";
            // 
            // txtUnitNameCommon
            // 
            this.txtUnitNameCommon.Location = new System.Drawing.Point(9, 200);
            this.txtUnitNameCommon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUnitNameCommon.Name = "txtUnitNameCommon";
            this.txtUnitNameCommon.Size = new System.Drawing.Size(107, 20);
            this.txtUnitNameCommon.TabIndex = 19;
            // 
            // lblUnitHealth
            // 
            this.lblUnitHealth.AutoSize = true;
            this.lblUnitHealth.Location = new System.Drawing.Point(137, 226);
            this.lblUnitHealth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnitHealth.Name = "lblUnitHealth";
            this.lblUnitHealth.Size = new System.Drawing.Size(56, 13);
            this.lblUnitHealth.TabIndex = 20;
            this.lblUnitHealth.Text = "Здоровье";
            // 
            // lblUnitExperience
            // 
            this.lblUnitExperience.AutoSize = true;
            this.lblUnitExperience.Location = new System.Drawing.Point(144, 250);
            this.lblUnitExperience.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnitExperience.Name = "lblUnitExperience";
            this.lblUnitExperience.Size = new System.Drawing.Size(34, 13);
            this.lblUnitExperience.TabIndex = 22;
            this.lblUnitExperience.Text = "Опыт";
            // 
            // lblUnitSupply
            // 
            this.lblUnitSupply.AutoSize = true;
            this.lblUnitSupply.Location = new System.Drawing.Point(137, 273);
            this.lblUnitSupply.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnitSupply.Name = "lblUnitSupply";
            this.lblUnitSupply.Size = new System.Drawing.Size(52, 13);
            this.lblUnitSupply.TabIndex = 24;
            this.lblUnitSupply.Text = "Патроны";
            // 
            // lblUnitId
            // 
            this.lblUnitId.AutoSize = true;
            this.lblUnitId.Location = new System.Drawing.Point(155, 177);
            this.lblUnitId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnitId.Name = "lblUnitId";
            this.lblUnitId.Size = new System.Drawing.Size(16, 13);
            this.lblUnitId.TabIndex = 16;
            this.lblUnitId.Text = "Id";
            // 
            // txtUnitNameDivision
            // 
            this.txtUnitNameDivision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnitNameDivision.Location = new System.Drawing.Point(210, 200);
            this.txtUnitNameDivision.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUnitNameDivision.Name = "txtUnitNameDivision";
            this.txtUnitNameDivision.Size = new System.Drawing.Size(107, 20);
            this.txtUnitNameDivision.TabIndex = 27;
            // 
            // btnUnitDivisionApply
            // 
            this.btnUnitDivisionApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnitDivisionApply.Location = new System.Drawing.Point(210, 297);
            this.btnUnitDivisionApply.Name = "btnUnitDivisionApply";
            this.btnUnitDivisionApply.Size = new System.Drawing.Size(107, 23);
            this.btnUnitDivisionApply.TabIndex = 31;
            this.btnUnitDivisionApply.Text = "Применить";
            this.btnUnitDivisionApply.UseVisualStyleBackColor = true;
            this.btnUnitDivisionApply.Click += new System.EventHandler(this.btnUnitDivisionApply_Click);
            // 
            // numUnitHealthCommon
            // 
            this.numUnitHealthCommon.Location = new System.Drawing.Point(9, 224);
            this.numUnitHealthCommon.Name = "numUnitHealthCommon";
            this.numUnitHealthCommon.Size = new System.Drawing.Size(107, 20);
            this.numUnitHealthCommon.TabIndex = 21;
            this.numUnitHealthCommon.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numUnitExperienceCommon
            // 
            this.numUnitExperienceCommon.Location = new System.Drawing.Point(9, 248);
            this.numUnitExperienceCommon.Name = "numUnitExperienceCommon";
            this.numUnitExperienceCommon.Size = new System.Drawing.Size(107, 20);
            this.numUnitExperienceCommon.TabIndex = 23;
            // 
            // numUnitSupplyCommon
            // 
            this.numUnitSupplyCommon.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numUnitSupplyCommon.Location = new System.Drawing.Point(9, 271);
            this.numUnitSupplyCommon.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUnitSupplyCommon.Name = "numUnitSupplyCommon";
            this.numUnitSupplyCommon.Size = new System.Drawing.Size(107, 20);
            this.numUnitSupplyCommon.TabIndex = 25;
            this.numUnitSupplyCommon.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numUnitIdCommon
            // 
            this.numUnitIdCommon.Location = new System.Drawing.Point(9, 175);
            this.numUnitIdCommon.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUnitIdCommon.Name = "numUnitIdCommon";
            this.numUnitIdCommon.Size = new System.Drawing.Size(107, 20);
            this.numUnitIdCommon.TabIndex = 17;
            // 
            // numUnitIdDivision
            // 
            this.numUnitIdDivision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numUnitIdDivision.Enabled = false;
            this.numUnitIdDivision.Location = new System.Drawing.Point(211, 175);
            this.numUnitIdDivision.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUnitIdDivision.Name = "numUnitIdDivision";
            this.numUnitIdDivision.Size = new System.Drawing.Size(106, 20);
            this.numUnitIdDivision.TabIndex = 26;
            // 
            // numUnitHealthDivision
            // 
            this.numUnitHealthDivision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numUnitHealthDivision.Location = new System.Drawing.Point(210, 224);
            this.numUnitHealthDivision.Name = "numUnitHealthDivision";
            this.numUnitHealthDivision.Size = new System.Drawing.Size(107, 20);
            this.numUnitHealthDivision.TabIndex = 28;
            this.numUnitHealthDivision.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numUnitExperienceDivision
            // 
            this.numUnitExperienceDivision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numUnitExperienceDivision.Location = new System.Drawing.Point(210, 248);
            this.numUnitExperienceDivision.Name = "numUnitExperienceDivision";
            this.numUnitExperienceDivision.Size = new System.Drawing.Size(107, 20);
            this.numUnitExperienceDivision.TabIndex = 29;
            // 
            // numUnitSupplyDivision
            // 
            this.numUnitSupplyDivision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numUnitSupplyDivision.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numUnitSupplyDivision.Location = new System.Drawing.Point(210, 271);
            this.numUnitSupplyDivision.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUnitSupplyDivision.Name = "numUnitSupplyDivision";
            this.numUnitSupplyDivision.Size = new System.Drawing.Size(107, 20);
            this.numUnitSupplyDivision.TabIndex = 30;
            this.numUnitSupplyDivision.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // DialogDivisionNew
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(325, 372);
            this.Controls.Add(this.numUnitSupplyDivision);
            this.Controls.Add(this.numUnitExperienceDivision);
            this.Controls.Add(this.numUnitHealthDivision);
            this.Controls.Add(this.numUnitIdDivision);
            this.Controls.Add(this.numUnitIdCommon);
            this.Controls.Add(this.numUnitSupplyCommon);
            this.Controls.Add(this.numUnitExperienceCommon);
            this.Controls.Add(this.numUnitHealthCommon);
            this.Controls.Add(this.btnUnitDivisionApply);
            this.Controls.Add(this.txtUnitNameDivision);
            this.Controls.Add(this.lblUnitId);
            this.Controls.Add(this.lblUnitSupply);
            this.Controls.Add(this.lblUnitExperience);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogDivisionNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новое подразделение";
            this.Load += new System.EventHandler(this.DialogMapNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUnitHealthCommon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitExperienceCommon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitSupplyCommon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitIdCommon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitIdDivision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitHealthDivision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitExperienceDivision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitSupplyDivision)).EndInit();
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
        private System.Windows.Forms.Label lblUnitExperience;
        private System.Windows.Forms.Label lblUnitSupply;
        private System.Windows.Forms.Label lblUnitId;
        private System.Windows.Forms.TextBox txtUnitNameDivision;
        private System.Windows.Forms.Button btnUnitDivisionApply;
        private System.Windows.Forms.NumericUpDown numUnitHealthCommon;
        private System.Windows.Forms.NumericUpDown numUnitExperienceCommon;
        private System.Windows.Forms.NumericUpDown numUnitSupplyCommon;
        private System.Windows.Forms.NumericUpDown numUnitIdCommon;
        private System.Windows.Forms.NumericUpDown numUnitIdDivision;
        private System.Windows.Forms.NumericUpDown numUnitHealthDivision;
        private System.Windows.Forms.NumericUpDown numUnitExperienceDivision;
        private System.Windows.Forms.NumericUpDown numUnitSupplyDivision;
    }
}
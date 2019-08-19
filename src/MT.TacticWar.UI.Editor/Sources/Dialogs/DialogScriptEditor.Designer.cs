namespace MT.TacticWar.UI.Editor.Dialogs
{
    partial class DialogScriptEditor
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
            this.lblConditionType = new System.Windows.Forms.Label();
            this.comboConditionType = new System.Windows.Forms.ComboBox();
            this.lblConditionParams = new System.Windows.Forms.Label();
            this.listConditionParams = new System.Windows.Forms.ListBox();
            this.groupCondition = new System.Windows.Forms.GroupBox();
            this.groupStatement = new System.Windows.Forms.GroupBox();
            this.comboStatementType = new System.Windows.Forms.ComboBox();
            this.lblStatementType = new System.Windows.Forms.Label();
            this.listStatementParams = new System.Windows.Forms.ListBox();
            this.lblStatementParams = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupCondition.SuspendLayout();
            this.groupStatement.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblConditionType
            // 
            this.lblConditionType.AutoSize = true;
            this.lblConditionType.Location = new System.Drawing.Point(15, 33);
            this.lblConditionType.Name = "lblConditionType";
            this.lblConditionType.Size = new System.Drawing.Size(37, 17);
            this.lblConditionType.TabIndex = 0;
            this.lblConditionType.Text = "Тип:";
            // 
            // comboConditionType
            // 
            this.comboConditionType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboConditionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboConditionType.FormattingEnabled = true;
            this.comboConditionType.Location = new System.Drawing.Point(18, 53);
            this.comboConditionType.Name = "comboConditionType";
            this.comboConditionType.Size = new System.Drawing.Size(229, 24);
            this.comboConditionType.TabIndex = 1;
            this.comboConditionType.SelectedIndexChanged += new System.EventHandler(this.ComboConditionType_SelectedIndexChanged);
            // 
            // lblConditionParams
            // 
            this.lblConditionParams.AutoSize = true;
            this.lblConditionParams.Location = new System.Drawing.Point(15, 89);
            this.lblConditionParams.Name = "lblConditionParams";
            this.lblConditionParams.Size = new System.Drawing.Size(88, 17);
            this.lblConditionParams.TabIndex = 2;
            this.lblConditionParams.Text = "Параметры:";
            // 
            // listConditionParams
            // 
            this.listConditionParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listConditionParams.FormattingEnabled = true;
            this.listConditionParams.ItemHeight = 16;
            this.listConditionParams.Location = new System.Drawing.Point(18, 109);
            this.listConditionParams.Name = "listConditionParams";
            this.listConditionParams.Size = new System.Drawing.Size(229, 100);
            this.listConditionParams.TabIndex = 3;
            this.listConditionParams.DoubleClick += new System.EventHandler(this.ListConditionParams_DoubleClick);
            // 
            // groupCondition
            // 
            this.groupCondition.Controls.Add(this.comboConditionType);
            this.groupCondition.Controls.Add(this.lblConditionType);
            this.groupCondition.Controls.Add(this.listConditionParams);
            this.groupCondition.Controls.Add(this.lblConditionParams);
            this.groupCondition.Location = new System.Drawing.Point(12, 65);
            this.groupCondition.Name = "groupCondition";
            this.groupCondition.Size = new System.Drawing.Size(270, 230);
            this.groupCondition.TabIndex = 2;
            this.groupCondition.TabStop = false;
            this.groupCondition.Text = "Условие";
            // 
            // groupStatement
            // 
            this.groupStatement.Controls.Add(this.comboStatementType);
            this.groupStatement.Controls.Add(this.lblStatementType);
            this.groupStatement.Controls.Add(this.listStatementParams);
            this.groupStatement.Controls.Add(this.lblStatementParams);
            this.groupStatement.Location = new System.Drawing.Point(296, 65);
            this.groupStatement.Name = "groupStatement";
            this.groupStatement.Size = new System.Drawing.Size(270, 230);
            this.groupStatement.TabIndex = 3;
            this.groupStatement.TabStop = false;
            this.groupStatement.Text = "Действие";
            // 
            // comboStatementType
            // 
            this.comboStatementType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboStatementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStatementType.FormattingEnabled = true;
            this.comboStatementType.Location = new System.Drawing.Point(20, 53);
            this.comboStatementType.Name = "comboStatementType";
            this.comboStatementType.Size = new System.Drawing.Size(226, 24);
            this.comboStatementType.TabIndex = 5;
            this.comboStatementType.SelectedIndexChanged += new System.EventHandler(this.ComboStatementType_SelectedIndexChanged);
            // 
            // lblStatementType
            // 
            this.lblStatementType.AutoSize = true;
            this.lblStatementType.Location = new System.Drawing.Point(17, 33);
            this.lblStatementType.Name = "lblStatementType";
            this.lblStatementType.Size = new System.Drawing.Size(37, 17);
            this.lblStatementType.TabIndex = 4;
            this.lblStatementType.Text = "Тип:";
            // 
            // listStatementParams
            // 
            this.listStatementParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listStatementParams.FormattingEnabled = true;
            this.listStatementParams.ItemHeight = 16;
            this.listStatementParams.Location = new System.Drawing.Point(20, 109);
            this.listStatementParams.Name = "listStatementParams";
            this.listStatementParams.Size = new System.Drawing.Size(226, 100);
            this.listStatementParams.TabIndex = 7;
            this.listStatementParams.DoubleClick += new System.EventHandler(this.ListStatementParams_DoubleClick);
            // 
            // lblStatementParams
            // 
            this.lblStatementParams.AutoSize = true;
            this.lblStatementParams.Location = new System.Drawing.Point(17, 89);
            this.lblStatementParams.Name = "lblStatementParams";
            this.lblStatementParams.Size = new System.Drawing.Size(88, 17);
            this.lblStatementParams.TabIndex = 6;
            this.lblStatementParams.Text = "Параметры:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(27, 9);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(78, 17);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Описание:";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(30, 29);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(512, 22);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.Text = "Скрипт";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(444, 313);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(122, 30);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 313);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DialogScriptEditor
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(579, 355);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.groupStatement);
            this.Controls.Add(this.groupCondition);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DialogScriptEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор скриптов";
            this.groupCondition.ResumeLayout(false);
            this.groupCondition.PerformLayout();
            this.groupStatement.ResumeLayout(false);
            this.groupStatement.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConditionType;
        private System.Windows.Forms.ComboBox comboConditionType;
        private System.Windows.Forms.Label lblConditionParams;
        private System.Windows.Forms.ListBox listConditionParams;
        private System.Windows.Forms.GroupBox groupCondition;
        private System.Windows.Forms.GroupBox groupStatement;
        private System.Windows.Forms.ComboBox comboStatementType;
        private System.Windows.Forms.Label lblStatementType;
        private System.Windows.Forms.ListBox listStatementParams;
        private System.Windows.Forms.Label lblStatementParams;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
namespace MT.TacticWar.UI.Dialogs
{
    partial class DialogMissionSettings
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
            this.groupIgrok1 = new System.Windows.Forms.GroupBox();
            this.lblName1 = new System.Windows.Forms.Label();
            this.txtName1 = new System.Windows.Forms.TextBox();
            this.radioPC1 = new System.Windows.Forms.RadioButton();
            this.radioHuman1 = new System.Windows.Forms.RadioButton();
            this.groupIgrok2 = new System.Windows.Forms.GroupBox();
            this.lblName2 = new System.Windows.Forms.Label();
            this.radioHuman2 = new System.Windows.Forms.RadioButton();
            this.txtName2 = new System.Windows.Forms.TextBox();
            this.radioPC2 = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupIgrok1.SuspendLayout();
            this.groupIgrok2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupIgrok1
            // 
            this.groupIgrok1.Controls.Add(this.lblName1);
            this.groupIgrok1.Controls.Add(this.txtName1);
            this.groupIgrok1.Controls.Add(this.radioPC1);
            this.groupIgrok1.Controls.Add(this.radioHuman1);
            this.groupIgrok1.Location = new System.Drawing.Point(12, 12);
            this.groupIgrok1.Name = "groupIgrok1";
            this.groupIgrok1.Size = new System.Drawing.Size(141, 121);
            this.groupIgrok1.TabIndex = 0;
            this.groupIgrok1.TabStop = false;
            this.groupIgrok1.Text = "Игрок 1 (зелёные)";
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.Location = new System.Drawing.Point(21, 68);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(70, 13);
            this.lblName1.TabIndex = 3;
            this.lblName1.Text = "Имя игрока:";
            // 
            // txtName1
            // 
            this.txtName1.Location = new System.Drawing.Point(21, 87);
            this.txtName1.Name = "txtName1";
            this.txtName1.Size = new System.Drawing.Size(100, 20);
            this.txtName1.TabIndex = 1;
            this.txtName1.Text = "Игрок 1";
            // 
            // radioPC1
            // 
            this.radioPC1.AutoSize = true;
            this.radioPC1.Enabled = false;
            this.radioPC1.Location = new System.Drawing.Point(21, 43);
            this.radioPC1.Name = "radioPC1";
            this.radioPC1.Size = new System.Drawing.Size(83, 17);
            this.radioPC1.TabIndex = 4;
            this.radioPC1.Text = "Компьютер";
            this.radioPC1.UseVisualStyleBackColor = true;
            this.radioPC1.CheckedChanged += new System.EventHandler(this.RadioPC1_CheckedChanged);
            // 
            // radioHuman1
            // 
            this.radioHuman1.AutoSize = true;
            this.radioHuman1.Checked = true;
            this.radioHuman1.Location = new System.Drawing.Point(21, 20);
            this.radioHuman1.Name = "radioHuman1";
            this.radioHuman1.Size = new System.Drawing.Size(69, 17);
            this.radioHuman1.TabIndex = 3;
            this.radioHuman1.TabStop = true;
            this.radioHuman1.Text = "Человек";
            this.radioHuman1.UseVisualStyleBackColor = true;
            this.radioHuman1.CheckedChanged += new System.EventHandler(this.RadioHuman1_CheckedChanged);
            // 
            // groupIgrok2
            // 
            this.groupIgrok2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupIgrok2.Controls.Add(this.lblName2);
            this.groupIgrok2.Controls.Add(this.radioHuman2);
            this.groupIgrok2.Controls.Add(this.txtName2);
            this.groupIgrok2.Controls.Add(this.radioPC2);
            this.groupIgrok2.Location = new System.Drawing.Point(159, 12);
            this.groupIgrok2.Name = "groupIgrok2";
            this.groupIgrok2.Size = new System.Drawing.Size(141, 121);
            this.groupIgrok2.TabIndex = 1;
            this.groupIgrok2.TabStop = false;
            this.groupIgrok2.Text = "Игрок 2 (красные)";
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Location = new System.Drawing.Point(21, 68);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(70, 13);
            this.lblName2.TabIndex = 3;
            this.lblName2.Text = "Имя игрока:";
            // 
            // radioHuman2
            // 
            this.radioHuman2.AutoSize = true;
            this.radioHuman2.Checked = true;
            this.radioHuman2.Location = new System.Drawing.Point(21, 20);
            this.radioHuman2.Name = "radioHuman2";
            this.radioHuman2.Size = new System.Drawing.Size(69, 17);
            this.radioHuman2.TabIndex = 5;
            this.radioHuman2.TabStop = true;
            this.radioHuman2.Text = "Человек";
            this.radioHuman2.UseVisualStyleBackColor = true;
            this.radioHuman2.CheckedChanged += new System.EventHandler(this.RadioHuman2_CheckedChanged);
            // 
            // txtName2
            // 
            this.txtName2.Location = new System.Drawing.Point(21, 87);
            this.txtName2.Name = "txtName2";
            this.txtName2.Size = new System.Drawing.Size(100, 20);
            this.txtName2.TabIndex = 2;
            this.txtName2.Text = "Игрок 2";
            // 
            // radioPC2
            // 
            this.radioPC2.AutoSize = true;
            this.radioPC2.Enabled = false;
            this.radioPC2.Location = new System.Drawing.Point(21, 43);
            this.radioPC2.Name = "radioPC2";
            this.radioPC2.Size = new System.Drawing.Size(83, 17);
            this.radioPC2.TabIndex = 6;
            this.radioPC2.Text = "Компьютер";
            this.radioPC2.UseVisualStyleBackColor = true;
            this.radioPC2.CheckedChanged += new System.EventHandler(this.RadioPC2_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(109, 139);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(96, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Начать";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // FrmUsersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 171);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupIgrok2);
            this.Controls.Add(this.groupIgrok1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUsersControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки пользователей";
            this.groupIgrok1.ResumeLayout(false);
            this.groupIgrok1.PerformLayout();
            this.groupIgrok2.ResumeLayout(false);
            this.groupIgrok2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupIgrok1;
        private System.Windows.Forms.GroupBox groupIgrok2;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.TextBox txtName1;
        private System.Windows.Forms.RadioButton radioPC1;
        private System.Windows.Forms.RadioButton radioHuman1;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.RadioButton radioHuman2;
        private System.Windows.Forms.TextBox txtName2;
        private System.Windows.Forms.RadioButton radioPC2;
        private System.Windows.Forms.Button btnStart;
    }
}
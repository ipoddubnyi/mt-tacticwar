namespace MT.TacticWar.UI.Editor.Dialogs
{
    partial class DialogPlayers
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
            this.listPlayers = new System.Windows.Forms.ListBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblTeam = new System.Windows.Forms.Label();
            this.numTeam = new System.Windows.Forms.NumericUpDown();
            this.lblColor = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            this.numMoney = new System.Windows.Forms.NumericUpDown();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.btnRemovePlayer = new System.Windows.Forms.Button();
            this.btnUpPlayer = new System.Windows.Forms.Button();
            this.btnDownPlayer = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoney)).BeginInit();
            this.SuspendLayout();
            // 
            // listPlayers
            // 
            this.listPlayers.FormattingEnabled = true;
            this.listPlayers.ItemHeight = 16;
            this.listPlayers.Location = new System.Drawing.Point(16, 15);
            this.listPlayers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listPlayers.Name = "listPlayers";
            this.listPlayers.Size = new System.Drawing.Size(156, 148);
            this.listPlayers.TabIndex = 0;
            this.listPlayers.SelectedIndexChanged += new System.EventHandler(this.listPlayers_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(325, 18);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Имя";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(181, 15);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(135, 22);
            this.txtName.TabIndex = 2;
            // 
            // lblTeam
            // 
            this.lblTeam.AutoSize = true;
            this.lblTeam.Location = new System.Drawing.Point(325, 49);
            this.lblTeam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(66, 17);
            this.lblTeam.TabIndex = 3;
            this.lblTeam.Text = "Команда";
            // 
            // numTeam
            // 
            this.numTeam.Location = new System.Drawing.Point(181, 47);
            this.numTeam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numTeam.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTeam.Name = "numTeam";
            this.numTeam.Size = new System.Drawing.Size(136, 22);
            this.numTeam.TabIndex = 4;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(325, 80);
            this.lblColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(41, 17);
            this.lblColor.TabIndex = 5;
            this.lblColor.Text = "Цвет";
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Green;
            this.btnColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnColor.Location = new System.Drawing.Point(181, 75);
            this.btnColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(135, 24);
            this.btnColor.TabIndex = 6;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Location = new System.Drawing.Point(325, 110);
            this.lblMoney.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(55, 17);
            this.lblMoney.TabIndex = 7;
            this.lblMoney.Text = "Деньги";
            // 
            // numMoney
            // 
            this.numMoney.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numMoney.Location = new System.Drawing.Point(181, 107);
            this.numMoney.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numMoney.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numMoney.Name = "numMoney";
            this.numMoney.Size = new System.Drawing.Size(136, 22);
            this.numMoney.TabIndex = 9;
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Location = new System.Drawing.Point(16, 171);
            this.btnAddPlayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(33, 28);
            this.btnAddPlayer.TabIndex = 10;
            this.btnAddPlayer.Text = "+";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // btnRemovePlayer
            // 
            this.btnRemovePlayer.Location = new System.Drawing.Point(57, 171);
            this.btnRemovePlayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemovePlayer.Name = "btnRemovePlayer";
            this.btnRemovePlayer.Size = new System.Drawing.Size(33, 28);
            this.btnRemovePlayer.TabIndex = 11;
            this.btnRemovePlayer.Text = "-";
            this.btnRemovePlayer.UseVisualStyleBackColor = true;
            this.btnRemovePlayer.Click += new System.EventHandler(this.btnRemovePlayer_Click);
            // 
            // btnUpPlayer
            // 
            this.btnUpPlayer.Location = new System.Drawing.Point(99, 171);
            this.btnUpPlayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpPlayer.Name = "btnUpPlayer";
            this.btnUpPlayer.Size = new System.Drawing.Size(33, 28);
            this.btnUpPlayer.TabIndex = 12;
            this.btnUpPlayer.Text = "↑";
            this.btnUpPlayer.UseVisualStyleBackColor = true;
            this.btnUpPlayer.Click += new System.EventHandler(this.btnUpPlayer_Click);
            // 
            // btnDownPlayer
            // 
            this.btnDownPlayer.Location = new System.Drawing.Point(140, 171);
            this.btnDownPlayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDownPlayer.Name = "btnDownPlayer";
            this.btnDownPlayer.Size = new System.Drawing.Size(33, 28);
            this.btnDownPlayer.TabIndex = 13;
            this.btnDownPlayer.Text = "↓";
            this.btnDownPlayer.UseVisualStyleBackColor = true;
            this.btnDownPlayer.Click += new System.EventHandler(this.btnDownPlayer_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(16, 215);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(300, 215);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 15;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(217, 136);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 28);
            this.btnApply.TabIndex = 16;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // DialogPlayers
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(416, 258);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDownPlayer);
            this.Controls.Add(this.btnUpPlayer);
            this.Controls.Add(this.btnRemovePlayer);
            this.Controls.Add(this.btnAddPlayer);
            this.Controls.Add(this.numMoney);
            this.Controls.Add(this.lblMoney);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.numTeam);
            this.Controls.Add(this.lblTeam);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.listPlayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogPlayers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Игроки";
            ((System.ComponentModel.ISupportInitialize)(this.numTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoney)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listPlayers;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.NumericUpDown numTeam;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label btnColor;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.NumericUpDown numMoney;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.Button btnRemovePlayer;
        private System.Windows.Forms.Button btnUpPlayer;
        private System.Windows.Forms.Button btnDownPlayer;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnApply;
    }
}
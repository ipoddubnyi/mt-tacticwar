namespace MT.TacticWar.UI.Editor.Controls
{
    partial class ObjectProperties
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblObjectPlayer = new System.Windows.Forms.Label();
            this.numObjectId = new System.Windows.Forms.NumericUpDown();
            this.lblObjectId = new System.Windows.Forms.Label();
            this.txtObjectName = new System.Windows.Forms.TextBox();
            this.lblObjectName = new System.Windows.Forms.Label();
            this.comboObjectPlayer = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numObjectId)).BeginInit();
            this.SuspendLayout();
            // 
            // lblObjectPlayer
            // 
            this.lblObjectPlayer.AutoSize = true;
            this.lblObjectPlayer.Location = new System.Drawing.Point(3, 10);
            this.lblObjectPlayer.Name = "lblObjectPlayer";
            this.lblObjectPlayer.Size = new System.Drawing.Size(46, 17);
            this.lblObjectPlayer.TabIndex = 42;
            this.lblObjectPlayer.Text = "Игрок";
            // 
            // numObjectId
            // 
            this.numObjectId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numObjectId.Location = new System.Drawing.Point(84, 33);
            this.numObjectId.Margin = new System.Windows.Forms.Padding(4);
            this.numObjectId.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numObjectId.Name = "numObjectId";
            this.numObjectId.Size = new System.Drawing.Size(120, 22);
            this.numObjectId.TabIndex = 39;
            this.numObjectId.ValueChanged += new System.EventHandler(this.NumBuildingId_ValueChanged);
            // 
            // lblObjectId
            // 
            this.lblObjectId.AutoSize = true;
            this.lblObjectId.Location = new System.Drawing.Point(3, 36);
            this.lblObjectId.Name = "lblObjectId";
            this.lblObjectId.Size = new System.Drawing.Size(19, 17);
            this.lblObjectId.TabIndex = 38;
            this.lblObjectId.Text = "Id";
            // 
            // txtObjectName
            // 
            this.txtObjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObjectName.BackColor = System.Drawing.SystemColors.Window;
            this.txtObjectName.Location = new System.Drawing.Point(84, 60);
            this.txtObjectName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObjectName.Name = "txtObjectName";
            this.txtObjectName.Size = new System.Drawing.Size(119, 22);
            this.txtObjectName.TabIndex = 41;
            this.txtObjectName.TextChanged += new System.EventHandler(this.TxtBuildingName_TextChanged);
            // 
            // lblObjectName
            // 
            this.lblObjectName.AutoSize = true;
            this.lblObjectName.Location = new System.Drawing.Point(3, 64);
            this.lblObjectName.Name = "lblObjectName";
            this.lblObjectName.Size = new System.Drawing.Size(72, 17);
            this.lblObjectName.TabIndex = 40;
            this.lblObjectName.Text = "Название";
            // 
            // comboObjectPlayer
            // 
            this.comboObjectPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboObjectPlayer.BackColor = System.Drawing.SystemColors.Window;
            this.comboObjectPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboObjectPlayer.FormattingEnabled = true;
            this.comboObjectPlayer.Location = new System.Drawing.Point(84, 6);
            this.comboObjectPlayer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboObjectPlayer.Name = "comboObjectPlayer";
            this.comboObjectPlayer.Size = new System.Drawing.Size(119, 24);
            this.comboObjectPlayer.TabIndex = 37;
            this.comboObjectPlayer.SelectedIndexChanged += new System.EventHandler(this.ComboBuildingPlayer_SelectedIndexChanged);
            // 
            // ObjectProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblObjectPlayer);
            this.Controls.Add(this.numObjectId);
            this.Controls.Add(this.lblObjectId);
            this.Controls.Add(this.txtObjectName);
            this.Controls.Add(this.lblObjectName);
            this.Controls.Add(this.comboObjectPlayer);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ObjectProperties";
            this.Size = new System.Drawing.Size(215, 91);
            ((System.ComponentModel.ISupportInitialize)(this.numObjectId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblObjectPlayer;
        private System.Windows.Forms.NumericUpDown numObjectId;
        private System.Windows.Forms.Label lblObjectId;
        private System.Windows.Forms.TextBox txtObjectName;
        private System.Windows.Forms.Label lblObjectName;
        private System.Windows.Forms.ComboBox comboObjectPlayer;
    }
}

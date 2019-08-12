namespace MT.TacticWar.UI.Editor.Controls
{
    partial class DivisionProperties
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
            this.lblDivisionPlayer = new System.Windows.Forms.Label();
            this.numDivisionId = new System.Windows.Forms.NumericUpDown();
            this.lblDivisionId = new System.Windows.Forms.Label();
            this.txtDivisionName = new System.Windows.Forms.TextBox();
            this.lblDivisionName = new System.Windows.Forms.Label();
            this.comboDivisionPlayer = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numDivisionId)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDivisionPlayer
            // 
            this.lblDivisionPlayer.AutoSize = true;
            this.lblDivisionPlayer.Location = new System.Drawing.Point(2, 8);
            this.lblDivisionPlayer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDivisionPlayer.Name = "lblDivisionPlayer";
            this.lblDivisionPlayer.Size = new System.Drawing.Size(38, 13);
            this.lblDivisionPlayer.TabIndex = 42;
            this.lblDivisionPlayer.Text = "Игрок";
            // 
            // numDivisionId
            // 
            this.numDivisionId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numDivisionId.Location = new System.Drawing.Point(63, 27);
            this.numDivisionId.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numDivisionId.Name = "numDivisionId";
            this.numDivisionId.Size = new System.Drawing.Size(90, 20);
            this.numDivisionId.TabIndex = 39;
            this.numDivisionId.ValueChanged += new System.EventHandler(this.NumDivisionId_ValueChanged);
            // 
            // lblDivisionId
            // 
            this.lblDivisionId.AutoSize = true;
            this.lblDivisionId.Location = new System.Drawing.Point(2, 29);
            this.lblDivisionId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDivisionId.Name = "lblDivisionId";
            this.lblDivisionId.Size = new System.Drawing.Size(16, 13);
            this.lblDivisionId.TabIndex = 38;
            this.lblDivisionId.Text = "Id";
            // 
            // txtDivisionName
            // 
            this.txtDivisionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDivisionName.Location = new System.Drawing.Point(63, 49);
            this.txtDivisionName.Margin = new System.Windows.Forms.Padding(2);
            this.txtDivisionName.Name = "txtDivisionName";
            this.txtDivisionName.Size = new System.Drawing.Size(90, 20);
            this.txtDivisionName.TabIndex = 41;
            this.txtDivisionName.TextChanged += new System.EventHandler(this.TxtDivisionName_TextChanged);
            // 
            // lblDivisionName
            // 
            this.lblDivisionName.AutoSize = true;
            this.lblDivisionName.Location = new System.Drawing.Point(2, 52);
            this.lblDivisionName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDivisionName.Name = "lblDivisionName";
            this.lblDivisionName.Size = new System.Drawing.Size(57, 13);
            this.lblDivisionName.TabIndex = 40;
            this.lblDivisionName.Text = "Название";
            // 
            // comboDivisionPlayer
            // 
            this.comboDivisionPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboDivisionPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDivisionPlayer.FormattingEnabled = true;
            this.comboDivisionPlayer.Location = new System.Drawing.Point(63, 5);
            this.comboDivisionPlayer.Margin = new System.Windows.Forms.Padding(2);
            this.comboDivisionPlayer.Name = "comboDivisionPlayer";
            this.comboDivisionPlayer.Size = new System.Drawing.Size(90, 21);
            this.comboDivisionPlayer.TabIndex = 37;
            this.comboDivisionPlayer.SelectedIndexChanged += new System.EventHandler(this.ComboDivisionPlayer_SelectedIndexChanged);
            // 
            // DivisionProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDivisionPlayer);
            this.Controls.Add(this.numDivisionId);
            this.Controls.Add(this.lblDivisionId);
            this.Controls.Add(this.txtDivisionName);
            this.Controls.Add(this.lblDivisionName);
            this.Controls.Add(this.comboDivisionPlayer);
            this.Name = "DivisionProperties";
            this.Size = new System.Drawing.Size(161, 74);
            ((System.ComponentModel.ISupportInitialize)(this.numDivisionId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDivisionPlayer;
        private System.Windows.Forms.NumericUpDown numDivisionId;
        private System.Windows.Forms.Label lblDivisionId;
        private System.Windows.Forms.TextBox txtDivisionName;
        private System.Windows.Forms.Label lblDivisionName;
        private System.Windows.Forms.ComboBox comboDivisionPlayer;
    }
}

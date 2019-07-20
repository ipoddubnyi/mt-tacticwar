namespace MT.TacticWar.UI
{
    partial class FrmAttack
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
            this.listElAtakU = new System.Windows.Forms.ListBox();
            this.listElDefU = new System.Windows.Forms.ListBox();
            this.listElAtakPod = new System.Windows.Forms.ListBox();
            this.listElDefPod = new System.Windows.Forms.ListBox();
            this.txtElAtak = new System.Windows.Forms.TextBox();
            this.txtElDefend = new System.Windows.Forms.TextBox();
            this.lblPodAtak = new System.Windows.Forms.Label();
            this.lblPodDefend = new System.Windows.Forms.Label();
            this.btnCount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listElAtakU
            // 
            this.listElAtakU.FormattingEnabled = true;
            this.listElAtakU.Location = new System.Drawing.Point(12, 40);
            this.listElAtakU.Name = "listElAtakU";
            this.listElAtakU.Size = new System.Drawing.Size(146, 134);
            this.listElAtakU.TabIndex = 1;
            // 
            // listElDefU
            // 
            this.listElDefU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listElDefU.FormattingEnabled = true;
            this.listElDefU.Location = new System.Drawing.Point(214, 40);
            this.listElDefU.Name = "listElDefU";
            this.listElDefU.Size = new System.Drawing.Size(146, 134);
            this.listElDefU.TabIndex = 3;
            // 
            // listElAtakPod
            // 
            this.listElAtakPod.FormattingEnabled = true;
            this.listElAtakPod.Location = new System.Drawing.Point(12, 207);
            this.listElAtakPod.Name = "listElAtakPod";
            this.listElAtakPod.Size = new System.Drawing.Size(146, 56);
            this.listElAtakPod.TabIndex = 2;
            // 
            // listElDefPod
            // 
            this.listElDefPod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listElDefPod.FormattingEnabled = true;
            this.listElDefPod.Location = new System.Drawing.Point(214, 207);
            this.listElDefPod.Name = "listElDefPod";
            this.listElDefPod.Size = new System.Drawing.Size(146, 56);
            this.listElDefPod.TabIndex = 4;
            // 
            // txtElAtak
            // 
            this.txtElAtak.Location = new System.Drawing.Point(12, 14);
            this.txtElAtak.Name = "txtElAtak";
            this.txtElAtak.ReadOnly = true;
            this.txtElAtak.Size = new System.Drawing.Size(146, 20);
            this.txtElAtak.TabIndex = 1;
            // 
            // txtElDefend
            // 
            this.txtElDefend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtElDefend.Location = new System.Drawing.Point(214, 14);
            this.txtElDefend.Name = "txtElDefend";
            this.txtElDefend.ReadOnly = true;
            this.txtElDefend.Size = new System.Drawing.Size(146, 20);
            this.txtElDefend.TabIndex = 1;
            // 
            // lblPodAtak
            // 
            this.lblPodAtak.AutoSize = true;
            this.lblPodAtak.Location = new System.Drawing.Point(12, 188);
            this.lblPodAtak.Name = "lblPodAtak";
            this.lblPodAtak.Size = new System.Drawing.Size(68, 13);
            this.lblPodAtak.TabIndex = 2;
            this.lblPodAtak.Text = "Поддержка:";
            // 
            // lblPodDefend
            // 
            this.lblPodDefend.AutoSize = true;
            this.lblPodDefend.Location = new System.Drawing.Point(211, 188);
            this.lblPodDefend.Name = "lblPodDefend";
            this.lblPodDefend.Size = new System.Drawing.Size(68, 13);
            this.lblPodDefend.TabIndex = 2;
            this.lblPodDefend.Text = "Поддержка:";
            // 
            // btnCount
            // 
            this.btnCount.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCount.Location = new System.Drawing.Point(259, 282);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(101, 23);
            this.btnCount.TabIndex = 0;
            this.btnCount.Text = "Просчитать";
            this.btnCount.UseVisualStyleBackColor = true;
            // 
            // FrmAttack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 317);
            this.Controls.Add(this.btnCount);
            this.Controls.Add(this.lblPodDefend);
            this.Controls.Add(this.lblPodAtak);
            this.Controls.Add(this.txtElDefend);
            this.Controls.Add(this.txtElAtak);
            this.Controls.Add(this.listElDefU);
            this.Controls.Add(this.listElDefPod);
            this.Controls.Add(this.listElAtakPod);
            this.Controls.Add(this.listElAtakU);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAttack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Атака";
            this.Load += new System.EventHandler(this.FrmAttack_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listElAtakU;
        private System.Windows.Forms.ListBox listElDefU;
        private System.Windows.Forms.ListBox listElAtakPod;
        private System.Windows.Forms.ListBox listElDefPod;
        private System.Windows.Forms.TextBox txtElAtak;
        private System.Windows.Forms.TextBox txtElDefend;
        private System.Windows.Forms.Label lblPodAtak;
        private System.Windows.Forms.Label lblPodDefend;
        private System.Windows.Forms.Button btnCount;
    }
}
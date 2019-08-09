namespace MT.TacticWar.UI.Editor.Dialogs
{
    partial class DialogMapNew
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
            this.lblSizeWidth = new System.Windows.Forms.Label();
            this.txtSizeWidth = new System.Windows.Forms.TextBox();
            this.lblSizeHeight = new System.Windows.Forms.Label();
            this.txtSizeHeight = new System.Windows.Forms.TextBox();
            this.lblSchema = new System.Windows.Forms.Label();
            this.comboMapSchema = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblMapName = new System.Windows.Forms.Label();
            this.txtMapName = new System.Windows.Forms.TextBox();
            this.lblMapDescription = new System.Windows.Forms.Label();
            this.txtMapDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSizeWidth
            // 
            this.lblSizeWidth.AutoSize = true;
            this.lblSizeWidth.Location = new System.Drawing.Point(44, 20);
            this.lblSizeWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSizeWidth.Name = "lblSizeWidth";
            this.lblSizeWidth.Size = new System.Drawing.Size(63, 17);
            this.lblSizeWidth.TabIndex = 0;
            this.lblSizeWidth.Text = "Ширина:";
            // 
            // txtSizeWidth
            // 
            this.txtSizeWidth.Location = new System.Drawing.Point(119, 16);
            this.txtSizeWidth.Margin = new System.Windows.Forms.Padding(4);
            this.txtSizeWidth.Name = "txtSizeWidth";
            this.txtSizeWidth.Size = new System.Drawing.Size(92, 22);
            this.txtSizeWidth.TabIndex = 1;
            this.txtSizeWidth.Text = "25";
            // 
            // lblSizeHeight
            // 
            this.lblSizeHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSizeHeight.AutoSize = true;
            this.lblSizeHeight.Location = new System.Drawing.Point(222, 20);
            this.lblSizeHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSizeHeight.Name = "lblSizeHeight";
            this.lblSizeHeight.Size = new System.Drawing.Size(61, 17);
            this.lblSizeHeight.TabIndex = 2;
            this.lblSizeHeight.Text = "Высота:";
            // 
            // txtSizeHeight
            // 
            this.txtSizeHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSizeHeight.Location = new System.Drawing.Point(291, 16);
            this.txtSizeHeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtSizeHeight.Name = "txtSizeHeight";
            this.txtSizeHeight.Size = new System.Drawing.Size(92, 22);
            this.txtSizeHeight.TabIndex = 3;
            this.txtSizeHeight.Text = "25";
            // 
            // lblSchema
            // 
            this.lblSchema.AutoSize = true;
            this.lblSchema.Location = new System.Drawing.Point(55, 51);
            this.lblSchema.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSchema.Name = "lblSchema";
            this.lblSchema.Size = new System.Drawing.Size(52, 17);
            this.lblSchema.TabIndex = 4;
            this.lblSchema.Text = "Схема:";
            // 
            // comboMapSchema
            // 
            this.comboMapSchema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboMapSchema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMapSchema.FormattingEnabled = true;
            this.comboMapSchema.Location = new System.Drawing.Point(119, 48);
            this.comboMapSchema.Margin = new System.Windows.Forms.Padding(4);
            this.comboMapSchema.Name = "comboMapSchema";
            this.comboMapSchema.Size = new System.Drawing.Size(264, 24);
            this.comboMapSchema.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(283, 245);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblMapName
            // 
            this.lblMapName.AutoSize = true;
            this.lblMapName.Location = new System.Drawing.Point(31, 84);
            this.lblMapName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMapName.Name = "lblMapName";
            this.lblMapName.Size = new System.Drawing.Size(76, 17);
            this.lblMapName.TabIndex = 7;
            this.lblMapName.Text = "Название:";
            // 
            // txtMapName
            // 
            this.txtMapName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMapName.Location = new System.Drawing.Point(119, 81);
            this.txtMapName.Margin = new System.Windows.Forms.Padding(4);
            this.txtMapName.Name = "txtMapName";
            this.txtMapName.Size = new System.Drawing.Size(264, 22);
            this.txtMapName.TabIndex = 8;
            this.txtMapName.Text = "Карта местности";
            // 
            // lblMapDescription
            // 
            this.lblMapDescription.AutoSize = true;
            this.lblMapDescription.Location = new System.Drawing.Point(29, 113);
            this.lblMapDescription.Name = "lblMapDescription";
            this.lblMapDescription.Size = new System.Drawing.Size(78, 17);
            this.lblMapDescription.TabIndex = 9;
            this.lblMapDescription.Text = "Описание:";
            // 
            // txtMapDescription
            // 
            this.txtMapDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMapDescription.Location = new System.Drawing.Point(119, 110);
            this.txtMapDescription.Multiline = true;
            this.txtMapDescription.Name = "txtMapDescription";
            this.txtMapDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMapDescription.Size = new System.Drawing.Size(264, 126);
            this.txtMapDescription.TabIndex = 10;
            // 
            // DialogMapNew
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 286);
            this.Controls.Add(this.txtMapDescription);
            this.Controls.Add(this.lblMapDescription);
            this.Controls.Add(this.txtMapName);
            this.Controls.Add(this.lblMapName);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.comboMapSchema);
            this.Controls.Add(this.lblSchema);
            this.Controls.Add(this.txtSizeHeight);
            this.Controls.Add(this.lblSizeHeight);
            this.Controls.Add(this.txtSizeWidth);
            this.Controls.Add(this.lblSizeWidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogMapNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новая карта";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DialogMapNew_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSizeWidth;
        private System.Windows.Forms.TextBox txtSizeWidth;
        private System.Windows.Forms.Label lblSizeHeight;
        private System.Windows.Forms.TextBox txtSizeHeight;
        private System.Windows.Forms.Label lblSchema;
        private System.Windows.Forms.ComboBox comboMapSchema;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblMapName;
        private System.Windows.Forms.TextBox txtMapName;
        private System.Windows.Forms.Label lblMapDescription;
        private System.Windows.Forms.TextBox txtMapDescription;
    }
}
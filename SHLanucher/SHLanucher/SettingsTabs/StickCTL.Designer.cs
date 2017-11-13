namespace SHLanucher.SettingsTabs
{
    partial class StickCTL
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
            this.CommandLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CommandLabel
            // 
            this.CommandLabel.AutoSize = true;
            this.CommandLabel.ForeColor = System.Drawing.Color.White;
            this.CommandLabel.Location = new System.Drawing.Point(3, 0);
            this.CommandLabel.Name = "CommandLabel";
            this.CommandLabel.Size = new System.Drawing.Size(54, 13);
            this.CommandLabel.TabIndex = 0;
            this.CommandLabel.Text = "Command";
            this.CommandLabel.Click += new System.EventHandler(this.CommandLabel_Click);
            // 
            // StickCTL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.CommandLabel);
            this.Name = "StickCTL";
            this.Size = new System.Drawing.Size(433, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CommandLabel;
    }
}

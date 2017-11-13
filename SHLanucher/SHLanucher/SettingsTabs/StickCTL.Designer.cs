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
            this.InputItem = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CommandLabel
            // 
            this.CommandLabel.AutoSize = true;
            this.CommandLabel.ForeColor = System.Drawing.Color.White;
            this.CommandLabel.Location = new System.Drawing.Point(3, 6);
            this.CommandLabel.Name = "CommandLabel";
            this.CommandLabel.Size = new System.Drawing.Size(54, 13);
            this.CommandLabel.TabIndex = 0;
            this.CommandLabel.Text = "Command";
            this.CommandLabel.Click += new System.EventHandler(this.CommandLabel_Click);
            // 
            // InputItem
            // 
            this.InputItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.InputItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.InputItem.BackColor = System.Drawing.Color.White;
            this.InputItem.FormattingEnabled = true;
            this.InputItem.Location = new System.Drawing.Point(112, 2);
            this.InputItem.Name = "InputItem";
            this.InputItem.Size = new System.Drawing.Size(174, 21);
            this.InputItem.TabIndex = 1;
            this.InputItem.SelectedIndexChanged += new System.EventHandler(this.InputItem_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(292, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StickCTL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InputItem);
            this.Controls.Add(this.CommandLabel);
            this.Name = "StickCTL";
            this.Size = new System.Drawing.Size(348, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CommandLabel;
        private System.Windows.Forms.ComboBox InputItem;
        private System.Windows.Forms.Button button1;
    }
}

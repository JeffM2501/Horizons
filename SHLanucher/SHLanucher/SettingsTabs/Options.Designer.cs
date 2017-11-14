namespace SHLanucher.SettingsTabs
{
    partial class Options
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
            this.label9 = new System.Windows.Forms.Label();
            this.SetPCode = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.WorldDropdown = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DMXController = new System.Windows.Forms.ComboBox();
            this.Resolutions = new System.Windows.Forms.ComboBox();
            this.DMXEnabled = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Fullscreen = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ConsoleUpdateSpeed = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ConsoleUpdateSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Khaki;
            this.label9.Location = new System.Drawing.Point(21, 377);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 16);
            this.label9.TabIndex = 33;
            this.label9.Text = "License";
            // 
            // SetPCode
            // 
            this.SetPCode.AutoSize = true;
            this.SetPCode.LinkColor = System.Drawing.Color.Aqua;
            this.SetPCode.Location = new System.Drawing.Point(52, 407);
            this.SetPCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SetPCode.Name = "SetPCode";
            this.SetPCode.Size = new System.Drawing.Size(113, 16);
            this.SetPCode.TabIndex = 34;
            this.SetPCode.TabStop = true;
            this.SetPCode.Text = "Set Product Code";
            this.SetPCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SetPCode_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Khaki;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "World Setting";
            // 
            // WorldDropdown
            // 
            this.WorldDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WorldDropdown.FormattingEnabled = true;
            this.WorldDropdown.Items.AddRange(new object[] {
            "Horizons"});
            this.WorldDropdown.Location = new System.Drawing.Point(20, 34);
            this.WorldDropdown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WorldDropdown.Name = "WorldDropdown";
            this.WorldDropdown.Size = new System.Drawing.Size(371, 24);
            this.WorldDropdown.TabIndex = 20;
            this.WorldDropdown.SelectedIndexChanged += new System.EventHandler(this.WorldDropdown_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Cornsilk;
            this.label8.Location = new System.Drawing.Point(67, 334);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 16);
            this.label8.TabIndex = 32;
            this.label8.Text = "Controller";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Khaki;
            this.label2.Location = new System.Drawing.Point(8, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Display Settings";
            // 
            // DMXController
            // 
            this.DMXController.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DMXController.FormattingEnabled = true;
            this.DMXController.Items.AddRange(new object[] {
            "None,",
            "Open DMX",
            "DMX Pro"});
            this.DMXController.Location = new System.Drawing.Point(161, 332);
            this.DMXController.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DMXController.Name = "DMXController";
            this.DMXController.Size = new System.Drawing.Size(230, 24);
            this.DMXController.TabIndex = 31;
            this.DMXController.SelectedIndexChanged += new System.EventHandler(this.DMXController_SelectedIndexChanged);
            // 
            // Resolutions
            // 
            this.Resolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Resolutions.FormattingEnabled = true;
            this.Resolutions.Location = new System.Drawing.Point(147, 116);
            this.Resolutions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Resolutions.Name = "Resolutions";
            this.Resolutions.Size = new System.Drawing.Size(244, 24);
            this.Resolutions.TabIndex = 22;
            this.Resolutions.SelectedIndexChanged += new System.EventHandler(this.Resolutions_SelectedIndexChanged);
            // 
            // DMXEnabled
            // 
            this.DMXEnabled.AutoSize = true;
            this.DMXEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DMXEnabled.ForeColor = System.Drawing.Color.Cornsilk;
            this.DMXEnabled.Location = new System.Drawing.Point(56, 297);
            this.DMXEnabled.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DMXEnabled.Name = "DMXEnabled";
            this.DMXEnabled.Size = new System.Drawing.Size(80, 22);
            this.DMXEnabled.TabIndex = 30;
            this.DMXEnabled.Text = "Enabled";
            this.DMXEnabled.UseVisualStyleBackColor = true;
            this.DMXEnabled.CheckedChanged += new System.EventHandler(this.DMXEnabled_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Cornsilk;
            this.label3.Location = new System.Drawing.Point(43, 117);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Resolution";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Khaki;
            this.label7.Location = new System.Drawing.Point(16, 273);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "DMX Settings";
            // 
            // Fullscreen
            // 
            this.Fullscreen.AutoSize = true;
            this.Fullscreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fullscreen.ForeColor = System.Drawing.Color.Cornsilk;
            this.Fullscreen.Location = new System.Drawing.Point(147, 149);
            this.Fullscreen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Fullscreen.Name = "Fullscreen";
            this.Fullscreen.Size = new System.Drawing.Size(101, 22);
            this.Fullscreen.TabIndex = 24;
            this.Fullscreen.Text = "Full Screen";
            this.Fullscreen.UseVisualStyleBackColor = true;
            this.Fullscreen.CheckedChanged += new System.EventHandler(this.Fullscreen_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Cornsilk;
            this.label6.Location = new System.Drawing.Point(319, 231);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "ms.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Khaki;
            this.label4.Location = new System.Drawing.Point(16, 197);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Console Network Settings";
            // 
            // ConsoleUpdateSpeed
            // 
            this.ConsoleUpdateSpeed.BackColor = System.Drawing.Color.Black;
            this.ConsoleUpdateSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleUpdateSpeed.ForeColor = System.Drawing.Color.White;
            this.ConsoleUpdateSpeed.Location = new System.Drawing.Point(239, 229);
            this.ConsoleUpdateSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConsoleUpdateSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ConsoleUpdateSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ConsoleUpdateSpeed.Name = "ConsoleUpdateSpeed";
            this.ConsoleUpdateSpeed.Size = new System.Drawing.Size(72, 22);
            this.ConsoleUpdateSpeed.TabIndex = 27;
            this.ConsoleUpdateSpeed.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.ConsoleUpdateSpeed.ValueChanged += new System.EventHandler(this.ConsoleUpdateSpeed_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Cornsilk;
            this.label5.Location = new System.Drawing.Point(52, 229);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "Packet Refresh Time";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.SetPCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WorldDropdown);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DMXController);
            this.Controls.Add(this.Resolutions);
            this.Controls.Add(this.DMXEnabled);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Fullscreen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ConsoleUpdateSpeed);
            this.Controls.Add(this.label5);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Options";
            this.Size = new System.Drawing.Size(551, 438);
            ((System.ComponentModel.ISupportInitialize)(this.ConsoleUpdateSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel SetPCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DMXController;
        private System.Windows.Forms.ComboBox Resolutions;
        private System.Windows.Forms.CheckBox DMXEnabled;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox Fullscreen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ConsoleUpdateSpeed;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox WorldDropdown;
    }
}

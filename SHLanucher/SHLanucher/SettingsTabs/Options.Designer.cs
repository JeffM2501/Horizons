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
            this.DMXControllerLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DMXController = new System.Windows.Forms.ComboBox();
            this.Resolutions = new System.Windows.Forms.ComboBox();
            this.DMXEnabled = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ConsoleUpdateSpeed = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ScreenMode = new System.Windows.Forms.ComboBox();
            this.MusicVolumeLabel = new System.Windows.Forms.Label();
            this.MusicEnabled = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.MusicVolume = new System.Windows.Forms.NumericUpDown();
            this.VolumePercent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ConsoleUpdateSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Khaki;
            this.label9.Location = new System.Drawing.Point(16, 306);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 16);
            this.label9.TabIndex = 33;
            this.label9.Text = "License";
            // 
            // SetPCode
            // 
            this.SetPCode.AutoSize = true;
            this.SetPCode.LinkColor = System.Drawing.Color.Aqua;
            this.SetPCode.Location = new System.Drawing.Point(39, 331);
            this.SetPCode.Name = "SetPCode";
            this.SetPCode.Size = new System.Drawing.Size(91, 13);
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
            this.label1.Location = new System.Drawing.Point(6, 9);
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
            this.WorldDropdown.Location = new System.Drawing.Point(15, 28);
            this.WorldDropdown.Name = "WorldDropdown";
            this.WorldDropdown.Size = new System.Drawing.Size(279, 21);
            this.WorldDropdown.TabIndex = 20;
            this.WorldDropdown.SelectedIndexChanged += new System.EventHandler(this.WorldDropdown_SelectedIndexChanged);
            // 
            // DMXControllerLabel
            // 
            this.DMXControllerLabel.AutoSize = true;
            this.DMXControllerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DMXControllerLabel.ForeColor = System.Drawing.Color.Cornsilk;
            this.DMXControllerLabel.Location = new System.Drawing.Point(50, 271);
            this.DMXControllerLabel.Name = "DMXControllerLabel";
            this.DMXControllerLabel.Size = new System.Drawing.Size(65, 16);
            this.DMXControllerLabel.TabIndex = 32;
            this.DMXControllerLabel.Text = "Controller";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Khaki;
            this.label2.Location = new System.Drawing.Point(6, 66);
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
            this.DMXController.Location = new System.Drawing.Point(121, 270);
            this.DMXController.Name = "DMXController";
            this.DMXController.Size = new System.Drawing.Size(174, 21);
            this.DMXController.TabIndex = 31;
            this.DMXController.SelectedIndexChanged += new System.EventHandler(this.DMXController_SelectedIndexChanged);
            // 
            // Resolutions
            // 
            this.Resolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Resolutions.FormattingEnabled = true;
            this.Resolutions.Location = new System.Drawing.Point(111, 119);
            this.Resolutions.Name = "Resolutions";
            this.Resolutions.Size = new System.Drawing.Size(184, 21);
            this.Resolutions.TabIndex = 22;
            this.Resolutions.SelectedIndexChanged += new System.EventHandler(this.Resolutions_SelectedIndexChanged);
            // 
            // DMXEnabled
            // 
            this.DMXEnabled.AutoSize = true;
            this.DMXEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DMXEnabled.ForeColor = System.Drawing.Color.Cornsilk;
            this.DMXEnabled.Location = new System.Drawing.Point(42, 241);
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
            this.label3.Location = new System.Drawing.Point(33, 120);
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
            this.label7.Location = new System.Drawing.Point(12, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "DMX Settings";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Cornsilk;
            this.label6.Location = new System.Drawing.Point(239, 188);
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
            this.label4.Location = new System.Drawing.Point(12, 160);
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
            this.ConsoleUpdateSpeed.Location = new System.Drawing.Point(179, 186);
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
            this.ConsoleUpdateSpeed.Size = new System.Drawing.Size(54, 22);
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
            this.label5.Location = new System.Drawing.Point(39, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "Packet Refresh Time";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Cornsilk;
            this.label10.Location = new System.Drawing.Point(32, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 16);
            this.label10.TabIndex = 35;
            this.label10.Text = "Mode";
            // 
            // ScreenMode
            // 
            this.ScreenMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScreenMode.FormattingEnabled = true;
            this.ScreenMode.Items.AddRange(new object[] {
            "Windowed",
            "Fullscreen",
            "Fullscreen Window"});
            this.ScreenMode.Location = new System.Drawing.Point(110, 92);
            this.ScreenMode.Name = "ScreenMode";
            this.ScreenMode.Size = new System.Drawing.Size(184, 21);
            this.ScreenMode.TabIndex = 36;
            // 
            // MusicVolumeLabel
            // 
            this.MusicVolumeLabel.AutoSize = true;
            this.MusicVolumeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MusicVolumeLabel.ForeColor = System.Drawing.Color.Cornsilk;
            this.MusicVolumeLabel.Location = new System.Drawing.Point(344, 58);
            this.MusicVolumeLabel.Name = "MusicVolumeLabel";
            this.MusicVolumeLabel.Size = new System.Drawing.Size(54, 16);
            this.MusicVolumeLabel.TabIndex = 40;
            this.MusicVolumeLabel.Text = "Volume";
            // 
            // MusicEnabled
            // 
            this.MusicEnabled.AutoSize = true;
            this.MusicEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MusicEnabled.ForeColor = System.Drawing.Color.Cornsilk;
            this.MusicEnabled.Location = new System.Drawing.Point(336, 28);
            this.MusicEnabled.Name = "MusicEnabled";
            this.MusicEnabled.Size = new System.Drawing.Size(80, 22);
            this.MusicEnabled.TabIndex = 38;
            this.MusicEnabled.Text = "Enabled";
            this.MusicEnabled.UseVisualStyleBackColor = true;
            this.MusicEnabled.CheckedChanged += new System.EventHandler(this.MusicEnabled_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Khaki;
            this.label12.Location = new System.Drawing.Point(306, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 16);
            this.label12.TabIndex = 37;
            this.label12.Text = "Music";
            // 
            // MusicVolume
            // 
            this.MusicVolume.BackColor = System.Drawing.Color.Black;
            this.MusicVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MusicVolume.ForeColor = System.Drawing.Color.White;
            this.MusicVolume.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.MusicVolume.Location = new System.Drawing.Point(404, 56);
            this.MusicVolume.Name = "MusicVolume";
            this.MusicVolume.Size = new System.Drawing.Size(54, 22);
            this.MusicVolume.TabIndex = 41;
            this.MusicVolume.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // VolumePercent
            // 
            this.VolumePercent.AutoSize = true;
            this.VolumePercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolumePercent.ForeColor = System.Drawing.Color.Cornsilk;
            this.VolumePercent.Location = new System.Drawing.Point(464, 58);
            this.VolumePercent.Name = "VolumePercent";
            this.VolumePercent.Size = new System.Drawing.Size(20, 16);
            this.VolumePercent.TabIndex = 42;
            this.VolumePercent.Text = "%";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.VolumePercent);
            this.Controls.Add(this.MusicVolume);
            this.Controls.Add(this.MusicVolumeLabel);
            this.Controls.Add(this.MusicEnabled);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ScreenMode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.SetPCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WorldDropdown);
            this.Controls.Add(this.DMXControllerLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DMXController);
            this.Controls.Add(this.Resolutions);
            this.Controls.Add(this.DMXEnabled);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ConsoleUpdateSpeed);
            this.Controls.Add(this.label5);
            this.Name = "Options";
            this.Size = new System.Drawing.Size(486, 356);
            ((System.ComponentModel.ISupportInitialize)(this.ConsoleUpdateSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel SetPCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DMXControllerLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DMXController;
        private System.Windows.Forms.ComboBox Resolutions;
        private System.Windows.Forms.CheckBox DMXEnabled;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ConsoleUpdateSpeed;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox WorldDropdown;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox ScreenMode;
        private System.Windows.Forms.Label MusicVolumeLabel;
        private System.Windows.Forms.CheckBox MusicEnabled;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown MusicVolume;
        private System.Windows.Forms.Label VolumePercent;
    }
}

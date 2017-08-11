namespace SHLanucher
{
    partial class Launcher
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
            this.WebContext = new System.Windows.Forms.WebBrowser();
            this.LogText = new System.Windows.Forms.TextBox();
            this.LaunchButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.NewsButton = new System.Windows.Forms.Button();
            this.LogButton = new System.Windows.Forms.Button();
            this.CreditsButton = new System.Windows.Forms.Button();
            this.ProgressPannel = new System.Windows.Forms.Panel();
            this.DownloadLabel4 = new System.Windows.Forms.Label();
            this.progressBar4 = new System.Windows.Forms.ProgressBar();
            this.DownloadLabel3 = new System.Windows.Forms.Label();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.DownloadLabel2 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.DownloadLabel1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ProgressPannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WebContext
            // 
            this.WebContext.AllowWebBrowserDrop = false;
            this.WebContext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebContext.Location = new System.Drawing.Point(169, 45);
            this.WebContext.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebContext.Name = "WebContext";
            this.WebContext.Size = new System.Drawing.Size(618, 550);
            this.WebContext.TabIndex = 0;
            this.WebContext.Visible = false;
            // 
            // LogText
            // 
            this.LogText.BackColor = System.Drawing.Color.Black;
            this.LogText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogText.ForeColor = System.Drawing.Color.ForestGreen;
            this.LogText.Location = new System.Drawing.Point(169, 45);
            this.LogText.Multiline = true;
            this.LogText.Name = "LogText";
            this.LogText.ReadOnly = true;
            this.LogText.Size = new System.Drawing.Size(618, 424);
            this.LogText.TabIndex = 1;
            // 
            // LaunchButton
            // 
            this.LaunchButton.BackColor = System.Drawing.Color.ForestGreen;
            this.LaunchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LaunchButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LaunchButton.ForeColor = System.Drawing.Color.White;
            this.LaunchButton.Location = new System.Drawing.Point(12, 565);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(140, 30);
            this.LaunchButton.TabIndex = 2;
            this.LaunchButton.Text = "LAUNCH";
            this.LaunchButton.UseVisualStyleBackColor = false;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.DarkCyan;
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.ForeColor = System.Drawing.Color.White;
            this.UpdateButton.Location = new System.Drawing.Point(12, 529);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(140, 30);
            this.UpdateButton.TabIndex = 3;
            this.UpdateButton.Text = "UPDATE";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(750, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "v1.2.1";
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButton.ForeColor = System.Drawing.Color.White;
            this.SettingsButton.Location = new System.Drawing.Point(12, 493);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(140, 30);
            this.SettingsButton.TabIndex = 5;
            this.SettingsButton.Text = "SETTINGS";
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // NewsButton
            // 
            this.NewsButton.BackColor = System.Drawing.Color.Black;
            this.NewsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewsButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewsButton.ForeColor = System.Drawing.Color.White;
            this.NewsButton.Location = new System.Drawing.Point(19, 45);
            this.NewsButton.Name = "NewsButton";
            this.NewsButton.Size = new System.Drawing.Size(133, 30);
            this.NewsButton.TabIndex = 6;
            this.NewsButton.Text = "TRANSMISSIONS";
            this.NewsButton.UseVisualStyleBackColor = false;
            this.NewsButton.Click += new System.EventHandler(this.NewsButton_Click);
            // 
            // LogButton
            // 
            this.LogButton.BackColor = System.Drawing.Color.Transparent;
            this.LogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogButton.ForeColor = System.Drawing.Color.White;
            this.LogButton.Location = new System.Drawing.Point(19, 76);
            this.LogButton.Name = "LogButton";
            this.LogButton.Size = new System.Drawing.Size(133, 30);
            this.LogButton.TabIndex = 7;
            this.LogButton.Text = "LOG";
            this.LogButton.UseVisualStyleBackColor = false;
            this.LogButton.Click += new System.EventHandler(this.LogButton_Click);
            // 
            // CreditsButton
            // 
            this.CreditsButton.BackColor = System.Drawing.Color.Transparent;
            this.CreditsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditsButton.ForeColor = System.Drawing.Color.White;
            this.CreditsButton.Location = new System.Drawing.Point(19, 107);
            this.CreditsButton.Name = "CreditsButton";
            this.CreditsButton.Size = new System.Drawing.Size(133, 30);
            this.CreditsButton.TabIndex = 8;
            this.CreditsButton.Text = "CREDITS";
            this.CreditsButton.UseVisualStyleBackColor = false;
            this.CreditsButton.Click += new System.EventHandler(this.CreditsButton_Click);
            // 
            // ProgressPannel
            // 
            this.ProgressPannel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressPannel.BackColor = System.Drawing.Color.Black;
            this.ProgressPannel.Controls.Add(this.DownloadLabel4);
            this.ProgressPannel.Controls.Add(this.progressBar4);
            this.ProgressPannel.Controls.Add(this.DownloadLabel3);
            this.ProgressPannel.Controls.Add(this.progressBar3);
            this.ProgressPannel.Controls.Add(this.DownloadLabel2);
            this.ProgressPannel.Controls.Add(this.progressBar2);
            this.ProgressPannel.Controls.Add(this.DownloadLabel1);
            this.ProgressPannel.Controls.Add(this.progressBar1);
            this.ProgressPannel.Location = new System.Drawing.Point(169, 463);
            this.ProgressPannel.Name = "ProgressPannel";
            this.ProgressPannel.Size = new System.Drawing.Size(618, 132);
            this.ProgressPannel.TabIndex = 9;
            // 
            // DownloadLabel4
            // 
            this.DownloadLabel4.AutoSize = true;
            this.DownloadLabel4.BackColor = System.Drawing.Color.Transparent;
            this.DownloadLabel4.ForeColor = System.Drawing.Color.White;
            this.DownloadLabel4.Location = new System.Drawing.Point(3, 96);
            this.DownloadLabel4.Name = "DownloadLabel4";
            this.DownloadLabel4.Size = new System.Drawing.Size(61, 13);
            this.DownloadLabel4.TabIndex = 8;
            this.DownloadLabel4.Text = "Download4";
            // 
            // progressBar4
            // 
            this.progressBar4.Location = new System.Drawing.Point(3, 112);
            this.progressBar4.Name = "progressBar4";
            this.progressBar4.Size = new System.Drawing.Size(609, 10);
            this.progressBar4.TabIndex = 7;
            // 
            // DownloadLabel3
            // 
            this.DownloadLabel3.AutoSize = true;
            this.DownloadLabel3.BackColor = System.Drawing.Color.Transparent;
            this.DownloadLabel3.ForeColor = System.Drawing.Color.White;
            this.DownloadLabel3.Location = new System.Drawing.Point(3, 67);
            this.DownloadLabel3.Name = "DownloadLabel3";
            this.DownloadLabel3.Size = new System.Drawing.Size(61, 13);
            this.DownloadLabel3.TabIndex = 6;
            this.DownloadLabel3.Text = "Download3";
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(3, 83);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(609, 10);
            this.progressBar3.TabIndex = 5;
            // 
            // DownloadLabel2
            // 
            this.DownloadLabel2.AutoSize = true;
            this.DownloadLabel2.BackColor = System.Drawing.Color.Transparent;
            this.DownloadLabel2.ForeColor = System.Drawing.Color.White;
            this.DownloadLabel2.Location = new System.Drawing.Point(3, 38);
            this.DownloadLabel2.Name = "DownloadLabel2";
            this.DownloadLabel2.Size = new System.Drawing.Size(61, 13);
            this.DownloadLabel2.TabIndex = 4;
            this.DownloadLabel2.Text = "Download2";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(3, 54);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(609, 10);
            this.progressBar2.TabIndex = 3;
            // 
            // DownloadLabel1
            // 
            this.DownloadLabel1.AutoSize = true;
            this.DownloadLabel1.BackColor = System.Drawing.Color.Transparent;
            this.DownloadLabel1.ForeColor = System.Drawing.Color.White;
            this.DownloadLabel1.Location = new System.Drawing.Point(3, 9);
            this.DownloadLabel1.Name = "DownloadLabel1";
            this.DownloadLabel1.Size = new System.Drawing.Size(61, 13);
            this.DownloadLabel1.TabIndex = 2;
            this.DownloadLabel1.Text = "Download1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 25);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(609, 10);
            this.progressBar1.TabIndex = 1;
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SHLanucher.Properties.Resources.LanucherBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(799, 607);
            this.Controls.Add(this.ProgressPannel);
            this.Controls.Add(this.CreditsButton);
            this.Controls.Add(this.LogButton);
            this.Controls.Add(this.NewsButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.LogText);
            this.Controls.Add(this.WebContext);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Launcher";
            this.ShowIcon = false;
            this.Text = "Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Launcher_FormClosing);
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.ProgressPannel.ResumeLayout(false);
            this.ProgressPannel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser WebContext;
        private System.Windows.Forms.TextBox LogText;
        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button NewsButton;
        private System.Windows.Forms.Button LogButton;
        private System.Windows.Forms.Button CreditsButton;
        private System.Windows.Forms.Panel ProgressPannel;
        private System.Windows.Forms.Label DownloadLabel4;
        private System.Windows.Forms.ProgressBar progressBar4;
        private System.Windows.Forms.Label DownloadLabel3;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.Label DownloadLabel2;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label DownloadLabel1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}


namespace SHLanucher
{
    partial class SettingsDialog
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
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Options = new System.Windows.Forms.Button();
            this.Controller = new System.Windows.Forms.Button();
            this.ControlerTab = new SHLanucher.SettingsTabs.ControllerSetup();
            this.OptionsCTL = new SHLanucher.SettingsTabs.Options();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK.BackColor = System.Drawing.Color.ForestGreen;
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.ForeColor = System.Drawing.Color.White;
            this.OK.Location = new System.Drawing.Point(666, 537);
            this.OK.Margin = new System.Windows.Forms.Padding(4);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(119, 44);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = false;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.BackColor = System.Drawing.Color.Firebrick;
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.ForeColor = System.Drawing.Color.White;
            this.Cancel.Location = new System.Drawing.Point(548, 537);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(109, 44);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = false;
            // 
            // Options
            // 
            this.Options.BackColor = System.Drawing.Color.Gray;
            this.Options.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Options.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Options.ForeColor = System.Drawing.Color.White;
            this.Options.Location = new System.Drawing.Point(16, 15);
            this.Options.Margin = new System.Windows.Forms.Padding(4);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(109, 44);
            this.Options.TabIndex = 20;
            this.Options.Text = "Options";
            this.Options.UseVisualStyleBackColor = false;
            this.Options.Click += new System.EventHandler(this.Options_Click);
            // 
            // Controller
            // 
            this.Controller.BackColor = System.Drawing.Color.Gray;
            this.Controller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Controller.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Controller.ForeColor = System.Drawing.Color.White;
            this.Controller.Location = new System.Drawing.Point(133, 15);
            this.Controller.Margin = new System.Windows.Forms.Padding(4);
            this.Controller.Name = "Controller";
            this.Controller.Size = new System.Drawing.Size(129, 44);
            this.Controller.TabIndex = 21;
            this.Controller.Text = "Controller";
            this.Controller.UseVisualStyleBackColor = false;
            this.Controller.Click += new System.EventHandler(this.Controller_Click);
            // 
            // ControlerTab
            // 
            this.ControlerTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlerTab.BackColor = System.Drawing.Color.Black;
            this.ControlerTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ControlerTab.Location = new System.Drawing.Point(16, 66);
            this.ControlerTab.Margin = new System.Windows.Forms.Padding(5);
            this.ControlerTab.Name = "ControlerTab";
            this.ControlerTab.Size = new System.Drawing.Size(768, 451);
            this.ControlerTab.TabIndex = 23;
            this.ControlerTab.Load += new System.EventHandler(this.ControlerTab_Load);
            // 
            // OptionsCTL
            // 
            this.OptionsCTL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsCTL.BackColor = System.Drawing.Color.Black;
            this.OptionsCTL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OptionsCTL.Location = new System.Drawing.Point(16, 66);
            this.OptionsCTL.Margin = new System.Windows.Forms.Padding(5);
            this.OptionsCTL.Name = "OptionsCTL";
            this.OptionsCTL.Size = new System.Drawing.Size(768, 451);
            this.OptionsCTL.TabIndex = 22;
            // 
            // SettingsDialog
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(800, 596);
            this.Controls.Add(this.ControlerTab);
            this.Controls.Add(this.OptionsCTL);
            this.Controls.Add(this.Controller);
            this.Controls.Add(this.Options);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsDialog_FormClosing);
            this.Load += new System.EventHandler(this.SettingsDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Options;
        private System.Windows.Forms.Button Controller;
        private SettingsTabs.Options OptionsCTL;
        private SettingsTabs.ControllerSetup ControlerTab;
    }
}
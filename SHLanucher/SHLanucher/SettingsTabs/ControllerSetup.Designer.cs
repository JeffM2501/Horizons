namespace SHLanucher.SettingsTabs
{
    partial class ControllerSetup
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
            this.CommandList = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // CommandList
            // 
            this.CommandList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandList.AutoScroll = true;
            this.CommandList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.CommandList.Location = new System.Drawing.Point(0, 0);
            this.CommandList.Name = "CommandList";
            this.CommandList.Size = new System.Drawing.Size(575, 327);
            this.CommandList.TabIndex = 0;
            this.CommandList.WrapContents = false;
            // 
            // ControllerSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.CommandList);
            this.Name = "ControllerSetup";
            this.Size = new System.Drawing.Size(578, 330);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel CommandList;
    }
}

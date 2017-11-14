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
            this.StickState = new System.Windows.Forms.TextBox();
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
            this.CommandList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CommandList.Name = "CommandList";
            this.CommandList.Size = new System.Drawing.Size(559, 402);
            this.CommandList.TabIndex = 0;
            this.CommandList.WrapContents = false;
            // 
            // StickState
            // 
            this.StickState.BackColor = System.Drawing.Color.Black;
            this.StickState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StickState.ForeColor = System.Drawing.Color.White;
            this.StickState.Location = new System.Drawing.Point(566, 4);
            this.StickState.Multiline = true;
            this.StickState.Name = "StickState";
            this.StickState.ReadOnly = true;
            this.StickState.Size = new System.Drawing.Size(202, 399);
            this.StickState.TabIndex = 1;
            this.StickState.Visible = false;
            // 
            // ControllerSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.StickState);
            this.Controls.Add(this.CommandList);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ControllerSetup";
            this.Size = new System.Drawing.Size(771, 406);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel CommandList;
        private System.Windows.Forms.TextBox StickState;
    }
}

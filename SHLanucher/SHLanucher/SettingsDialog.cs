﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHLanucher
{
    public partial class SettingsDialog : Form
    {
        public Config Settings = new Config();

        public DirectoryInfo GameDir = null;

        public bool NeedLicenseValidate = false;

        protected Color ActiveColor = Color.White;
        protected Color InactiveColor = Color.Black;

        public SettingsDialog()
        {
            InitializeComponent();
        }

        private void SettingsDialog_Load(object sender, EventArgs e)
        {
            ActiveColor = Options.BackColor;
            Controller.BackColor = InactiveColor;

            OptionsCTL.Settings = Settings;
            OptionsCTL.GameDir = GameDir;
            OptionsCTL.NeedLicenseValidate = NeedLicenseValidate;
            OptionsCTL.Setup();


            ControlerTab.Settings = Settings;
            ControlerTab.Setup();

            ControlerTab.Visible = false;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (!OptionsCTL.Confirm() || !ControlerTab.Confirm())
                DialogResult = DialogResult.Cancel;
        }

        private void Options_Click(object sender, EventArgs e)
        {
            Options.BackColor = ActiveColor;
            Controller.BackColor = InactiveColor;

            OptionsCTL.Visible = true;
            ControlerTab.Visible = false;
        }

        private void Controller_Click(object sender, EventArgs e)
        {
            Controller.BackColor = ActiveColor;
            Options.BackColor = InactiveColor;

            OptionsCTL.Visible = false;
            ControlerTab.Visible = true;
        }

        private void ControlerTab_Load(object sender, EventArgs e)
        {

        }

        private void SettingsDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            ControlerTab.Shutdown();
        }
    }
}

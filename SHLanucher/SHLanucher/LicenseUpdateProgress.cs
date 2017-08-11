using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHLanucher
{
    public partial class LicenseUpdateProgress : Form
    {
        public LicenseUpdateProgress()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 1)
                progressBar1.Value = 0;
            else
                progressBar1.Value += 1;
        }

        private void LicenseUpdateProgress_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void LicenseUpdateProgress_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }
    }
}

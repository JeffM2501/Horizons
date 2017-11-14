using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHLanucher.SettingsTabs
{
    public partial class StickGetter : Form
    {
        public bool IsAxis = false;
        public string Command = string.Empty;
        public string ControlItem = string.Empty;

        Timer Ticker = new Timer();


        public StickGetter()
        {
            InitializeComponent();

            Ticker.Interval = 10;
            Ticker.Tick += Ticker_Tick;
        }

        private void End(string value)
        {
            if (!Ticker.Enabled)
                return;

            Ticker.Stop();

            foreach (Joystick stick in Joystick.GetDevices())
                stick.EndCapture();
     
            ControlItem = value;

            DialogResult = DialogResult.OK;
            this.BeginInvoke(new Action(() => { Close(); }));
        }

        private void Ticker_Tick(object sender, EventArgs e)
        {
            foreach( Joystick stick in Joystick.GetDevices())
            {
                List<string> changed = IsAxis ? stick.GetMovedAxes() : stick.GetPushedButtons();

                if (changed.Count == 1)
                    End(changed[0]);
            }
        }

        private void StickGetter_Load(object sender, EventArgs e)
        {
            foreach (Joystick stick in Joystick.GetDevices())
                stick.StartCapture();

            CommandLabel.Text += Command;
            Ticker.Start();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Ticker.Stop();

            foreach (Joystick stick in Joystick.GetDevices())
                stick.EndCapture();
        }
    }
}

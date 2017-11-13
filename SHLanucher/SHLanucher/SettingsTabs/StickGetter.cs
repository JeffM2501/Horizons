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

            Ticker.Interval = 100;
            Ticker.Tick += Ticker_Tick;
        }

        private void End(string value)
        {
            Ticker.Stop();

            ControlItem = value;

            DialogResult = DialogResult.OK;
            this.BeginInvoke(new Action(() => { Close(); }));
        }

        private void Ticker_Tick(object sender, EventArgs e)
        {
            WinMMAPI.JOYINFOEX info = new WinMMAPI.JOYINFOEX();
            info.flags = WinMMAPI.JoyPosFlags.ReturnAll;

            var ret = WinMMAPI.joyGetPosEx(0, info);

            if (ret != WinMMAPI.ResultCode.NoError)
                return;

            if (IsAxis)
            {
                if (info.xPos != 0)
                    End("X");
                else if (info.yPos != 0)
                    End("Y");
                else if (info.zPos != 0)
                    End("Z");
                else if (info.rPos != 0)
                    End("R");
            }
            else
            {
                for (int i = 0; i < info.buttonNumber; i++)
                {
                    int mask = (int)Math.Pow(2, i);
                    if ((info.buttons & mask) != 0)
                        End("Button" + (i+1).ToString());
                }
            }
        }

        [Flags]
        public enum Buttons
        {
            Button1 = 1,
            Button2 = 2,
            Button3 = 4,
            Button4 = 8,
            Button5 = 16,
            Button6 = 32,
            Button7 = 64,
            Button8 = 128,
            Button9 = 256,
            Button10 = 512,
            Button11 = 1024,
            Button12 = 2048,
            Button13 = 4096,
            Button14 = 8192,
            Button15 = 16384,
            Button16 = 32768
        }

        private void StickGetter_Load(object sender, EventArgs e)
        {
            CommandLabel.Text += Command;
            Ticker.Start();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Ticker.Stop();
        }
    }
}

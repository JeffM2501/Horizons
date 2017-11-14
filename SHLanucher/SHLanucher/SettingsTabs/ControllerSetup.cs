using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHLanucher.SettingsTabs
{
    public partial class ControllerSetup : UserControl
    {
        public Config Settings = new Config();

      //  Timer StickUpdater = new Timer();

        public ControllerSetup()
        {
            InitializeComponent();

        //    StickUpdater.Interval = 10;

       //     StickUpdater.Tick += StickUpdater_Tick;
        }

        private void StickUpdater_Tick(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach(var stick in Joystick.GetDevices())
            {
                sb.AppendLine("Stick " + stick.Name);

                List<double> axes = stick.GetAxisStates();

                for(int i = 0; i < stick.Axes.Count; i++)
                {
                    sb.AppendLine( stick.Axes[i] + " axis = " + axes[i].ToString());
                }

                List<bool> button = stick.GetButtonStates();

                for (int i = 0; i < stick.Buttons.Count; i++)
                {
                    sb.AppendLine(stick.Buttons[i] + " = " + button[i].ToString());
                }
            }

            sb.AppendLine(DateTime.Now.ToLongTimeString());

            StickState.BeginInvoke(new Action(() => StickState.Text = sb.ToString()));
        }

        public void Setup()
        {
         //   StickUpdater.Start();

            foreach (var axisCmd in Settings.StickMap)
            {
                if (axisCmd.Key != string.Empty)
                    CommandList.Controls.Add(new StickCTL(axisCmd.Value, true, axisCmd.Key));
            }

            foreach (var btnCmd in Settings.ButtonMap)
            {
                if (btnCmd.Key != string.Empty)
                    CommandList.Controls.Add(new StickCTL(btnCmd.Key, false, btnCmd.Value));
            }
        }

        public void Shutdown()
        {
         //   StickUpdater.Stop();
        }

        public bool Confirm()
        {
            Shutdown();

            Settings.ButtonMap.Clear();
            Settings.StickMap.Clear();
            foreach (var item in CommandList.Controls)
            {
                StickCTL ctl = item as StickCTL;
                if (ctl == null)
                    continue;

                Config.InputMapItem cfg = new Config.InputMapItem();

                if (ctl.IsAxis)
                {
                    cfg.Key = ctl.Value;
                    cfg.Value = ctl.Command;

                }
                else
                {
                    cfg.Value = ctl.Value;
                    cfg.Key = ctl.Command;
                }
                Settings.StickMap.Add(cfg);
            }
     
            return true;
        }
    }
}

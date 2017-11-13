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

        public ControllerSetup()
        {
            InitializeComponent();
        }

        public void Setup()
        {
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

        public bool Confirm()
        {
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

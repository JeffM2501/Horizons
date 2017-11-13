using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SHLanucher.SettingsTabs
{
    public partial class Options : UserControl
    {
        public Config Settings = new Config();

        public DirectoryInfo GameDir = null;

        public bool NeedLicenseValidate = false;

        public Options()
        {
            InitializeComponent();
        }

        public class ResolutionItem
        {
            public int X = 0;
            public int Y = 0;

            public override string ToString()
            {
                return X.ToString() + " x " + Y.ToString();
            }

            public ResolutionItem(Rectangle bounds)
            {
                X = bounds.Width;
                Y = bounds.Height;
            }

            public ResolutionItem(int[] bounds)
            {
                X = bounds[0];
                Y = bounds[1];
            }

            public ResolutionItem(int w, int h)
            {
                X = w;
                Y = h;
            }
        }

        private bool ResolutionExists(int x, int y)
        {
            foreach (ResolutionItem item in Resolutions.Items)
            {
                if (item.X == x && item.Y == y)
                    return true;
            }

            return false;

        }

        private void AddResolution(ResolutionItem item)
        {
            if (!ResolutionExists(item.X, item.Y))
                Resolutions.Items.Add(item);
        }

        private void SelectResolution(int x, int y)
        {
           foreach (ResolutionItem item in Resolutions.Items)
           {
               if (item.X == x && item.Y == y)
               {
                   Resolutions.SelectedItem = item;
                   return;
               }
           }
        }

        public void Setup()
        {
            AddResolution(new ResolutionItem(Screen.PrimaryScreen.Bounds));
            AddResolution(new ResolutionItem(Settings.Video.Size));

            AddResolution(new ResolutionItem(1920, 1080));
            AddResolution(new ResolutionItem(1280, 720));
            AddResolution(new ResolutionItem(1024, 768));
            AddResolution(new ResolutionItem(800, 600));

            SelectResolution(Settings.Video.Size[0], Settings.Video.Size[1]);

            Fullscreen.Checked = Settings.Video.Fullscreen;
            
            DirectoryInfo worldsDir = new DirectoryInfo(Path.Combine(GameDir.FullName, "worlds"));
            
            int worldIndex = 0;
            foreach (var w in worldsDir.GetDirectories())
            {
                if (w.Name.ToLowerInvariant() != "horizons")
                {
                    WorldDropdown.Items.Add(w.Name);
                    if (w.Name.ToLowerInvariant() == Settings.World.ToLowerInvariant())
                        worldIndex = WorldDropdown.Items.Count - 1;
                }
            }
            
            ConsoleUpdateSpeed.Value = Settings.Websockets.Heartbeat;
            
            WorldDropdown.SelectedIndex = worldIndex;
            
            DMXEnabled.Checked = Settings.DMX.Enabled;
            
            if (Settings.DMX.Controller == "Open DMX")
                DMXController.SelectedIndex = 1;
            else if (Settings.DMX.Controller == "DMX Pro")
                DMXController.SelectedIndex = 2;
            else
                DMXController.SelectedIndex = 0;
        }

        public bool Confirm()
        {
            Settings.Video.Fullscreen = Fullscreen.Checked;
            
            ResolutionItem res = Resolutions.SelectedItem as ResolutionItem;
            if (res != null)
            {
                Settings.Video.Size[0] = res.X;
                Settings.Video.Size[1] = res.Y;
            }
            
            Settings.World = WorldDropdown.SelectedItem.ToString();
            
            Settings.DMX.Enabled = DMXEnabled.Checked;
            
            switch (DMXController.SelectedIndex)
            {
                case 0:
                    Settings.DMX.Controller = "None";
                    break;
            
                case 1:
                    Settings.DMX.Controller = "Open DMX";
                    break;
            
                case 2:
                    Settings.DMX.Controller = "DMX Pro";
                    break;
            }

            Settings.Websockets.Heartbeat = (int)ConsoleUpdateSpeed.Value;

            return true;
        }

        private void WorldDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Resolutions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ConsoleUpdateSpeed_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Fullscreen_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DMXEnabled_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DMXController_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SetPCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseEntryDialog licenseDialog = new LicenseEntryDialog();

            licenseDialog.LicenseCode = Launcher.GetProductCode();

            if (licenseDialog.ShowDialog(this) != DialogResult.OK)
                return;

            else
            {
                FileInfo licenseFile = new FileInfo(Launcher.GetLicenseFilePath());
                if (!licenseFile.Directory.Exists)
                    licenseFile.Directory.Create();

                if (!licenseFile.Exists)
                    HorizonLicenses.WriteLicenseFile(licenseFile, HorizonLicenses.CreateLicenseString(licenseDialog.LicenseCode, "Alpha", licenseFile.FullName));

                NeedLicenseValidate = true;
            }
        }
    }
}

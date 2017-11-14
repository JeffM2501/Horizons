using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NAudio;
using NAudio.Wave;

namespace SHLanucher
{
    internal partial class Launcher : Form
    {
        List<Tuple<Label, ProgressBar>> ProgressBars = new List<Tuple<Label, ProgressBar>>();

        private static DirectoryInfo GameDir = null;

        protected UpdateManager UpMan = null;

        private WaveOutEvent AudioOutputDevice;
        private WaveStream BackgroundAudioFile;

        public Launcher()
        {
            GameDir = new DirectoryInfo(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Game"));
            UpMan = new UpdateManager(GameDir);

            InitializeComponent();

            // don't group into user controls, gets too slow and BG colors get odd on the panel
            ProgressBars.Add(new Tuple<Label, ProgressBar>(DownloadLabel1, progressBar1));
            ProgressBars.Add(new Tuple<Label, ProgressBar>(DownloadLabel2, progressBar2));
            ProgressBars.Add(new Tuple<Label, ProgressBar>(DownloadLabel3, progressBar3));
            ProgressBars.Add(new Tuple<Label, ProgressBar>(DownloadLabel4, progressBar4));

            LaunchButton.Enabled = false;

            UpMan.UpdateStarted += UpMan_UpdateStarted;
            UpMan.UpdateFailed += UpMan_UpdateFailed;
            UpMan.UpdateComplete += UpMan_UpdateComplete;
            UpMan.UpdateCanceled += UpMan_UpdateCanceled;
            UpMan.UpdateServerConnectStarted += UpMan_UpdateServerConnectStarted;
            UpMan.UpdateServerConnectCompleted += UpMan_UpdateServerConnectCompleted;
            UpMan.UpdateServerConnectFailed += UpMan_UpdateServerConnectFailed;

            UpMan.FileSyncStarted += UpMan_FileSyncStarted;
            UpMan.FileSyncEnded += UpMan_FileSyncEnded;
            UpMan.FileSyncNotNeeded += UpMan_FileSyncNotNeeded;
            UpMan.FileDownloadStarted += UpMan_FileDownloadStarted;
            UpMan.FileDownloadCompleted += UpMan_FileDownloadCompleted;
            UpMan.FileDownloadProgress += UpMan_FileDownloadProgress;
            UpMan.FileDownloadError += UpMan_FileDownloadError;
        }

        private void UpMan_FileDownloadError(object sender, UpdateManager.FileProgressEventArgs e)
        {
            PushLog("Downloading file " + e.DownloadFileName + " failed");
        }

        private void UpMan_FileDownloadProgress(object sender, UpdateManager.FileProgressEventArgs e)
        {
            if (e.DownloadIndex - 1 < ProgressBars.Count)
            {
                var bar = ProgressBars[e.DownloadIndex - 1];
                bar.Item2.BeginInvoke(new Action(() => bar.Item2.Value = (int)(e.Progress * 100)));
            }
        }

        private void UpMan_FileDownloadCompleted(object sender, UpdateManager.FileProgressEventArgs e)
        {
           if (e.DownloadFileName == "config.xml")
                SettingsButton.BeginInvoke(new Action(() => SettingsButton.Enabled = true));
        }

        private void UpMan_FileDownloadStarted(object sender, UpdateManager.FileProgressEventArgs e)
        {
            PushLog("Downloading file " + e.DownloadFileName);

            if (e.DownloadIndex-1 < ProgressBars.Count)
            {
                var bar = ProgressBars[e.DownloadIndex-1];

                bar.Item1.BeginInvoke(new Action(() => bar.Item1.Text = e.DownloadFileName));

                bar.Item2.BeginInvoke(new Action(() => bar.Item2.Visible = true));
                bar.Item2.BeginInvoke(new Action(() => bar.Item2.Value = (int)(e.Progress * 100)));
            }
        }

        private void UpMan_FileSyncNotNeeded(object sender, EventArgs e)
        {
            PushLog("All files up to date");
        }

        private void UpMan_FileSyncEnded(object sender, EventArgs e)
        {
            PushLog("File Update Complete");
            DisableProgressBars();
        }

        private void UpMan_FileSyncStarted(object sender, EventArgs e)
        {
            PushLog("Updating Files...");
        }

        private void UpMan_UpdateServerConnectFailed(object sender, EventArgs e)
        {
            PushLog("Failed To Contact Update Server; " + UpMan.GetLastError());
        }

        private void UpMan_UpdateServerConnectCompleted(object sender, EventArgs e)
        {
            PushLog("Processing Update Server Response");
        }

        private void UpMan_UpdateServerConnectStarted(object sender, EventArgs e)
        {
            PushLog("Contacting Update Server");
        }

        private DateTime UpdateStartTime = DateTime.MinValue;

        private void UpMan_UpdateCanceled(object sender, EventArgs e)
        {
            PushLog("Update Canceled");
            UpdateButton.BeginInvoke(new Action(() => UpdateButton.Enabled = true));
            LaunchButton.BeginInvoke(new Action(() => LaunchButton.Enabled = false));
        }

        private void UpMan_UpdateComplete(object sender, EventArgs e)
        {
            PushLog("Update Completed");
            PushLog("Elapsed time :" + string.Format("{0:hh\\:mm\\:ss}",(DateTime.Now - UpdateStartTime)));
            PushLog("Valid install detected, Launch when ready");
            UpdateButton.BeginInvoke(new Action(() => UpdateButton.Enabled = true));
            LaunchButton.BeginInvoke(new Action(() => LaunchButton.Enabled = true));
        }

        private void UpMan_UpdateFailed(object sender, EventArgs e)
        {
            PushLog("Update failed :" + UpMan.GetLastError());

            UpdateButton.BeginInvoke(new Action(() => UpdateButton.Enabled = true));
            LaunchButton.BeginInvoke(new Action(() => LaunchButton.Enabled = false));
        }

        private void UpMan_UpdateStarted(object sender, EventArgs e)
        {
            UpdateStartTime = DateTime.Now;
            PushLog("Update Started");
        }

        private void Launcher_Load(object sender, EventArgs e)
        {
            DisableProgressBars();

            PushLog("Startup");

            AudioOutputDevice = new WaveOutEvent();
            BackgroundAudioFile = new Mp3FileReader(new MemoryStream(Resources.Fanfare_for_Space));

            AudioOutputDevice.Init(BackgroundAudioFile);

            AudioOutputDevice.Play();
            AudioOutputDevice.Volume = 0.25f;

            SettingsButton.Enabled = HasSettings();

            if (!IsLicensed())
                Application.Idle += Application_Idle;   // let the app update for a sec
            else
            { 
                ValidateLicense();

                if (IsValdInstall())
                {
                    PushLog("Valid install detected, Launch when ready");
                    LaunchButton.Enabled = true;
                    NewsButton_Click(sender, e);
                }
                else 
                {
                    PushLog("Invalid install detected, forcing update");
                    UpdateButton_Click(sender, e);
                }
            }
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            if (!IsLicensed())
            {
                // show license dialog
                Application.Idle -= Application_Idle;

                LicenseEntryDialog licenseDialog = new LicenseEntryDialog();
                if (licenseDialog.ShowDialog(this) != DialogResult.OK)
                    InvalidLicense();
                else
                {
                    FileInfo licenseFile = new FileInfo(GetLicenseFilePath());
                    if (!licenseFile.Directory.Exists)
                        licenseFile.Directory.Create();

                    if (!licenseFile.Exists)
                        HorizonLicenses.WriteLicenseFile(licenseFile, HorizonLicenses.CreateLicenseString(licenseDialog.LicenseCode, "Alpha", licenseFile.FullName));
                }

                if (IsLicensed())
                {
                    ValidateLicense();
              
                    if (IsValdInstall())
                    {
                        PushLog("Valid install detected, Launch when ready");
                        LaunchButton.Enabled = true;
                        SettingsButton.Enabled = true;
                        NewsButton_Click(sender, e);
                    }
                    else
                    {
                        PushLog("Invalid install detected, forcing update");
                        SettingsButton.Enabled = HasSettings();
                        UpdateButton_Click(sender, e);
                    }
                }
            }
        }

        internal static string GetProductCode()
        {
            string pCode = string.Empty;

            HorizonLicenses.CheckForLicense("Alpha", GetLicenseFilePath(), ref pCode);
            return pCode;
        }

        private bool ValidateLicense()
        {
            bool ret = HorizonLicenses.CheckForLicense("Alpha", GetLicenseFilePath(), ref UpMan.ProductCode);
            if (!ret)
                InvalidLicense();

            return ret;
        }

        private void Launcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            AudioOutputDevice?.Stop();

            AudioOutputDevice?.Dispose();
            BackgroundAudioFile?.Dispose();

            WebContext.Stop();
            WebContext.Dispose();
            UpMan.Kill();

            if (CreditsFile != null)
                CreditsFile.Delete();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            LogButton_Click(sender, e);

            PushLog("Starting Update");

            UpMan.Start();
            UpdateButton.Enabled = false;

            LogButton.BackColor = Color.Black;
            NewsButton.BackColor = Color.Transparent;
            CreditsButton.BackColor = Color.Transparent;
        }

        private void NewsButton_Click(object sender, EventArgs e)
        {
            WebContext.Navigate("https://www.starshiphorizons.com/pediab/bare.aspx?id=Active_Release");
            WebContext.Visible = true;
            LogText.Visible = false;
            ProgressPannel.Visible = false;

            LogButton.BackColor = Color.Transparent;
            NewsButton.BackColor = Color.Black;
            CreditsButton.BackColor = Color.Transparent;
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            WebContext.Visible = false;
            LogText.Visible = true;
            ProgressPannel.Visible = true;
        }

        protected bool IsValdInstall()
        {
            if (GameDir == null || !Directory.Exists(GameDir.FullName))
                return false;

            return (File.Exists(Path.Combine(GameDir.FullName, "bin", "Horizons.exe")));
        }

        protected bool IsLicensed()
        {
            if (GameDir == null || !Directory.Exists(GameDir.FullName))
                return false;

            return (File.Exists(GetLicenseFilePath()));
        }

        protected bool HasSettings()
        {
            if (GameDir == null || !Directory.Exists(GameDir.FullName))
                return false;

            return (File.Exists(GetSettingsFilePath()));
        }

        internal static string GetLicenseFilePath()
        {
            return Path.Combine(GameDir.FullName, "bin", "license.dat");
        }

        protected string GetSettingsFilePath()
        {
            return Path.Combine(GameDir.FullName, "config.xml");
        }

        protected void PushLog(string text)
        {
            LogText.BeginInvoke(new Action(() => LogText.Text = text + "\r\n" + LogText.Text));
        }

        protected void DisableProgressBars()
        {
            foreach (var p in ProgressBars)
                DisableProgressBar(p);
        }

        protected void DisableProgressBar(Tuple<Label,ProgressBar> item)
        {
            item.Item1.BeginInvoke(new Action(() => item.Item1.Text = string.Empty));
            item.Item2.BeginInvoke(new Action(() => item.Item2.Visible = false));
        }

        protected void InvalidLicense()
        {
            Close();
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            FileInfo licenseFile = new FileInfo(GetLicenseFilePath());

            if (!licenseFile.Exists)
            {
                InvalidLicense();
                return;
            }

            string code = string.Empty;
            bool valid = HorizonLicenses.CheckForLicense("Alpha", licenseFile.FullName, ref code);
            if (!valid)
            {
                MessageBox.Show(this, "Invalid license: " + HorizonLicenses.LastError, "License Error", MessageBoxButtons.OK);
                return;
            }

            string binPath = Path.Combine(GameDir.FullName, "bin");

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.Arguments = "";
            startInfo.FileName = "Horizons.exe";
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = binPath;
            startInfo.CreateNoWindow = true;
            this.WindowState = FormWindowState.Minimized;

            Process.Start(startInfo);

            Close();
        }

        protected FileInfo CreditsFile = null;
        private void CreditsButton_Click(object sender, EventArgs e)
        {
            if (CreditsFile == null)
            {
                CreditsFile = new FileInfo(Path.GetTempFileName());
                var t = CreditsFile.AppendText();
                t.Write(Resources.CreditsText);
                t.Flush();
                t.Close();
            }

            WebContext.Navigate("file://" + CreditsFile.FullName);
            WebContext.Visible = true;
            LogText.Visible = false;
            ProgressPannel.Visible = false;

            LogButton.BackColor = Color.Transparent;
            NewsButton.BackColor = Color.Transparent;
            CreditsButton.BackColor = Color.Black;
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Config cfg = Config.LoadXML(GetSettingsFilePath());

            SettingsDialog dlg = new SettingsDialog();
            dlg.Settings = cfg;
            dlg.GameDir = GameDir;

            if (dlg.ShowDialog(this) == DialogResult.OK)
                dlg.Settings.SaveXML(GetSettingsFilePath());

            if (dlg.NeedLicenseValidate)
                ValidateLicense();
        }
    }
}

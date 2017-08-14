using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Threading;
using System.Security.Cryptography;

namespace SHLanucher
{
    internal class UpdateManager
    {
        protected object GUILocker = new object();

        protected bool InProgress = false;
        protected string LastErrorMessage = string.Empty;

        public static string CryptoSecret = "SH1864";
        public string ProductCode = string.Empty;

        public bool UseRealMacName = false;

        public string VersionToReport = "1.3.0.0";
        public string UpdateServerURL = "http://updates.starshiphorizons.com/comm/";

        protected Guid LicenseKeyGUID = Guid.Empty;

        public int MaxDownloads = 4;

        protected Thread Worker = null;

        public bool Updating()
        {
            lock (GUILocker)
                return InProgress;
        }

        public string GetLastError()
        {
            lock (GUILocker)
                return LastErrorMessage;
        }

        protected void SetLastError(string err)
        {
            lock (GUILocker)
                LastErrorMessage = err;
        }

        protected DirectoryInfo RootDir = null;

        public class FileProgressEventArgs : EventArgs
        {
            public string DownloadFileName = string.Empty;
            public string LocalFileName = string.Empty;

            public int DownloadIndex = 0;

            public int Progress = 0;

            public FileProgressEventArgs(string dl, string lf, int i, int p)
            {
                DownloadFileName = dl;
                LocalFileName = lf;
                DownloadIndex = i;
                Progress = p;
            }
        }

        public event EventHandler UpdateStarted = null;

        public event EventHandler DirectoryScanStarted = null;
        public event EventHandler DirectoryScanEnded = null;

        public event EventHandler UpdateServerConnectStarted = null;
        public event EventHandler UpdateServerConnectCompleted = null;
        public event EventHandler UpdateServerConnectFailed = null;

        public event EventHandler FileSyncNotNeeded = null;

        public event EventHandler FileSyncStarted = null;

        public event EventHandler<FileProgressEventArgs> FileDownloadStarted = null;
        public event EventHandler<FileProgressEventArgs> FileDownloadCompleted = null;
        public event EventHandler<FileProgressEventArgs> FileDownloadProgress = null;
        public event EventHandler<FileProgressEventArgs> FileDownloadError = null;
        public event EventHandler<FileProgressEventArgs> FileDownloadErrorRetry = null;

        public event EventHandler FileSyncEnded = null;
       
        public event EventHandler UpdateFailed = null;
        public event EventHandler UpdateCanceled = null;
        public event EventHandler UpdateComplete = null;

        protected Dictionary<string, FileInfo> LocalFileMap = new Dictionary<string, FileInfo>();

        protected List<string> FailedFiles = new List<string>();

        public string[] GetFailedFiles () { lock (FailedFiles) return FailedFiles.ToArray(); }

        protected StringBuilder LocalFileHashes = new StringBuilder();

        public UpdateManager (DirectoryInfo root)
        {
            RootDir = root;
            if (!RootDir.Exists)
                RootDir.Create();
        }

        private void CheckLicenseData()
        {
            if (ProductCode == string.Empty)    // if we don't have a valid product code, generate one, the update server doesn't care
            {
                int len = 32;

                StringBuilder sb = new StringBuilder();
                Random rng = new Random();

                for (int i = 0; i < len; i++)
                {
                    int v = rng.Next(10);
                    sb.Append(v.ToString());
                }

                ProductCode = sb.ToString();
            }

            LicenseKeyGUID = new Guid(ProductCode);
        }

        public void Start()
        {
            CheckLicenseData();

            lock (GUILocker)
                InProgress = true;

            Worker = new Thread(new ThreadStart(ProcessUpdate));
            Worker.Start();
        }
        
        public void Kill()
        {
            lock (GUILocker)
            {
                if (Worker != null)
                {
                    Worker.Abort();
                    Worker = null;
                }
            }

            if (Updating())
            {
                lock (GUILocker)
                    InProgress = false;
                UpdateCanceled?.Invoke(this, EventArgs.Empty);
            }
        }

        private void FailThread()
        {
            lock (GUILocker)
            {
                Worker = null;
                InProgress = false;
            }
            UpdateFailed?.Invoke(this, EventArgs.Empty);
        }

        protected List<string> FilesToDownload = new List<string>();

        protected string PopDownloadFile()
        {
            lock(FilesToDownload)
            {
                if (FilesToDownload.Count == 0)
                    return string.Empty;

                string url = FilesToDownload[0];
                FilesToDownload.RemoveAt(0);
                return url;
            }
        }

        protected void PushReDownloadFile(string file)
        {
            lock (FilesToDownload)
                FilesToDownload.Add(file);
        }

        protected virtual void ProcessUpdate()
        {
            LocalFileHashes.Clear();
            SetLastError(string.Empty);

            UpdateStarted?.Invoke(this, EventArgs.Empty);

            DirectoryScanStarted?.Invoke(this, EventArgs.Empty);

            LocalFileMap.Clear();
            BuildLocalFileMap(RootDir);

            DirectoryScanEnded?.Invoke(this, EventArgs.Empty);

            if (!GetRemoteFileList())
            {
                FailThread();
                return;
            }

            if (FilesToDownload.Count > 0)
            {
                SyncFiles();
            }
            else
                FileSyncNotNeeded?.Invoke(this, EventArgs.Empty);

            lock (GUILocker)
            {
                Worker = null;
                InProgress = false;
            }
            UpdateComplete?.Invoke(this, EventArgs.Empty);
        }

        protected class FileDownloadInfo
        {
            public WebClient Connection = null;
            public FileProgressEventArgs Args = null;
            public FileInfo LocalFile = null;

            public SHA1Managed Hasher = new SHA1Managed();

            public object Tag = null;
        }

        protected List<FileDownloadInfo> DownloadPool = new List<FileDownloadInfo>();

        public bool PushRetryFile(string file)
        {
            lock (FailedFiles)
            {
                if (!FailedFiles.Contains(file))
                {
                    FailedFiles.Add(file);
                    PushReDownloadFile(file);

                    return true;
                }
            }

            return false;
        }

        private void SyncFiles()
        {
            FailedFiles.Clear();

            FileSyncStarted?.Invoke(this, EventArgs.Empty);

            for (int i =0; i < MaxDownloads; i++)
            {
                FileDownloadInfo info = new FileDownloadInfo();
                info.Connection = new WebClient();
                info.Connection.UploadValuesCompleted += Connection_UploadValuesCompleted;
                info.Connection.UploadProgressChanged += Connection_UploadProgressChanged;

                info.Args = new FileProgressEventArgs(string.Empty, string.Empty, i + 1, 0);
                DownloadPool.Add(info);

                StartDLJob(info);
            }

            bool done = false;
            while (!done)
            {
                Thread.Sleep(100);
                lock (DownloadPool)
                    done = DownloadPool.Count == 0;
            }

            FileSyncEnded?.Invoke(this, EventArgs.Empty);
        }

        private void Connection_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            FileDownloadInfo info = e.UserState as FileDownloadInfo;
            if (info == null)
                return;

            info.Args.Progress = e.ProgressPercentage;

            FileDownloadProgress?.Invoke(this, info.Args);
        }

        private void Connection_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            FileDownloadInfo info = e.UserState as FileDownloadInfo;
            if (info == null)
                return;

            if (e.Error != null || e.Cancelled)
            {
                info.Args.Progress = 100;
                FileDownloadError?.Invoke(this, info.Args);
            }

            info.Args.Progress = 100;
            FileDownloadProgress?.Invoke(this, info.Args);

            lock (info.LocalFile.Directory)
            {
                if (!info.LocalFile.Directory.Exists)
                    info.LocalFile.Directory.Create();
            }

            try
            {
                var fs = info.LocalFile.OpenWrite();
                var ms = new MemoryStream(e.Result);
                DeflateStream df = new DeflateStream(ms, CompressionMode.Decompress);

                df.CopyTo(fs);
                df.Close();
                fs.Close();

                FileDownloadCompleted?.Invoke(this, info.Args);
            }
            catch (Exception)
            {
                info.Args.Progress = 100;

                if (PushRetryFile(info.Args.DownloadFileName))
                    FileDownloadErrorRetry?.Invoke(this, info.Args);
                else
                    FileDownloadError?.Invoke(this, info.Args);
            }

            StartDLJob(info);
        }

        protected virtual void StartDLJob(FileDownloadInfo info)
        {
            string jobURL = PopDownloadFile();
            if (jobURL == string.Empty)
            {
                lock (DownloadPool)
                    DownloadPool.Remove(info);

                info.Connection.Dispose();
                info = null;
            }
            else
            {
                info.Args.DownloadFileName = jobURL;
                info.Args.Progress = 0;
                lock (RootDir)
                    info.LocalFile = new FileInfo(Path.Combine(RootDir.FullName, jobURL));
                info.Args.LocalFileName = info.LocalFile.FullName;

                FileDownloadStarted?.Invoke(this,info.Args);

                string uriString = string.Empty;
                lock (UpdateServerURL)
                    uriString = UpdateServerURL + "dl.aspx";

                NameValueCollection data = new NameValueCollection();

                string cryptoFileName = HorizonCrypto.EncryptString(jobURL, CryptoSecret);

                data.Add("Timestamp", HorizonCrypto.TimeStamp());
                data.Add("Data", cryptoFileName);

                info.Connection.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                info.Connection.UploadValuesAsync(new Uri(uriString), "POST", data, info);
            }
        }

        private bool GetRemoteFileList()
        {
            UpdateServerConnectStarted.Invoke(this, EventArgs.Empty);

            NameValueCollection data = new NameValueCollection();
            string fileListThatIsEncryptedForSomeReason = HorizonCrypto.EncryptString(LocalFileHashes.ToString(), CryptoSecret);

            data.Add("Timestamp", HorizonCrypto.TimeStamp());
            data.Add("TimeDiff", LicenseKeyGUID.ToString());
            data.Add("MacName", Environment.MachineName);
            data.Add("Launcher", VersionToReport);
            data.Add("Data", fileListThatIsEncryptedForSomeReason);

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                    byte[] responce = webClient.UploadValues(UpdateServerURL + "updates.aspx", data);
                    if (responce == null || responce.Length == 0)
                    {
                        SetLastError("GetRemoteFileList failed, server returned no data" );
                        UpdateServerConnectFailed?.Invoke(this, EventArgs.Empty);
                        return false;
                    }
                    string responceText = HorizonCrypto.DecryptString(Encoding.UTF8.GetString(responce), CryptoSecret);

                    foreach (var line in responceText.Split("\r\n".ToCharArray()))
                    {
                        if (line == string.Empty)
                            continue;

                        string[] parts = line.Split(":".ToCharArray(), 2);

                        if (parts.Length > 2 || parts[0].ToUpperInvariant() == "TIME")
                            continue;

                        string urlPath = parts[1];
//                         if (LocalFileMap.ContainsKey(urlPath.ToLowerInvariant()))
//                             continue;

                        FilesToDownload.Add(urlPath);
                    }

                    UpdateServerConnectCompleted.Invoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    SetLastError("GetRemoteFileList failed " + ex.ToString());
                    UpdateServerConnectFailed?.Invoke(this, EventArgs.Empty);
                    return false;
                }
            }

            return true;
        }

        public MD5 FileHasher = MD5.Create();

        private void BuildLocalFileMap(DirectoryInfo dir)
        {
            if (dir.Name.Substring(0,1) == ".")
                return;

            foreach (var file in dir.GetFiles())
            {
                string urlPath = file.FullName.Substring(RootDir.FullName.Length);
                LocalFileMap.Add(urlPath.ToLowerInvariant(), file);

                var sr = file.OpenRead();
                LocalFileHashes.AppendLine(urlPath + "|" + BitConverter.ToString(FileHasher.ComputeHash(sr)).Replace("-",string.Empty));
                sr.Close();
            }
     
            foreach (var sd in dir.GetDirectories())
                BuildLocalFileMap(sd);
        }
    }
}

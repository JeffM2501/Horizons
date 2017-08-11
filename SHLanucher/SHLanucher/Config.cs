using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SHLanucher
{
    internal class Config
    {
        public string World = "Horizons";

        public class VideoInfo
        {
            public bool Fullscreen = false;
            public string Size = "1280 720";
            public int TargetFPS = 60;
            public bool FixedFPS = false;
            public bool VSync = true;
        }
        public VideoInfo Video = new VideoInfo();

        public class VRInfo
        {
            public string Mode = "Oculus";
            public bool Enabled = false;
        }
        public VRInfo VR = new VRInfo();

        public bool ComponentDamangeEnabled = true;
        
        public class DMXInfo
        {
            public bool Enabled = false;
            public string Controller = "Open DMX";
            public int Port = 4;
            public class Fixture
            {
                public string Name = string.Empty;
                public string Channel = string.Empty;
                public int Track = 0;
            }
        }


        public static Config Load(string path)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(Config));

                FileInfo file = new FileInfo(path);
                if (!file.Exists)
                    return new Config();

                StreamReader sr = file.OpenText();
                Config cfg = xml.Deserialize(sr) as Config;

                if (cfg == null)
                    return new Config();

                sr.Close();
                return cfg;
            }
            catch (Exception)
            {
                return new Config();
            }
        }

        public void Save(string path)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(Config));

                FileInfo file = new FileInfo(path);
                if (file.Exists)
                    file.Delete();

                var sw = file.AppendText();
                xml.Serialize(sw, this);
                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {
  
            }
        }
    }
}

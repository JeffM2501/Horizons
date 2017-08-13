using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SHLanucher
{
    public class Config
    {
        public string World = "Horizons";

        public class VideoInfo
        {
            public bool Fullscreen = false;
            public int[] Size = new int[] { 1280, 720 };
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
                public string Mode = "RGB";
            }
            public List<Fixture> Fixtures = new List<Fixture>();
        }
        public DMXInfo DMX = new DMXInfo();

        public class VoiceInfo
        {
            public bool Synthesis = true;
            public bool Recognition = false;
        }
        public VoiceInfo Voice = new VoiceInfo();

        public class DebugInfo
        {
            public bool Enabled = false;
            public bool ModelSpheres = false;
            public bool ProjectileSpheres = false;
            public bool HardpointSpheres = false;
            public bool CollisionMesh = false;
        }
        public DebugInfo Debug = new DebugInfo();

        public class WebserverInfo
        {
            public bool Enabled = true;
            public int Port = 1864;
            public int Heartbeat = 200;
            public bool Cache = false;
        }
        public WebserverInfo Webserver = new WebserverInfo();

        public class WebSocketsInfo
        {
            public bool Enabled = true;
            public int Port = 1865;
            public int Heartbeat = 200;
            public bool Batch = false;
        }
        public WebSocketsInfo Websockets = new WebSocketsInfo();

        public class NetworkInfo
        {
            public bool Enabled = true;
            public int Port = 18864;
            public int Heartbeat = 50;
        }
        public NetworkInfo Network = new NetworkInfo();

        public enum CollisionMethods
        {
            Sphere,
            Vertex,
        }

        public CollisionMethods CollisionMethod = CollisionMethods.Vertex;

        public class InputMapItem
        {
            public string Value = string.Empty;
            public string Key = string.Empty;
        }
        public List<InputMapItem> KeyMap = new List<InputMapItem>();
        public List<InputMapItem> StickMap = new List<InputMapItem>();
        public List<InputMapItem> ButtonMap = new List<InputMapItem>();


        public delegate bool ConfigTagReader(string tag, XmlNode node, Config cfg);

        public static Dictionary<string, ConfigTagReader> Readers = new Dictionary<string, ConfigTagReader>();

        public static void CheckReaders()
        {
            if (Readers.Count != 0)
                return;

            Readers.Add("world", ReadWorld);
            Readers.Add("video", ReadVideo);
            Readers.Add("vr", ReadVR);
            Readers.Add("component", ReadComponent);
            Readers.Add("dmx", ReadDMX);
            Readers.Add("voice", ReadVoice);
            Readers.Add("Debug", ReadDebug);
            Readers.Add("webserver", ReadWebserver);
            Readers.Add("websockets", ReadWebsockets);
            Readers.Add("network", ReadNetwork);
            Readers.Add("collision", ReadCollision);
            Readers.Add("keymap", ReadKeyMap);
            Readers.Add("stickmap", ReadStickMap);
            Readers.Add("buttonmap", ReadButtonMap);
        }

        public static Config LoadXML(string path)
        {
            Config cfg = new Config();
            CheckReaders();

            try
            {
                FileInfo file = new FileInfo(path);
                if (!file.Exists)
                    return cfg;


                XmlDocument doc = new XmlDocument();
                StreamReader sr = file.OpenText();
                doc.LoadXml(sr.ReadToEnd());
                sr.Close();

                foreach (XmlNode xmlNode in doc.ChildNodes[0])
                {
                    string name = xmlNode.Name.ToLowerInvariant();

                    if (Readers.ContainsKey(name))
                        Readers[name](name, xmlNode, cfg);
                }
            }
            catch (Exception)
            {
               
            }

            return cfg;
        }

        private static bool ReadWorld(string tag, XmlNode node, Config cfg)
        {
            try
            {
                cfg.World = node.Attributes["id"].InnerText;
            }
            catch (Exception)
            {
                return false;
            }
           
            return true;
        }

        private static bool ReadVideo(string tag, XmlNode node, Config cfg)
        {
            try
            {
                bool.TryParse(node.Attributes["fullscreen"].InnerText, out cfg.Video.Fullscreen);
                int.TryParse(node.Attributes["targetfps"].InnerText, out cfg.Video.TargetFPS);
                bool.TryParse(node.Attributes["fixedfps"].InnerText, out cfg.Video.FixedFPS);
                bool.TryParse(node.Attributes["vsync"].InnerText, out cfg.Video.VSync);

                string[] p = node.Attributes["size"].InnerText.Split(" ".ToCharArray(),2);
                if (p.Length == 2)
                {
                    int.TryParse(p[0], out cfg.Video.Size[0]);
                    int.TryParse(p[1], out cfg.Video.Size[1]);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static bool ReadVR(string tag, XmlNode node, Config cfg)
        {
            try
            {
                bool.TryParse(node.Attributes["enabled"].InnerText, out cfg.VR.Enabled);
                cfg.VR.Mode = node.Attributes["mode"].InnerText;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static bool ReadComponent(string tag, XmlNode node, Config cfg)
        {
            try
            {
                bool.TryParse(node.Attributes["damageenabled"].InnerText, out cfg.ComponentDamangeEnabled);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static bool ReadDMX(string tag, XmlNode node, Config cfg)
        {
            try
            {
                bool.TryParse(node.Attributes["enabled"].InnerText, out cfg.DMX.Enabled);
                cfg.DMX.Controller = node.Attributes["controller"].InnerText;
                int.TryParse(node.Attributes["port"].InnerText, out cfg.DMX.Port);

                foreach (XmlNode child in node.ChildNodes)
                {
                    string name = child.Name.ToLowerInvariant();
                    if (name == "fixture")
                    {
                        DMXInfo.Fixture fixture = new DMXInfo.Fixture();
                        fixture.Name = child.Attributes["name"].InnerText;
                        fixture.Channel = child.Attributes["channel"].InnerText;
                        int.TryParse(child.Attributes["track"].InnerText, out fixture.Track);
                        fixture.Mode = child.Attributes["mode"].InnerText;

                        cfg.DMX.Fixtures.Add(fixture);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static bool ReadVoice(string tag, XmlNode node, Config cfg)
        {
            try
            {
                bool.TryParse(node.Attributes["synthesis"].InnerText, out cfg.Voice.Synthesis);
                bool.TryParse(node.Attributes["recognition"].InnerText, out cfg.Voice.Recognition);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static bool ReadDebug(string tag, XmlNode node, Config cfg)
        {
            try
            {
                bool.TryParse(node.Attributes["enabled"].InnerText, out cfg.Debug.Enabled);
                bool.TryParse(node.Attributes["modelspheres"].InnerText, out cfg.Debug.ModelSpheres);
                bool.TryParse(node.Attributes["projectilespheres"].InnerText, out cfg.Debug.ProjectileSpheres);
                bool.TryParse(node.Attributes["hardpointspheres"].InnerText, out cfg.Debug.HardpointSpheres);
                bool.TryParse(node.Attributes["collisionmesh"].InnerText, out cfg.Debug.CollisionMesh);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static bool ReadWebserver(string tag, XmlNode node, Config cfg)
        {
            try
            {
                bool.TryParse(node.Attributes["enabled"].InnerText, out cfg.Webserver.Enabled);
                int.TryParse(node.Attributes["port"].InnerText, out cfg.Webserver.Port);
                int.TryParse(node.Attributes["heartbeat"].InnerText, out cfg.Webserver.Heartbeat);
                bool.TryParse(node.Attributes["cache"].InnerText, out cfg.Webserver.Cache);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static bool ReadWebsockets(string tag, XmlNode node, Config cfg)
        {
            try
            {
                bool.TryParse(node.Attributes["enabled"].InnerText, out cfg.Websockets.Enabled);
                int.TryParse(node.Attributes["port"].InnerText, out cfg.Websockets.Port);
                int.TryParse(node.Attributes["heartbeat"].InnerText, out cfg.Websockets.Heartbeat);
                bool.TryParse(node.Attributes["batch"].InnerText, out cfg.Websockets.Batch);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static bool ReadNetwork(string tag, XmlNode node, Config cfg)
        {
            try
            {
                bool.TryParse(node.Attributes["enabled"].InnerText, out cfg.Network.Enabled);
                int.TryParse(node.Attributes["port"].InnerText, out cfg.Network.Port);
                int.TryParse(node.Attributes["heartbeat"].InnerText, out cfg.Network.Heartbeat);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static bool ReadCollision(string tag, XmlNode node, Config cfg)
        {
            try
            {
                Enum.TryParse<CollisionMethods>(node.Attributes["method"].InnerText, out cfg.CollisionMethod);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static List<InputMapItem> ReadInputMap(XmlNode node)
        {
            List<InputMapItem> items = new List<InputMapItem>();

            foreach (XmlNode child in node.ChildNodes)
            {
                string name = child.Name.ToLowerInvariant();
                if (name == "map")
                {
                    InputMapItem item = new InputMapItem();
                    item.Value = child.Attributes["value"].InnerText;
                    item.Key = child.Attributes["key"].InnerText;
                    items.Add(item);
                }
            }

            return items;
        }


        private static bool ReadKeyMap(string tag, XmlNode node, Config cfg)
        {
            try
            {
                cfg.KeyMap = ReadInputMap(node);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static bool ReadStickMap(string tag, XmlNode node, Config cfg)
        {
            try
            {
                cfg.StickMap = ReadInputMap(node);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static bool ReadButtonMap(string tag, XmlNode node, Config cfg)
        {
            try
            {
                cfg.ButtonMap = ReadInputMap(node);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private void WriteWorld (XmlTextWriter tw)
        {
            tw.WriteStartElement("world");

            tw.WriteAttributeString("id", World);

            tw.WriteEndElement();
        }

        private void WriteVideo(XmlTextWriter tw)
        {
            tw.WriteStartElement("video");

            tw.WriteAttributeString("fullscreen", Video.Fullscreen.ToString().ToLower());
            tw.WriteAttributeString("size", Video.Size[0].ToString() + " " + Video.Size[1].ToString());
            tw.WriteAttributeString("targetfps", Video.TargetFPS.ToString());
            tw.WriteAttributeString("fixedfps", Video.FixedFPS.ToString().ToLower());
            tw.WriteAttributeString("vsync", Video.VSync.ToString().ToLower());

            tw.WriteEndElement();
        }

        private void WriteVR(XmlTextWriter tw)
        {
            tw.WriteStartElement("vr");

            tw.WriteAttributeString("mode", VR.Mode);
            tw.WriteAttributeString("enabled", VR.Enabled.ToString().ToLower());

            tw.WriteEndElement();
        }

        private void WriteComponent(XmlTextWriter tw)
        {
            tw.WriteStartElement("component");

            tw.WriteAttributeString("damageenabled", ComponentDamangeEnabled.ToString().ToLower());

            tw.WriteEndElement();
        }

        private void WriteDMX(XmlTextWriter tw)
        {
            tw.WriteStartElement("dmx");

            tw.WriteAttributeString("enabled", DMX.Enabled.ToString().ToLower());
            tw.WriteAttributeString("controller", DMX.Controller);
            tw.WriteAttributeString("port", DMX.Port.ToString());

            foreach(var f in DMX.Fixtures)
            {
                tw.WriteStartElement("fixture");
                tw.WriteAttributeString("name", f.Name);
                tw.WriteAttributeString("channel", f.Channel);
                tw.WriteAttributeString("track", f.Track.ToString());
                tw.WriteAttributeString("mode", f.Mode);
                tw.WriteEndElement();
            }
            tw.WriteEndElement();
        }

        private void WriteVoice(XmlTextWriter tw)
        {
            tw.WriteStartElement("voice");

            tw.WriteAttributeString("synthesis", Voice.Synthesis.ToString().ToLower());
            tw.WriteAttributeString("recognition", Voice.Recognition.ToString().ToLower());

            tw.WriteEndElement();
        }

        private void WriteDebug(XmlTextWriter tw)
        {
            tw.WriteStartElement("debug");

            tw.WriteAttributeString("enabled", Debug.Enabled.ToString().ToLower());
            tw.WriteAttributeString("modelspheres", Debug.ModelSpheres.ToString().ToLower());
            tw.WriteAttributeString("projectilespheres", Debug.ProjectileSpheres.ToString().ToLower());
            tw.WriteAttributeString("hardpointspheres", Debug.HardpointSpheres.ToString().ToLower());
            tw.WriteAttributeString("collisionmesh", Debug.CollisionMesh.ToString().ToLower());

            tw.WriteEndElement();
        }

        private void WriteWebserver(XmlTextWriter tw)
        {
            tw.WriteStartElement("webserver");

            tw.WriteAttributeString("enabled", Webserver.Enabled.ToString().ToLower());
            tw.WriteAttributeString("port", Webserver.Port.ToString());
            tw.WriteAttributeString("heartbeat", Webserver.Heartbeat.ToString());
            tw.WriteAttributeString("cache", Webserver.Cache.ToString().ToLower());

            tw.WriteEndElement();
        }

        private void WriteWebsockets(XmlTextWriter tw)
        {
            tw.WriteStartElement("websockets");

            tw.WriteAttributeString("enabled", Websockets.Enabled.ToString().ToLower());
            tw.WriteAttributeString("port", Websockets.Port.ToString());
            tw.WriteAttributeString("heartbeat", Websockets.Heartbeat.ToString());
            tw.WriteAttributeString("batch", Websockets.Batch.ToString().ToLower());

            tw.WriteEndElement();
        }

        private void WriteNetwork(XmlTextWriter tw)
        {
            tw.WriteStartElement("network");

            tw.WriteAttributeString("enabled", Network.Enabled.ToString().ToLower());
            tw.WriteAttributeString("port", Network.Port.ToString());
            tw.WriteAttributeString("heartbeat", Network.Heartbeat.ToString());

            tw.WriteEndElement();
        }
        private void WriteCollision(XmlTextWriter tw)
        {
            tw.WriteStartElement("collision");

            tw.WriteAttributeString("method", CollisionMethod.ToString());

            tw.WriteEndElement();
        }

        private void WriteInputMap(XmlTextWriter tw, string name, List<InputMapItem> items)
        {
            tw.WriteStartElement(name);

            foreach (var i in items)
            {
                tw.WriteStartElement("map");
                tw.WriteAttributeString("value",i.Value);
                tw.WriteAttributeString("key", i.Key);
                tw.WriteEndElement();
            }
            tw.WriteEndElement();
        }

        public void SaveXML(string path)
        {
            FileInfo file = new FileInfo(path);
            if (file.Exists)
                file.Delete();

            var sw = file.AppendText();

            XmlTextWriter tw = new XmlTextWriter(sw);

            tw.Indentation = 2;
            tw.IndentChar = ' ';
            tw.Formatting = Formatting.Indented;

            tw.WriteStartElement("config");

            WriteWorld(tw);
            WriteVideo(tw);
            WriteVR(tw);
            WriteComponent(tw);
            WriteDMX(tw);
            WriteVoice(tw);
            WriteDebug(tw);
            WriteWebserver(tw);
            WriteWebsockets(tw);
            WriteNetwork(tw);
            WriteCollision(tw);

            WriteInputMap(tw, "keymap", KeyMap);
            WriteInputMap(tw, "stickmap", StickMap);
            WriteInputMap(tw, "buttonmap", ButtonMap);

            tw.WriteEndElement();
            tw.Close();
         /*   sw.Flush();*/
            sw.Close();
        }


        public static Config LoadSerialzed(string path)
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

        public void SaveSerialized(string path)
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
            catch (Exception /*ex*/)
            {
  
            }
        }
    }
}

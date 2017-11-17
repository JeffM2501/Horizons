using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;

using MissionManager.Horizons;

namespace MissionManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public class MissionPackage
        {
            public Mission mission = new Mission();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                Mission mission = null;
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(MissionPackage));

                    StreamReader sr = new FileInfo(ofd.FileName).OpenText();
                    string text = sr.ReadToEnd();
                    sr.Close();

                    text = "<?xml version=\"1.0\"?>\r\n<MissionPackage xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n" + text + "\r\n</MissionPackage>";

                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(text);
                    MemoryStream ms = new MemoryStream(buffer);

                    MissionPackage mp = xml.Deserialize(ms) as MissionPackage;
                    mission = mp?.mission;
                    ms.Close();
                }
                catch (Exception ex)
                {
                    mission = null;
                }
                
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHLanucher
{
    public partial class LicenseEntryDialog : Form
    {
        public string LicenseCode = string.Empty;

        public LicenseEntryDialog()
        {
            InitializeComponent();
            OK.Enabled = false;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (ProdcutCode.Text == string.Empty)
                DialogResult = DialogResult.Cancel;
            else
            {
                if (!CheckNetwork())
                {
                    MessageBox.Show(this, "An active Internet connection is required for activation", "No Network Connection", MessageBoxButtons.OK);
                    DialogResult = DialogResult.None;
                    return;
                }

                string licenseKey = ProdcutCode.Text.Replace("-", "");

                using (WebClient webClient = new WebClient())
                {
                    string address = "http://updates.starshiphorizons.com/comm/license.aspx";
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                    NameValueCollection data = new NameValueCollection();
         
                    data.Add("Timestamp", HorizonCrypto.TimeStamp());
                    data.Add("Login", "-");
                    data.Add("Key", HorizonCrypto.EncryptString(licenseKey,UpdateManager.CryptoSecret));

                    // show update progress

                    LicenseUpdateProgress p = new LicenseUpdateProgress();
                    p.Show(this);

                    var responce = webClient.UploadValues(address, data);

                    p.Close();

                    if (responce == null || responce.Length == 0)
                    {
                        MessageBox.Show(this, "Validation failed, unable to contact server", "Validation Failed", MessageBoxButtons.OK);
                        DialogResult = DialogResult.None;
                        return;
                    }

                    string results = HorizonCrypto.DecryptString(Encoding.UTF8.GetString(responce), UpdateManager.CryptoSecret);

                    foreach (var part in results.Split("\r\n".ToCharArray()))
                    {
                        if (part.ToUpperInvariant() == "VALID")
                        {
                            LicenseCode = licenseKey;
                            DialogResult = DialogResult.OK;
                            return;
                        }
                    }

                    MessageBox.Show(this, "Validation failed, unable to contact server", "Validation Failed", MessageBoxButtons.OK);
                    DialogResult = DialogResult.None;
                }
            }
        }

        protected bool CheckNetwork()
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    using (webClient.OpenRead("http://www.google.com"))
                        return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void ProdcutCode_TextChanged(object sender, EventArgs e)
        {
            OK.Enabled = ProdcutCode.Text != string.Empty;
        }
    }
}

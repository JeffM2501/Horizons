using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHLanucher
{
    internal static class HorizonLicenses
    {

        internal static string GenerateProductCode()
        {
            int len = 32;

            StringBuilder sb = new StringBuilder();
            Random rng = new Random();

            for (int i = 0; i < len; i++)
            {
                int v = rng.Next(10);
                sb.Append(v.ToString());
            }

            return sb.ToString();
        }

        internal static string CreateLicenseString(string productCode, string product, string path)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("MAC," + Environment.MachineName);
                sb.Append("|Path," + path);
                sb.Append("|" + product + "," + productCode);
                sb.Append("|"); 

                return HorizonCrypto.EncryptString(sb.ToString(), "a1783!b1971|c2005"); 

            }
            catch (Exception /*ex*/)
            {
                return string.Empty;
            }
        }

        internal static void WriteLicenseFile(FileInfo file, string licenseString)
        {
            var sr = file.AppendText();
            sr.WriteLine(licenseString);
            sr.Flush();
            sr.Close();
        }

        internal static string LastError = string.Empty;

        internal static bool CheckForLicense(string product, string path, ref string productCode)
        {
            LastError = string.Empty;
            try
            {
                if (File.Exists(path))
                {
                    string str1 = HorizonCrypto.DecryptString(Encoding.Default.GetString(File.ReadAllBytes(path)), "a1783!b1971|c2005");
                    char[] chArray1 = new char[1] { '|' };
                    foreach (string str2 in str1.Split(chArray1))
                    {
                        char[] chArray2 = new char[1] { ',' };
                        string[] strArray = str2.Split(chArray2);
                        if (strArray.Length > 1)
                        {
                            if (strArray[0] == "MAC" && strArray[1] != Environment.MachineName)
                            {
                                LastError = "This license was validated on another machine.";
                                return false;
                            }
                            if (strArray[0] == "Path" && strArray[1] != path)
                            {
                                LastError = "This license file has been copied or moved.";
                                return false;
                            }
                            if (strArray[0] == product)
                            {
                                productCode = strArray[1];
                                Guid guid = new Guid(strArray[1]);
                                return true;
                            }
                        }
                    }
                }
                else
                {
                    LastError = "CheckForLicense: License File Missing";
                    return false;
                }
            }
            catch (Exception ex)
            {
                LastError = "CheckForLicense: " + ex.Message;
                return false;
            }
            return false;
        }
    }
}

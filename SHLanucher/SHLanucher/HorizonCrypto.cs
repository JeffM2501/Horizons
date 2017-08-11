using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SHLanucher
{
    internal static class HorizonCrypto
    {
        public static string TimeStamp()
        {
            return string.Format("{0:M/dd/yyy H:mm:ss}", DateTime.Now);
        }

        private static readonly byte[] CryptoMagic = Encoding.ASCII.GetBytes("su89geji34ht89u2");
        private const int KeySize = 256;

        public static string EncryptString(string plainText, string passPhrase)
        {
            byte[] dataBuffer = Encoding.UTF8.GetBytes(plainText);

            using (PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(passPhrase, null))
            {
                byte[] keyBuffer = passwordDeriveBytes.GetBytes(32);

                using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
                {
                    rijndaelManaged.Mode = CipherMode.CBC;

                    using (ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(keyBuffer, CryptoMagic))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(dataBuffer, 0, dataBuffer.Length);
                                cryptoStream.FlushFinalBlock();
                                return Convert.ToBase64String(memoryStream.ToArray());
                            }
                        }
                    }
                }
            }
        }

        public static string DecryptString(string cipherText, string passPhrase)
        {
            byte[] dataBuffer = Convert.FromBase64String(cipherText);

            using (PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(passPhrase, (byte[])null))
            {
                byte[] keyBuffer = passwordDeriveBytes.GetBytes(32);
                using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
                {
                    rijndaelManaged.Mode = CipherMode.CBC;

                    using (ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(keyBuffer, CryptoMagic))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(dataBuffer))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                byte[] decryptBuffer = new byte[dataBuffer.Length];
                                int count = cryptoStream.Read(decryptBuffer, 0, decryptBuffer.Length);
                                return Encoding.UTF8.GetString(decryptBuffer, 0, count);
                            }
                        }
                    }
                }
            }
        }
    }
}

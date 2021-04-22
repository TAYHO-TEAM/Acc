using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Services.Common.Security
{
    public class RijndaelHelper
    {
        public static string EncryptStringToBytes(string plainText, string Key, string IV)
        {
            byte[] _key = Encoding.ASCII.GetBytes(Key);
            byte[] _IV = Encoding.ASCII.GetBytes(IV);
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = _key;
                rijAlg.IV = _IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.
            return Convert.ToBase64String(encrypted);
        }

        public static string DecryptStringFromBytes(string cipherText, string Key, string IV)
        {
            byte[] _cipherText = Encoding.ASCII.GetBytes(cipherText);
            byte[] _key = Encoding.ASCII.GetBytes(Key);
            byte[] _IV = Encoding.ASCII.GetBytes(IV);

            // Check arguments.
            if (_cipherText == null || _cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (_key == null || _key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (_IV == null || _IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = _key;
                rijAlg.IV = _IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(_cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
    }
}

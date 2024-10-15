using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Eventos.Platinum.Library.HelperServices
{
    public class EncryptorService : IEncryptorService
    {
        private readonly IConfiguration _configuration;
        private readonly string _key;

        public EncryptorService(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = _configuration.GetSection("AppSettings:EncryptionKey").Value;
            if (string.IsNullOrEmpty(_key))
            {
                throw new Exception("No hay Key para encriptar en la configuración.");
            }
        }

        public string Encrypt(string textoAEncriptar)
        {
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(_key);
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using MemoryStream ms = new();
                using CryptoStream cryptoStream = new(ms, encryptor, CryptoStreamMode.Write);
                using (StreamWriter streamWriter = new(cryptoStream))
                {
                    streamWriter.Write(textoAEncriptar);
                }
                array = ms.ToArray();
            }
            return Convert.ToBase64String(array);
        }

        public string Decrypt(string textoADesencriptar)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(textoADesencriptar);
            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(_key);
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using MemoryStream ms = new(buffer);
            using CryptoStream cryptoStream = new(ms, decryptor, CryptoStreamMode.Read);
            using StreamReader sr = new(cryptoStream);
            return sr.ReadToEnd();
        }
    }
}

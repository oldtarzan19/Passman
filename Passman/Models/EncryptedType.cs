using System.Security.Cryptography;
using System.Text;
using Cryptography; 
using Utility;      

namespace Passman.Models
{
    public class EncryptedType
    {
        public string Key { get; set; }
        public string Secret { get; set; }
        
        public EncryptedType()
        {
        }
        
        public EncryptedType Encrypt(string key, string secret)
        {
            using var hashing = SHA256.Create();
            byte[] keyHash = hashing.ComputeHash(Encoding.Unicode.GetBytes(key));
            string encodedKey = Base64UrlEncoder.Encode(keyHash);
            string message = Base64UrlEncoder.Encode(Encoding.Unicode.GetBytes(secret));
            return new EncryptedType { Key = encodedKey, Secret = Fernet.Encrypt(encodedKey, message) };
        }
        
        public EncryptedType Decrypt(string key, string secret)
        {
            using var hashing = SHA256.Create();
            byte[] keyHash = hashing.ComputeHash(Encoding.Unicode.GetBytes(key));
            string encodedKey = Base64UrlEncoder.Encode(keyHash);
            string encodedSecret = Fernet.Decrypt(encodedKey, secret);
            string message = Encoding.Unicode.GetString(Base64UrlEncoder.DecodeBytes(encodedSecret));
            return new EncryptedType { Key = encodedKey, Secret = message };
        }
        
        public string Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // Konvertáljuk hexadecimális formátumba
                }

                return builder.ToString();
            }
        }
    }
}
using System.Security.Cryptography;
using System.Text;
using Cryptography;
using Utility;

namespace PassmanWeb.Models;
  

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
    
    public string GetHashedKey(string email)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(email));
            return Encoding.UTF8.GetString(bytes, 0, 32);
        }
    }

    public string EncryptString(string email, string plainText)
    {
        string key = GetHashedKey(email);
        byte[] iv = new byte[16];
        byte[] array;

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                    {
                        streamWriter.Write(plainText);
                    }

                    array = memoryStream.ToArray();
                }
            }
        }

        return Convert.ToBase64String(array);
    }

    public string DecryptString(string email, string cipherText)
    {
        string key = GetHashedKey(email);
        byte[] iv = new byte[16];
        byte[] buffer = Convert.FromBase64String(cipherText);

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }

}
using Passman.Models;

namespace Passman
{
    class Program
    {
        static void Main(string[] args)
        {
            // Példa key és secret
            string key = "mySecretKey123";
            string secret = "This is a secret message!";

            // Létrehozunk egy példa objektumot
            var encryptedType = new EncryptedType();

            // Titkosítás
            EncryptedType encryptedData = encryptedType.Encrypt(key, secret);
            Console.WriteLine("Titkosított kulcs (key): " + encryptedData.Key);
            Console.WriteLine("Titkosított üzenet (secret): " + encryptedData.Secret);

            // Visszafejtés
            EncryptedType decryptedData = encryptedType.Decrypt(key, encryptedData.Secret);
            Console.WriteLine("Visszafejtett üzenet (secret): " + decryptedData.Secret);
        }
    }
}
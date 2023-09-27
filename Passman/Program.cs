using Passman.Models;

namespace Passman
{
    class Program
    {
        static void Main(string[] args)
        {
            // // Példa key és secret
            // string key = "mySecretKey123";
            // string secret = "This is a secret message!";
            //
            // // Létrehozunk egy példa objektumot
            // var encryptedType = new EncryptedType();
            //
            // // Titkosítás
            // EncryptedType encryptedData = encryptedType.Encrypt(key, secret);
            // Console.WriteLine("Titkosított kulcs (key): " + encryptedData.Key);
            // Console.WriteLine("Titkosított üzenet (secret): " + encryptedData.Secret);
            //
            // // Visszafejtés
            // EncryptedType decryptedData = encryptedType.Decrypt(key, encryptedData.Secret);
            // Console.WriteLine("Visszafejtett üzenet (secret): " + decryptedData.Secret);
            
            if (args.Length > 0)
            {
                bool found = false;
                string command = args[0];
                if (command == "--register" || command == "-r")
                {
                    // Regisztrációs logika
                    Console.WriteLine("Sikeres regisztráció!");
                    found = true;
                }

                if (command == "--login" || command == "-l")
                {
                    // Bejelentkezési logika
                    Console.WriteLine("Sikeres bejelentkezés!");
                    found = true;
                }
                if (!found)
                {
                    Console.WriteLine("Ismeretlen parancs. Használat: --register vagy -r");
                }
            }
            else
            {
                Console.WriteLine("Nincs parancs megadva. Használat: --register vagy -r");
            }
        }
    }
}
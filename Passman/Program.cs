using System.Globalization;
using CsvHelper;
using Passman.Models;

namespace Passman
{
    class Program
    {
        static void Main(string[] args)
        {
            User.VaultEntryPath = Path.Combine("..", "..", "..","resources", "vault.csv");
            string userCsvPath = Path.Combine("..", "..", "..","resources", "user.csv");
            //  HATALMAS MEGAMIND ÖTLET HOGY A USERBEN A VAULTENTRY LISTET AD VISSZA
            using StreamReader reader = new StreamReader(userCsvPath);
            using CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<User>().ToList();
            var encryptedType = new EncryptedType();
            for (int i = 0; i < records.Count; i++)
            {
                if (records[i].VaultEntry.Count != 0)
                {
                    for (int j = 0; j < records[i].VaultEntry.Count; j++)
                    {
                        Console.WriteLine("Felhasználónév: " + records[i].Username + ", mentett felhasználónév: " + records[i].VaultEntry[j].Username);
                        EncryptedType decryptedData = encryptedType.Decrypt(records[i].Email, records[i].VaultEntry[j].Password);
                        Console.WriteLine("Visszafejtett üzenet (secret): " + decryptedData.Secret);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Felhasználónév: " + records[i].Username + ", nincs mentett felhasználónév.");
                }
                
            }
        }
        
        
    }
}








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
            
// parancssori argumentumok kezelése
// if (args.Length > 0)
// {
//     bool found = false;
//     string command = args[0];
//     if (command == "--register" || command == "-r")
//     {
//         // Regisztrációs logika
//         Console.WriteLine("Sikeres regisztráció!");
//         found = true;
//     }
//
//     if (command == "--login" || command == "-l")
//     {
//         // Bejelentkezési logika
//         Console.WriteLine("Sikeres bejelentkezés!");
//         found = true;
//     }
//     if (!found)
//     {
//         Console.WriteLine("Ismeretlen parancs. Használat: --register vagy -r");
//     }
// }
// else
// {
//     Console.WriteLine("Nincs parancs megadva. Használat: --register vagy -r");
// }
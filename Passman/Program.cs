using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Passman.Models;

namespace Passman
{
    class Program
    {

        static void Main(string[] args)
        {
            
            
            string userCsvPath = Path.Combine("..", "..", "..", "resources", "user.csv");
            string vaultCsvPath = Path.Combine("..", "..", "..", "resources", "vault.csv");

            if (args.Length > 0)
            {
                string command = args[0];

                if (command == "register")
                {
                    User.VaultEntryPath = Path.Combine("..", "..", "..", "resources", "vault.csv");
                    
                    bool hiba = false;
                    Console.WriteLine("Felhasználó regisztráció");
                    Console.WriteLine("Felhasználónév: ");
                    string username = Console.ReadLine();
                    if (username.Length == 0) hiba = true;

                    Console.WriteLine("Jelszó: ");
                    string password = Console.ReadLine();
                    if (password.Trim().Length == 0) hiba = true;

                    Console.WriteLine("Email: ");
                    string email = Console.ReadLine();
                    if (email.Trim().Length == 0) hiba = true;

                    Console.WriteLine("Keresztnév: ");
                    string firstName = Console.ReadLine();
                    if (firstName.Trim().Length == 0) firstName = "default";

                    Console.WriteLine("Vezetéknév: ");
                    string lastName = Console.ReadLine();
                    if (lastName.Length == 0) lastName = "default";

                    if (!hiba)
                    {
                        User new_user = new User();
                        new_user.Save(username, password, email, firstName, lastName, userCsvPath);
                        Console.WriteLine("Sikeres regisztráció!");
                    }
                    else
                    {
                        Console.WriteLine("Hiba! Nem adtál meg minden adatot! Próbáld újra!");
                    }

                }
                else if (command == "list")
                {
                    User.VaultEntryPath = Path.Combine("..", "..", "..", "resources", "vault.csv");
                    Console.WriteLine("Mentett adatok megjenítése");
                    Console.WriteLine("Az adatok megjenítéséhez add meg a felhasználónevedet és a jelszavadat!");
                    Console.WriteLine("Felhasználónév: ");
                    string username = Console.ReadLine();
                    Console.WriteLine("Jelszó: ");
                    string password = Console.ReadLine();

                    User user = new User();
                    
                    if (user.Login(username, password, userCsvPath))
                    {
                        Console.WriteLine("Sikeres bejelentkezés!");

                        Console.WriteLine("A mentett adataid: ");
                        Console.WriteLine();
                        
                        using (StreamReader reader = new(userCsvPath))
                        {
                            using CsvReader csv = new(
                                reader, CultureInfo.InvariantCulture);
                            var records = csv.GetRecords<User>().ToList();
                            
                            var encryptedType = new EncryptedType();
                            for (int i = 0; i < records.Count; i++)
                            {

                                if (records[i].Username == username)
                                {
                                    if (records[i].VaultEntry.Count != 0)
                                    {
                                        for (int j = 0; j < records[i].VaultEntry.Count; j++)
                                        {
                                            Console.WriteLine("Felhasználónév: " + records[i].VaultEntry[j].Username);
                                            EncryptedType decryptedData = encryptedType.Decrypt(records[i].Email,
                                                records[i].VaultEntry[j].Password);
                                            Console.WriteLine("Weboldal: " + records[i].VaultEntry[j].Website);
                                            Console.WriteLine("Jelszó: " + decryptedData.Secret);
                                            Console.WriteLine();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Felhasználónévhez: " + records[i].Username +
                                                          ", nincs mentett felhasználónév.");
                                    }
                                }
                            }
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hibás felhasználónév vagy jelszó!");
                    }
                }
                
                else if(command == "add")
                {
                    Console.WriteLine("Új bejlenetkezési adat hozzáadása");
                    Console.WriteLine("Az adatok hozzáadásához add meg a felhasználónevedet és a jelszavadat!");
                    Console.WriteLine("Felhasználónév: ");
                    string username = Console.ReadLine();
                    Console.WriteLine("Jelszó: ");
                    string password = Console.ReadLine();
                    
                    User user = new User();
                    
                    if (user.Login(username, password, userCsvPath))
                    {
                        Console.WriteLine("Sikeres bejelentkezés!");
                        Console.WriteLine();
                        Console.WriteLine("Új adatok megadása:");
                        Console.WriteLine("Felhasználónév: ");
                        string newUsername = Console.ReadLine();
                        Console.WriteLine("Jelszó: ");
                        string newPassword = Console.ReadLine();
                        Console.WriteLine("Weboldal: ");
                        string newWebsite = Console.ReadLine();
                        
                        User loggedInUser = user.GetUserByUsername(username, userCsvPath, true);
                        
                        
                        
                        VaultEntry newVaultEntry = new VaultEntry();
                        newVaultEntry.Save(username,loggedInUser.Email, newUsername, newPassword, newWebsite, vaultCsvPath);
                        Console.WriteLine("Sikeres hozzáadás!");
                    }
                    else
                    {
                        Console.WriteLine("Hibás felhasználónév vagy jelszó!");
                    }
                }

            }



        }
    }
}





// User.VaultEntryPath = Path.Combine("..", "..", "..","resources", "vault.csv");
// string userCsvPath = Path.Combine("..", "..", "..","resources", "user.csv");
// //  HATALMAS MEGAMIND ÖTLET HOGY A USERBEN A VAULTENTRY LISTET AD VISSZA
// using StreamReader reader = new StreamReader(userCsvPath);
// using CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
// var records = csv.GetRecords<User>().ToList();
// var encryptedType = new EncryptedType();
// for (int i = 0; i < records.Count; i++)
// {
//     if (records[i].VaultEntry.Count != 0)
//     {
//         for (int j = 0; j < records[i].VaultEntry.Count; j++)
//         {
//             Console.WriteLine("Felhasználónév: " + records[i].Username + ", mentett felhasználónév: " + records[i].VaultEntry[j].Username);
//             EncryptedType decryptedData = encryptedType.Decrypt(records[i].Email, records[i].VaultEntry[j].Password);
//             Console.WriteLine("Visszafejtett üzenet (secret): " + decryptedData.Secret);
//             Console.WriteLine();
//         }
//     }
//     else
//     {
//         Console.WriteLine("Felhasználónév: " + records[i].Username + ", nincs mentett felhasználónév.");
//     }
//                 
// }


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
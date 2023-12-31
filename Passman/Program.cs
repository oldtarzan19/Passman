﻿using System.Globalization;
using System.Reflection;
using CommandLine;
using CsvHelper;
using CsvHelper.Configuration;
using Passman.Models;
using System.IO;
using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Passman
{
    class Program
    {
        // TODO: relatv utvonalak hasznalata és csv-k
        static void Main(string[] args)
        {
            
            Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            // string congifPath = Path.Combine("..", "..", "..", "resources", "config.json");
            // AppConfig appConfig = LoadConfig(congifPath);
            
            
            // Workdir beállítása
            // if (!string.IsNullOrEmpty(appConfig.WorkDirectory))
            // {
            //     Environment.CurrentDirectory = appConfig.WorkDirectory;
            // }
            

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(options =>
                {
                    string userCsvPath = Path.Combine("..", "..", "..", "resources", "user.csv");
                    string vaultCsvPath = Path.Combine("..", "..", "..", "resources", "vault.csv");
            

                    if (args.Length > 0)
                    {
                        string command = args[0];

                        if (options.Register)
                        {
                            User.VaultEntryPath = vaultCsvPath;
                    
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
                        else if (options.List)
                        {
                            User.VaultEntryPath = vaultCsvPath;
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
                        else if(options.Add)
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
                        else if(options.Test)
                        {
                            Console.WriteLine("Tesztelés");
                            Console.WriteLine("Teszt sikeresen lefutott!");
                        }
                        else if (options.Orderby)
                        {
                            Console.WriteLine("Rendezett listázás");
                            Console.WriteLine("A listázáshoz jelentkezz be");
                            Console.WriteLine("Felhasználónév: ");
                            string username = Console.ReadLine();
                            Console.WriteLine("Jelszó: ");
                            string password = Console.ReadLine();

                            User user = new User();

                            if (user.Login(username, password, userCsvPath))
                            {
                                Console.WriteLine("Sikeres bejelentkezés");
                                Console.WriteLine("Mi alapján szeretnél listázni. (Username, Website)");
                                Console.WriteLine("Add meg: ");
                                string orderby = Console.ReadLine();

                                List<VaultEntry> allvaultEntries = new List<VaultEntry>();
                                using (StreamReader reader = new(vaultCsvPath))
                                {
                                    CsvConfiguration config = new(CultureInfo.InvariantCulture)
                                    {
                                        HasHeaderRecord = false
                                    };
                                    using CsvReader csv = new(reader, config);
                                    allvaultEntries = csv.GetRecords<VaultEntry>().ToList();
                                }
                                
                                List<VaultEntry> personalvaultEntries = new List<VaultEntry>();
                                
                                for (int i = 0; i < allvaultEntries.Count; i++)
                                {
                                    if (allvaultEntries[i].UserId == username)
                                    {
                                        personalvaultEntries.Add(allvaultEntries[i]);
                                    }
                                }

                                Console.WriteLine();

                                User felh = user.Get(username);
                                Console.WriteLine("Rendezett lista");
                                var encryptedType = new EncryptedType();
                                if (orderby == "Website")
                                {
                                    var newList = personalvaultEntries.OrderBy(x => x.Website).ToList();
                                    for (int i = 0; i < newList.Count; i++)
                                    {
                                        Console.WriteLine("Felhasználónév: " + newList[i].Username);
                                        EncryptedType decryptedData = encryptedType.Decrypt(felh.Email,
                                                         newList[i].Password);
                                        Console.WriteLine("Jelszó: " + decryptedData.Secret);
                                        Console.WriteLine("Weboldal: " + newList[i].Website);
                                        
                                        Console.WriteLine();
                                    }
                                }

                                if (orderby == "Username")
                                {
                                    var newList = personalvaultEntries.OrderBy(x => x.Username).ToList();
                                    for (int i = 0; i < newList.Count; i++)
                                    {
                                        Console.WriteLine("Felhasználónév: " + newList[i].Username);
                                        EncryptedType decryptedData = encryptedType.Decrypt(felh.Email,
                                                         newList[i].Password);
                                        Console.WriteLine("Jelszó: " + decryptedData.Secret);
                                        Console.WriteLine("Weboldal: " + newList[i].Website);

                                        Console.WriteLine();
                                    }
                                }
                            }
                        }
                        // else if(options.Workdir)
                        // {
                        //     Console.WriteLine("Munkakönyvtár módosítása");
                        //     Console.WriteLine("Add meg az új munkakönyvtárat: ");
                        //     string newWorkdir = Console.ReadLine();
                        //     AppConfig config = new AppConfig
                        //     {
                        //         WorkDirectory = newWorkdir
                        //     };
                        //
                        //     SaveConfig(congifPath, config);
                        // }
                        // else if(options.Delete)
                        // {
                        //     Console.WriteLine("Munkakönyvtár alaphelyzetbe állítása");
                        //     appConfig.WorkDirectory = "";
                        //     SaveConfig(congifPath, appConfig);
                        //     Console.WriteLine("Sikeres módosítás!");
                        // }

                    }
                });
            
        }
    }
}
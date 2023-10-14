using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace Passman.Models;

public class VaultEntry
{
    [Name("user_id")]
    public string UserId { get; set; }
    [Name("username")]
    public string Username { get; set; }
    [Name("password")]
    public string Password { get; set; }
    [Name("website")]
    public string Website { get; set; }
    
    
    public VaultEntry(string userId, string username, string password, string website)
    {
        UserId = userId;
        Username = username;
        Password = password;
        Website = website;
    }
    public VaultEntry()
    {
    }
    
    // Hibás működést okozott, ezért kikommenteltem.
    
    // public User User
    // {
    //     get
    //     {
    //         User user = new User();
    //         return user.Get(UserId);
    //     }
    // }

    public void Save(string username,string email , string newUsername, string newPassword, string newWebsite, string vaultCsvPath)
    {
        EncryptedType hashedPassword = new EncryptedType();
        
        VaultEntry new_vaultEntry = new VaultEntry(username, newUsername, hashedPassword.Encrypt(email,newPassword).Secret , newWebsite);
        
        using (StreamWriter writer = new(vaultCsvPath, append: true))
        {
            CsvConfiguration config = new(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            using CsvWriter csv = new(writer, config);
            csv.WriteRecords(new List<VaultEntry>()
            {
                new_vaultEntry
            });
        }
    }
    
    public void Delete(string vaultCsvPath, string username)
    {
        List<VaultEntry> vaultEntries = new List<VaultEntry>();
        using (StreamReader reader = new(vaultCsvPath))
        {
            CsvConfiguration config = new(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            using CsvReader csv = new(reader, config);
            vaultEntries = csv.GetRecords<VaultEntry>().ToList();
        }

        for (int i = 0; i < vaultEntries.Count; i++)
        {
            if (vaultEntries[i].Username == username)
            {
                vaultEntries.RemoveAt(i);
                i--;
            }
        }
        
        using (StreamWriter writer = new(vaultCsvPath))
        {
            CsvConfiguration config = new(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            using CsvWriter csv = new(writer, config);
            csv.WriteRecords(vaultEntries);
        }
    }
    
    // Nem befejezett metódus, ezért kikommenteltem.
   /* public void OrderBy(string item, string vaultCsvPath)
    {
        List<VaultEntry> vaultEntries = new List<VaultEntry>();
        using (StreamReader reader = new(vaultCsvPath))
        {
            CsvConfiguration config = new(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            using CsvReader csv = new(reader, config);
            vaultEntries = csv.GetRecords<VaultEntry>().ToList();
        }

        for (int i = 0; i < vaultEntries.Count; i++)
        {
            Console.WriteLine(vaultEntries[i].Website);
        }
        Console.WriteLine("Rendezeés:");
        var newList = vaultEntries.OrderBy(x => x.Website).ToList();

        for (int i = 0;i < newList.Count; i++)
        {
            Console.WriteLine(newList[i].Website);
        }
    } */
}
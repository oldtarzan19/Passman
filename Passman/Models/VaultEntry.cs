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

    public User User
    {
        get
        {
            // get user by UserId from the database
             return new User();
        }
    }

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
}
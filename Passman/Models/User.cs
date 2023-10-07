using CsvHelper.Configuration;

namespace Passman.Models;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System.Globalization;

public class User
{
    public static string? VaultEntryPath { get; set; }
    [Name("username")]
    public string Username { get; set; }
    [Name("password")]
    public string Password { get; set; }
    [Name("email")]
    public string Email { get; set; }
    [Name("firstname")]
    public string firstName { get; set; }
    [Name("lastname")]
    public string lastName { get; set; }
    
    public User(string username, string password, string email, string firstName, string lastName)
    {
        Username = username;
        Password = password;
        Email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }
    
    public User()
    {
    }

    public List<VaultEntry> VaultEntry
    {
        get
        {
            if (VaultEntryPath == null)
            {
                return null;
            }
            using StreamReader reader = new StreamReader(VaultEntryPath);
            using CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<VaultEntry>().Where(el => el.UserId == Username).ToList();
        }
    }

    public void Save(string username, string password, string email, string firstName, string lastName, string userCsvPath)
    {
        EncryptedType jelszo = new EncryptedType();
                    
        User new_user = new User(username, jelszo.Hash(password), email, firstName, lastName);
                    
        using (StreamWriter writer = new(userCsvPath, append: true))
        {
            CsvConfiguration config = new(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            using CsvWriter csv = new(writer, config);
            csv.WriteRecords(new List<User>()
            {
                new_user
            });
        }
    }

    public bool Login(string username, string password, string userCsvPath)
    {
        using StreamReader reader = new(userCsvPath);
        using CsvReader csv = new(
            reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<User>().ToList();
        EncryptedType hash = new EncryptedType();
        for (int i = 0; i < records.Count; i++)
        {
            if (records[i].Username == username && records[i].Password == hash.Hash(password))
            {
                return true;
            }
        }
        return false;
    }
    
    public User GetUserByUsername(string username, string userCsvPath, bool letezik)
    {
        User user;
        if (letezik)
        {
            using StreamReader reader = new(userCsvPath);
            using CsvReader csv = new(
                reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<User>().ToList();
            for (int i = 0; i < records.Count; i++)
            {
                if (records[i].Username == username)
                {
                    return user = new User(records[i].Username, records[i].Password, records[i].Email, records[i].firstName, records[i].lastName);
                }
            }
        }
        
        return null;
    }

    public User Get(string userId)
    {
        string userCsvPath = Path.Combine("..", "..", "..", "resources", "user.csv");
        using StreamReader reader = new(userCsvPath);
        using CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<User>().ToList();
        for (int i = 0; i < records.Count; i++)
        {
            if (records[i].Username == userId)
            {
                return new User(records[i].Username, records[i].Password, records[i].Email, records[i].firstName, records[i].lastName);
            }
        }
        return null;
    }
    
    
    public void DeleteUser(string userCsvPath, string vaultEntryCsvPath, string userId)
    {
        List<User> users = new List<User>();
        List<VaultEntry> vaultEntries = new List<VaultEntry>();

        using (StreamReader streamReader = new StreamReader(userCsvPath))
        {
            using (CsvReader csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                users = csvReader.GetRecords<User>().ToList();
            }
        }
        
        using (StreamReader streamReader = new StreamReader(vaultEntryCsvPath))
        {
            using (CsvReader csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                vaultEntries = csvReader.GetRecords<VaultEntry>().ToList();
            }
        }
        
        // Törölni a felhasználót a listából

        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].Username == userId)
            {
                users.RemoveAt(i);
                break;
            }
        }
        
        // Törölni a felhasználóhoz tartozó jelszavakat a listából
        
        for (int i = 0; i < vaultEntries.Count; i++)
        {
            if (vaultEntries[i].UserId == userId)
            {
                vaultEntries.RemoveAt(i);
                i--;
            }
        }

        using (StreamWriter streamWriter = new StreamWriter(userCsvPath))
        {
            using (CsvWriter csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(users);
            }
        }
        
        using (StreamWriter streamWriter = new StreamWriter(vaultEntryCsvPath))
        {
            using (CsvWriter csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(vaultEntries);
            }
        }
    }
}
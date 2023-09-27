namespace Passman.Models;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System.Globalization;

public class User
{
    public static string? VaultEntryPath { get; set; }
    // public string UserId { get; set; }
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
    
}
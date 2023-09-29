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
}
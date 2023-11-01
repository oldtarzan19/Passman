namespace Passman.Core.Models;

public class VaultEntry
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Website { get; set; }
    
    public VaultEntry()
    {
    }
    
    public VaultEntry(int id, int userId, string username, string password, string website)
    {
        Id = id;
        UserId = userId;
        Username = username;
        Password = password;
        Website = website;
    }
    
    public VaultEntry(int userId, string username, string password, string website)
    {
        UserId = userId;
        Username = username;
        Password = password;
        Website = website;
    }
}
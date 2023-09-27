namespace Passman.Models;

public class User
{
    public static string? VaultEntryPath { get; set; }
    public string UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
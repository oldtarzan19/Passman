namespace Passman.Models;

public class VaultEntry
{
    public string UserId { get; set; }

    public User User
    {
        get
        {
            // get user by UserId from the database
            return new User();
        }
    }
}
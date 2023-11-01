namespace Passman.Core.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public User()
    {
    }

    public User(string username, string password, string email, string firstName, string lastName)
    {
        Username = username;
        Password = password;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }
    
    public User(int id, string username, string password, string email, string firstName, string lastName)
    {
        Id = id;
        Username = username;
        Password = password;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }
}
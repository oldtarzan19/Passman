using Passman.Core.Data;
using Passman.Core.Models;
using Passman.Models;


namespace Passman.Core.dao;

public class Dao
{
    private EncryptedType encryptedType;
    // Register a new user
    public void RegisterUser(string username, string password, string email, string firstName, string lastName)
    {
        try
        {
            encryptedType = new EncryptedType();
            using var context = new PassmanDbContext();
            context.Database.EnsureCreated(); // Ensure the database and tables are created

            // Create a new User object
            var user = new User(username, encryptedType.Hash(password), email, firstName, lastName);

            // Add the new User object to the Users DbSet
            context.Users.Add(user);

            // Save the changes to the database
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    // Login a user (I have to use the EncryptedType class to encrypt the password)
    public bool LoginUser(string username, string password)
    {
        try
        {
            encryptedType = new EncryptedType();
            using var context = new PassmanDbContext();
            context.Database.EnsureCreated(); // Ensure the database and tables are created

            // Get the user from the database
            var user = context.Users.FirstOrDefault(u => u.Username == username);

            // Check if the user exists
            if (user == null)
            {
                return false;
            }

            // Check if the password is correct
            if (user.Password != encryptedType.Hash(password))
            {
                return false;
            }

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
}
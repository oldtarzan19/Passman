using Passman.Core.Data;
using Passman.Core.Models;


namespace Passman.Core.dao;

public class Dao
{
    // Register a new user
    public void RegisterUser(string username, string password, string email, string firstName, string lastName)
    {
        try
        {
            using var context = new PassmanDbContext();
            context.Database.EnsureCreated(); // Ensure the database and tables are created

            // Create a new User object
            var user = new User(username, password, email, firstName, lastName);

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
}
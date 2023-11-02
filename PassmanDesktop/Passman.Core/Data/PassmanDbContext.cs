using Microsoft.EntityFrameworkCore;
using Passman.Core.Models;

namespace Passman.Core.Data;

public class PassmanDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<VaultEntry> VaultEntries { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        //var databasePath = Path.Combine(Directory.GetCurrentDirectory() + "/res", "passman.db");
        //var databasePath = "PassmanDesktop/Passman.Core/res/passman.db";
        // I want to use the path from the solution root, but I don't know how to do it.
        var databasePath = Path.Combine("..","Passman.Core", "res", "passman.db");
        options.UseSqlite($"Data Source={databasePath}");
    }
}
using Microsoft.EntityFrameworkCore;
using PassmanWeb.Models;

namespace PassmanWeb.Controllers;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<VaultEntry> VaultEntries { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
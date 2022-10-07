using EFContext.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EFContext.Infrastructure;
public class DBContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ContactLocation> ContactLocations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .EnableSensitiveDataLogging()
            .UseSqlServer(@"");
    }

    public async Task<Contact> GetContactById(Guid contactId) => default;

    public async Task<IList<Contact>> GetContacts() => await default(Task<IList<Contact>>);
}

public static class DBContextExtension
{
    public static async Task<bool> IsNotFound(this Task<Contact> contact)
    {
        return await contact == null;
    }
}
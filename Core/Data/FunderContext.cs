using jwt_funder.Models;
using Microsoft.EntityFrameworkCore;

namespace jwt_funder.Core.Data;

public class FunderContext(DbContextOptions<FunderContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasConversion<string>();
    }

}
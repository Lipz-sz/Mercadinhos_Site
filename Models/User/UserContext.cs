using MarketplaceAPI.Models; //User //AuthUser
using Microsoft.EntityFrameworkCore;

namespace MarketplaceAPI.Models; //UserContext


public class UserContext(DbContextOptions<UserContext> options) : DbContext(options){
    public DbSet<User> Users {get; set;}
    public DbSet<AuthUser> AuthUsers {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
        .HasMany(a => a.Auths)
        .WithOne(b => b.User).HasForeignKey(c => c.UserId);
    }
}
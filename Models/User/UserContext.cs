using MarketplaceAPI.Models; //User //AuthUser
using Microsoft.EntityFrameworkCore;

namespace MarketplaceAPI.Models.User; //UserContext


public class UserContext(DbContextOptions<UserContext> options) : DbContext(options){
    public DbSet<UserDTO> Users {get; set;}
    public DbSet<AuthUser> AuthUsers {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDTO>()
        .HasMany(a => a.Auths)
        .WithOne(b => b.UserProfile).HasForeignKey(c => c.UserId);
    }
}
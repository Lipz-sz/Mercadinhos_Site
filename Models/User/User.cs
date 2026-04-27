using MarketplaceAPI.Models;
namespace MarketplaceAPI.Models.User;

public class UserProfile
{
    public long Id {get; set;}
    public string? Username {get; set;} = "Your Username";
    public Role Role {get; set;}
    public DateTime Creat_at {get; private set;} = DateTime.Today;
    public ICollection<AuthUser> Auths {get; set;} = [];
    public string? SecretInternal {get; private set;} = "007";
}

public enum Role
{
    Basic_User,
    Seller_User,
    Moderation_User
}
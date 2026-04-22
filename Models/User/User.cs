using MarketplaceAPI.Models;
namespace MarketplaceAPI.Models;

public class User
{
    public long Id {get; private set;}
    public string? Username {get; set;} = "Your Username";
    public Role Role {get; set;}
    public DateTime Creat_at {get; private set;} = DateTime.Today;
    public ICollection<AuthUser> Auths {get; set;} = new List<AuthUser>();
    public string? SecretInternal {get; set;}
}

public enum Role
{
    Basic_User,
    Seller_User,
    Moderation_User
}
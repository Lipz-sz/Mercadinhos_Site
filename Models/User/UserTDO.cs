using MarketplaceAPI.Models;
namespace MarketplaceAPI.Models;

public class UserTDO
{
    public long Id {get; private set;}
    public string? Username {get; set;} = "Your Username";
    public string? Role {get; set;} = "Basic User";
    public DateTime CreateAt {get; private set;} = DateTime.UtcNow;

    public ICollection<AuthUser> Auths {get; set;} = new List<AuthUser>();
}
using MarketplaceAPI.Models.User;

namespace MarketplaceAPI.Models.User;

public class AuthUser
{
    public long Id {get; set;}

    public long UserId { get; set; }
    public UserProfile UserProfile { get; set;} = null!;
    public string? Email {get; set;}
    public string? Passoword {get; set;}
    public TypeLogin Type {get; set;}
}

public enum TypeLogin
{
    Email,
    Goolge
}


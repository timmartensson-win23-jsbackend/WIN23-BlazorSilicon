using BlazorWebApp.Data;

namespace BlazorWebApp.Models;

public class CascadingUser
{
    public ApplicationUser AppUser { get; set; } = null!;
    public UserProfile UserProfile { get; set; } = null!;
    public UserAddress UserAddress { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
}

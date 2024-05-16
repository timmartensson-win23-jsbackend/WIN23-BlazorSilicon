using BlazorWebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebApp.Services;

public class UserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ApplicationUser> GetCurrentUserAsync(HttpContext context)
    {
        var user = await _userManager.Users
            .Include(x => x.UserProfile)
            .Include(x => x.UserAddress)
            .FirstOrDefaultAsync(x => x.Email == context.User.Identity!.Name);
        if (user != null)
        {
            return user;
        }
        return null!;
    }
}

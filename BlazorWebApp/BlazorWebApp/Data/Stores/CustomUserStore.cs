using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebApp.Data.Stores;

public class CustomUserStore : UserStore<ApplicationUser>
{
    public CustomUserStore(IDbContextFactory<ApplicationDbContext> contextFactory) : base(contextFactory.CreateDbContext())
    {
    }
}

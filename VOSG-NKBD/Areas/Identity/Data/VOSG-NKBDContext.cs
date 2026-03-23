using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VOSG_NKBD.Models;

namespace VOSG_NKBD.Data;

public class VOSG_NKBDContext : IdentityDbContext<IdentityUser>
{
    public VOSG_NKBDContext(DbContextOptions<VOSG_NKBDContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<VOSG_NKBD.Models.Movie> Movie { get; set; } = default!;
}

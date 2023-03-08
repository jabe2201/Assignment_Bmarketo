using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebShop.Models.Identity;

namespace WebShop.Context
{
    public class IdentityContext : IdentityDbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }
        public DbSet<IdentityUserProfile> Profiles { get; set; }
    }
}

using Derivco.GameRoulette.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Derivco.GameRoulette.Identity.DbContext
{
    public class DerivcoIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public DerivcoIdentityDbContext(DbContextOptions<DerivcoIdentityDbContext> options)
            : base(options)
        {
        }

        //Method to cede in some roles and assign users to the roles
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(DerivcoIdentityDbContext).Assembly);
        }
    }
}

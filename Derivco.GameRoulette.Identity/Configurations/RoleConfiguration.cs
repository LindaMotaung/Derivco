using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Derivco.GameRoulette.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
               new IdentityRole
               {
                   Id = "f13852d3-5b67-4ec0-8d5c-6ca350060fc0", //These static guid values will not be changed with every migration
                   Name = "Bettor",
                   NormalizedName = "BETTOR"
               },
               new IdentityRole
               {
                   Id = "c144a600-c3fa-4c55-b437-18f31ca1f21e",
                   Name = "Administrator",
                   NormalizedName = "ADMINISTRATOR"
               }
           );
        }
    }
}

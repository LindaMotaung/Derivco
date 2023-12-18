using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Derivco.GameRoulette.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "b7591523-42df-4908-a3de-0b3378d0c43f",
                    UserId = "2cc04dd0-2989-4415-8354-a4e2c925ce23"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "a768f38e-8a1d-4080-993f-ed865d5a4d5e",
                    UserId = "2545f45d-4892-4bae-b1b5-9b2b9eacd7cc"
                }
            );
        }
    }
}

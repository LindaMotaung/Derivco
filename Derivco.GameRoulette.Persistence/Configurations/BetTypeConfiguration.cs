using Derivco.GameRoulette.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Derivco.GameRoulette.Persistence.Configurations
{
    public class BetTypeConfiguration : IEntityTypeConfiguration<BetType>
    {
        public void Configure(EntityTypeBuilder<BetType> builder)
        {
            builder.HasData(
                new BetType
                {
                    Id = 1,
                    Name = "Inside Bet",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                }
            );

            builder.Property(q => q.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}

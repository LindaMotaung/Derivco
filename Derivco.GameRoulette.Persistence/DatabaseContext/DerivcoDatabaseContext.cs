using Derivco.GameRoulette.Application.Contracts.Identity;
using Derivco.GameRoulette.Domain;
using Derivco.GameRoulette.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Persistence.DatabaseContext
{
    public class DerivcoDatabaseContext : DbContext
    {
        private readonly IUserService _userService;

        public DerivcoDatabaseContext(DbContextOptions<DerivcoDatabaseContext> options, IUserService userService) : base(options)
        {
            this._userService = userService;
        }
        public DbSet<BetType> BetTypes { get; set; } //DerivcoDatabaseContext will know about a table that is modelled from this BetType class 
        public DbSet<BetAllocation> BetAllocations { get; set; }
        public DbSet<BetRequest> BetRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DerivcoDatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;
                entry.Entity.ModifiedBy = _userService.BettorId;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedBy = _userService.BettorId;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
using Derivco.GameRoulette.Application.Contracts.Persistence;
using Derivco.GameRoulette.Domain;
using Derivco.GameRoulette.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Persistence.Repositories
{
    public class BetAllocationRepository : GenericRepository<BetAllocation>, IBetAllocationRepository
    {
        public BetAllocationRepository(DerivcoDatabaseContext context) : base(context)
        {
        }

        public async Task AddAllocations(List<BetAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AllocationExists(string bettorId, int betTypeId)
        {
            return await _context.BetAllocations.AnyAsync(q => q.BettorId == bettorId
                                        && q.BetTypeId == betTypeId);
        }
        public async Task<List<BetAllocation>> GetBetAllocationsWithDetails()
        {
            var betAllocations = await _context.BetAllocations
               .Include(q => q.BetType)
               .ToListAsync();
            return betAllocations;
        }

        public async Task<List<BetAllocation>> GetBetAllocationsWithDetails(string bettorId)
        {
            var betAllocations = await _context.BetAllocations.Where(q => q.BettorId == bettorId)
               .Include(q => q.BetType)
               .ToListAsync();
            return betAllocations;
        }

        public async Task<BetAllocation> GetBetAllocationWithDetails(int id)
        {
            var betAllocation = await _context.BetAllocations
                .Include(q => q.BetType)
                .FirstOrDefaultAsync(q => q.Id == id);

            return betAllocation;
        }

        public async Task<BetAllocation> GetBettorAllocations(string bettorId, int betTypeId)
        {
            return await _context.BetAllocations.FirstOrDefaultAsync(q => q.BettorId == bettorId
                                        && q.BetTypeId == betTypeId);
        }
    }
}

using Derivco.GameRoulette.Application.Contracts.Persistence;
using Derivco.GameRoulette.Domain;
using Derivco.GameRoulette.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Persistence.Repositories
{
    public class BetRequestRepository : GenericRepository<BetRequest>, IBetRequestRepository
    {
        public BetRequestRepository(DerivcoDatabaseContext context) : base(context)
        {
        }

        public async Task<List<BetRequest>> GetBetRequestsWithDetails()
        {
            var betRequests = await _context.BetRequests
                .Where(q => !string.IsNullOrEmpty(q.RequestingBettorId))
                .Include(q => q.BetType)
                .ToListAsync();
            return betRequests;
        }

        public async Task<List<BetRequest>> GetBetRequestsWithDetails(string bettorId)
        {
            var betRequests = await _context.BetRequests
               .Where(q => q.RequestingBettorId == bettorId)
               .Include(q => q.BetType)
               .ToListAsync();
            return betRequests;
        }

        public async Task<BetRequest> GetBetRequestWithDetails(int id)
        {
            var betRequest = await _context.BetRequests
                .Include(q => q.BetType)
                .FirstOrDefaultAsync(q => q.Id == id);

            return betRequest;
        }
    }
}

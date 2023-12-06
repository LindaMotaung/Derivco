using System.Collections.Generic;
using System.Threading.Tasks;
using Derivco.GameRoulette.Domain;

namespace Derivco.GameRoulette.Application.Contracts.Persistence
{
    public interface IBetRequestRepository : IGenericRepository<BetRequest>
    {
        Task<BetRequest> GetBetRequestWithDetails(int id);
        Task<List<BetRequest>> GetBetRequestsWithDetails();
        Task<List<BetRequest>> GetBetRequestsWithDetails(string bettorId);
    }
}

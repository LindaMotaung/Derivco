using Derivco.GameRoulette.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Application.Contracts.Persistence
{
    public interface IBetAllocationRepository : IGenericRepository<BetAllocation>
    {
        Task<BetAllocation> GetBetAllocationWithDetails(int id);
        Task<List<BetAllocation>> GetBetAllocationsWithDetails();
        Task<List<BetAllocation>> GetBetAllocationsWithDetails(string bettorId);
        Task<bool> AllocationExists(string bettorId, int betTypeId);
        Task AddAllocations(List<BetAllocation> allocations);
        Task<BetAllocation> GetBettorAllocations(string bettorId, int betTypeId);
    }
}

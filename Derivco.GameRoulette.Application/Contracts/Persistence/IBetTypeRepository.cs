using System.Threading.Tasks;
using Derivco.GameRoulette.Domain;

namespace Derivco.GameRoulette.Application.Contracts.Persistence
{
    public interface IBetTypeRepository : IGenericRepository<BetType>
    {
        Task<bool> IsBetTypeUnique(string name);
    }
}

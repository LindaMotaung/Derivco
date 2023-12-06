using Derivco.GameRoulette.Application.Contracts.Persistence;
using Derivco.GameRoulette.Domain;
using Derivco.GameRoulette.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Persistence.Repositories
{
    public class BetTypeRepository : GenericRepository<BetType>, IBetTypeRepository
    {
        public BetTypeRepository(DerivcoDatabaseContext context) : base(context)
        {

        }

        public async Task<bool> IsBetTypeUnique(string name)
        {
            return await _context.BetTypes.AnyAsync(q => q.Name == name) == false;
        }
    }
}

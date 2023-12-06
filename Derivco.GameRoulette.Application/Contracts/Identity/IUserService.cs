using Derivco.GameRoulette.Application.Models.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Bettor>> GetBettors();
        Task<Bettor> GetBettor(string bettorId);
        public string BettorId { get; }
    }
}

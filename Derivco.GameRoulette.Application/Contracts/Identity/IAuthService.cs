using Derivco.GameRoulette.Application.Models.Identity;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}

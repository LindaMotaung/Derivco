using Derivco.GameRoulette.Application.Contracts.Identity;
using Derivco.GameRoulette.Application.Models.Identity;
using Derivco.GameRoulette.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public string BettorId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }

        public async Task<Bettor> GetBettor(string bettorId)
        {
            var bettor = await _userManager.FindByIdAsync(bettorId);
            return new Bettor
            {
                Email = bettor.Email,
                Id = bettor.Id,
                Firstname = bettor.FirstName,
                Lastname = bettor.LastName
            };
        }

        public async Task<List<Bettor>> GetBettors()
        {
            var bettors = await _userManager.GetUsersInRoleAsync("Bettor"); //Get users with the role "Bettor"
            return bettors.Select(q => new Bettor
            {
                Id = q.Id,
                Email = q.Email,
                Firstname = q.FirstName,
                Lastname = q.LastName
            }).ToList();
        }
    }
}

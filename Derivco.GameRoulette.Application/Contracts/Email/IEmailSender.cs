using Derivco.GameRoulette.Application.Models.Email;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailMessage email);
    }
}

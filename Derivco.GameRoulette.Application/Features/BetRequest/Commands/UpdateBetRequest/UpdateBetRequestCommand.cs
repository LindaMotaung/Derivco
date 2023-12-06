using Derivco.GameRoulette.Application.Features.BetRequest.Shared;
using MediatR;

namespace Derivco.GameRoulette.Application.Features.BetRequest.Commands.UpdateBetRequest
{
    public class UpdateBetRequestCommand : BaseBetRequest, IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

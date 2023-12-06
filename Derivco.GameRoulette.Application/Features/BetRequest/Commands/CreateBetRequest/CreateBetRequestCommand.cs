using Derivco.GameRoulette.Application.Features.BetRequest.Shared;
using MediatR;

namespace Derivco.GameRoulette.Application.Features.BetRequest.Commands.CreateBetRequest
{
    public class CreateBetRequestCommand : BaseBetRequest, IRequest<Unit>
    {
    }
}

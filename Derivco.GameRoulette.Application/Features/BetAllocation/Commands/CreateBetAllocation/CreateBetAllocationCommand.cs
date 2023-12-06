using MediatR;

namespace Derivco.GameRoulette.Application.Features.BetAllocation.Commands.CreateBetAllocation
{
    public class CreateBetAllocationCommand : IRequest<Unit>
    {
        public int BetTypeId { get; set; }
    }
}

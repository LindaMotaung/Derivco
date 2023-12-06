using MediatR;

namespace Derivco.GameRoulette.Application.Features.BetAllocation.Commands.UpdateBetAllocation
{
    public class UpdateBetAllocationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int NumberOfBets { get; set; }
        public int BetTypeId { get; set; }
    }
}

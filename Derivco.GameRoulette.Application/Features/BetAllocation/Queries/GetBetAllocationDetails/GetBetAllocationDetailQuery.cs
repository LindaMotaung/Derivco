using MediatR;

namespace Derivco.GameRoulette.Application.Features.BetAllocation.Queries.GetBetAllocationDetails
{
    public class GetBetAllocationDetailQuery : IRequest<BetAllocationDetailsDto>
    {
        public int Id { get; set; }
    }
}

using MediatR;

namespace Derivco.GameRoulette.Application.Features.BetRequest.Queries.GetBetRequestDetail
{
    public class GetBetRequestDetailQuery : IRequest<BetRequestDetailsDto>
    {
        public int Id { get; set; }
    }
}

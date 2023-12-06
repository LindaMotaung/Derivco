using MediatR;

namespace Derivco.GameRoulette.Application.Features.BetType.Queries.GetBetTypeDetails
{
    public class GetBetTypeDetailsQuery : IRequest<BetTypeDetailsDto>
    {
        public GetBetTypeDetailsQuery(int id) { }
    }
}

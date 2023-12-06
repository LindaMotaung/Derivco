using MediatR;
using System.Collections.Generic;

namespace Derivco.GameRoulette.Application.Features.BetRequest.Queries.GetBetRequestsList
{
    public class GetBetRequestListQuery : IRequest<List<BetRequestListDto>>
    {
        public bool IsLoggedInBettor { get; set; }
    }
}

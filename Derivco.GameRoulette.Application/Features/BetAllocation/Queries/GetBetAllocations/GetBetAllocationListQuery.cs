using MediatR;
using System.Collections.Generic;

namespace Derivco.GameRoulette.Application.Features.BetAllocation.Queries.GetBetAllocations
{
    public class GetBetAllocationListQuery : IRequest<List<BetAllocationDto>>
    {
    }
}

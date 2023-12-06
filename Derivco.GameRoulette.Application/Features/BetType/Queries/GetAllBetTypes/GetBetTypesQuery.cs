using MediatR;
using System.Collections.Generic;

namespace Derivco.GameRoulette.Application.Features.BetType.Queries.GetAllBetTypes
{
    public class GetBetTypesQuery : IRequest<List<BetTypeDto>>
    {
    }
}

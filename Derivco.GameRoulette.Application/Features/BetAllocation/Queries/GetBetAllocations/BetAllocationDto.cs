using Derivco.GameRoulette.Application.Features.BetType.Queries.GetAllBetTypes;

namespace Derivco.GameRoulette.Application.Features.BetAllocation.Queries.GetBetAllocations
{
    public class BetAllocationDto
    {
        public int Id { get; set; }
        public int NumberOfBets { get; set; }
        public BetTypeDto BetTypeType { get; set; }
        public int BetTypeId { get; set; }
    }
}

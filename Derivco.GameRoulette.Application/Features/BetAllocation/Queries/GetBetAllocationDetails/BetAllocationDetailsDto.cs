using Derivco.GameRoulette.Application.Features.BetType.Queries.GetAllBetTypes;

namespace Derivco.GameRoulette.Application.Features.BetAllocation.Queries.GetBetAllocationDetails
{
    public class BetAllocationDetailsDto
    {
        public int Id { get; set; }
        public int NumberOfBets { get; set; }
        public BetTypeDto BetType { get; set; }
        public int BetTypeId { get; set; }
    }
}

using Derivco.GameRoulette.Domain.Common;

namespace Derivco.GameRoulette.Domain
{
    public class BetAllocation : BaseEntity
    {
        public int NumberOfBets { get; set; }
        public BetType? BetType { get; set; }
        public int BetTypeId { get; set; }
        public string BettorId { get; set; } = string.Empty;
    }
}

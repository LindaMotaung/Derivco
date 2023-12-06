using Derivco.GameRoulette.Domain.Common;

namespace Derivco.GameRoulette.Domain
{
    /// <summary>
    /// Class to facilitate the placing of bets
    /// </summary>
    public class BetRequest : BaseEntity
    {
        public BetType? BetType { get; set; }
        public int BetTypeId { get; set; }
        public int BetAmount { get; set; }
        public bool? Won { get; set; } //Dealer determines if the player won
        public bool Lost { get; set; }
        public string RequestingBettorId { get; set; } = string.Empty;
    }
}

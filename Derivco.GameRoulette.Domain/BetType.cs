using Derivco.GameRoulette.Domain.Common;

namespace Derivco.GameRoulette.Domain
{
    /// <summary>
    /// 1. Inside bets
    /// 2. Outside bets
    /// 3. Call bets
    /// 4. Neighbour bets
    /// 5. Special bets
    /// </summary>
    public class BetType : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}

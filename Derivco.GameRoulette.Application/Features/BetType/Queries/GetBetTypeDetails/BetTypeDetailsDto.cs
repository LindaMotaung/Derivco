using System;

namespace Derivco.GameRoulette.Application.Features.BetType.Queries.GetBetTypeDetails
{
    public class BetTypeDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}

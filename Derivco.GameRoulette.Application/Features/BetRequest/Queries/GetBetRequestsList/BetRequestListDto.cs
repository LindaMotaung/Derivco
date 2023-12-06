using Derivco.GameRoulette.Application.Features.BetType.Queries.GetAllBetTypes;
using Derivco.GameRoulette.Application.Models.Identity;
using System;

namespace Derivco.GameRoulette.Application.Features.BetRequest.Queries.GetBetRequestsList
{
    public class BetRequestListDto
    {
        public int Id { get; set; }
        public Bettor Bettor { get; set; }
        public string RequestingBettorId { get; set; }
        public BetTypeDto BetType { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Won { get; set; }
        public bool? Lost { get; set; }
    }
}

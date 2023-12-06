using AutoMapper;
using Derivco.GameRoulette.Application.Features.BetAllocation.Commands.CreateBetAllocation;
using Derivco.GameRoulette.Application.Features.BetAllocation.Commands.UpdateBetAllocation;
using Derivco.GameRoulette.Application.Features.BetAllocation.Queries.GetBetAllocationDetails;
using Derivco.GameRoulette.Application.Features.BetAllocation.Queries.GetBetAllocations;
using Derivco.GameRoulette.Domain;

namespace Derivco.GameRoulette.Application.MappingProfiles
{
    public class BetAllocationProfile : Profile
    {
        public BetAllocationProfile()
        {
            CreateMap<BetAllocationDto, BetAllocation>().ReverseMap();
            CreateMap<BetAllocation, BetAllocationDetailsDto>();
            CreateMap<CreateBetAllocationCommand, BetAllocation>();
            CreateMap<UpdateBetAllocationCommand, BetAllocation>();
        }
    }
}

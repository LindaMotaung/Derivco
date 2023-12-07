using AutoMapper;
using Derivco.GameRoulette.Application.Features.BetRequest.Commands.CreateBetRequest;
using Derivco.GameRoulette.Application.Features.BetRequest.Commands.UpdateBetRequest;
using Derivco.GameRoulette.Application.Features.BetRequest.Queries.GetBetRequestDetail;
using Derivco.GameRoulette.Application.Features.BetRequest.Queries.GetBetRequestsList;
using Derivco.GameRoulette.Domain;

namespace Derivco.GameRoulette.Application.MappingProfiles
{
    public class BetRequestProfile : Profile
    {
        public BetRequestProfile() 
        {
            CreateMap<BetRequestListDto, BetRequest>().ReverseMap();
            CreateMap<BetRequestDetailsDto, BetRequest>().ReverseMap();
            CreateMap<BetRequest, BetRequestDetailsDto>();
            CreateMap<CreateBetRequestCommand, BetRequest>();
            CreateMap<UpdateBetRequestCommand, BetRequest>();
        }
    }
}

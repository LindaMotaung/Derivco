using AutoMapper;
using Derivco.GameRoulette.Application.Features.BetType.Commands.CreateBetType;
using Derivco.GameRoulette.Application.Features.BetType.Commands.UpdateBetType;
using Derivco.GameRoulette.Application.Features.BetType.Queries.GetAllBetTypes;
using Derivco.GameRoulette.Application.Features.BetType.Queries.GetBetTypeDetails;
using Derivco.GameRoulette.Domain;

namespace Derivco.GameRoulette.Application.MappingProfiles
{
    public class BetTypeProfile : Profile
    {
        public BetTypeProfile()
        {
            CreateMap<BetTypeDto, BetType>().ReverseMap();
            CreateMap<BetType, BetTypeDetailsDto>();
            CreateMap<CreateBetTypeCommand, BetType>();
            CreateMap<UpdateBetTypeCommand, BetType>();
        }
    }
}

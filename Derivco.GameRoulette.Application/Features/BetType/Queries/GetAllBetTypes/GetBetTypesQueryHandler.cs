using AutoMapper;
using Derivco.GameRoulette.Application.Contracts.Logging;
using Derivco.GameRoulette.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Application.Features.BetType.Queries.GetAllBetTypes
{
    public class GetBetTypesQueryHandler : IRequestHandler<GetBetTypesQuery, List<BetTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBetTypeRepository _BetTypeRepository;
        private readonly IAppLogger<GetBetTypesQueryHandler> _logger;

        public GetBetTypesQueryHandler(IMapper mapper,
            IBetTypeRepository BetTypeRepository,
            IAppLogger<GetBetTypesQueryHandler> logger)
        {
            this._mapper = mapper;
            this._BetTypeRepository = BetTypeRepository;
            this._logger = logger;
        }

        public async Task<List<BetTypeDto>> Handle(GetBetTypesQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var betTypes = await _BetTypeRepository.GetAsync();

            // convert data objects to DTO objects
            var data = _mapper.Map<List<BetTypeDto>>(betTypes);

            // return list of DTO object
            _logger.LogInformation("Bet types were retrieved successfully");
            return data;
        }
    }
}

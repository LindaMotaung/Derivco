using AutoMapper;
using Derivco.GameRoulette.Application.Contracts.Persistence;
using Derivco.GameRoulette.Application.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Application.Features.BetType.Commands.CreateBetType
{
    public class CreateBetTypeCommandHandler : IRequestHandler<CreateBetTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IBetTypeRepository _betTypeRepository;

        public CreateBetTypeCommandHandler(IMapper mapper, IBetTypeRepository betTypeRepository) 
        {
            _mapper = mapper;
            _betTypeRepository = betTypeRepository;
        }

        public async Task<int> Handle(CreateBetTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateBetTypeCommandValidator(_betTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Bet type", validationResult);

            // convert to domain entity object
            var betTypeToCreate = _mapper.Map<Domain.BetType>(request);

            // add to database
            await _betTypeRepository.CreateAsync(betTypeToCreate);

            // retun record id
            return betTypeToCreate.Id;
        }
    }
}

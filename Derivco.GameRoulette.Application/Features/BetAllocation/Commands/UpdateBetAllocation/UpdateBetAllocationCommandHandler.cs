using AutoMapper;
using Derivco.GameRoulette.Application.Contracts.Persistence;
using Derivco.GameRoulette.Application.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Application.Features.BetAllocation.Commands.UpdateBetAllocation
{
    public class UpdateBetAllocationCommandHandler : IRequestHandler<UpdateBetAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IBetTypeRepository _betTypeRepository;
        private readonly IBetAllocationRepository _betAllocationRepository;

        public UpdateBetAllocationCommandHandler(IMapper mapper,
            IBetTypeRepository betTypeRepository,
            IBetAllocationRepository betAllocationRepository) 
        {
            _mapper = mapper;
            this._betTypeRepository = betTypeRepository;
            this._betAllocationRepository = betAllocationRepository;
        }

        public async Task<Unit> Handle(UpdateBetAllocationCommand request, CancellationToken cancellationToken) 
        {
            var validator = new UpdateBetAllocationDtoValidator(_betTypeRepository, _betAllocationRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Bet Allocation", validationResult);

            var betAllocation = await _betAllocationRepository.GetByIdAsync(request.Id);

            if (betAllocation is null)
                throw new NotFoundException(nameof(BetAllocation), request.Id);

            _mapper.Map(request, betAllocation);

            await _betAllocationRepository.UpdateAsync(betAllocation);
            return Unit.Value;
        }
    }
}

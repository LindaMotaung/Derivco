using AutoMapper;
using Derivco.GameRoulette.Application.Contracts.Identity;
using Derivco.GameRoulette.Application.Contracts.Persistence;
using Derivco.GameRoulette.Application.Exceptions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Application.Features.BetAllocation.Commands.CreateBetAllocation
{
    public class CreateBetAllocationCommandHandler : IRequestHandler<CreateBetAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IBetAllocationRepository _betAllocationRepository;
        private readonly IBetTypeRepository _betTypeRepository;
        private readonly IUserService _userService;

        public CreateBetAllocationCommandHandler(IMapper mapper,
           IBetAllocationRepository betAllocationRepository, IBetTypeRepository betTypeRepository,
           IUserService userService)
        {
            _mapper = mapper;
            this._betAllocationRepository = betAllocationRepository;
            this._betTypeRepository = betTypeRepository;
            this._userService = userService;
        }

        public async Task<Unit> Handle(CreateBetAllocationCommand request, CancellationToken cancellationToken) 
        {
            var validator = new CreateBetAllocationCommandValidator(_betTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Bet Allocation Request", validationResult);

            // Get Bet type for allocations
            var betType = await _betTypeRepository.GetByIdAsync(request.BetTypeId);

            // Get Bettors
            var bettors = await _userService.GetBettors();

            //Assign Allocations IF an allocation doesn't already exist for the bet type
            var allocations = new List<Domain.BetAllocation>();
            foreach (var bettr in bettors) 
            {
                var allocationExists = await _betAllocationRepository.AllocationExists(bettr.Id, request.BetTypeId);

                if (allocationExists == false)
                {
                    allocations.Add(new Domain.BetAllocation
                    {
                        BettorId = bettr.Id,
                        BetTypeId = betType.Id,
                        NumberOfBets = 0,
                    });
                }
            }

            if (allocations.Any())
            {
                await _betAllocationRepository.AddAllocations(allocations);
            }

            return Unit.Value;
        }
    }
}

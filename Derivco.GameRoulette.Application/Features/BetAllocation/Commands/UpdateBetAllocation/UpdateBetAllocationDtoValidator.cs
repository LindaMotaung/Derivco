using FluentValidation;
using Derivco.GameRoulette.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Application.Features.BetAllocation.Commands.UpdateBetAllocation
{
    public class UpdateBetAllocationDtoValidator : AbstractValidator<UpdateBetAllocationCommand>
    {
        private readonly IBetTypeRepository _betTypeRepository;
        private readonly IBetAllocationRepository _betAllocationRepository;

        public UpdateBetAllocationDtoValidator(
            IBetTypeRepository betTypeRepository,
            IBetAllocationRepository betAllocationRepository)
        {
            _betTypeRepository = betTypeRepository;
            this._betAllocationRepository = betAllocationRepository;
            RuleFor(p => p.NumberOfBets)
                .GreaterThan(0).WithMessage("{PropertyName} must greater than {ComparisonValue}");

            RuleFor(p => p.BetTypeId)
              .GreaterThan(0)
              .MustAsync(BetTypeMustExist)
              .WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p.Id)
            .NotNull()
            .MustAsync(BetAllocationMustExist)
            .WithMessage("{PropertyName} must be present");
        }

        private async Task<bool> BetAllocationMustExist(int id, CancellationToken arg2)
        {
            var betAllocation = await _betAllocationRepository.GetByIdAsync(id);
            return betAllocation != null;
        }

        private async Task<bool> BetTypeMustExist(int id, CancellationToken arg2)
        {
            var betType = await _betTypeRepository.GetByIdAsync(id);
            return betType != null;
        }
    }
}

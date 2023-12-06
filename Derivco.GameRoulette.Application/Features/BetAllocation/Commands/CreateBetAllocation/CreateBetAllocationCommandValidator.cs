using FluentValidation;
using Derivco.GameRoulette.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.Application.Features.BetAllocation.Commands.CreateBetAllocation
{
    public class CreateBetAllocationCommandValidator : AbstractValidator<CreateBetAllocationCommand>
    {
        private readonly IBetTypeRepository _betTypeRepository;

        public CreateBetAllocationCommandValidator(IBetTypeRepository betTypeRepository) 
        {
            _betTypeRepository = betTypeRepository;

            RuleFor(p => p.BetTypeId)
               .GreaterThan(0)
               .MustAsync(BetTypeMustExist)
               .WithMessage("{PropertyName} does not exist.");
        }

        private async Task<bool> BetTypeMustExist(int id, CancellationToken arg2)
        {
            var BetType = await _betTypeRepository.GetByIdAsync(id);
            return BetType != null;
        }
    }
}

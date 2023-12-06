using FluentValidation;
using Derivco.GameRoulette.Application.Contracts.Persistence;
using System.Threading.Tasks;
using System.Threading;

namespace Derivco.GameRoulette.Application.Features.BetType.Commands.CreateBetType
{
    public class CreateBetTypeCommandValidator : AbstractValidator<CreateBetTypeCommand>
    {
        private readonly IBetTypeRepository _betTypeRepository;

        public CreateBetTypeCommandValidator(IBetTypeRepository betTypeRepository)
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");


            RuleFor(q => q)
                .MustAsync(BetTypeNameUnique)
                .WithMessage("Bet type already exists");


            this._betTypeRepository = betTypeRepository;
        }

        private Task<bool> BetTypeNameUnique(CreateBetTypeCommand command, CancellationToken token)
        {
            return _betTypeRepository.IsBetTypeUnique(command.Name);
        }
    }
}

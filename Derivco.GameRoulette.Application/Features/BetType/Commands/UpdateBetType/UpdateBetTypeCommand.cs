using MediatR;

namespace Derivco.GameRoulette.Application.Features.BetType.Commands.UpdateBetType
{
    public class UpdateBetTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}

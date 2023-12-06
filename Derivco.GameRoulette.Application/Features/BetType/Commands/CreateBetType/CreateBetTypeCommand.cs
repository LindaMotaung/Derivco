using MediatR;

namespace Derivco.GameRoulette.Application.Features.BetType.Commands.CreateBetType
{
    public class CreateBetTypeCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
    }
}

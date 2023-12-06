using AutoMapper;
using Derivco.GameRoulette.Application.Contracts.Persistence;
using Derivco.GameRoulette.Application.Features.BetType.Commands.CreateBetType;
using Derivco.GameRoulette.Application.MappingProfiles;
using Derivco.GameRoulette.UnitTests.Mocks;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Derivco.GameRoulette.UnitTests.Features.Commands
{
    public class CreateBetTypeCommandTests
    {
        private readonly IMapper _mapper;
        private Mock<IBetTypeRepository> _mockRepo;

        public CreateBetTypeCommandTests()
        {
            _mockRepo = MockBetTypeRepository.GetMockBetTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<BetTypeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidBetType()
        {
            var handler = new CreateBetTypeCommandHandler(_mapper, _mockRepo.Object);

            await handler.Handle(new CreateBetTypeCommand()
            {
                Name = "Inside Bets",
            }, CancellationToken.None);

            var betTypes = await _mockRepo.Object.GetAsync();
            betTypes.Count.ShouldBe(4);
        }
    }
}

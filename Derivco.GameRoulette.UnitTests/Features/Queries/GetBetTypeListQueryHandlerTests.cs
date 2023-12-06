using AutoMapper;
using Derivco.GameRoulette.Application.Contracts.Logging;
using Derivco.GameRoulette.Application.Contracts.Persistence;
using Derivco.GameRoulette.Application.Features.BetType.Queries.GetAllBetTypes;
using Derivco.GameRoulette.Application.MappingProfiles;
using Derivco.GameRoulette.UnitTests.Mocks;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Derivco.GameRoulette.UnitTests.Features.Queries
{
    public class GetBetTypeListQueryHandlerTests
    {
        private readonly Mock<IBetTypeRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetBetTypesQueryHandler>> _mockAppLogger;

        public GetBetTypeListQueryHandlerTests()
        {
            _mockRepo = MockBetTypeRepository.GetMockBetTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<BetTypeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetBetTypesQueryHandler>>();
        }

        [Fact]
        public async Task GetBetTypeListTest()
        {
            var handler = new GetBetTypesQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

            var result = await handler.Handle(new GetBetTypesQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<BetTypeDto>>();
            result.Count.ShouldBe(3);
        }
    }
}

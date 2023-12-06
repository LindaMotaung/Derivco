using Derivco.GameRoulette.Application.Contracts.Persistence;
using Derivco.GameRoulette.Domain;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Derivco.GameRoulette.UnitTests.Mocks
{
    public class MockBetTypeRepository
    {
        public static Mock<IBetTypeRepository> GetMockBetTypeRepository() 
        {
            var betTypes = new List<BetType>
            {
                 new BetType
                {
                    Id = 1,
                    Name = "Inside Bets"
                },
                new BetType
                {
                    Id = 2,
                    Name = "Outside Bets"
                },
                new BetType
                {
                    Id = 3,
                    Name = "Call Bets"
                },
                 new BetType
                {
                    Id = 4,
                    Name = "Neighbour Bets"
                }, new BetType
                {
                    Id = 5,
                    Name = "Special Bets"
                }
            };

            var mockRepo = new Mock<IBetTypeRepository>();

            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(betTypes);

            mockRepo.Setup(r => r.CreateAsync(It.IsAny<BetType>()))
              .Returns((BetType betType) =>
              {
                  betTypes.Add(betType);
                  return Task.CompletedTask;
              });

            mockRepo.Setup(r => r.IsBetTypeUnique(It.IsAny<string>()))
                .ReturnsAsync((string name) => {
                    return !betTypes.Any(q => q.Name == name);
                });

            return mockRepo;
        }
    }
}

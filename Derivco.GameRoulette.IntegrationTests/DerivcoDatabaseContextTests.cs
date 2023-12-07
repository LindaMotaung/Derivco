using Derivco.GameRoulette.Application.Contracts.Identity;
using Derivco.GameRoulette.Domain;
using Derivco.GameRoulette.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using Xunit;

namespace Derivco.GameRoulette.IntegrationTests
{
    /// <summary>
    /// Mocking the db representation of the db context
    /// </summary>
    public class DerivcoDatabaseContextTests
    {
        private DerivcoDatabaseContext _derivcoDatabaseContext;
        private readonly string _bettorId;
        private readonly Mock<IUserService> _bettorServiceMock;

        public DerivcoDatabaseContextTests() 
        {
            //Creating the database in memory whenever that db context is invoked
            var dbOptions = new DbContextOptionsBuilder<DerivcoDatabaseContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options; //Get a random database with a new Guid each time
            _bettorId = "00000000-0000-0000-0000-000000000000";
            _bettorServiceMock = new Mock<IUserService>();
            _bettorServiceMock.Setup(m => m.BettorId).Returns(_bettorId);
            _derivcoDatabaseContext = new DerivcoDatabaseContext(dbOptions, _bettorServiceMock.Object);
        }

        /// <summary>
        /// Scenario to test for when a bet is created
        /// </summary>
        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            // Arrange
            var betType = new BetType
            {
                Id = 1,
                Name = "Inside bets"
            };

            // Act
            await _derivcoDatabaseContext.BetTypes.AddAsync(betType);
            await _derivcoDatabaseContext.SaveChangesAsync();

            // Assert
            betType.DateCreated.ShouldNotBeNull(); //Validating that the bet type should not be null at the end of the Save operation
        }
    }
}

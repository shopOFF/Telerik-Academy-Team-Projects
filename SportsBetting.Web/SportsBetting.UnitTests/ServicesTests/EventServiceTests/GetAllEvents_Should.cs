using Moq;
using NUnit.Framework;
using SportsBetting.Data.Common.Contracts;
using SportsBetting.Data.Models;
using SportsBetting.Services;
using System.Collections.Generic;
using System.Linq;

namespace SportsBetting.UnitTests.ServicesTests.EventServiceTests
{
    [TestFixture]
    public class GetAllEvents_Should
    {
        [TestCase]
        public void GetAll_WhenValidParametersArePased_ShouldReturnAllOffers()
        {
            // Arrange
            var sportEvent = new Event();
            var sportEvent2 = new Event();

            var efRepoMock = new Mock<IEfRepository<Event>>();
            efRepoMock
                .Setup(x => x.GetAll)
                .Returns(new List<Event> { sportEvent, sportEvent2 }.AsQueryable());

            var uowMock = new Mock<IEfUnitOfWork>();

            var service = new EventService(efRepoMock.Object, uowMock.Object);
            service.AddEvent(sportEvent);
            service.AddEvent(sportEvent);

            // Act
            var result = service.GetAllEvents();

            // Assert
            Assert.AreEqual(2, result.Count());
        }
    }
}

using Moq;
using NUnit.Framework;
using SportsBetting.Data.Common.Contracts;
using SportsBetting.Data.Models;
using SportsBetting.Services;
using SportsBetting.Services.Contracts;

namespace SportsBetting.UnitTests.ServicesTests.EventServiceTests
{
    [TestFixture]
    public class AddEvent_Should
    {
        [TestCase]
        public void AddEvent_WhenValidParametersArePased_ShouldCallAddEventMethod()
        {
            // Arrange
            var efRepoMock = new Mock<IEfRepository<Event>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var sportEvent = new Event();

            var serviceMock = new Mock<IEventService>();
            serviceMock.Setup(x => x.AddEvent(sportEvent));

            // Act
            serviceMock.Object.AddEvent(sportEvent);
            serviceMock.Object.AddEvent(sportEvent);

            // Assert
            serviceMock.Verify(x => x.AddEvent(sportEvent), Times.Exactly(2));
        }

        [TestCase]
        public void AddEvent_WhenValidParametersArePased_ShouldCallEfRepositoryMethodAddEvent()
        {
            // Arrange
            var sportEvent = new Event();

            var efRepoMock = new Mock<IEfRepository<Event>>();
            efRepoMock.Setup(x => x.Add(sportEvent));
            var uowMock = new Mock<IEfUnitOfWork>();

            var serviceMock = new EventService(efRepoMock.Object, uowMock.Object);

            // Act
            serviceMock.AddEvent(sportEvent);

            // Assert
            efRepoMock.Verify(x => x.Add(sportEvent), Times.Once);
        }

        [TestCase]
        public void AddEvent_WhenValidParametersArePased_ShouldCallUnitOfWorkMethodCommit()
        {
            // Arrange
            var sportEvent = new Event();

            var efRepoMock = new Mock<IEfRepository<Event>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            uowMock.Setup(x => x.Commit());

            var serviceMock = new EventService(efRepoMock.Object, uowMock.Object);

            // Act
            serviceMock.AddEvent(sportEvent);
            serviceMock.AddEvent(sportEvent);

            // Assert
            uowMock.Verify(x => x.Commit(), Times.Exactly(2));
        }
    }
}

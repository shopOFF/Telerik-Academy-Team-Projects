using Moq;
using NUnit.Framework;
using SportsBetting.Data.Common.Contracts;
using SportsBetting.Data.Models;
using SportsBetting.Services;
using SportsBetting.Services.Contracts;

namespace SportsBetting.UnitTests.ServicesTests.EventServiceTests
{
    [TestFixture]
    public class UpdateEvent_Should
    {
        [TestCase]
        public void UpdateEvent_WhenValidParametersArePased_ShouldCallUpdateEventMethod()
        {
            // Arrange
            var efRepoMock = new Mock<IEfRepository<Event>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var sportEvent = new Event();

            var serviceMock = new Mock<IEventService>();
            serviceMock.Setup(x => x.UpdateEvent(sportEvent));

            // Act
            serviceMock.Object.UpdateEvent(sportEvent);
            serviceMock.Object.UpdateEvent(sportEvent);

            // Assert
            serviceMock.Verify(x => x.UpdateEvent(sportEvent), Times.Exactly(2));
        }
        [TestCase]
        public void UpdateEvent_WhenValidParametersArePased_ShouldCallEfRepositoryMethodUpdateEvent()
        {
            // Arrange
            var sportEvent = new Event();

            var efRepoMock = new Mock<IEfRepository<Event>>();
            efRepoMock.Setup(x => x.Update(sportEvent));
            var uowMock = new Mock<IEfUnitOfWork>();

            var serviceMock = new EventService(efRepoMock.Object, uowMock.Object);

            // Act
            serviceMock.UpdateEvent(sportEvent);

            // Assert
            efRepoMock.Verify(x => x.Update(sportEvent), Times.Once);
        }

        [TestCase]
        public void UpdateEvent_WhenValidParametersArePased_ShouldCallUnitOfWorkMethodCommit()
        {
            // Arrange
            var sportEvent = new Event();

            var efRepoMock = new Mock<IEfRepository<Event>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            uowMock.Setup(x => x.Commit());

            var service = new EventService(efRepoMock.Object, uowMock.Object);

            // Act
            service.UpdateEvent(sportEvent);
            service.UpdateEvent(sportEvent);

            // Assert
            uowMock.Verify(x => x.Commit(), Times.Exactly(2));
        }
    }
}

using Moq;
using NUnit.Framework;
using SportsBetting.Data.Common.Contracts;
using SportsBetting.Data.Models;
using SportsBetting.Services;
using SportsBetting.Services.Contracts;

namespace SportsBetting.UnitTests.ServicesTests.EventServiceTests
{
    [TestFixture]
    public class DeleteEvent_Should
    {
        [TestCase]
        public void DeleteEvent_WhenValidParametersArePased_ShouldCallDeleteEventMethod()
        {
            // Arrange
            var efRepoMock = new Mock<IEfRepository<Event>>();
            var uofMock = new Mock<IEfUnitOfWork>();
            var sportEvent = new Event();

            var serviceMock = new Mock<IEventService>();
            serviceMock.Setup(x => x.DeleteEvent(sportEvent));

            // Act
            serviceMock.Object.DeleteEvent(sportEvent);

            // Assert
            serviceMock.Verify(x => x.DeleteEvent(sportEvent), Times.Once);
        }

        [TestCase]
        public void DeleteEvent_WhenValidParametersArePased_ShouldCallEfRepositoryMethodDelete()
        {
            // Arrange
            var sportEvent = new Event();

            var efRepoMock = new Mock<IEfRepository<Event>>();
            efRepoMock.Setup(x => x.Delete(sportEvent));
            var uofMock = new Mock<IEfUnitOfWork>();

            var serviceMock = new EventService(efRepoMock.Object, uofMock.Object);

            // Act
            serviceMock.DeleteEvent(sportEvent);

            // Assert
            efRepoMock.Verify(x => x.Delete(sportEvent), Times.Once);
        }

        [TestCase]
        public void DeleteEvent_WhenValidParametersArePased_ShouldCallUnitOfWorkMethodCommit()
        {
            // Arrange
            var sportEvent = new Event();

            var efRepoMock = new Mock<IEfRepository<Event>>();
            var uofMock = new Mock<IEfUnitOfWork>();
            uofMock.Setup(x => x.Commit());

            var service = new EventService(efRepoMock.Object, uofMock.Object);

            // Act
            service.DeleteEvent(sportEvent);
            service.DeleteEvent(sportEvent);

            // Assert
            uofMock.Verify(x => x.Commit(), Times.Exactly(2));
        }
    }
}

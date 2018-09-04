using Moq;
using NUnit.Framework;
using SportsBetting.Services.Contracts;
using SportsBetting.Web.Controllers;

namespace SportsBetting.UnitTests.ControllersTests.EventsDataControllerTests
{
    [TestFixture]
    public class Constuctor_Should
    {
        [TestCase]
        public void Constructor_WhenValidParameterIsPassed_ShouldNotBeNull()
        {
            // Arrange
            var eventServiceMock = new Mock<IEventService>();

            // Act
            EventsDataController offersController = new EventsDataController(eventServiceMock.Object);

            // Assert
            Assert.IsNotNull(offersController);
        }

        [TestCase]
        public void Constructor_WhenInValidParameterIsPassed_ShouldThrowArgumentNullExceptionWithMessage()
        {
            //  Arrange, Act & Assert
            Assert.That(() => new EventsDataController(null),
                 Throws.ArgumentNullException.With.Message.Contains("EventService can not be null"));
        }
    }
}

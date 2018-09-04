using Moq;
using NUnit.Framework;
using SportsBetting.Data.Common.Contracts;
using SportsBetting.Data.Models;
using SportsBetting.Services;
using SportsBetting.Services.Contracts;
using System;

namespace SportsBetting.UnitTests.ServicesTests.EventServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [TestCase]
        public void Constructor_WhenValidParametersArePased_ShouldNotBeNull()
        {
            // Arrange
            var eventRepoMock = new Mock<IEfRepository<Event>>();
            var uowkMock = new Mock<IEfUnitOfWork>();

            // Act
            var eventService = new EventService(eventRepoMock.Object, uowkMock.Object);

            // Assert
            Assert.IsNotNull(eventService);
        }

        [TestCase]
        public void Constructor_WhenValidParametersArePased_ShouldInitializeCorrectly()
        {
            // Arrange
            var eventRepoMock = new Mock<IEfRepository<Event>>();
            var uowkMock = new Mock<IEfUnitOfWork>();

            // Act
            var eventService = new EventService(eventRepoMock.Object, uowkMock.Object);

            // Assert
            Assert.IsInstanceOf<IEventService>(eventService);
        }

        [TestCase]
        public void Constructor_WhenInValidParametersArePased_ShouldThrowArgumentNullExceptionWithMessage()
        {
            //  Arrange, Act & Assert
            Assert.That(() => new EventService(null, null),
                 Throws.ArgumentNullException.With.Message.Contains("EventService initializing parameters can not"));
        }

        [TestCase]
        public void Constructor_WhenInValidParameterEfRepositoryIsPased_ShouldThrowNullReferenceException()
        {
            // Arrange
            var uowkMock = new Mock<IEfUnitOfWork>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new EventService(null, uowkMock.Object));
        }

        [TestCase]
        public void Constructor_WhenInValidParameterIEfUnitOfWorkIsPased_ShouldThrowNullReferenceException()
        {
            // Arrange
            var eventRepoMock = new Mock<IEfRepository<Event>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new EventService(eventRepoMock.Object, null));
        }
    }
}

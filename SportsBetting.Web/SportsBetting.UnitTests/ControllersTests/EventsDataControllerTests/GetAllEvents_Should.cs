using Moq;
using NUnit.Framework;
using SportsBetting.Data.Common.Contracts;
using SportsBetting.Data.Models;
using SportsBetting.Services;
using SportsBetting.Services.Contracts;
using SportsBetting.Web.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace SportsBetting.UnitTests.ControllersTests.EventsDataControllerTests
{
    [TestFixture]
    public class GetAllEvents_Should
    {
        [TestCase]
        public void GetAllEvents_WhenValidParametersArePased_ShouldReturnCorerectNumberOfEvents()
        {
            // Arrange
            var sportEvent = new Event();
            var sportEvent2 = new Event();

            var eventServiceMock = new Mock<IEventService>();
            eventServiceMock
                .Setup(x => x.GetAllEvents())
                .Returns(() => new List<Event> { sportEvent,sportEvent2 }
                .AsQueryable());

            EventsDataController offersController = new EventsDataController(eventServiceMock.Object);

            // Act
            var result = offersController.GetEvents();

            // Assert
            Assert.AreEqual(2, result.Count());
        }
    }
}

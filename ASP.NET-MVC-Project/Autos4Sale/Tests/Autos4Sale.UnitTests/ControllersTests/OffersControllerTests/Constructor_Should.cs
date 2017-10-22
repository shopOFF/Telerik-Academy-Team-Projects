using Autos4Sale.Services.Contracts;
using Autos4Sale.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Autos4Sale.UnitTests.ControllersTests.OffersControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {

        [TestCase]
        public void Constructor_WhenValidParametersArePased_ShouldNotBeNull()
        {
            // Arrange
            var carOffersServiceMock = new Mock<ICarOffersService>();
            var userServiceMock = new Mock<IUserService>();
   
            // Act
            OffersController offersController = new OffersController(carOffersServiceMock.Object, userServiceMock.Object);

            // Assert
            Assert.IsNotNull(offersController);
        }
    }
}

﻿using Autos4Sale.Data.Models;
using Autos4Sale.Services.Contracts;
using Autos4Sale.Web.App_Start;
using Autos4Sale.Web.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace Autos4Sale.UnitTests.ControllersTests.OffersControllerTests
{
    [TestFixture]
    public class YourOffers_Should
    {
        [TestCase]
        public void YourOffers_WhenInValidParametersArePased_ShouldThrowNullReferenceException()
        {
            // Arrange
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(OffersController).Assembly);

            var carOffer = new CarOffer();

            var carOffersServiceMock = new Mock<ICarOffersService>();
            carOffersServiceMock.Setup(x => x.GetAll())
                .Returns(() => new List<CarOffer> { carOffer }.AsQueryable());

            var userServiceMock = new Mock<IUserService>();
            OffersController offersController = new OffersController(carOffersServiceMock.Object, userServiceMock.Object);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => offersController.YourOffers());
        }

        [TestCase]
        public void YourOffers_WhenInValidGetAllParamIsPased_ShouldReturnNull()
        {
            // Arrange
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(OffersController).Assembly);
            var userServiceMock = new Mock<IUserService>();
            var carOffer = new CarOffer();

            var carOffersServiceMock = new Mock<ICarOffersService>();
            carOffersServiceMock.Setup(x => x.GetAll())
                .Returns(() => new List<CarOffer> { carOffer }.AsQueryable());
           
            OffersController offersController = new OffersController(carOffersServiceMock.Object, userServiceMock.Object);
            // Act & Assert
            Assert.Throws<NullReferenceException>(() => offersController.YourOffers());
        }
    }
}

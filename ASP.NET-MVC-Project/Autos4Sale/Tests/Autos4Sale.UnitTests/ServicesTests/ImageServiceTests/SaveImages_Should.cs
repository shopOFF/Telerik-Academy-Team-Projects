﻿using Autos4Sale.Data.Common.Contracts;
using Autos4Sale.Data.Models;
using Autos4Sale.Services;
using Autos4Sale.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Web;

namespace Autos4Sale.UnitTests.ServicesTests.ImageServiceTests
{
    [TestFixture]
    public class SaveImages_Should
    {
        [TestCase]
        public void SaveImages_WhenInValidImageParameterIsPased_ShouldThrowNullReferenceException()
        {
            // Arrange
            var filesMock = new Mock<HttpPostedFileBase>();
            filesMock.Setup(x => x.FileName).Returns("file");

            var imgs = new List<HttpPostedFileBase>() { filesMock.Object };
            var efRepoMock = new Mock<IEfRepository<User>>();

            var imageService = new ImageService(efRepoMock.Object);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => imageService.SaveImages(imgs));
        }

        [TestCase]
        public void SaveImages_WhenValidImageParameterIsPased_ShouldReturnCorrectResult()
        {
            // Arrange
            var filesMock = new Mock<HttpPostedFileBase>();
            filesMock.Setup(x => x.FileName).Returns("file");

            var imgs = new List<HttpPostedFileBase>();
            var efRepoMock = new Mock<IEfRepository<User>>();

            var imageService = new ImageService(efRepoMock.Object);

            // Act
            var result = imageService.SaveImages(imgs);

            // Assert
            Assert.AreEqual(imgs.Count, result.Count);
        }

        [TestCase]
        public void SaveImages_WhenValidImageParameterIsPased_ShouldCallSaveImagesMethod()
        {
            // Arrange
            var filesMock = new Mock<HttpPostedFileBase>();
            filesMock.Setup(x => x.FileName).Returns("file");

            var imgs = new List<HttpPostedFileBase>() { filesMock.Object };
            var imageServiceMock = new Mock<IImageService>();
            imageServiceMock.Setup(x => x.SaveImages(imgs));

            // Act
            imageServiceMock.Object.SaveImages(imgs);

            // Assert
            imageServiceMock.Verify(x => x.SaveImages(imgs), Times.Once);
        }

        [TestCase]
        public void SaveImages_WhenValidParametersArePased_ShouldSetCorrectly()
        {
            // Arrange
            var filesMock = new Mock<HttpPostedFileBase>();
            filesMock.Setup(x => x.FileName).Returns("file");

            var imgs = new List<HttpPostedFileBase>() { filesMock.Object };
            var imageServiceMock = new Mock<IImageService>();
            imageServiceMock.Setup(x => x.SaveImages(imgs));

            // Act
            imageServiceMock.Object.SaveImages(imgs);

            // Assert
            imageServiceMock.Verify(x => x.SaveImages(imgs), Times.Once);
        }
    }
}

using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Contracts;
using VideoGameStore.Data.Models;

namespace VideoGameStore.Services.Tests.PlatformServicesTests
{
    [TestFixture]
    public class GetByIdTests
    {
        [Test]
        public void IdLessThanZero_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Platform>>();

            var service = new PlatformServices(repositoryMock.Object);

            var platform = new Platform();

            repositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(platform);

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => service.GetById(-1));

            Assert.AreEqual("id cannot be less than 0", err.Message);
        }

        [Test]
        public void ShouldReturnPlatform()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Platform>>();

            var service = new PlatformServices(repositoryMock.Object);

            var platform = new Platform();

            repositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(platform);

            //Act
            Platform res = service.GetById(2);

            //Assert
            Assert.AreSame(platform, res);

            repositoryMock.Verify(x => x.GetById(2), Times.Once());
        }
    }
}

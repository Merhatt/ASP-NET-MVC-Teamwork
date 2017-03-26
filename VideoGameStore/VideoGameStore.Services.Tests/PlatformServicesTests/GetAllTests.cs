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
    public class GetAllTests
    {
        [Test]
        public void ShouldGetAll()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Platform>>();

            var service = new PlatformServices(repositoryMock.Object);

            var platform = new Platform();

            repositoryMock.Setup(x => x.All())
                .Returns(new List<Platform>() { platform }.AsQueryable());

            //Act
            var all = service.GetAll();

            //Assert
            Assert.Contains(platform, all.ToList());
            repositoryMock.Verify(x => x.All());
        }
    }
}

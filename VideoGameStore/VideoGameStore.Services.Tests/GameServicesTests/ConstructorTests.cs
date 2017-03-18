using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Contracts;
using VideoGameStore.Data.Models;
using VideoGameStore.Services;
using VideoGameStore.Utils.Factories.Contracts;

namespace VideoGameStore.Services.Tests.GameServicesTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void NullRepository_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Game>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var gameFactoryMock = new Mock<IGameFactory>();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => new GameServices(null, unitOfWorkMock.Object, gameFactoryMock.Object));

            Assert.AreEqual("repository cannot be null", msg.Message);
        }

        [Test]
        public void NullUnitOfWork_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Game>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var gameFactoryMock = new Mock<IGameFactory>();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => new GameServices(repositoryMock.Object, null, gameFactoryMock.Object));

            Assert.AreEqual("unitOfWork cannot be null", msg.Message);
        }

        [Test]
        public void NullGameFactory_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Game>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var gameFactoryMock = new Mock<IGameFactory>();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => new GameServices(repositoryMock.Object, unitOfWorkMock.Object, null));

            Assert.AreEqual("gameFactory cannot be null", msg.Message);
        }
    }
}

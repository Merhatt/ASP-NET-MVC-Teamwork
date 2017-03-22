using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Contracts;
using VideoGameStore.Data.Models;
using VideoGameStore.Utils.Factories.Contracts;

namespace VideoGameStore.Services.Tests.GameServicesTests
{
    [TestFixture]
    public class GetByIdTests
    {
        [Test]
        public void LessThanZeroId_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Game>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var gameFactoryMock = new Mock<IGameFactory>();

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => services.GetById(-1));

            Assert.AreEqual("id cannot be less than 0", msg.Message);
        }

        [Test]
        public void CorrectId_ShouldReturn()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Game>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var gameFactoryMock = new Mock<IGameFactory>();

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            Game gameToReturn = new Game();

            repositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(gameToReturn);

            //Act
            Game game = services.GetById(2);

            //Assert
            Assert.AreSame(gameToReturn, game);

            repositoryMock.Verify(x => x.GetById(2), Times.Once());
        }
    }
}

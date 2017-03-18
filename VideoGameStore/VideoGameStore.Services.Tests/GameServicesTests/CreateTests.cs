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
    public class CreateTests
    {
        [Test]
        public void NullName_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Game>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var gameFactoryMock = new Mock<IGameFactory>();

            string name = null;
            decimal price = 10;
            string description = "description";
            string imageUrl = "testUrl";
            ICollection<Category> categories = new List<Category>();
            categories.Add(new Category());

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => services.Create(name, price, description, imageUrl, categories));

            Assert.AreEqual("name cannot be null", msg.Message);
        }

        [Test]
        public void LessThanZeroPrice_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Game>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var gameFactoryMock = new Mock<IGameFactory>();

            string name = "asdsa";
            decimal price = -10;
            string description = "description";
            string imageUrl = "testUrl";
            ICollection<Category> categories = new List<Category>();
            categories.Add(new Category());

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            //Act & Assert
            var msg = Assert.Throws<ArgumentOutOfRangeException>(() => services.Create(name, price, description, imageUrl, categories));
        }

        [Test]
        public void NullDescription_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Game>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var gameFactoryMock = new Mock<IGameFactory>();

            string name = "Asasdas";
            decimal price = 10;
            string description = null;
            string imageUrl = "testUrl";
            ICollection<Category> categories = new List<Category>();
            categories.Add(new Category());

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => services.Create(name, price, description, imageUrl, categories));

            Assert.AreEqual("description cannot be null", msg.Message);
        }

        [Test]
        public void NullImageUrl_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Game>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var gameFactoryMock = new Mock<IGameFactory>();

            string name = "Asdasd";
            decimal price = 10;
            string description = "description";
            string imageUrl = null;
            ICollection<Category> categories = new List<Category>();
            categories.Add(new Category());

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => services.Create(name, price, description, imageUrl, categories));

            Assert.AreEqual("imageUrl cannot be null", msg.Message);
        }

        [Test]
        public void NullCategories_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Game>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var gameFactoryMock = new Mock<IGameFactory>();

            string name = "asd";
            decimal price = 10;
            string description = "description";
            string imageUrl = "testUrl";
            ICollection<Category> categories = null;

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => services.Create(name, price, description, imageUrl, categories));

            Assert.AreEqual("game categories cannot be null or empty", msg.Message);
        }

        [Test]
        public void EmptyCategories_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Game>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var gameFactoryMock = new Mock<IGameFactory>();

            string name = "asd";
            decimal price = 10;
            string description = "description";
            string imageUrl = "testUrl";
            ICollection<Category> categories = new List<Category>();

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => services.Create(name, price, description, imageUrl, categories));

            Assert.AreEqual("game categories cannot be null or empty", msg.Message);
        }

        [Test]
        public void ShouldCreateSuccesfully()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Game>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var gameFactoryMock = new Mock<IGameFactory>();

            string name = "asd";
            decimal price = 10;
            string description = "description";
            string imageUrl = "testUrl";
            ICollection<Category> categories = new List<Category>();
            categories.Add(new Category());

            Game game = new Game();

            gameFactoryMock.Setup(x => x.Create(name, price, description, imageUrl, categories))
                .Returns(game)
                .Verifiable();

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            //Act
            services.Create(name, price, description, imageUrl, categories);

            //Assert
            gameFactoryMock.VerifyAll();
            repositoryMock.Verify(x => x.Add(game), Times.Once());
            unitOfWorkMock.Verify(x => x.Commit(), Times.Once());
        }
    }
}

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

            ICollection<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform());

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => services.Create(name, price, description, imageUrl, categories, platforms));

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

            ICollection<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform());

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            //Act & Assert
            var msg = Assert.Throws<ArgumentOutOfRangeException>(() => services.Create(name, price, description, imageUrl, categories, platforms));
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

            ICollection<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform());

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => services.Create(name, price, description, imageUrl, categories, platforms));

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

            ICollection<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform());

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => services.Create(name, price, description, imageUrl, categories, platforms));

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

            ICollection<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform());

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => services.Create(name, price, description, imageUrl, categories, platforms));

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

            ICollection<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform());

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => services.Create(name, price, description, imageUrl, categories, platforms));

            Assert.AreEqual("game categories cannot be null or empty", msg.Message);
        }

        [Test]
        public void NullPlatforms_ShouldThrow()
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

            ICollection<Platform> platforms = null;

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => services.Create(name, price, description, imageUrl, categories, platforms));

            Assert.AreEqual("platforms cannot be null or empty", msg.Message);
        }

        [Test]
        public void EmptyPlatforms_ShouldThrow()
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

            ICollection<Platform> platforms = new List<Platform>();

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => services.Create(name, price, description, imageUrl, categories, platforms));

            Assert.AreEqual("platforms cannot be null or empty", msg.Message);
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

            ICollection<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform());

            Game game = new Game();

            gameFactoryMock.Setup(x => x.Create(name, price, description, imageUrl, categories, platforms))
                .Returns(game)
                .Verifiable();

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            //Act
            services.Create(name, price, description, imageUrl, categories, platforms);

            //Assert
            gameFactoryMock.VerifyAll();
            repositoryMock.Verify(x => x.Add(game), Times.Once());
            unitOfWorkMock.Verify(x => x.Commit(), Times.Once());
        }
    }
}

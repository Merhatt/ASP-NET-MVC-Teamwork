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
    public class GetAllTests
    {
        [Test]
        public void WithoutCategories_ShouldCreateSuccesfully()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Game>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var gameFactoryMock = new Mock<IGameFactory>();

            var allGames = new List<Game>();
            allGames.Add(new Game());

            repositoryMock.Setup(x => x.All()).Returns(allGames.AsQueryable());

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            //Act
            IEnumerable<Game> allGamesRes = services.GetAll();

            //Assert
            Assert.AreEqual(allGames, allGamesRes.ToList());
            repositoryMock.Verify(x => x.All(), Times.Once());
        }

        [Test]
        public void WithCategories_NullCategories_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Game>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var gameFactoryMock = new Mock<IGameFactory>();

            var allGames = new List<Game>();
            allGames.Add(new Game());

            repositoryMock.Setup(x => x.All()).Returns(allGames.AsQueryable());

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => services.GetAll(null));

            Assert.AreEqual("categories cannot be null", msg.Message);
        }

        [Test]
        public void WithCategories_ShouldGetCorrectly()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Game>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var gameFactoryMock = new Mock<IGameFactory>();

            var allGames = new List<Game>();

            var battlefield = new Game()
            {
                Name = "Battlefield 1",
                Categories = new List<Category>()
                {
                    new Category() { Name = "Action" },
                    new Category() { Name = "FPS" }
                }
            };

            allGames.Add(battlefield);

            var darkSouls = new Game()
            {
                Name = "Dark Souls 3",
                Categories = new List<Category>()
                {
                    new Category() { Name = "RPG" },
                    new Category() { Name = "FPS" }
                }
            };

            allGames.Add(darkSouls);

            var cod = new Game()
            {
                Name = "Call of Duty 4",
                Categories = new List<Category>()
                {
                    new Category() { Name = "Action" },
                    new Category() { Name = "FPS" }
                }
            };

            allGames.Add(cod);

            repositoryMock.Setup(x => x.All()).Returns(allGames.AsQueryable());

            GameServices services = new GameServices(repositoryMock.Object, unitOfWorkMock.Object, gameFactoryMock.Object);

            var categoriesToSearch = new List<Category>
            {
                new Category() { Name = "Action" },
                new Category() { Name = "FPS" }
            };

            //Act
            var resultGames = services.GetAll(categoriesToSearch);

            //Assert
            Assert.AreEqual(2, resultGames.Count());
            Assert.Contains(battlefield, resultGames.ToList());
            Assert.Contains(cod, resultGames.ToList());
        }
    }
}

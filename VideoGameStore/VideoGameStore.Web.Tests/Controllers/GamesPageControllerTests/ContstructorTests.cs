using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Models;
using VideoGameStore.Services.Contracts;
using VideoGameStore.Utils.Factories.Contracts;
using VideoGameStore.Web.Controllers;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Tests.Controllers.GamesPageControllerTests
{
    [TestFixture]
    public class ContstructorTests
    {
        [Test]
        public void NullGameServices_ShouldThrow()
        {
            //Arrange
            var gameServicesMock = new Mock<IGameServices>();
            var categortServicesMock = new Mock<ICategoryServices>();
            var checkboxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var userServicesMock = new Mock<IUserServices>();
            var gamesPageViewModelFactoryMock = new Mock<IGamesPageViewModelFactory>();
            var pageServiceFactoryMock = new Mock<IPageServiceFactory<Game>>();
            var gameModelFactoryMock = new Mock<IGameModelFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => new GamesPageController(null,
                categortServicesMock.Object, checkboxModelFactoryMock.Object, userServicesMock.Object,
                gamesPageViewModelFactoryMock.Object, pageServiceFactoryMock.Object,
                gameModelFactoryMock.Object));

            Assert.AreEqual("gameServices cannot be null", err.Message);
        }

        [Test]
        public void NullCategoryServices_ShouldThrow()
        {
            //Arrange
            var gameServicesMock = new Mock<IGameServices>();
            var categoryServicesMock = new Mock<ICategoryServices>();
            var checkboxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var userServicesMock = new Mock<IUserServices>();
            var gamesPageViewModelFactoryMock = new Mock<IGamesPageViewModelFactory>();
            var pageServiceFactoryMock = new Mock<IPageServiceFactory<Game>>();
            var gameModelFactoryMock = new Mock<IGameModelFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => new GamesPageController(gameServicesMock.Object,
                null, checkboxModelFactoryMock.Object, userServicesMock.Object,
                gamesPageViewModelFactoryMock.Object, pageServiceFactoryMock.Object,
                gameModelFactoryMock.Object));

            Assert.AreEqual("categoryServices cannot be null", err.Message);
        }

        [Test]
        public void NullCheckboxModelFactory_ShouldThrow()
        {
            //Arrange
            var gameServicesMock = new Mock<IGameServices>();
            var categoryServicesMock = new Mock<ICategoryServices>();
            var checkboxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var userServicesMock = new Mock<IUserServices>();
            var gamesPageViewModelFactoryMock = new Mock<IGamesPageViewModelFactory>();
            var pageServiceFactoryMock = new Mock<IPageServiceFactory<Game>>();
            var gameModelFactoryMock = new Mock<IGameModelFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => new GamesPageController(gameServicesMock.Object,
                categoryServicesMock.Object, null, userServicesMock.Object,
                gamesPageViewModelFactoryMock.Object, pageServiceFactoryMock.Object,
                gameModelFactoryMock.Object));

            Assert.AreEqual("checkBoxCategoryModelFactory cannot be null", err.Message);
        }

        [Test]
        public void NullUserServices_ShouldThrow()
        {
            //Arrange
            var gameServicesMock = new Mock<IGameServices>();
            var categoryServicesMock = new Mock<ICategoryServices>();
            var checkboxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var userServicesMock = new Mock<IUserServices>();
            var gamesPageViewModelFactoryMock = new Mock<IGamesPageViewModelFactory>();
            var pageServiceFactoryMock = new Mock<IPageServiceFactory<Game>>();
            var gameModelFactoryMock = new Mock<IGameModelFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => new GamesPageController(gameServicesMock.Object,
                categoryServicesMock.Object, checkboxModelFactoryMock.Object, null,
                gamesPageViewModelFactoryMock.Object, pageServiceFactoryMock.Object,
                gameModelFactoryMock.Object));

            Assert.AreEqual("userServices cannot be null", err.Message);
        }

        [Test]
        public void NullGamesPageViewModelFactory_ShouldThrow()
        {
            //Arrange
            var gameServicesMock = new Mock<IGameServices>();
            var categoryServicesMock = new Mock<ICategoryServices>();
            var checkboxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var userServicesMock = new Mock<IUserServices>();
            var gamesPageViewModelFactoryMock = new Mock<IGamesPageViewModelFactory>();
            var pageServiceFactoryMock = new Mock<IPageServiceFactory<Game>>();
            var gameModelFactoryMock = new Mock<IGameModelFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => new GamesPageController(gameServicesMock.Object,
                categoryServicesMock.Object, checkboxModelFactoryMock.Object, userServicesMock.Object,
                null, pageServiceFactoryMock.Object,
                gameModelFactoryMock.Object));

            Assert.AreEqual("gamesPageViewModelFactory cannot be null", err.Message);
        }

        [Test]
        public void NullPageServiceFactory_ShouldThrow()
        {
            //Arrange
            var gameServicesMock = new Mock<IGameServices>();
            var categoryServicesMock = new Mock<ICategoryServices>();
            var checkboxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var userServicesMock = new Mock<IUserServices>();
            var gamesPageViewModelFactoryMock = new Mock<IGamesPageViewModelFactory>();
            var pageServiceFactoryMock = new Mock<IPageServiceFactory<Game>>();
            var gameModelFactoryMock = new Mock<IGameModelFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => new GamesPageController(gameServicesMock.Object,
                categoryServicesMock.Object, checkboxModelFactoryMock.Object, userServicesMock.Object,
                gamesPageViewModelFactoryMock.Object, null,
                gameModelFactoryMock.Object));

            Assert.AreEqual("pageServiceFactory cannot be null", err.Message);
        }

        [Test]
        public void NullGameModelFactory_ShouldThrow()
        {
            //Arrange
            var gameServicesMock = new Mock<IGameServices>();
            var categoryServicesMock = new Mock<ICategoryServices>();
            var checkboxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var userServicesMock = new Mock<IUserServices>();
            var gamesPageViewModelFactoryMock = new Mock<IGamesPageViewModelFactory>();
            var pageServiceFactoryMock = new Mock<IPageServiceFactory<Game>>();
            var gameModelFactoryMock = new Mock<IGameModelFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => new GamesPageController(gameServicesMock.Object,
                categoryServicesMock.Object, checkboxModelFactoryMock.Object, userServicesMock.Object,
                gamesPageViewModelFactoryMock.Object, pageServiceFactoryMock.Object,
                null));

            Assert.AreEqual("gameModelFactory cannot be null", err.Message);
        }
    }
}

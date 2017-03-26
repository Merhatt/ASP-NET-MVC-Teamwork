using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VideoGameStore.Data.Models;
using VideoGameStore.Services.Contracts;
using VideoGameStore.Utils.Factories.Contracts;
using VideoGameStore.Utils.Pagings.Contracts;
using VideoGameStore.Web.Controllers;
using VideoGameStore.Web.Models;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Tests.Controllers.GamesPageControllerTests
{
    [TestFixture]
    public class SearchTests
    {
        [Test]
        public void ShouldGetViewCorrectly_WithoutFilters()
        {
            //Arrange
            var gameServicesMock = new Mock<IGameServices>();
            var categortServicesMock = new Mock<ICategoryServices>();
            var checkboxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var userServicesMock = new Mock<IUserServices>();
            var gamesPageViewModelFactoryMock = new Mock<IGamesPageViewModelFactory>();
            var pageServiceFactoryMock = new Mock<IPageServiceFactory<Game>>();
            var gameModelFactoryMock = new Mock<IGameModelFactory>();

            var controller = new GamesPageController(gameServicesMock.Object,
                    categortServicesMock.Object, checkboxModelFactoryMock.Object, userServicesMock.Object,
                    gamesPageViewModelFactoryMock.Object, pageServiceFactoryMock.Object,
                    gameModelFactoryMock.Object);

            GamesPageViewModel model = new GamesPageViewModel();
            model.CheckBoxesCategories = new List<CheckBoxModel>();

            //Act
            var view = controller.Search(model) as ViewResult;

            //Assert
            Assert.IsFalse((view.Model as GamesPageViewModel).IsSearchPage);
            gameServicesMock.Verify(x => x.GetAll(), Times.Once());
        }

        [Test]
        public void ShouldGetViewCorrectly_WithSearch_WithoutCategories()
        {
            //Arrange
            var gameServicesMock = new Mock<IGameServices>();
            var categortServicesMock = new Mock<ICategoryServices>();
            var checkboxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var userServicesMock = new Mock<IUserServices>();
            var gamesPageViewModelFactoryMock = new Mock<IGamesPageViewModelFactory>();
            var pageServiceFactoryMock = new Mock<IPageServiceFactory<Game>>();
            var gameModelFactoryMock = new Mock<IGameModelFactory>();

            var controller = new GamesPageController(gameServicesMock.Object,
                    categortServicesMock.Object, checkboxModelFactoryMock.Object, userServicesMock.Object,
                    gamesPageViewModelFactoryMock.Object, pageServiceFactoryMock.Object,
                    gameModelFactoryMock.Object);

            GamesPageViewModel model = new GamesPageViewModel();
            model.CheckBoxesCategories = new List<CheckBoxModel>();
            model.SearchName = "Test";

            //Act
            var view = controller.Search(model) as ViewResult;

            //Assert
            Assert.IsTrue((view.Model as GamesPageViewModel).IsSearchPage);
            gameServicesMock.Verify(x => x.GetAll("Test"), Times.Once());
        }

        [Test]
        public void ShouldGetViewCorrectly_WithoutSearch_WithCategories()
        {
            //Arrange
            var gameServicesMock = new Mock<IGameServices>();
            var categortServicesMock = new Mock<ICategoryServices>();
            var checkboxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var userServicesMock = new Mock<IUserServices>();
            var gamesPageViewModelFactoryMock = new Mock<IGamesPageViewModelFactory>();
            var pageServiceFactoryMock = new Mock<IPageServiceFactory<Game>>();
            var gameModelFactoryMock = new Mock<IGameModelFactory>();

            var controller = new GamesPageController(gameServicesMock.Object,
                    categortServicesMock.Object, checkboxModelFactoryMock.Object, userServicesMock.Object,
                    gamesPageViewModelFactoryMock.Object, pageServiceFactoryMock.Object,
                    gameModelFactoryMock.Object);

            GamesPageViewModel model = new GamesPageViewModel();
            model.CheckBoxesCategories = new List<CheckBoxModel>();
            model.SearchName = "";
            model.CheckBoxesCategories = new List<CheckBoxModel>()
            {
                new CheckBoxModel()
                {
                    Checked = true
                }
            };

            //Act
            var view = controller.Search(model) as ViewResult;

            //Assert
            Assert.IsTrue((view.Model as GamesPageViewModel).IsSearchPage);
            gameServicesMock.Verify(x => x.GetAll(It.IsAny<IEnumerable<Category>>()), Times.Once());
        }

        [Test]
        public void ShouldGetViewCorrectly_WithSearch_WithCategories()
        {
            //Arrange
            var gameServicesMock = new Mock<IGameServices>();
            var categortServicesMock = new Mock<ICategoryServices>();
            var checkboxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var userServicesMock = new Mock<IUserServices>();
            var gamesPageViewModelFactoryMock = new Mock<IGamesPageViewModelFactory>();
            var pageServiceFactoryMock = new Mock<IPageServiceFactory<Game>>();
            var gameModelFactoryMock = new Mock<IGameModelFactory>();

            var controller = new GamesPageController(gameServicesMock.Object,
                    categortServicesMock.Object, checkboxModelFactoryMock.Object, userServicesMock.Object,
                    gamesPageViewModelFactoryMock.Object, pageServiceFactoryMock.Object,
                    gameModelFactoryMock.Object);

            GamesPageViewModel model = new GamesPageViewModel();
            model.CheckBoxesCategories = new List<CheckBoxModel>();
            model.SearchName = "Test";
            model.CheckBoxesCategories = new List<CheckBoxModel>()
            {
                new CheckBoxModel()
                {
                    Checked = true
                }
            };

            //Act
            var view = controller.Search(model) as ViewResult;

            //Assert
            Assert.IsTrue((view.Model as GamesPageViewModel).IsSearchPage);
            gameServicesMock.Verify(x => x.GetAll(It.IsAny<IEnumerable<Category>>(), "Test"), Times.Once());
        }
    }
}

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
    public class AddToCartTests
    {
        [Test]
        public void ShouldGetViewCorrectly()
        {
            //Arrange
            var gameServicesMock = new Mock<IGameServices>();
            var categortServicesMock = new Mock<ICategoryServices>();
            var checkboxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var userServicesMock = new Mock<IUserServices>();
            var gamesPageViewModelFactoryMock = new Mock<IGamesPageViewModelFactory>();
            var pageServiceFactoryMock = new Mock<IPageServiceFactory<Game>>();
            var gameModelFactoryMock = new Mock<IGameModelFactory>();

            var mocks = new MockRepository(MockBehavior.Default);
            Mock<IPrincipal> mockPrincipal = mocks.Create<IPrincipal>();
            mockPrincipal.SetupGet(p => p.Identity.Name).Returns("User");

            // create mock controller context
            var mockContext = new Mock<ControllerContext>();
            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);


            var controller = new GamesPageController(gameServicesMock.Object,
                categortServicesMock.Object, checkboxModelFactoryMock.Object, userServicesMock.Object,
                gamesPageViewModelFactoryMock.Object, pageServiceFactoryMock.Object,
                gameModelFactoryMock.Object)
            {
                ControllerContext = mockContext.Object
            };

            var allGames = new List<Game>()
            {
                new Game()
            };

            gameServicesMock.Setup(x => x.GetAll())
                .Returns(allGames);

            var pageServiceMock = new Mock<IPageService<Game>>();

            pageServiceFactoryMock.Setup(x => x.Create(It.IsAny<IEnumerable<Game>>(), It.IsAny<int>()))
                .Returns(pageServiceMock.Object);

            pageServiceMock.Setup(x => x.GetPage(It.IsAny<int>()))
                .Returns(allGames);

            GamesPageViewModel model = new GamesPageViewModel();

            gamesPageViewModelFactoryMock.Setup(x => x.Create(It.IsAny<IEnumerable<Game>>()))
                .Returns(model);

            var allCategories = new List<Category>()
            {
                new Category()
                {
                    Name = "Action"
                }
            };

            categortServicesMock.Setup(x => x.GetAll())
                .Returns(allCategories);

            checkboxModelFactoryMock.Setup(x => x.Create(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new CheckBoxModel());

            gameServicesMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Game());
            

            userServicesMock.Setup(x => x.GetUser(It.IsAny<string>()))
                .Returns(new ApplicationUser());

            //Act
            var view = controller.AddToCart(2);

            //Assert
            userServicesMock.Verify(x => x.GetUser("User"), Times.Once());
            userServicesMock.Verify(x => x.AddGameToCart(It.IsAny<ApplicationUser>(), It.IsAny<Game>()), Times.Once());
            gameServicesMock.Verify(x => x.GetAll(), Times.Once());
            pageServiceFactoryMock.Verify(x => x.Create(It.IsAny<IEnumerable<Game>>(), It.IsAny<int>()), Times.Exactly(2));
            pageServiceMock.Verify(x => x.GetPage(It.IsAny<int>()), Times.Once());
        }
    }
}

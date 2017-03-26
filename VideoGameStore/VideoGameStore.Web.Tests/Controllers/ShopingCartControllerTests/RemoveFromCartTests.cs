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

namespace VideoGameStore.Web.Tests.Controllers.ShopingCartControllerTests
{
    [TestFixture]
    public class RemoveFromCartTests
    {
        [Test]
        public void ShouldGetView()
        {
            //Arrange
            var userServicesMock = new Mock<IUserServices>();
            var gameServicesMock = new Mock<IGameServices>();
            var cartViewModelFactory = new Mock<ICartViewModelFactory>();
            var pageFactory = new Mock<IPageServiceFactory<Game>>();

            var mocks = new MockRepository(MockBehavior.Default);
            Mock<IPrincipal> mockPrincipal = mocks.Create<IPrincipal>();
            mockPrincipal.SetupGet(p => p.Identity.Name).Returns("User");

            // create mock controller context
            var mockContext = new Mock<ControllerContext>();
            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            var controller = new ShopingCartController(userServicesMock.Object,
                gameServicesMock.Object, cartViewModelFactory.Object,
                pageFactory.Object)
            {
                ControllerContext = mockContext.Object
            };

            var user = new ApplicationUser()
            {
                ShopingCart = new List<Game>()
                {
                    new Game()
                    {

                    }
                }
            };

            var pageMock = new Mock<IPageService<Game>>();

            pageMock.Setup(x => x.GetMaxPage())
                .Returns(2);

            pageMock.Setup(x => x.GetPage(It.IsAny<int>()))
                .Returns(user.ShopingCart);

            pageFactory.Setup(x => x.Create(It.IsAny<IEnumerable<Game>>(), It.IsAny<int>()))
                .Returns(pageMock.Object);

            userServicesMock.Setup(x => x.GetUser("User"))
                .Returns(user);

            var model = new CartViewModel();

            cartViewModelFactory.Setup(x => x.Create(It.IsAny<IEnumerable<Game>>()))
                .Returns(model);

            gameServicesMock.Setup(x => x.GetById(1))
                .Returns(new Game())
                .Verifiable();
                

            //Act
            var view = controller.RemoveFromCart(1, 1) as ViewResult;

            //Assert
            Assert.AreSame(model, view.Model);
            gameServicesMock.VerifyAll();
            userServicesMock.Verify(x => x.GetUser("User"), Times.Exactly(2));
            pageFactory.Verify(x => x.Create(It.IsAny<IEnumerable<Game>>(), It.IsAny<int>()), Times.Exactly(2));
            pageMock.Verify(x => x.GetPage(It.IsAny<int>()), Times.Once());
            pageMock.Verify(x => x.GetMaxPage(), Times.Once());
            userServicesMock.Verify(x => x.RemoveGameFromCart(user, It.IsAny<Game>()), Times.Once());
        }
    }
}

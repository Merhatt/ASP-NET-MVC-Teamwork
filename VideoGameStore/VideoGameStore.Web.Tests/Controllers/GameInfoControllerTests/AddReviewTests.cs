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
using VideoGameStore.Web.Controllers;
using VideoGameStore.Web.Models;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Tests.Controllers.GameInfoControllerTests
{
    [TestFixture]
    public class AddReviewTests
    {
        [Test]
        public void NullReviewModelFactory_ShouldThrow()
        {
            //Arrange
            var gameServiceMock = new Mock<IGameServices>();
            var userServiceMock = new Mock<IUserServices>();
            var reviewServiceMock = new Mock<IReviewServices>();
            var gameInfoViewModelFactoryMock = new Mock<IGameInfoViewModelFactory>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var suportedPlatformModelFactoryMock = new Mock<ISuportedPlatformModelFactory>();
            var reviewModelFactory = new Mock<IReviewModelFactory>();

            var mocks = new MockRepository(MockBehavior.Default);
            Mock<IPrincipal> mockPrincipal = mocks.Create<IPrincipal>();
            mockPrincipal.SetupGet(p => p.Identity.Name).Returns("User");

            // create mock controller context
            var mockContext = new Mock<ControllerContext>();
            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            var controller = new GameInfoController(gameServiceMock.Object, userServiceMock.Object,
                reviewServiceMock.Object, gameInfoViewModelFactoryMock.Object,
                checkBoxModelFactoryMock.Object, suportedPlatformModelFactoryMock.Object,
                reviewModelFactory.Object)
            {
                ControllerContext = mockContext.Object
            };

            Game game = new Game();

            game.Categories = new List<Category>()
            {
                new Category()
                {
                    Name = "FPS"
                }
            };

            gameServiceMock.Setup(x => x.GetById(2))
                .Returns(game);

            var model = new GameInfoViewModel();

            model.Id = 2;
            model.ReviewComment = "ASDASD";

            //Act
            var err = Assert.Throws<NullReferenceException>(() => controller.AddReview(model));

            //Assert
            gameServiceMock.Verify(x => x.GetById(2), Times.Once());
            userServiceMock.Verify(x => x.GetUser(It.IsAny<string>()), Times.Once());
            reviewServiceMock.Verify(x => x.CreateReview("ASDASD", It.IsAny<ApplicationUser>(), game), Times.Once());
        }
    }
}

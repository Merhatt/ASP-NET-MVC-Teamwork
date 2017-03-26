using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class IndexTests
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

            var controller = new GameInfoController(gameServiceMock.Object, userServiceMock.Object,
                reviewServiceMock.Object, gameInfoViewModelFactoryMock.Object,
                checkBoxModelFactoryMock.Object, suportedPlatformModelFactoryMock.Object,
                reviewModelFactory.Object);

            Game game = new Game();

            game.Categories = new List<Category>()
            {
                new Category()
                {
                    Name = "FPS"
                }
            };

            checkBoxModelFactoryMock.Setup(x => x.Create(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new CheckBoxModel());


            game.SupportedPlatforms = new List<Platform>()
            {
                new Platform()
                {
                    Name = "Xbox"
                }
            };

            suportedPlatformModelFactoryMock.Setup(x => x.Create(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new SuportedPlatformModel());

            game.Reviews = new List<Review>()
            {
                new Review()
                {
                    Comment = "Test",
                    User = new ApplicationUser()
                    {
                        Id = "Id",
                        UserName = "Mincho"
                    }
                }
            };

            reviewModelFactory.Setup(x => x.Create(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new ReviewModel());

            gameServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(game);

            var model = new GameInfoViewModel();

            gameInfoViewModelFactoryMock.Setup(x => x.Create(It.IsAny<int>(),
                It.IsAny<string>(), It.IsAny<decimal>(),
                It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<IEnumerable<CheckBoxModel>>(),
                It.IsAny<IEnumerable<SuportedPlatformModel>>(),
                It.IsAny<IEnumerable<ReviewModel>>()))
                .Returns(model);

            //Act
            var view = controller.Index(2) as ViewResult;

            //Assert
            Assert.AreSame(model, view.Model);

            gameServiceMock.Verify(x => x.GetById(2), Times.Once());
            checkBoxModelFactoryMock.Verify(x => x.Create(0, "FPS"), Times.Once());
            suportedPlatformModelFactoryMock.Verify(x => x.Create(0, "Xbox"), Times.Once());
        }
    }
}

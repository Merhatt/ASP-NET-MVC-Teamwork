using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Services.Contracts;
using VideoGameStore.Web.Controllers;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Tests.Controllers.GameInfoControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void NullGameServices_ShouldThrow()
        {
            //Arrange
            var gameServiceMock = new Mock<IGameServices>();
            var userServiceMock = new Mock<IUserServices>();
            var reviewServiceMock = new Mock<IReviewServices>();
            var gameInfoViewModelFactoryMock = new Mock<IGameInfoViewModelFactory>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var suportedPlatformModelFactoryMock = new Mock<ISuportedPlatformModelFactory>();
            var reviewModelFactory = new Mock<IReviewModelFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => new GameInfoController(null, userServiceMock.Object,
                reviewServiceMock.Object, gameInfoViewModelFactoryMock.Object,
                checkBoxModelFactoryMock.Object, suportedPlatformModelFactoryMock.Object,
                reviewModelFactory.Object));

            Assert.AreEqual("gameServices cannot be null", err.Message);
        }

        [Test]
        public void NullUserServices_ShouldThrow()
        {
            //Arrange
            var gameServiceMock = new Mock<IGameServices>();
            var userServiceMock = new Mock<IUserServices>();
            var reviewServiceMock = new Mock<IReviewServices>();
            var gameInfoViewModelFactoryMock = new Mock<IGameInfoViewModelFactory>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var suportedPlatformModelFactoryMock = new Mock<ISuportedPlatformModelFactory>();
            var reviewModelFactory = new Mock<IReviewModelFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => 
            new GameInfoController(gameServiceMock.Object, null,
                reviewServiceMock.Object, gameInfoViewModelFactoryMock.Object,
                checkBoxModelFactoryMock.Object, suportedPlatformModelFactoryMock.Object,
                reviewModelFactory.Object));

            Assert.AreEqual("userServices cannot be null", err.Message);
        }

        [Test]
        public void NullReviewServices_ShouldThrow()
        {
            //Arrange
            var gameServiceMock = new Mock<IGameServices>();
            var userServiceMock = new Mock<IUserServices>();
            var reviewServiceMock = new Mock<IReviewServices>();
            var gameInfoViewModelFactoryMock = new Mock<IGameInfoViewModelFactory>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var suportedPlatformModelFactoryMock = new Mock<ISuportedPlatformModelFactory>();
            var reviewModelFactory = new Mock<IReviewModelFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() =>
            new GameInfoController(gameServiceMock.Object, userServiceMock.Object,
                null, gameInfoViewModelFactoryMock.Object,
                checkBoxModelFactoryMock.Object, suportedPlatformModelFactoryMock.Object,
                reviewModelFactory.Object));

            Assert.AreEqual("reviewServices cannot be null", err.Message);
        }

        [Test]
        public void NullGameInfoViewModelFactory_ShouldThrow()
        {
            //Arrange
            var gameServiceMock = new Mock<IGameServices>();
            var userServiceMock = new Mock<IUserServices>();
            var reviewServiceMock = new Mock<IReviewServices>();
            var gameInfoViewModelFactoryMock = new Mock<IGameInfoViewModelFactory>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var suportedPlatformModelFactoryMock = new Mock<ISuportedPlatformModelFactory>();
            var reviewModelFactory = new Mock<IReviewModelFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() =>
            new GameInfoController(gameServiceMock.Object, userServiceMock.Object,
                reviewServiceMock.Object, null,
                checkBoxModelFactoryMock.Object, suportedPlatformModelFactoryMock.Object,
                reviewModelFactory.Object));

            Assert.AreEqual("gameInfoViewModelFactory cannot be null", err.Message);
        }

        [Test]
        public void NullCheckBoxModelFactory_ShouldThrow()
        {
            //Arrange
            var gameServiceMock = new Mock<IGameServices>();
            var userServiceMock = new Mock<IUserServices>();
            var reviewServiceMock = new Mock<IReviewServices>();
            var gameInfoViewModelFactoryMock = new Mock<IGameInfoViewModelFactory>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var suportedPlatformModelFactoryMock = new Mock<ISuportedPlatformModelFactory>();
            var reviewModelFactory = new Mock<IReviewModelFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() =>
            new GameInfoController(gameServiceMock.Object, userServiceMock.Object,
                reviewServiceMock.Object, gameInfoViewModelFactoryMock.Object,
                null, suportedPlatformModelFactoryMock.Object,
                reviewModelFactory.Object));

            Assert.AreEqual("checkBoxCategoryModelFactory cannot be null", err.Message);
        }

        [Test]
        public void NullSuportedPlatformModelFactory_ShouldThrow()
        {
            //Arrange
            var gameServiceMock = new Mock<IGameServices>();
            var userServiceMock = new Mock<IUserServices>();
            var reviewServiceMock = new Mock<IReviewServices>();
            var gameInfoViewModelFactoryMock = new Mock<IGameInfoViewModelFactory>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var suportedPlatformModelFactoryMock = new Mock<ISuportedPlatformModelFactory>();
            var reviewModelFactory = new Mock<IReviewModelFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() =>
            new GameInfoController(gameServiceMock.Object, userServiceMock.Object,
                reviewServiceMock.Object, gameInfoViewModelFactoryMock.Object,
                checkBoxModelFactoryMock.Object, null,
                reviewModelFactory.Object));

            Assert.AreEqual("suportedPlatformModelFactory cannot be null", err.Message);
        }

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

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() =>
            new GameInfoController(gameServiceMock.Object, userServiceMock.Object,
                reviewServiceMock.Object, gameInfoViewModelFactoryMock.Object,
                checkBoxModelFactoryMock.Object, suportedPlatformModelFactoryMock.Object,
                null));

            Assert.AreEqual("reviewModelFactory cannot be null", err.Message);
        }
    }
}

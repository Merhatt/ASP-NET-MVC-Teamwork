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

namespace VideoGameStore.Web.Tests.Controllers.AdminControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void NullCategoryServices_ShouldThrow()
        {
            //Arrange
            var categoryServicesMock = new Mock<ICategoryServices>();
            var gameServicesMock = new Mock<IGameServices>();
            var platformServicesMock = new Mock<IPlatformServices>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var addGameViewModelFactoryMock = new Mock<IAddGameViewModelFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => new AdminController(null, gameServicesMock.Object,
                platformServicesMock.Object, checkBoxModelFactoryMock.Object,
                addGameViewModelFactoryMock.Object));

            Assert.AreEqual("categoryServices cannot be null", err.Message);
        }

        [Test]
        public void NullGameServices_ShouldThrow()
        {
            //Arrange
            var categoryServicesMock = new Mock<ICategoryServices>();
            var gameServicesMock = new Mock<IGameServices>();
            var platformServicesMock = new Mock<IPlatformServices>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var addGameViewModelFactoryMock = new Mock<IAddGameViewModelFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => new AdminController(categoryServicesMock.Object, null,
                platformServicesMock.Object, checkBoxModelFactoryMock.Object,
                addGameViewModelFactoryMock.Object));

            Assert.AreEqual("gameServices cannot be null", err.Message);
        }

        [Test]
        public void NullPlatformServices_ShouldThrow()
        {
            //Arrange
            var categoryServicesMock = new Mock<ICategoryServices>();
            var gameServicesMock = new Mock<IGameServices>();
            var platformServicesMock = new Mock<IPlatformServices>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var addGameViewModelFactoryMock = new Mock<IAddGameViewModelFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => new AdminController(categoryServicesMock.Object, gameServicesMock.Object,
                null, checkBoxModelFactoryMock.Object,
                addGameViewModelFactoryMock.Object));

            Assert.AreEqual("platformServices cannot be null", err.Message);
        }

        [Test]
        public void NullCheckBoxModelFactory_ShouldThrow()
        {
            //Arrange
            var categoryServicesMock = new Mock<ICategoryServices>();
            var gameServicesMock = new Mock<IGameServices>();
            var platformServicesMock = new Mock<IPlatformServices>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var addGameViewModelFactoryMock = new Mock<IAddGameViewModelFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => new AdminController(categoryServicesMock.Object, gameServicesMock.Object,
                platformServicesMock.Object, null,
                addGameViewModelFactoryMock.Object));

            Assert.AreEqual("checkBoxFactory cannot be null", err.Message);
        }

        [Test]
        public void NullAddGameViewModelFactory_ShouldThrow()
        {
            //Arrange
            var categoryServicesMock = new Mock<ICategoryServices>();
            var gameServicesMock = new Mock<IGameServices>();
            var platformServicesMock = new Mock<IPlatformServices>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var addGameViewModelFactoryMock = new Mock<IAddGameViewModelFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => new AdminController(categoryServicesMock.Object, gameServicesMock.Object,
                platformServicesMock.Object, checkBoxModelFactoryMock.Object,
                null));

            Assert.AreEqual("addGameViewModelFactory cannot be null", err.Message);
        }
    }
}

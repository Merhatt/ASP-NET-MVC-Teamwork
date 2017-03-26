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

namespace VideoGameStore.Web.Tests.Controllers.ShopingCartControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void NullUserServices_ShouldThrow()
        {
            //Arrange
            var userServicesMock = new Mock<IUserServices>();
            var gameServicesMock = new Mock<IGameServices>();
            var cartViewModelFactory = new Mock<ICartViewModelFactory>();
            var pageFactory = new Mock<IPageServiceFactory<Game>>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => new ShopingCartController(null,
                gameServicesMock.Object, cartViewModelFactory.Object, pageFactory.Object));

            Assert.AreEqual("userServices cannot be null", err.Message);
        }

        [Test]
        public void NullGameServices_ShouldThrow()
        {
            //Arrange
            var userServicesMock = new Mock<IUserServices>();
            var gameServicesMock = new Mock<IGameServices>();
            var cartViewModelFactory = new Mock<ICartViewModelFactory>();
            var pageFactory = new Mock<IPageServiceFactory<Game>>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => 
            new ShopingCartController(userServicesMock.Object,
                null, cartViewModelFactory.Object, pageFactory.Object));

            Assert.AreEqual("gameServices cannot be null", err.Message);
        }

        [Test]
        public void NullCartViewModelFactory_ShouldThrow()
        {
            //Arrange
            var userServicesMock = new Mock<IUserServices>();
            var gameServicesMock = new Mock<IGameServices>();
            var cartViewModelFactory = new Mock<ICartViewModelFactory>();
            var pageFactory = new Mock<IPageServiceFactory<Game>>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() =>
            new ShopingCartController(userServicesMock.Object,
                gameServicesMock.Object, null, 
                pageFactory.Object));

            Assert.AreEqual("cartViewModelFactory cannot be null", err.Message);
        }

        [Test]
        public void NullPageFactory_ShouldThrow()
        {
            //Arrange
            var userServicesMock = new Mock<IUserServices>();
            var gameServicesMock = new Mock<IGameServices>();
            var cartViewModelFactory = new Mock<ICartViewModelFactory>();
            var pageFactory = new Mock<IPageServiceFactory<Game>>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() =>
            new ShopingCartController(userServicesMock.Object,
                gameServicesMock.Object, cartViewModelFactory.Object,
                null));

            Assert.AreEqual("pageServiceFactory cannot be null", err.Message);
        }
    }
}

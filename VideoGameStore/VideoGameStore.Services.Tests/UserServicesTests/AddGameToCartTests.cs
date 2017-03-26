using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Contracts;
using VideoGameStore.Data.Models;

namespace VideoGameStore.Services.Tests.UserServicesTests
{
    [TestFixture]
    public class AddGameToCartTests
    {
        [Test]
        public void NullUser_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var service = new UserServices(repositoryMock.Object, unitOfWorkMock.Object);

            ApplicationUser user = new ApplicationUser();
            Game game = new Game();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => service.AddGameToCart(null, game));

            Assert.AreEqual("user cannot be null", err.Message);
        }

        [Test]
        public void NullGame_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var service = new UserServices(repositoryMock.Object, unitOfWorkMock.Object);

            ApplicationUser user = new ApplicationUser();
            Game game = new Game();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => service.AddGameToCart(user, null));

            Assert.AreEqual("game cannot be null", err.Message);
        }

        [Test]
        public void CorrectValues_GameNotInCart_ShouldAdd()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var service = new UserServices(repositoryMock.Object, unitOfWorkMock.Object);

            ApplicationUser user = new ApplicationUser();
            Game game = new Game();
            game.Name = "game";

            //Act
            service.AddGameToCart(user, game);

            //Assert
            Assert.AreEqual(1, user.ShopingCart.Count);
            Assert.Contains(game, user.ShopingCart.ToList());

            unitOfWorkMock.Verify(x => x.Commit(), Times.Once());
        }

        [Test]
        public void CorrectValues_GameInCart_ShouldNotAdd()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var service = new UserServices(repositoryMock.Object, unitOfWorkMock.Object);

            ApplicationUser user = new ApplicationUser();
            Game game = new Game();
            game.Name = "game";

            user.ShopingCart.Add(game);

            //Act
            service.AddGameToCart(user, game);

            //Assert
            unitOfWorkMock.Verify(x => x.Commit(), Times.Never());
        }
    }
}

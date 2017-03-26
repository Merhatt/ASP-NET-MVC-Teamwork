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
    public class RemoveGameFromCartTests
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
            var err = Assert.Throws<NullReferenceException>(() => service.RemoveGameFromCart(null, game));

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
            var err = Assert.Throws<NullReferenceException>(() => service.RemoveGameFromCart(user, null));

            Assert.AreEqual("game cannot be null", err.Message);
        }

        [Test]
        public void GameNotInShoppingCart_ShouldReturn()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var service = new UserServices(repositoryMock.Object, unitOfWorkMock.Object);

            ApplicationUser user = new ApplicationUser();
            Game game = new Game();
            game.Name = "Cod";
            game.Id = 1;

            user.ShopingCart.Add(new Game()
            {
                Name = "Battlefield 1",
                Id = 2
            });

            //Act
            service.RemoveGameFromCart(user, game);

            //Assert
            unitOfWorkMock.Verify(x => x.Commit(), Times.Never());
        }

        [Test]
        public void GameInShoppingCart_ShouldRemove()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var service = new UserServices(repositoryMock.Object, unitOfWorkMock.Object);

            ApplicationUser user = new ApplicationUser();
            Game game = new Game();
            game.Name = "Cod";
            game.Id = 1;

            user.ShopingCart.Add(game);

            //Act
            service.RemoveGameFromCart(user, game);

            //Assert
            Assert.AreEqual(0, user.ShopingCart.Count);
            
            unitOfWorkMock.Verify(x => x.Commit(), Times.Once());
        }
    }
}

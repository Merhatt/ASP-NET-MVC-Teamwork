using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Contracts;
using VideoGameStore.Data.Models;
using VideoGameStore.Utils.Factories.Contracts;

namespace VideoGameStore.Services.Tests.ReviewServicesTests
{
    [TestFixture]
    public class CreateReviewTests
    {
        [Test]
        public void NullComment_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Review>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var reviewFactoryMock = new Mock<IReviewFactory>();
            
            var service = new ReviewServices(repositoryMock.Object, unitOfWorkMock.Object, reviewFactoryMock.Object);

            string comment = null;
            ApplicationUser user = new ApplicationUser();
            Game game = new Game();

            //Act & Assert
            var message = Assert.Throws<NullReferenceException>(() => service.CreateReview(comment, user, game));

            Assert.AreEqual("comment cannot be null", message.Message);
        }

        [Test]
        public void EmptyComment_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Review>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var reviewFactoryMock = new Mock<IReviewFactory>();

            var service = new ReviewServices(repositoryMock.Object, unitOfWorkMock.Object, reviewFactoryMock.Object);

            string comment = "";
            ApplicationUser user = new ApplicationUser();
            Game game = new Game();

            //Act & Assert
            var message = Assert.Throws<NullReferenceException>(() => service.CreateReview(comment, user, game));

            Assert.AreEqual("comment cannot be null", message.Message);
        }

        [Test]
        public void NullUser_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Review>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var reviewFactoryMock = new Mock<IReviewFactory>();

            var service = new ReviewServices(repositoryMock.Object, unitOfWorkMock.Object, reviewFactoryMock.Object);

            string comment = "asdsad";
            ApplicationUser user = null;
            Game game = new Game();

            //Act & Assert
            var message = Assert.Throws<NullReferenceException>(() => service.CreateReview(comment, user, game));

            Assert.AreEqual("user cannot be null", message.Message);
        }

        [Test]
        public void NullGame_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Review>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var reviewFactoryMock = new Mock<IReviewFactory>();

            var service = new ReviewServices(repositoryMock.Object, unitOfWorkMock.Object, reviewFactoryMock.Object);

            string comment = "asdsad";
            ApplicationUser user = new ApplicationUser();
            Game game = null;

            //Act & Assert
            var message = Assert.Throws<NullReferenceException>(() => service.CreateReview(comment, user, game));

            Assert.AreEqual("game cannot be null", message.Message);
        }

        [Test]
        public void EverythingCorrect_ShouldCreate()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Review>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var reviewFactoryMock = new Mock<IReviewFactory>();

            var service = new ReviewServices(repositoryMock.Object, unitOfWorkMock.Object, reviewFactoryMock.Object);

            string comment = "asdsad";
            ApplicationUser user = new ApplicationUser();
            Game game = new Game();

            var reviewToAdd = new Review();

            reviewFactoryMock.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<ApplicationUser>(), It.IsAny<Game>()))
                .Returns(reviewToAdd);

            //Act
            service.CreateReview(comment, user, game);

            //Assert
            reviewFactoryMock.Verify(x => x.Create(comment, user, game), Times.Once());
            repositoryMock.Verify(x => x.Add(reviewToAdd), Times.Once());
            unitOfWorkMock.Verify(x => x.Commit(), Times.Once());
        }
    }
}

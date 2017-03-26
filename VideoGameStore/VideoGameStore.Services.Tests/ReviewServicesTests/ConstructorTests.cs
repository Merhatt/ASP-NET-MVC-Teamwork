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
    public class ConstructorTests
    {
        [Test]
        public void NullRepository_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Review>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var reviewFactoryMock = new Mock<IReviewFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => new ReviewServices(null, unitOfWorkMock.Object, reviewFactoryMock.Object));

            Assert.AreEqual("repository cannot be null", err.Message);
        }

        [Test]
        public void NullUnitOfWork_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Review>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var reviewFactoryMock = new Mock<IReviewFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => new ReviewServices(repositoryMock.Object, null, reviewFactoryMock.Object));

            Assert.AreEqual("unitOfWork cannot be null", err.Message);
        }

        [Test]
        public void NullReviewFactory_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Review>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var reviewFactoryMock = new Mock<IReviewFactory>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => new ReviewServices(repositoryMock.Object, unitOfWorkMock.Object, null));

            Assert.AreEqual("reviewFactory cannot be null", err.Message);
        }
    }
}

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
    public class ConstructorTests
    {
        [Test]
        public void NullRepository_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => new UserServices(null, unitOfWorkMock.Object));

            Assert.AreEqual("repository cannot be null", err.Message);
        }

        [Test]
        public void NullUnitOfWork_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => new UserServices(repositoryMock.Object, null));

            Assert.AreEqual("unitOfWork cannot be null", err.Message);
        }
    }
}

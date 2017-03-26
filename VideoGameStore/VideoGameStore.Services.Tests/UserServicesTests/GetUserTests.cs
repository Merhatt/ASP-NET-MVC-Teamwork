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
    public class GetUserTests
    {
        [Test]
        public void NullUsername_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var service = new UserServices(repositoryMock.Object, unitOfWorkMock.Object);

            string name = null;

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => service.GetUser(name));

            Assert.AreEqual("username cannot be null or empty", err.Message);
        }

        [Test]
        public void EmptyUsername_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var service = new UserServices(repositoryMock.Object, unitOfWorkMock.Object);

            string name = "";

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => service.GetUser(name));

            Assert.AreEqual("username cannot be null or empty", err.Message);
        }

        [Test]
        public void MatchingResult_ShouldReturnCorrectly()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var service = new UserServices(repositoryMock.Object, unitOfWorkMock.Object);

            string name = "ivan";

            var users = new List<ApplicationUser>();

            var user1 = new ApplicationUser();
            user1.UserName = "ivan";

            users.Add(user1);

            var user2 = new ApplicationUser();
            user2.UserName = "dragan";

            users.Add(user2);

            repositoryMock.Setup(x => x.All())
                .Returns(users.AsQueryable());

            //Act
            var user = service.GetUser("ivan");

            //Assert
            Assert.AreEqual("ivan", user.UserName);
            repositoryMock.Verify(x => x.All(), Times.Once());
        }

        [Test]
        public void NoMatchingResult_ShouldReturnCorrectly()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<ApplicationUser>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var service = new UserServices(repositoryMock.Object, unitOfWorkMock.Object);

            string name = "ivan";

            var users = new List<ApplicationUser>();

            var user1 = new ApplicationUser();
            user1.UserName = "ivan";

            users.Add(user1);

            var user2 = new ApplicationUser();
            user2.UserName = "dragan";

            users.Add(user2);

            repositoryMock.Setup(x => x.All())
                .Returns(users.AsQueryable());

            //Act
            var user = service.GetUser("test");

            //Assert
            Assert.IsNull(user);
            repositoryMock.Verify(x => x.All(), Times.Once());
        }
    }
}

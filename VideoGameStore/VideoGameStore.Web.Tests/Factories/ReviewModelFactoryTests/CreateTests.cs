using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Web.Models.Factories;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Tests.Factories.ReviewModelFactoryTests
{
    [TestFixture]
    public class CreateTests
    {
        [Test]
        public void NegativeId_ShouldThrow()
        {
            //Arrange
            var userFactoryMock = new Mock<IUserModelFactory>();

            var factory = new ReviewModelFactory(userFactoryMock.Object);

            int id = -2;
            string comment = "comment";
            string userId = "userId";
            string authorName = "name";

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, comment, userId, authorName));

            Assert.AreEqual("id cannot be less than 0", msg.Message);
        }

        [Test]
        public void NullComment_ShouldThrow()
        {
            //Arrange
            var userFactoryMock = new Mock<IUserModelFactory>();

            var factory = new ReviewModelFactory(userFactoryMock.Object);

            int id = 2;
            string comment = null;
            string userId = "userId";
            string authorName = "name";

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, comment, userId, authorName));

            Assert.AreEqual("comment cannot be less than 0", msg.Message);
        }

        [Test]
        public void EmptyComment_ShouldThrow()
        {
            //Arrange
            var userFactoryMock = new Mock<IUserModelFactory>();

            var factory = new ReviewModelFactory(userFactoryMock.Object);

            int id = 2;
            string comment = "";
            string userId = "userId";
            string authorName = "name";

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, comment, userId, authorName));

            Assert.AreEqual("comment cannot be less than 0", msg.Message);
        }

        [Test]
        public void ShouldSetCorrectly()
        {
            //Arrange
            var userFactoryMock = new Mock<IUserModelFactory>();

            var factory = new ReviewModelFactory(userFactoryMock.Object);

            int id = 2;
            string comment = "asda";
            string userId = "userId";
            string authorName = "name";

            //Act
            var model = factory.Create(id, comment, userId, authorName);

            //Assert
            Assert.AreEqual(id, model.Id);
            Assert.AreEqual(comment, model.Comment);

            userFactoryMock.Verify(x => x.Create(userId, authorName), Times.Once());
        }
    }
}

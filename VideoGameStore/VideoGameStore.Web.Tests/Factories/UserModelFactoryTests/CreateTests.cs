using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Web.Models.Factories;

namespace VideoGameStore.Web.Tests.Factories.UserModelFactoryTests
{
    [TestFixture]
    public class CreateTests
    {
        [Test]
        public void NullId_ShouldThrow()
        {
            //Arrange
            var factory = new UserModelFactory();

            string id = null;
            string username = "Ivan";

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, username));

            Assert.AreEqual("id cannot be null", msg.Message);
        }

        [Test]
        public void EmptyId_ShouldThrow()
        {
            //Arrange
            var factory = new UserModelFactory();

            string id = "";
            string username = "Ivan";

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, username));

            Assert.AreEqual("id cannot be null", msg.Message);
        }

        [Test]
        public void NullUsername_ShouldThrow()
        {
            //Arrange
            var factory = new UserModelFactory();

            string id = "asdas";
            string username = null;

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, username));

            Assert.AreEqual("username cannot be null", msg.Message);
        }

        [Test]
        public void EmptyUsername_ShouldThrow()
        {
            //Arrange
            var factory = new UserModelFactory();

            string id = "asdas";
            string username = "";

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, username));

            Assert.AreEqual("username cannot be null", msg.Message);
        }

        [Test]
        public void ShouldReturnCorrectly()
        {
            //Arrange
            var factory = new UserModelFactory();

            string id = "asdas";
            string username = "test";

            //Act
            var model = factory.Create(id, username);

            //Assert
            Assert.AreEqual(id, model.Id);
            Assert.AreEqual(username, model.Username);
        }
    }
}

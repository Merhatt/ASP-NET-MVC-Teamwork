using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Web.Models.Factories;

namespace VideoGameStore.Web.Tests.Factories.SuportedPlatformModelFactoryTests
{
    [TestFixture]
    public class CreateTests
    {
        [Test]
        public void LessThanZeroId_ShouldThrow()
        {
            //Arrange
            var factory = new SuportedPlatformModelFactory();

            int id = -2;
            string name = "test";

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, name));

            Assert.AreEqual("Id cannot be less than 0", msg.Message);
        }

        [Test]
        public void NullName_ShouldThrow()
        {
            //Arrange
            var factory = new SuportedPlatformModelFactory();

            int id = 2;
            string name = null;

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, name));

            Assert.AreEqual("name cannot be null", msg.Message);
        }

        [Test]
        public void EmptyName_ShouldThrow()
        {
            //Arrange
            var factory = new SuportedPlatformModelFactory();

            int id = 2;
            string name = "";

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, name));

            Assert.AreEqual("name cannot be null", msg.Message);
        }

        [Test]
        public void ShouldReturnCorrectly()
        {
            //Arrange
            var factory = new SuportedPlatformModelFactory();

            int id = 2;
            string name = "Test";

            //Act
            var model = factory.Create(id, name);

            //Assert
            Assert.AreEqual(id, model.Id);
            Assert.AreEqual(name, model.Name);
        }
    }
}

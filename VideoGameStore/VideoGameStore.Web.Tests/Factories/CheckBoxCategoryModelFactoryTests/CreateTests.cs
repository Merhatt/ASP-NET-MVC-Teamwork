using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Web.Models.Factories;

namespace VideoGameStore.Web.Tests.Factories.CheckBoxCategoryModelFactoryTests
{
    [TestFixture]
    public class CreateTests
    {
        [Test]
        public void NegativeId_ShouldThrow()
        {
            //Arrange
            int id = -1;

            string name = "ivan";

            var factory = new CheckBoxCategoryModelFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, name));

            Assert.AreEqual("Id cannot be less than 0", msg.Message);
        }

        [Test]
        public void NullName_ShouldThrow()
        {
            //Arrange
            int id = 4;

            string name = null;

            var factory = new CheckBoxCategoryModelFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, name));

            Assert.AreEqual("name cannot be null", msg.Message);
        }

        [Test]
        public void EmptyName_ShouldThrow()
        {
            //Arrange
            int id = 4;

            string name = "";

            var factory = new CheckBoxCategoryModelFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, name));

            Assert.AreEqual("name cannot be null", msg.Message);
        }

        [Test]
        public void ShouldReturnCorrectly()
        {
            //Arrange
            int id = 4;

            string name = "Ivan";

            var factory = new CheckBoxCategoryModelFactory();

            //Act
            var model = factory.Create(id, name);

            //Assert
            Assert.AreEqual(name, model.Name);
            Assert.AreEqual(id, model.Id);
        }
    }
}

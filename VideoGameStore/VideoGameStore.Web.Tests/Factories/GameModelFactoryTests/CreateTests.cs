using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Web.Models;
using VideoGameStore.Web.Models.Factories;

namespace VideoGameStore.Web.Tests.Factories.GameModelFactoryTests
{
    [TestFixture]
    public class CreateTests
    {
        [Test]
        public void NegativeId_ShouldThrow()
        {
            //Arrange
            GameModelFactory factory = new GameModelFactory();

            int id = -4;
            string name = "test";
            decimal price = 213;
            string description = "dsad";
            string imageUrl = "asdas";
            IEnumerable<string> categories = new List<string>();
            IEnumerable<string> platforms = new List<string>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, platforms));
            Assert.AreEqual("id cannot be less than 0", err.Message);
        }

        [Test]
        public void NullName_ShouldThrow()
        {
            //Arrange
            GameModelFactory factory = new GameModelFactory();

            int id = 4;
            string name = null;
            decimal price = 213;
            string description = "dsad";
            string imageUrl = "asdas";
            IEnumerable<string> categories = new List<string>();
            IEnumerable<string> platforms = new List<string>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, platforms));
            Assert.AreEqual("name cannot be null", err.Message);
        }

        [Test]
        public void EmptyName_ShouldThrow()
        {
            //Arrange
            GameModelFactory factory = new GameModelFactory();

            int id = 4;
            string name = "";
            decimal price = 213;
            string description = "dsad";
            string imageUrl = "asdas";
            IEnumerable<string> categories = new List<string>();
            IEnumerable<string> platforms = new List<string>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, platforms));
            Assert.AreEqual("name cannot be null", err.Message);
        }

        [Test]
        public void NegativePrice_ShouldThrow()
        {
            //Arrange
            GameModelFactory factory = new GameModelFactory();

            int id = 4;
            string name = "asdd";
            decimal price = -213;
            string description = "dsad";
            string imageUrl = "asdas";
            IEnumerable<string> categories = new List<string>();
            IEnumerable<string> platforms = new List<string>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, platforms));
            Assert.AreEqual("price cannot be less than 0", err.Message);
        }

        [Test]
        public void NullDescription_ShouldThrow()
        {
            //Arrange
            GameModelFactory factory = new GameModelFactory();

            int id = 4;
            string name = "asdd";
            decimal price = 213;
            string description = null;
            string imageUrl = "asdas";
            IEnumerable<string> categories = new List<string>();
            IEnumerable<string> platforms = new List<string>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, platforms));
            Assert.AreEqual("description cannot be null", err.Message);
        }

        [Test]
        public void EmptypDescription_ShouldThrow()
        {
            //Arrange
            GameModelFactory factory = new GameModelFactory();

            int id = 4;
            string name = "asdd";
            decimal price = 213;
            string description = "";
            string imageUrl = "asdas";
            IEnumerable<string> categories = new List<string>();
            IEnumerable<string> platforms = new List<string>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, platforms));
            Assert.AreEqual("description cannot be null", err.Message);
        }

        [Test]
        public void NullImageUrl_ShouldThrow()
        {
            //Arrange
            GameModelFactory factory = new GameModelFactory();

            int id = 4;
            string name = "asdd";
            decimal price = 213;
            string description = "asdas";
            string imageUrl = null;
            IEnumerable<string> categories = new List<string>();
            IEnumerable<string> platforms = new List<string>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, platforms));
            Assert.AreEqual("imageUrl cannot be null", err.Message);
        }

        [Test]
        public void EmptyImageUrl_ShouldThrow()
        {
            //Arrange
            GameModelFactory factory = new GameModelFactory();

            int id = 4;
            string name = "asdd";
            decimal price = 213;
            string description = "asdas";
            string imageUrl = "";
            IEnumerable<string> categories = new List<string>();
            IEnumerable<string> platforms = new List<string>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, platforms));
            Assert.AreEqual("imageUrl cannot be null", err.Message);
        }

        [Test]
        public void NullCategories_ShouldThrow()
        {
            //Arrange
            GameModelFactory factory = new GameModelFactory();

            int id = 4;
            string name = "asdd";
            decimal price = 213;
            string description = "asdas";
            string imageUrl = "asdsad";
            IEnumerable<string> categories = null;
            IEnumerable<string> platforms = new List<string>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, platforms));
            Assert.AreEqual("categories cannot be null", err.Message);
        }

        [Test]
        public void NullPlatforms_ShouldThrow()
        {
            //Arrange
            GameModelFactory factory = new GameModelFactory();

            int id = 4;
            string name = "asdd";
            decimal price = 213;
            string description = "asdas";
            string imageUrl = "asdsad";
            IEnumerable<string> categories = new List<string>();
            IEnumerable<string> platforms = null;

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, platforms));
            Assert.AreEqual("platforms cannot be null", err.Message);
        }

        [Test]
        public void ShouldGetModel()
        {
            //Arrange
            GameModelFactory factory = new GameModelFactory();

            int id = 4;
            string name = "asdd";
            decimal price = 213;
            string description = "asdas";
            string imageUrl = "asdsad";
            IEnumerable<string> categories = new List<string>();
            IEnumerable<string> platforms = new List<string>();

            //Act
            GameModel model = factory.Create(id, name, price, description, imageUrl, categories, platforms);

            //Assert
            Assert.AreEqual(id, model.Id);
            Assert.AreEqual(name, model.Name);
            Assert.AreEqual(price, model.Price);
            Assert.AreEqual(description, model.Description);
            Assert.AreEqual(imageUrl, model.ImageUrl);
            Assert.AreSame(categories, model.Categories);
            Assert.AreSame(platforms, model.Platforms);
        }
    }
}

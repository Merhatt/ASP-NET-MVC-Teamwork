using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Models;
using VideoGameStore.Utils.Factories;

namespace VideoGameStore.Utils.Tests.Factories
{
    [TestFixture]
    public class GameFactoryTests
    {
        [Test]
        public void Create_NullName_ShouldThrow()
        {
            //Arrange
            string name = null;
            decimal price = 10;
            string description = "description";
            string imageUrl = "testUrl";

            ICollection<Category> categories = new List<Category>();
            categories.Add(new Category());

            GameFactory factory = new GameFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(name, price, description, imageUrl, categories));

            Assert.AreEqual("name cannot be null", msg.Message);
        }

        [Test]
        public void Create_PriceLessThanZero_ShouldThrow()
        {
            //Arrange
            string name = "Asd";
            decimal price = -10;
            string description = "description";
            string imageUrl = "testUrl";

            ICollection<Category> categories = new List<Category>();
            categories.Add(new Category());

            GameFactory factory = new GameFactory();

            //Act & Assert
            var msg = Assert.Throws<ArgumentOutOfRangeException>(() => factory.Create(name, price, description, imageUrl, categories));
        }

        [Test]
        public void Create_NullDescription_ShouldThrow()
        {
            //Arrange
            string name = "Asd";
            decimal price = 10;
            string description = null;
            string imageUrl = "testUrl";

            ICollection<Category> categories = new List<Category>();
            categories.Add(new Category());

            GameFactory factory = new GameFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(name, price, description, imageUrl, categories));

            Assert.AreEqual("description cannot be null", msg.Message);
        }

        [Test]
        public void Create_NullImageUrl_ShouldThrow()
        {
            //Arrange
            string name = "Asd";
            decimal price = 10;
            string description = "Tests";
            string imageUrl = null;

            ICollection<Category> categories = new List<Category>();
            categories.Add(new Category());

            GameFactory factory = new GameFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(name, price, description, imageUrl, categories));

            Assert.AreEqual("imageUrl cannot be null", msg.Message);
        }

        [Test]
        public void Create_NullCategories_ShouldThrow()
        {
            //Arrange
            string name = "Asd";
            decimal price = 10;
            string description = "Tests";
            string imageUrl = "asdasd";

            ICollection<Category> categories = null;

            GameFactory factory = new GameFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(name, price, description, imageUrl, categories));

            Assert.AreEqual("game categories cannot be null or empty", msg.Message);
        }

        [Test]
        public void Create_EmptyCategories_ShouldThrow()
        {
            //Arrange
            string name = "Asd";
            decimal price = 10;
            string description = "Tests";
            string imageUrl = "asdasd";

            ICollection<Category> categories = new List<Category>();

            GameFactory factory = new GameFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(name, price, description, imageUrl, categories));

            Assert.AreEqual("game categories cannot be null or empty", msg.Message);
        }

        [Test]
        public void Create_ShouldCreateGame()
        {
            //Arrange
            string name = "Asd";
            decimal price = 10;
            string description = "Tests";
            string imageUrl = "asdasd";

            ICollection<Category> categories = new List<Category>();
            categories.Add(new Category());

            GameFactory factory = new GameFactory();

            //Act
            Game game = factory.Create(name, price, description, imageUrl, categories);

            //Assert
            Assert.AreEqual(name, game.Name);
            Assert.AreEqual(price, game.Price);
            Assert.AreEqual(description, game.Description);
            Assert.AreEqual(imageUrl, game.ImageUrl);
            Assert.AreSame(categories, game.Categories);
        }
    }
}

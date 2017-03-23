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

            ICollection<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform());

            GameFactory factory = new GameFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(name, price, description, imageUrl, categories, platforms));

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

            ICollection<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform());

            ICollection<Category> categories = new List<Category>();
            categories.Add(new Category());

            GameFactory factory = new GameFactory();

            //Act & Assert
            var msg = Assert.Throws<ArgumentOutOfRangeException>(() => factory.Create(name, price, description, imageUrl, categories, platforms));
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

            ICollection<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform());

            GameFactory factory = new GameFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(name, price, description, imageUrl, categories, platforms));

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

            ICollection<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform());

            ICollection<Category> categories = new List<Category>();
            categories.Add(new Category());

            GameFactory factory = new GameFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(name, price, description, imageUrl, categories, platforms));

            Assert.AreEqual("imageUrl cannot be null", msg.Message);
        }

        [Test]
        public void Create_NullCategories_ShouldThrow()
        {
            //Arrange
            string name = "Asd";
            decimal price = 10;
            string description = "Tests";

            ICollection<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform());

            string imageUrl = "asdasd";

            ICollection<Category> categories = null;

            GameFactory factory = new GameFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(name, price, description, imageUrl, categories, platforms));

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

            ICollection<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform());

            ICollection<Category> categories = new List<Category>();

            GameFactory factory = new GameFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(name, price, description, imageUrl, categories, platforms));

            Assert.AreEqual("game categories cannot be null or empty", msg.Message);
        }

        [Test]
        public void Create_NullPlatforms_ShouldThrow()
        {
            //Arrange
            string name = "Asd";
            decimal price = 10;
            string description = "Tests";
            string imageUrl = "asdasd";

            ICollection<Platform> platforms = null;

            ICollection<Category> categories = new List<Category>();
            categories.Add(new Category());

            GameFactory factory = new GameFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(name, price, description, imageUrl, categories, platforms));

            Assert.AreEqual("platforms cannot be null or empty", msg.Message);
        }

        [Test]
        public void Create_EmptyPlatforms_ShouldThrow()
        {
            //Arrange
            string name = "Asd";
            decimal price = 10;
            string description = "Tests";
            string imageUrl = "asdasd";

            ICollection<Platform> platforms = new List<Platform>();

            ICollection<Category> categories = new List<Category>();
            categories.Add(new Category());

            GameFactory factory = new GameFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(name, price, description, imageUrl, categories, platforms));

            Assert.AreEqual("platforms cannot be null or empty", msg.Message);
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

            ICollection<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform());

            GameFactory factory = new GameFactory();

            //Act
            Game game = factory.Create(name, price, description, imageUrl, categories, platforms);

            //Assert
            Assert.AreEqual(name, game.Name);
            Assert.AreEqual(price, game.Price);
            Assert.AreEqual(description, game.Description);
            Assert.AreEqual(imageUrl, game.ImageUrl);
            Assert.AreEqual(categories, game.Categories);
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Web.Models;
using VideoGameStore.Web.Models.Factories;

namespace VideoGameStore.Web.Tests.Factories.GameInfoViewModelFactoryTests
{
    [TestFixture]
    public class CreateTests
    {
        [Test]
        public void NegativeId_ShouldThrow()
        {
            //Arrange
            int id = -2;
            string name = "Ivan";
            decimal price = 12;
            string description = "description";
            string imageUrl = "imgurl";
            IList<CheckBoxModel> categories = new List<CheckBoxModel>();
            IList<SuportedPlatformModel> suportedPlatforms = new List<SuportedPlatformModel>();
            IList<ReviewModel> reviews = new List<ReviewModel>();

            var factory = new GameInfoViewModelFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, suportedPlatforms, reviews));

            Assert.AreEqual("Id cannot be less than 0", msg.Message);
        }

        [Test]
        public void NullName_ShouldThrow()
        {
            //Arrange
            int id = 12;
            string name = null;
            decimal price = 12;
            string description = "description";
            string imageUrl = "imgurl";
            IList<CheckBoxModel> categories = new List<CheckBoxModel>();
            IList<SuportedPlatformModel> suportedPlatforms = new List<SuportedPlatformModel>();
            IList<ReviewModel> reviews = new List<ReviewModel>();

            var factory = new GameInfoViewModelFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, suportedPlatforms, reviews));

            Assert.AreEqual("name cannot be null or empty", msg.Message);
        }

        [Test]
        public void EmptyName_ShouldThrow()
        {
            //Arrange
            int id = 12;
            string name = "";
            decimal price = 12;
            string description = "description";
            string imageUrl = "imgurl";
            IList<CheckBoxModel> categories = new List<CheckBoxModel>();
            IList<SuportedPlatformModel> suportedPlatforms = new List<SuportedPlatformModel>();
            IList<ReviewModel> reviews = new List<ReviewModel>();

            var factory = new GameInfoViewModelFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, suportedPlatforms, reviews));

            Assert.AreEqual("name cannot be null or empty", msg.Message);
        }

        [Test]
        public void NegativePrice_ShouldThrow()
        {
            //Arrange
            int id = 12;
            string name = "asdag";
            decimal price = -12;
            string description = "description";
            string imageUrl = "imgurl";
            IList<CheckBoxModel> categories = new List<CheckBoxModel>();
            IList<SuportedPlatformModel> suportedPlatforms = new List<SuportedPlatformModel>();
            IList<ReviewModel> reviews = new List<ReviewModel>();

            var factory = new GameInfoViewModelFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, suportedPlatforms, reviews));

            Assert.AreEqual("price cannot be less than 0", msg.Message);
        }

        [Test]
        public void NullDescription_ShouldThrow()
        {
            //Arrange
            int id = 12;
            string name = "asdag";
            decimal price = 12;
            string description = null;
            string imageUrl = "imgurl";
            IList<CheckBoxModel> categories = new List<CheckBoxModel>();
            IList<SuportedPlatformModel> suportedPlatforms = new List<SuportedPlatformModel>();
            IList<ReviewModel> reviews = new List<ReviewModel>();

            var factory = new GameInfoViewModelFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, suportedPlatforms, reviews));

            Assert.AreEqual("description cannot be null or empty", msg.Message);
        }

        [Test]
        public void EmptyDescription_ShouldThrow()
        {
            //Arrange
            int id = 12;
            string name = "asdag";
            decimal price = 12;
            string description = "";
            string imageUrl = "imgurl";
            IList<CheckBoxModel> categories = new List<CheckBoxModel>();
            IList<SuportedPlatformModel> suportedPlatforms = new List<SuportedPlatformModel>();
            IList<ReviewModel> reviews = new List<ReviewModel>();

            var factory = new GameInfoViewModelFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, suportedPlatforms, reviews));

            Assert.AreEqual("description cannot be null or empty", msg.Message);
        }

        [Test]
        public void NullImageUrl_ShouldThrow()
        {
            //Arrange
            int id = 12;
            string name = "asdag";
            decimal price = 12;
            string description = "Desadas";
            string imageUrl = null;
            IList<CheckBoxModel> categories = new List<CheckBoxModel>();
            IList<SuportedPlatformModel> suportedPlatforms = new List<SuportedPlatformModel>();
            IList<ReviewModel> reviews = new List<ReviewModel>();

            var factory = new GameInfoViewModelFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, suportedPlatforms, reviews));

            Assert.AreEqual("imageUrl cannot be null or empty", msg.Message);
        }

        [Test]
        public void EmptyImageUrl_ShouldThrow()
        {
            //Arrange
            int id = 12;
            string name = "asdag";
            decimal price = 12;
            string description = "Desadas";
            string imageUrl = "";
            IList<CheckBoxModel> categories = new List<CheckBoxModel>();
            IList<SuportedPlatformModel> suportedPlatforms = new List<SuportedPlatformModel>();
            IList<ReviewModel> reviews = new List<ReviewModel>();

            var factory = new GameInfoViewModelFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, suportedPlatforms, reviews));

            Assert.AreEqual("imageUrl cannot be null or empty", msg.Message);
        }

        [Test]
        public void NullCategories_ShouldThrow()
        {
            //Arrange
            int id = 12;
            string name = "asdag";
            decimal price = 12;
            string description = "Desadas";
            string imageUrl = "asdasd";
            IList<CheckBoxModel> categories = null;
            IList<SuportedPlatformModel> suportedPlatforms = new List<SuportedPlatformModel>();
            IList<ReviewModel> reviews = new List<ReviewModel>();

            var factory = new GameInfoViewModelFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, suportedPlatforms, reviews));

            Assert.AreEqual("categories cannot be null", msg.Message);
        }

        [Test]
        public void NullPlatforms_ShouldThrow()
        {
            //Arrange
            int id = 12;
            string name = "asdag";
            decimal price = 12;
            string description = "Desadas";
            string imageUrl = "asdasd";
            IList<CheckBoxModel> categories = new List<CheckBoxModel>();
            IList<SuportedPlatformModel> suportedPlatforms = null;
            IList<ReviewModel> reviews = new List<ReviewModel>();

            var factory = new GameInfoViewModelFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, suportedPlatforms, reviews));

            Assert.AreEqual("suportedPlatforms cannot be null", msg.Message);
        }

        [Test]
        public void NullReviews_ShouldThrow()
        {
            //Arrange
            int id = 12;
            string name = "asdag";
            decimal price = 12;
            string description = "Desadas";
            string imageUrl = "asdasd";
            IList<CheckBoxModel> categories = new List<CheckBoxModel>();
            IList<SuportedPlatformModel> suportedPlatforms = new List<SuportedPlatformModel>();
            IList<ReviewModel> reviews = null;

            var factory = new GameInfoViewModelFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(id, name, price, description, imageUrl, categories, suportedPlatforms, reviews));

            Assert.AreEqual("reviews cannot be null", msg.Message);
        }

        [Test]
        public void ShouldReturnCorrectly()
        {
            //Arrange
            int id = 12;
            string name = "asdag";
            decimal price = 12;
            string description = "Desadas";
            string imageUrl = "asdasd";
            IList<CheckBoxModel> categories = new List<CheckBoxModel>();
            IList<SuportedPlatformModel> suportedPlatforms = new List<SuportedPlatformModel>();
            IList<ReviewModel> reviews = new List<ReviewModel>();

            var factory = new GameInfoViewModelFactory();

            //Act
            var model = factory.Create(id, name, price, description, imageUrl, categories, suportedPlatforms, reviews);

            //Assert
            Assert.AreEqual(id, model.Id);
            Assert.AreEqual(name, model.Name);
            Assert.AreEqual(price, model.Price);
            Assert.AreEqual(description, model.Description);
            Assert.AreEqual(imageUrl, model.ImageUrl);
            Assert.AreSame(categories, model.Categories);
            Assert.AreSame(suportedPlatforms, model.SuportedPlatforms);
            Assert.AreSame(reviews, model.Reviews);
        }
    }
}

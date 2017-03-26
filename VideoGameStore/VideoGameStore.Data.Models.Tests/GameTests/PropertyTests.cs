using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Data.Models.Tests.GameTests
{
    [TestFixture]
    public class PropertyTests
    {
        [Test]
        public void AllPropertyTests()
        {
            //Arrange
            Game game = new Game();

            //Act
            game.Id = 5;
            game.Name = "Test";
            var date = new DateTime();
            game.DateAdded = date;

            game.Categories = new List<Category>()
            {
                new Category()
            };

            game.SupportedPlatforms = new List<Platform>()
            {
                new Platform()
            };

            game.Users = new List<ApplicationUser>()
            {
                new ApplicationUser()
            };

            game.Reviews = new List<Review>()
            {
                new Review()
            };

            //Assert
            Assert.AreEqual(5, game.Id);
            Assert.AreEqual("Test", game.Name);
            Assert.AreEqual(date, game.DateAdded);
            Assert.AreEqual(1, game.Categories.Count);
            Assert.AreEqual(1, game.SupportedPlatforms.Count);
            Assert.AreEqual(1, game.Users.Count);
            Assert.AreEqual(1, game.Reviews.Count);
        }
    }
}

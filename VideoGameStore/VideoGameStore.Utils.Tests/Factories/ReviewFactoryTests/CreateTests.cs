using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Models;
using VideoGameStore.Utils.Factories;

namespace VideoGameStore.Utils.Tests.Factories.ReviewFactoryTests
{
    [TestFixture]
    public class CreateTests
    {
        [Test]
        public void NullComment_ShouldThrow()
        {
            //Arrange
            string comment = null;
            ApplicationUser user = new ApplicationUser();
            Game game = new Game();

            var factory = new ReviewFactory();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => factory.Create(comment, user, game));

            Assert.AreEqual("comment cannot be null or empty", err.Message);
        }

        [Test]
        public void EmptyComment_ShouldThrow()
        {
            //Arrange
            string comment = "";
            ApplicationUser user = new ApplicationUser();
            Game game = new Game();

            var factory = new ReviewFactory();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => factory.Create(comment, user, game));

            Assert.AreEqual("comment cannot be null or empty", err.Message);
        }

        [Test]
        public void NullUser_ShouldThrow()
        {
            //Arrange
            string comment = "asdas";
            ApplicationUser user = null;
            Game game = new Game();

            var factory = new ReviewFactory();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => factory.Create(comment, user, game));

            Assert.AreEqual("user cannot be null", err.Message);
        }

        [Test]
        public void NullGame_ShouldThrow()
        {
            //Arrange
            string comment = "asdas";
            ApplicationUser user = new ApplicationUser();
            Game game = null;

            var factory = new ReviewFactory();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => factory.Create(comment, user, game));

            Assert.AreEqual("game cannot be null", err.Message);
        }

        [Test]
        public void ShouldCreateReview()
        {
            //Arrange
            string comment = "asdas";
            ApplicationUser user = new ApplicationUser();
            Game game = new Game();

            var factory = new ReviewFactory();

            //Act
            Review review = factory.Create(comment, user, game);

            //Assert
            Assert.AreEqual(comment, review.Comment);
            Assert.AreEqual(user, review.User);
            Assert.AreEqual(game, review.Game);
        }
    }
}

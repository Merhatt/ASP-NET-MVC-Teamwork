using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Models;
using VideoGameStore.Web.Models.Factories;

namespace VideoGameStore.Web.Tests.Factories.GamesPageViewModelFactoryTests
{
    [TestFixture]
    public class CreateTests
    {
        [Test]
        public void NullGames_ShouldThrow()
        {
            //Arrange
            var factory = new GamesPageViewModelFactory();

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => factory.Create(null));

            Assert.AreEqual("games cannot be null", msg.Message);
        }

        [Test]
        public void ShouldCreateSuccesfully()
        {
            //Arrange
            var factory = new GamesPageViewModelFactory();

            IEnumerable<Game> games = new List<Game>();

            //Act
            var game = factory.Create(games);

            //Assert
            Assert.AreSame(games, game.Games);
        }
    }
}

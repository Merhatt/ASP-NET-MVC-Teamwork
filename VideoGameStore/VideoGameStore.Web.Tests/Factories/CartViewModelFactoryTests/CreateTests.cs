using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Models;
using VideoGameStore.Web.Models.Factories;

namespace VideoGameStore.Web.Tests.Factories.CartViewModelFactoryTests
{
    [TestFixture]
    public class CreateTests
    {
        [Test]
        public void NullGames_ShouldThrow()
        {
            //Arrange
            var factory = new CartViewModelFactory();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => factory.Create(null));

            Assert.AreEqual("games cannot be null", err.Message);
        }

        [Test]
        public void ShouldGetModel()
        {
            //Arrange
            var factory = new CartViewModelFactory();
            IEnumerable<Game> games = new List<Game>();

            //Act
            var model = factory.Create(games);

            //Assert
            Assert.AreSame(games, model.GamesInCart);
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Models;

namespace VideoGameStore.Data.Models.Tests.ApplicationUserTests
{
    [TestFixture]
    public class PropertyTests
    {
        [Test]
        public void AllPropertyTests()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser();

            //Act
            user.ShopingCart = new List<Game>()
            {
                new Game()
            };

            user.Reviews = new List<Review>()
            {
                new Review()
            };

            //Assert
            Assert.AreEqual(1, user.ShopingCart.Count);
            Assert.AreEqual(1, user.Reviews.Count);
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Data.Models.Tests.CategoryTests
{
    [TestFixture]
    public class PropertyTests
    {
        [Test]
        public void AllPropertyTests()
        {
            //Arrange
            Category category = new Category();

            //Act
            category.Id = 5;
            category.Name = "Test";
            category.Games = new List<Game>()
            {
                new Game()
            };

            //Assert
            Assert.AreEqual(5, category.Id);
            Assert.AreEqual("Test", category.Name);
            Assert.AreEqual(1, category.Games.Count);
        }
    }
}

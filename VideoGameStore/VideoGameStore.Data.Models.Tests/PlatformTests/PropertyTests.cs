using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Data.Models.Tests.PlatformTests
{
    [TestFixture]
    public class PropertyTests
    {
        [Test]
        public void AllPropertyTests()
        {
            //Arrange
            Platform platform = new Platform();

            //Act
            platform.Id = 5;
            platform.Name = "Test";
            platform.Games = new List<Game>()
            {
                new Game()
            };

            //Assert
            Assert.AreEqual(5, platform.Id);
            Assert.AreEqual("Test", platform.Name);
            Assert.AreEqual(1, platform.Games.Count);
        }
    }
}

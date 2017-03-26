using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Utils.Factories;

namespace VideoGameStore.Utils.Tests.Factories.PageServiceFactoryTests
{
    [TestFixture]
    public class CreateTests
    {
        [Test]
        public void NullItems_ShouldThrow()
        {
            //Arrange
            PageServiceFactory<object> factory = new PageServiceFactory<object>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => factory.Create(null, 5));

            Assert.AreEqual("items cannot be null", err.Message);
        }

        [Test]
        public void ItemsCountEqualZero_ShouldThrow()
        {
            //Arrange
            PageServiceFactory<object> factory = new PageServiceFactory<object>();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => factory.Create(new List<object>(), 0));

            Assert.AreEqual("itemsCountPerPage cannot be <= zero", err.Message);
        }

        [Test]
        public void ShouldGetService()
        {
            //Arrange
            PageServiceFactory<object> factory = new PageServiceFactory<object>();

            //Act
            var service = factory.Create(new List<object>(), 2);

            //Assert
            Assert.NotNull(service);
        }
    }
}

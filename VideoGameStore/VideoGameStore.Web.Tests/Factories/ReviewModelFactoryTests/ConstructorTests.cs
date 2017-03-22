using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Web.Models.Factories;

namespace VideoGameStore.Web.Tests.Factories.ReviewModelFactoryTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void NullUserModelFactory_ShouldThrow()
        {
            //Arrange & Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => new ReviewModelFactory(null));

            Assert.AreEqual("userModelFactory cannot be null", msg.Message);
        }
    }
}

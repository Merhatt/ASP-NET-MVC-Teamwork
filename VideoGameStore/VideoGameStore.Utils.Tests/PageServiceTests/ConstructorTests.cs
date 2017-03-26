using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Utils.Pagings;

namespace VideoGameStore.Utils.Tests.PageServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void NullItems_ShouldThrow()
        {
            //Arrange & Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => new PageService<object>(null, 3));

            Assert.AreEqual("items cannot be null", msg.Message);
        }

        [Test]
        public void PagesLessThanZero_ShouldThrow()
        {
            //Arrange & Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => new PageService<object>(new List<object>(), -3));

            Assert.AreEqual("itemsCountPerPage cannot be <= zero", msg.Message);
        }
    }
}

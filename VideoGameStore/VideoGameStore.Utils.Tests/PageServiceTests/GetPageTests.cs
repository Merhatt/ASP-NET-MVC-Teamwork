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
    public class GetPageTests
    {
        [Test]
        public void NegativePage_ShouldThrow()
        {
            //Arrange
            var service = new PageService<object>(new List<object>(), 3);

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => service.GetPage(-2));

            Assert.AreEqual("page cannot be <= zero", msg.Message);
        }

        [Test]
        public void SecondPage_ShouldGet()
        {
            //Arrange
            var service = new PageService<int>(new List<int>()
            {
                1,
                2,
                3,
                4,
                5
            }, 3);

            //Act
            IEnumerable<int> page = service.GetPage(2);

            //Assert
            Assert.AreEqual(2, page.Count());
        }

        [Test]
        public void FirstPage_ShouldGet()
        {
            //Arrange
            var service = new PageService<int>(new List<int>()
            {
                1,
                2,
                3,
                4,
                5
            }, 3);

            //Act
            IEnumerable<int> page = service.GetPage(1);

            //Assert
            Assert.AreEqual(3, page.Count());
        }
    }
}

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
    public class GetMaxPageTests
    {
        [Test]
        public void ShouldGetMaxPageTwo()
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
            int maxPage = service.GetMaxPage();

            //Assert
            Assert.AreEqual(2, maxPage);
        }

        [Test]
        public void ShouldGetMaxPageThree()
        {
            //Arrange
            var service = new PageService<int>(new List<int>()
            {
                1,
                2,
                3,
                4,
                5,
                6,
                7
            }, 3);

            //Act
            int maxPage = service.GetMaxPage();

            //Assert
            Assert.AreEqual(3, maxPage);
        }
    }
}

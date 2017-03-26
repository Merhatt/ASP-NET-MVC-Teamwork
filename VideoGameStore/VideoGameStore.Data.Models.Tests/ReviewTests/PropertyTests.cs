using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Data.Models.Tests.ReviewTests
{
    [TestFixture]
    public class PropertyTests
    {
        [Test]
        public void AllPropertyTests()
        {
            //Arrange
            Review review = new Review();

            //Act
            review.Id = 5;
            var date = new DateTime();
            review.DatePosted = date;

            //Assert
            Assert.AreEqual(5, review.Id);
            Assert.AreEqual(date, review.DatePosted);
        }
    }
}

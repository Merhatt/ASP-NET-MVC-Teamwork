using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Contracts;
using VideoGameStore.Data.Models;

namespace VideoGameStore.Services.Tests.CategoryServicesTests
{
    [TestFixture]
    public class GetByIdTests
    {
        [Test]
        public void NegativeId_ShouldThrow()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Category>>();

            CategoryServices services = new CategoryServices(repositoryMock.Object);

            //Act & Assert
            var msg = Assert.Throws<NullReferenceException>(() => services.GetById(-1));

            Assert.AreEqual("id cannot be less than zero", msg.Message);
        }

        [Test]
        public void ShouldReturnCorrect()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Category>>();

            CategoryServices services = new CategoryServices(repositoryMock.Object);

            Category cat = new Category();

            repositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(cat);

            //Act
            Category categoryRes = services.GetById(2);

            //Assert
            Assert.AreSame(cat, categoryRes);
            repositoryMock.Verify(x => x.GetById(2), Times.Once());
        }
    }
}

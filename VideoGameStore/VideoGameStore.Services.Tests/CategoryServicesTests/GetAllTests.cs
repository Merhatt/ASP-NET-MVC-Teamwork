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
    public class GetAllTests
    {
        [Test]
        public void ShouldReturnCategories()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Category>>();

            CategoryServices services = new CategoryServices(repositoryMock.Object);

            List<Category> categories = new List<Category>();
            categories.Add(new Category());

            repositoryMock.Setup(x => x.All()).Returns(categories.AsQueryable());

            //Act
            IEnumerable<Category> resCategories = services.GetAll();

            //Assert
            Assert.AreEqual(1, resCategories.Count());
            repositoryMock.Verify(x => x.All(), Times.Once());
        }
    }
}

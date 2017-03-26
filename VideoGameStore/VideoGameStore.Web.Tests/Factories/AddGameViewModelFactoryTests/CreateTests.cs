using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Web.Models;
using VideoGameStore.Web.Models.Factories;

namespace VideoGameStore.Web.Tests.Factories.AddGameViewModelFactoryTests
{
    [TestFixture]
    public class CreateTests
    {
        [Test]
        public void NullCategories_ShouldThrow()
        {
            //Arrange
            var factory = new AddGameViewModelFactory();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => factory.Create(null, new List<CheckBoxModel>()));

            Assert.AreEqual("checkBoxesCategories cannot be null", err.Message);
        }

        [Test]
        public void NullPlatforms_ShouldThrow()
        {
            //Arrange
            var factory = new AddGameViewModelFactory();

            //Act & Assert
            var err = Assert.Throws<NullReferenceException>(() => factory.Create(new List<CheckBoxModel>(), null));

            Assert.AreEqual("platforms cannot be null", err.Message);
        }

        [Test]
        public void GetModelCorectly()
        {
            //Arrange
            var factory = new AddGameViewModelFactory();
            List<CheckBoxModel> categories = new List<CheckBoxModel>();
            List<CheckBoxModel> platforms = new List<CheckBoxModel>();


            //Act
            var model = factory.Create(categories, platforms);

            //Assert
            Assert.AreSame(categories, model.CheckBoxesCategories);
            Assert.AreSame(platforms, model.Platforms);

        }
    }
}

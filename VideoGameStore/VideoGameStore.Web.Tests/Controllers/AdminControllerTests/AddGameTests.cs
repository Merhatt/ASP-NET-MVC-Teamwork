using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VideoGameStore.Data.Models;
using VideoGameStore.Services.Contracts;
using VideoGameStore.Web.Controllers;
using VideoGameStore.Web.Models;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Tests.Controllers.AdminControllerTests
{
    [TestFixture]
    public class AddGameTests
    {
        [Test]
        public void GetPage_ShouldGetCorrectly()
        {
            //Arrange
            var categoryServicesMock = new Mock<ICategoryServices>();
            var gameServicesMock = new Mock<IGameServices>();
            var platformServicesMock = new Mock<IPlatformServices>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var addGameViewModelFactoryMock = new Mock<IAddGameViewModelFactory>();

            var controller = new AdminController(categoryServicesMock.Object, gameServicesMock.Object,
                            platformServicesMock.Object, checkBoxModelFactoryMock.Object,
                            addGameViewModelFactoryMock.Object);

            var allCategories = new List<Category>()
            {
                new Category()
                {
                    Name = "Action"
                },
                new Category()
                {
                    Name = "Fps"
                },
                new Category()
                {
                    Name = "Strategy"
                }
            };

            categoryServicesMock.Setup(x => x.GetAll())
                .Returns(allCategories);

            checkBoxModelFactoryMock.Setup(x => x.Create(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new CheckBoxModel());

            var allPlatforms = new List<Platform>()
            {
                new Platform()
                {
                    Name = "Xbox"
                },
            };

            platformServicesMock.Setup(x => x.GetAll())
                .Returns(allPlatforms);

            AddGameViewModel modelToGet = new AddGameViewModel();

            addGameViewModelFactoryMock.Setup(x => x.Create(It.IsAny<IList<CheckBoxModel>>(), It.IsAny<IList<CheckBoxModel>>()))
                .Returns(modelToGet);

            //Act
            var model = controller.AddGame() as ViewResult;

            //Assert
            Assert.AreSame(model.Model as AddGameViewModel, modelToGet);

            checkBoxModelFactoryMock.Verify(x => x.Create(0, "Action"), Times.Once());
            checkBoxModelFactoryMock.Verify(x => x.Create(0, "Fps"), Times.Once());
            checkBoxModelFactoryMock.Verify(x => x.Create(0, "Strategy"), Times.Once());
            checkBoxModelFactoryMock.Verify(x => x.Create(0, "Xbox"), Times.Once());
        }

        [Test]
        public void PostPage_NullModel_ShouldGetCorrectly()
        {
            //Arrange
            var categoryServicesMock = new Mock<ICategoryServices>();
            var gameServicesMock = new Mock<IGameServices>();
            var platformServicesMock = new Mock<IPlatformServices>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var addGameViewModelFactoryMock = new Mock<IAddGameViewModelFactory>();

            var controller = new AdminController(categoryServicesMock.Object, gameServicesMock.Object,
                            platformServicesMock.Object, checkBoxModelFactoryMock.Object,
                            addGameViewModelFactoryMock.Object);

            var allCategories = new List<Category>()
            {
                new Category()
                {
                    Name = "Action"
                },
                new Category()
                {
                    Name = "Fps"
                },
                new Category()
                {
                    Name = "Strategy"
                }
            };

            categoryServicesMock.Setup(x => x.GetAll())
                .Returns(allCategories);

            checkBoxModelFactoryMock.Setup(x => x.Create(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new CheckBoxModel());

            var allPlatforms = new List<Platform>()
            {
                new Platform()
                {
                    Name = "Xbox"
                },
            };

            platformServicesMock.Setup(x => x.GetAll())
                .Returns(allPlatforms);

            AddGameViewModel modelToGet = new AddGameViewModel();

            addGameViewModelFactoryMock.Setup(x => x.Create(It.IsAny<IList<CheckBoxModel>>(), It.IsAny<IList<CheckBoxModel>>()))
                .Returns(modelToGet);

            //Act
            var model = controller.AddGame(null) as ViewResult;

            //Assert
            Assert.AreSame(model.Model as AddGameViewModel, modelToGet);

            checkBoxModelFactoryMock.Verify(x => x.Create(0, "Action"), Times.Once());
            checkBoxModelFactoryMock.Verify(x => x.Create(0, "Fps"), Times.Once());
            checkBoxModelFactoryMock.Verify(x => x.Create(0, "Strategy"), Times.Once());
            checkBoxModelFactoryMock.Verify(x => x.Create(0, "Xbox"), Times.Once());
        }

        [TestCase(null)]
        [TestCase("sh")]
        [TestCase("")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void PostPage_IncorrectName_ShouldSetError(string name)
        {
            //Arrange
            var categoryServicesMock = new Mock<ICategoryServices>();
            var gameServicesMock = new Mock<IGameServices>();
            var platformServicesMock = new Mock<IPlatformServices>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var addGameViewModelFactoryMock = new Mock<IAddGameViewModelFactory>();

            var controller = new AdminController(categoryServicesMock.Object, gameServicesMock.Object,
                            platformServicesMock.Object, checkBoxModelFactoryMock.Object,
                            addGameViewModelFactoryMock.Object);

            AddGameViewModel lastModel = new AddGameViewModel();

            lastModel.Name = name;
            lastModel.Description = "asdasdasdasddasd";
            lastModel.ImageUrl = "asdasdasdasddasd";
            lastModel.Price = 2;

            //Act
            var model = controller.AddGame(lastModel) as ViewResult;

            //Assert
            Assert.AreSame(model.Model as AddGameViewModel, lastModel);

            Assert.AreEqual("The name of the game must be between 3 and 100 chars", (model.Model as AddGameViewModel).ErrorText);
        }

        [TestCase(null)]
        [TestCase("sh")]
        [TestCase("")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void PostPage_IncorrectDescription_ShouldSetError(string description)
        {
            //Arrange
            var categoryServicesMock = new Mock<ICategoryServices>();
            var gameServicesMock = new Mock<IGameServices>();
            var platformServicesMock = new Mock<IPlatformServices>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var addGameViewModelFactoryMock = new Mock<IAddGameViewModelFactory>();

            var controller = new AdminController(categoryServicesMock.Object, gameServicesMock.Object,
                            platformServicesMock.Object, checkBoxModelFactoryMock.Object,
                            addGameViewModelFactoryMock.Object);

            AddGameViewModel lastModel = new AddGameViewModel();

            lastModel.Name = "asadasd";
            lastModel.Description = description;
            lastModel.ImageUrl = "asdasdasdasddasd";
            lastModel.Price = 2;

            //Act
            var model = controller.AddGame(lastModel) as ViewResult;

            //Assert
            Assert.AreSame(model.Model as AddGameViewModel, lastModel);

            Assert.AreEqual("The description of the game must be between 10 and 1000 chars", (model.Model as AddGameViewModel).ErrorText);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void PostPage_IncorrectImgUrl_ShouldSetError(string imgUrl)
        {
            //Arrange
            var categoryServicesMock = new Mock<ICategoryServices>();
            var gameServicesMock = new Mock<IGameServices>();
            var platformServicesMock = new Mock<IPlatformServices>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var addGameViewModelFactoryMock = new Mock<IAddGameViewModelFactory>();

            var controller = new AdminController(categoryServicesMock.Object, gameServicesMock.Object,
                            platformServicesMock.Object, checkBoxModelFactoryMock.Object,
                            addGameViewModelFactoryMock.Object);

            AddGameViewModel lastModel = new AddGameViewModel();

            lastModel.Name = "asadasd";
            lastModel.Description = "asdadsassdasd";
            lastModel.ImageUrl = imgUrl;
            lastModel.Price = 2;

            //Act
            var model = controller.AddGame(lastModel) as ViewResult;

            //Assert
            Assert.AreSame(model.Model as AddGameViewModel, lastModel);

            Assert.AreEqual("The Image Url must be between 1 and 1000 chars", (model.Model as AddGameViewModel).ErrorText);
        }

        [TestCase(1000000)]
        [TestCase(0)]
        [TestCase(-321)]
        [TestCase(-1)]
        public void PostPage_IncorrectPrice_ShouldSetError(decimal price)
        {
            //Arrange
            var categoryServicesMock = new Mock<ICategoryServices>();
            var gameServicesMock = new Mock<IGameServices>();
            var platformServicesMock = new Mock<IPlatformServices>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var addGameViewModelFactoryMock = new Mock<IAddGameViewModelFactory>();

            var controller = new AdminController(categoryServicesMock.Object, gameServicesMock.Object,
                            platformServicesMock.Object, checkBoxModelFactoryMock.Object,
                            addGameViewModelFactoryMock.Object);

            AddGameViewModel lastModel = new AddGameViewModel();

            lastModel.Name = "asadasd";
            lastModel.Description = "asdadsassdasd";
            lastModel.ImageUrl = "Test";
            lastModel.Price = price;

            //Act
            var model = controller.AddGame(lastModel) as ViewResult;

            //Assert
            Assert.AreSame(model.Model as AddGameViewModel, lastModel);

            Assert.AreEqual("The price of the game must be between 0.01$ and 100 000$", (model.Model as AddGameViewModel).ErrorText);
        }

        [Test]
        public void PostPage_IncorrectCategories_ShouldSetError()
        {
            //Arrange
            var categoryServicesMock = new Mock<ICategoryServices>();
            var gameServicesMock = new Mock<IGameServices>();
            var platformServicesMock = new Mock<IPlatformServices>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var addGameViewModelFactoryMock = new Mock<IAddGameViewModelFactory>();

            var controller = new AdminController(categoryServicesMock.Object, gameServicesMock.Object,
                            platformServicesMock.Object, checkBoxModelFactoryMock.Object,
                            addGameViewModelFactoryMock.Object);

            AddGameViewModel lastModel = new AddGameViewModel();

            lastModel.Name = "asadasd";
            lastModel.Description = "asdadsassdasd";
            lastModel.ImageUrl = "Test";
            lastModel.Price = 20;
            lastModel.CheckBoxesCategories = new List<CheckBoxModel>();

            //Act
            var model = controller.AddGame(lastModel) as ViewResult;

            //Assert
            Assert.AreSame(model.Model as AddGameViewModel, lastModel);

            Assert.AreEqual("Atleast 1 category must be chosen", (model.Model as AddGameViewModel).ErrorText);
        }

        [Test]
        public void PostPage_IncorrectPlatforms_ShouldSetError()
        {
            //Arrange
            var categoryServicesMock = new Mock<ICategoryServices>();
            var gameServicesMock = new Mock<IGameServices>();
            var platformServicesMock = new Mock<IPlatformServices>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var addGameViewModelFactoryMock = new Mock<IAddGameViewModelFactory>();

            var controller = new AdminController(categoryServicesMock.Object, gameServicesMock.Object,
                            platformServicesMock.Object, checkBoxModelFactoryMock.Object,
                            addGameViewModelFactoryMock.Object);

            AddGameViewModel lastModel = new AddGameViewModel();

            lastModel.Name = "asadasd";
            lastModel.Description = "asdadsassdasd";
            lastModel.ImageUrl = "Test";
            lastModel.Price = 20;
            lastModel.CheckBoxesCategories = new List<CheckBoxModel>()
            {
                new CheckBoxModel()
                {
                    Checked = true
                }
            };

            lastModel.Platforms = new List<CheckBoxModel>();

            //Act
            var model = controller.AddGame(lastModel) as ViewResult;

            //Assert
            Assert.AreSame(model.Model as AddGameViewModel, lastModel);

            Assert.AreEqual("Atleast 1 platform must be chosen", (model.Model as AddGameViewModel).ErrorText);
        }

        [Test]
        public void PostPage_NoErrors_ShouldAdd_ShouldSetError()
        {
            //Arrange
            var categoryServicesMock = new Mock<ICategoryServices>();
            var gameServicesMock = new Mock<IGameServices>();
            var platformServicesMock = new Mock<IPlatformServices>();
            var checkBoxModelFactoryMock = new Mock<ICheckBoxModelFactory>();
            var addGameViewModelFactoryMock = new Mock<IAddGameViewModelFactory>();

            var controller = new AdminController(categoryServicesMock.Object, gameServicesMock.Object,
                            platformServicesMock.Object, checkBoxModelFactoryMock.Object,
                            addGameViewModelFactoryMock.Object);

            AddGameViewModel lastModel = new AddGameViewModel();

            lastModel.Name = "asadasd";
            lastModel.Description = "asdadsassdasd";
            lastModel.ImageUrl = "Test";
            lastModel.Price = 20;
            lastModel.CheckBoxesCategories = new List<CheckBoxModel>()
            {
                new CheckBoxModel()
                {
                    Id = 1,
                    Checked = true
                }
            };

            lastModel.Platforms = new List<CheckBoxModel>()
            {
                new CheckBoxModel()
                {
                    Id = 2,
                    Checked = true
                }
            };

            Category category = new Category();

            categoryServicesMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(category);


            Platform platform = new Platform();

            platformServicesMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(platform);

            //Act
            var model = controller.AddGame(lastModel);

            //Assert
            categoryServicesMock.Verify(x => x.GetById(1), Times.Once());
            platformServicesMock.Verify(x => x.GetById(2), Times.Once());

            gameServicesMock.Verify(x => x.Create(lastModel.Name, lastModel.Price, lastModel.Description, lastModel.ImageUrl, It.IsAny<ICollection<Category>>(), It.IsAny<ICollection<Platform>>()));
        }
    }
}

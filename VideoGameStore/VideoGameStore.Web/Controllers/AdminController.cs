using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGameStore.Data.Models;
using VideoGameStore.Services.Contracts;
using VideoGameStore.Web.Models;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Controllers
{
    public class AdminController : Controller
    {
        private IAddGameViewModelFactory addGameViewModelFactory;
        private ICategoryServices categoryServices;
        private ICheckBoxModelFactory checkBoxFactory;
        private IGameServices gameServices;
        private IPlatformServices platformServices;

        public AdminController(ICategoryServices categoryServices, IGameServices gameServices,
            IPlatformServices platformServices, ICheckBoxModelFactory checkBoxFactory,
            IAddGameViewModelFactory addGameViewModelFactory)
        {
            if (categoryServices == null)
            {
                throw new NullReferenceException("categoryServices cannot be null");
            }

            if (gameServices == null)
            {
                throw new NullReferenceException("gameServices cannot be null");
            }

            if (platformServices == null)
            {
                throw new NullReferenceException("platformServices cannot be null");
            }

            if (checkBoxFactory == null)
            {
                throw new NullReferenceException("checkBoxFactory cannot be null");
            }

            if (addGameViewModelFactory == null)
            {
                throw new NullReferenceException("addGameViewModelFactory cannot be null");
            }

            this.categoryServices = categoryServices;
            this.gameServices = gameServices;
            this.platformServices = platformServices;
            this.checkBoxFactory = checkBoxFactory;
            this.addGameViewModelFactory = addGameViewModelFactory;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddGame()
        {
            IEnumerable<Category> allCategories = this.categoryServices.GetAll();

            IList<CheckBoxModel> checkBoxesCategories = new List<CheckBoxModel>();

            foreach (var category in allCategories)
            {
                CheckBoxModel modelToAdd = this.checkBoxFactory.Create(category.Id, category.Name);

                checkBoxesCategories.Add(modelToAdd);
            }

            IEnumerable<Platform> platforms = this.platformServices.GetAll();

            IList<CheckBoxModel> checkBoxesPlatforms = new List<CheckBoxModel>();

            foreach (var platform in platforms)
            {
                CheckBoxModel modelToAdd = this.checkBoxFactory.Create(platform.Id, platform.Name);

                checkBoxesPlatforms.Add(modelToAdd);
            }

            AddGameViewModel model = this.addGameViewModelFactory.Create(checkBoxesCategories, checkBoxesPlatforms);

            return View("~/Views/Admin/AddGame.cshtml", model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddGame(AddGameViewModel model)
        {
            bool isErrorFound = false;

            if (string.IsNullOrEmpty(model.Name) ||
                model.Name.Length < 3 ||
                model.Name.Length > 100)
            {
                model.ErrorText = "The name of the game must be between 3 and 100 chars";
                isErrorFound = true;
            }
            else if (string.IsNullOrEmpty(model.Description) ||
                model.Description.Length < 10 ||
                model.Description.Length > 1000)
            {
                model.ErrorText = "The description of the game must be between 10 and 1000 chars";
                isErrorFound = true;
            }
            else if (string.IsNullOrEmpty(model.ImageUrl) ||
                model.ImageUrl.Length < 1 ||
                model.ImageUrl.Length > 1000)
            {
                model.ErrorText = "The Image Url must be between 1 and 1000 chars";
                isErrorFound = true;
            }
            else if (model.Price < 0.01m ||
                model.Price > 100000m)
            {
                model.ErrorText = "The price of the game must be between 0.01$ and 100 000$";
                isErrorFound = true;
            }
            else
            {
                int categoriesCount = model.CheckBoxesCategories.Where(x => x.Checked)
                    .Count();

                if (categoriesCount == 0)
                {
                    model.ErrorText = "Atleast 1 category must be chosen";
                    isErrorFound = true;
                }

                if (isErrorFound == false)
                {
                    int platformsCount = model.Platforms.Where(x => x.Checked)
                        .Count();

                    if (platformsCount == 0)
                    {
                        model.ErrorText = "Atleast 1 platform must be chosen";
                        isErrorFound = true;
                    }
                }
            }

            if (isErrorFound)
            {
                return View("~/Views/Admin/AddGame.cshtml", model);
            }
            else
            {
                ICollection<Category> categories = new List<Category>();

                foreach (var cat in model.CheckBoxesCategories)
                {
                    if (cat.Checked)
                    {
                        Category categoryToAdd = this.categoryServices.GetById(cat.Id);

                        categories.Add(categoryToAdd);
                    }
                }

                ICollection<Platform> supportedPlatforms = new List<Platform>();

                foreach (var pl in model.Platforms)
                {
                    if (pl.Checked)
                    {
                        Platform platformToAdd = this.platformServices.GetById(pl.Id);

                        supportedPlatforms.Add(platformToAdd);
                    }
                }

                this.gameServices.Create(model.Name, model.Price, model.Description, model.ImageUrl, categories, supportedPlatforms);

                return RedirectToAction("Index", "GamesPage");
            }
        }
    }
}